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
    public class CartsController : BaseControllerOData
    {
        public CartsController(IStoreUow uow)
        {
            Uow = uow;
        }

        private bool CartExists(int key)
        {
            return Uow.Carts.GetAll()
                .Any(p => p.CartId == key);
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<CartDto> Get()
        {
            var dbset = (DbSet<Cart>)Uow.Carts.GetAll();
            // eager loading
            return dbset
                .Include(p => p.CartItems)
                .ToList()
                .AsQueryable()
                .ProjectTo<CartDto>();
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var result = await Uow.Carts.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<CartDto>(result));
        }

        [HttpPost]
        [Authorize]
        public async Task<IHttpActionResult> CreateCart(CartDto cartDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cartEntity = Mapper.Map<Cart>(cartDto);
            Uow.Carts.Add(cartEntity);
            await Uow.CommitAsync();

            return Created(Mapper.Map<CartDto>(cartEntity));
        }

        [HttpPatch]
        [Authorize]
        public async Task<IHttpActionResult> UpdateCart([FromODataUri] int key, Delta<CartDto> cartDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await Uow.Carts.GetByIdAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            var cartEntity = Mapper.Map<Delta<Cart>>(cartDto);
            cartEntity.Patch(entity);

            try
            {
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(key))
                {
                    return NotFound();
                }

                throw;
            }
            return Updated(Mapper.Map<CartDto>(entity));
        }

        [Authorize]
        public async Task<IHttpActionResult> DeleteProduct([FromODataUri] int key)
        {
            var cart = await Uow.Carts.GetByIdAsync(key);

            if (cart == null)
            {
                return NotFound();
            }

            Uow.Carts.Delete(cart);
            await Uow.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}