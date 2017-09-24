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

namespace Store.WebApi.Controllers.OData
{
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
        public IQueryable<ProductManufacturerDto> Get()
        {
            return Uow.ProductManufacturers.GetAll()
                .OrderBy(p => p.ProductManufacturerCountry)
                .ProjectTo<ProductManufacturerDto>();//use Automapper.QueryableExtension namespace
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var result = await Uow.ProductManufacturers.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<ProductManufacturerDto>(result));
        }

        public async Task<IHttpActionResult> Post(ProductManufacturerDto productManufacturerDto)
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

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ProductManufacturerDto> productManufacturerDto)
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

        public async Task<IHttpActionResult> Put([FromODataUri] int key, ProductManufacturerDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != updateDto.ProductManufacturerId)
            {
                return BadRequest();
            }

            try
            {
                Uow.ProductManufacturers.Update(Mapper.Map<ProductManufacturer>(updateDto));
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

            return Updated(updateDto);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
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