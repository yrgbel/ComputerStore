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
    public class ProductBrandsController : ODataControllerBase
    {
        public ProductBrandsController(IStoreUow uow)
        {
            Uow = uow;
        }

        private bool ProductBrandExists(int key)
        {
            return Uow.ProductBrands.GetAll()
                .Any(p => p.ProductBrandId == key);
        }

        [EnableQuery]
        public IQueryable<ProductBrandDto> Get()
        {
            return Uow.ProductBrands.GetAll()
                .OrderBy(p => p.ProductBrandName)
                .ProjectTo<ProductBrandDto>();//use Automapper.QueryableExtension namespace
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var result = await Uow.ProductBrands.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<ProductBrandDto>(result));
        }

        public async Task<IHttpActionResult> Post(ProductBrandDto productBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productBrandEntity = Mapper.Map<ProductBrand>(productBrandDto);
            Uow.ProductBrands.Add(productBrandEntity);
            await Uow.CommitAsync();

            return Created(productBrandDto);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ProductBrandDto> productBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await Uow.ProductBrands.GetByIdAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            var productBrandEntity = Mapper.Map<Delta<ProductBrand>>(productBrandDto);
            productBrandEntity.Patch(entity);

            try
            {
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductBrandExists(key))
                {
                    return NotFound();
                }

                throw;
            }

            return Updated(Mapper.Map<ProductBrandDto>(entity));
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, ProductBrandDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != updateDto.ProductBrandId)
            {
                return BadRequest();
            }

            try
            {
                Uow.ProductBrands.Update(Mapper.Map<ProductBrand>(updateDto));
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductBrandExists(key))
                {
                    return NotFound();
                }

                throw;
            }

            return Updated(updateDto);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var productBrandEntity = await Uow.ProductBrands.GetByIdAsync(key);

            if (productBrandEntity == null)
            {
                return NotFound();
            }

            Uow.ProductBrands.Delete(productBrandEntity);
            await Uow.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}