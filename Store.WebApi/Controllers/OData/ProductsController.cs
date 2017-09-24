﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Store.Data.Contracts;
using Store.DomainModel.DTOs;
using Store.Model.POCO_Entities;

namespace Store.WebApi.Controllers.OData
{
    public class ProductsController : ODataControllerBase
    {
        public ProductsController(IStoreUow uow)
        {
            Uow = uow;
        }

        private bool ProductExists(int key)
        {
            return Uow.Products.GetAll()
                .Any(p => p.ProductId == key);
        }

        [EnableQuery]
        public IQueryable<ProductDto> Get()
        {
            var dbset = (DbSet<Product>)Uow.Products.GetAll();
            // add eager loading
            return dbset
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductManufacturer)
                .Include(p => p.ProductSubCategory)
                .Include(p => p.ProductSubCategory.ProductCategory)
                .OrderBy(p => p.ProductName)
                .ProjectTo<ProductDto>();//use Automapper.QueryableExtension namespace
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var result = await Uow.Products.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<ProductDto>(result));
            //return Ok(result);
        }

        public async Task<IHttpActionResult> Post(ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productEntity = Mapper.Map<Product>(productDto);
            Uow.Products.Add(productEntity);
            await Uow.CommitAsync();

            return Created(Mapper.Map<ProductDto>(productEntity));
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ProductDto> productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await Uow.Products.GetByIdAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            var productEntity = Mapper.Map<Delta<Product>>(productDto);
            productEntity.Patch(entity);

            try
            {
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }

                throw;
            }
            return Updated(Mapper.Map<ProductDto>(entity));
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, ProductDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != updateDto.ProductId)
            {
                return BadRequest();
            }

            try
            {
                Uow.Products.Update(Mapper.Map<Product>(updateDto));
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(key))
                {
                    return NotFound();
                }

                throw;
            }

            return Updated(updateDto);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var product = await Uow.Products.GetByIdAsync(key);

            if (product == null)
            {
                return NotFound();
            }

            Uow.Products.Delete(product);
            await Uow.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}