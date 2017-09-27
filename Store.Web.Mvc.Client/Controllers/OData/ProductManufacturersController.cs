using System;
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

namespace Store.Web.Mvc.Client.Controllers.OData
{
    //[Authorize]
    public class ProductManufacturersController : ODataControllerBase
    {
        public ProductManufacturersController(IStoreUow uow)
        {
            Uow = uow;
        }

        private bool ProductManufacturerExists(int key)
        {
            return Uow.ProductManufacturers.GetAll()
                .Any(p => p.ProductManufacturerId == key);
        }

        [EnableQuery]
        public IQueryable<ProductManufacturerDto> GetProductManufacturers()
        {
            return Uow.ProductManufacturers.GetAll()
                .OrderBy(p => p.ProductManufacturerCountry)
                .ProjectTo<ProductManufacturerDto>();//use Automapper.QueryableExtension namespace
        }

        [EnableQuery]
        public async Task<IHttpActionResult> GetProductManufacturer([FromODataUri] int key)
        {
            var result = await Uow.ProductManufacturers.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<ProductManufacturerDto>(result));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> CreateProductManufacturer(ProductManufacturerDto productManufacturerDto)
        {
            if (productManufacturerDto == null) throw new ArgumentNullException(nameof(productManufacturerDto));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productManufacturerEntity = Mapper.Map<ProductManufacturer>(productManufacturerDto);
            Uow.ProductManufacturers.Add(productManufacturerEntity);
            await Uow.CommitAsync();

            return Created(productManufacturerDto);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> UpdateProductManufacturer([FromODataUri] int key, Delta<ProductManufacturerDto> productManufacturerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await Uow.ProductManufacturers.GetByIdAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            var productManufacturerEntity =
                Mapper.Map<Delta<ProductManufacturer>>(productManufacturerDto);
            productManufacturerEntity.Patch(entity);

            try
            {
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductManufacturerExists(key))
                {
                    return NotFound();
                }

                throw;
            }
            return Updated(entity);
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> DeleteProductManufacturer([FromODataUri] int key)
        {
            var productManufacturerEntity = await Uow.ProductManufacturers.GetByIdAsync(key);

            if (productManufacturerEntity == null)
            {
                return NotFound();
            }

            Uow.ProductManufacturers.Delete(productManufacturerEntity);
            await Uow.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}