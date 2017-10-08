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
using ProductBrand = Store.Model.POCO_Entities.ProductBrand;

namespace Store.Web.Mvc.Client.Controllers.OData
{
    //[Authorize]
    public class ProductBrandsController : BaseControllerOData
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


        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<ProductBrandDto> GetProductBrands()
        {
            return Uow.ProductBrands.GetAll()
                .OrderBy(p => p.ProductBrandName)
                .ProjectTo<ProductBrandDto>();//use Automapper.QueryableExtension namespace
        }


        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IHttpActionResult> GetProductBrand([FromODataUri] int key)
        {
            var result = await Uow.ProductBrands.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<ProductBrandDto>(result));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> CreateProductBrand(ProductBrandDto productBrandDto)
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

        [HttpPatch]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> UpdateProductBrand([FromODataUri] int key, Delta<ProductBrandDto> productBrandDto)
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

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> DeleteProductBrand([FromODataUri] int key)
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