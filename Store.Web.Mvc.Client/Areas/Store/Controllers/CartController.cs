using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Store.Data.Contracts;
using Store.DomainModel.Helpers;
using Store.Model.POCO_Entities;
using Store.Web.Mvc.Client.Areas.Store.Models;
using Store.Web.Mvc.Client.Controllers;
using Store.Web.Mvc.Client.Infrastructure;
using Store.Web.Mvc.Client.Infrastructure.Attributes;

namespace Store.Web.Mvc.Client.Areas.Store.Controllers
{
    public class CartController : BaseControllerStore
    {
        public CartController(IStoreUow uow)
        {
            Uow = uow;
        }

        // Show shopping cart

        [HttpGet]
        public ActionResult Cart()
        {
            var model = new CartModel();

            var cookie = Request.Cookies[".cart"];

            if (cookie == null)
            {
                CurrentCart.ItemCount = 0;
                return View(model);
            }

            var cart = Uow.Carts.GetAll()
                .SingleOrDefault(c => c.CartCookie == cookie.Value.ToString());

            if (cart == null)
            {
                // cookie and db are out of sync

                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                return View(model);
            }

            var items = cart.CartItems;

            if (items.Count() > 0)
            {
                model.Items = Mapper.Map<IEnumerable<CartItemModel>>(items);

                var products = Uow.Products.GetAll()
                    .Where(p => items.Select(i => i.ProductId).Contains(p.ProductId))
                    .ToDictionary(p => p.ProductId);

                foreach (var item in model.Items)
                {
                    item.SubTotal = item.CartItemQuantity * item.CartItemPrice;
                    item.ProductImageLargeUrl = DataSettingsProvider.GetProductImageLargeUrl(item.ProductId);
                    item.ProductName = products[item.ProductId].ProductName;
                    item.ProductDescription = products[item.ProductId].ProductDescription;
                }

                model.GrandTotal = items.Aggregate(0M, (runningTotal, next) => runningTotal + (next.CartItemQuantity * next.CartItemPrice));
            }

            // this is a good time to refresh cart item count in our cookie
            CurrentCart.ItemCount = items.Count();


            return View(model);
        }

        // add item to cart

        [HttpPost]
        [AjaxOnly]
        public ActionResult Cart(int count, int id)
        {
            bool newCart = false;
            var cookie = Request.Cookies[".cart"];

            if (cookie == null)
            {
                cookie = new HttpCookie(".cart", Guid.NewGuid().ToString());
                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
                newCart = true;
            }
            else
            {
                // double check that associated cart exists
                var cart = Uow.Carts.GetAll()
                    .SingleOrDefault(c => c.CartCookie == cookie.Value);

                if (cart == null) newCart = true;
            }

            // optimistic add count, that is, it assumes that the subsequent work will succeed. 
            CurrentCart.ItemCount += count;

            // ** CQRS Pattern (fire and forget)

            new Thread(() =>
            {
                if (newCart)
                    AddToNewCart(cookie, count, id);
                else
                    AddToExistingCart(cookie, count, id);

            }).Start();

            // ** Null Object Pattern
            return new EmptyResult();
        }

        #region Private Helpers

        private async void AddToNewCart(HttpCookie cookie, int count, int id)
        {
            var product = await Uow.Products.GetByIdAsync(id);

            var cart = new Cart
            {
              CartCookie = cookie.Value,
              CartItemCount = count
            };

            Uow.Carts.Add(cart);

            var item = new CartItem {
                CartId = cart.CartId,
                CartItemQuantity = count,
                ProductId = id,
                CartItemPrice = product.ProductPrice };

                Uow.CartItems.Add(item);

            // ** Unit of Work Pattern.
            await Uow.CommitAsync();
        }

        private async void AddToExistingCart(HttpCookie cookie, int count, int id)
        {
            var cart = Uow.Carts.GetAll()
                .SingleOrDefault(c => c.CartCookie == cookie.Value);

            var product = await Uow.Products.GetByIdAsync(id);

            // check if product already exists in cart
            var item = Uow.CartItems.GetAll()
                .SingleOrDefault(i => i.CartId == cart.CartId && i.ProductId == id);

            if (item != null)
            {
                item.CartItemQuantity += count;
                Uow.CartItems.Update(item);
            }
            else  // cart item has default values set
            {
                item = new CartItem
                {
                    CartId = cart.CartId,
                    CartItemQuantity = count,
                    ProductId = id,
                    CartItemPrice = product.ProductPrice
                };

                Uow.CartItems.Add(item);
            }

            await Uow.CommitAsync();
        }

        #endregion
    }
}