using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Store.Data.Contracts;
using Store.DomainModel.DTOs;
using Store.Model.POCO_Entities;

namespace Store.Web.Mvc.Client.Controllers.OData
{
    public class CartItemsController : BaseControllerOData
    {
        public CartItemsController(IStoreUow uow)
        {
            Uow = uow;
        }

        private bool CartItemExists(int key)
        {
            return Uow.CartItems.GetAll()
                .Any(p => p.CartItemId == key);
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<CartItemDto> Get()
        {
            var dbset = (DbSet<CartItem>)Uow.CartItems.GetAll();
            return dbset
                .ToList()
                .AsQueryable()
                .ProjectTo<CartItemDto>();
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var result = await Uow.CartItems.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<CartItemDto>(result));
        }

        [HttpPost]
        [Authorize]
        public async Task<IHttpActionResult> CreateCartItem(CartItemDto cartItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartItemEntity = Mapper.Map<CartItem>(cartItemDto);
            Uow.CartItems.Add(cartItemEntity);
            await Uow.CommitAsync();

            return Created(Mapper.Map<CartItemDto>(cartItemEntity));
        }

        [HttpPatch]
        [Authorize]
        public async Task<IHttpActionResult> UpdateCartItem([FromODataUri] int key, Delta<CartItemDto> cartItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await Uow.CartItems.GetByIdAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            var cartItemEntity = Mapper.Map<Delta<CartItem>>(cartItemDto);
            cartItemEntity.Patch(entity);

            try
            {
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(key))
                {
                    return NotFound();
                }

                throw;
            }
            return Updated(Mapper.Map<CartItemDto>(entity));
        }

        [Authorize]
        public async Task<IHttpActionResult> DeleteProduct([FromODataUri] int key)
        {
            var cartItem = await Uow.CartItems.GetByIdAsync(key);

            if (cartItem == null)
            {
                return NotFound();
            }

            Uow.CartItems.Delete(cartItem);
            await Uow.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}