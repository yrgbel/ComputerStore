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
    public class ProductSubCategoriesController : BaseControllerOData
    {
        public ProductSubCategoriesController(IStoreUow uow)
        {
            Uow = uow;
        }

        private bool ProductSubCategoryExists(int key)
        {
            return Uow.ProductCategories.GetAll()
                .Any(p => p.ProductCategoryId == key);
        }

        [EnableQuery]
        public IQueryable<ProductSubCategoryDto> GetProductSubCategories()
        {
            return Uow.ProductSubCategories.GetAll()
                .OrderBy(p => p.ProductSubCategoryName)
                .ProjectTo<ProductSubCategoryDto>();//use Automapper.QueryableExtension namespace
        }

        [EnableQuery]
        public async Task<IHttpActionResult> GetProductSubCategory([FromODataUri] int key)
        {
            var result = await Uow.ProductSubCategories.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<ProductSubCategoryDto>(result));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> CreateProductSubCategory(ProductSubCategoryDto productSubCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productSubCategoryEntity = Mapper.Map<ProductSubCategory>(productSubCategoryDto);
            Uow.ProductSubCategories.Add(productSubCategoryEntity);
            await Uow.CommitAsync();

            return Created(productSubCategoryDto);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> UpdateProductSubCategory([FromODataUri] int key, Delta<ProductSubCategoryDto> productSubCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await Uow.ProductSubCategories.GetByIdAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            var productSubCategoryEntity = Mapper.Map<Delta<ProductSubCategory>>(productSubCategoryDto);
            productSubCategoryEntity.Patch(entity);

            try
            {
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSubCategoryExists(key))
                {
                    return NotFound();
                }

                throw;
            }
            return Updated(entity);
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> DeleteProductSubCategory([FromODataUri] int key)
        {
            var productSubCategoryEntity = await Uow.ProductSubCategories.GetByIdAsync(key);

            if (productSubCategoryEntity == null)
            {
                return NotFound();
            }

            Uow.ProductSubCategories.Delete(productSubCategoryEntity);
            await Uow.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}