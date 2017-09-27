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
    public class ProductCategoriesController : ODataControllerBase
    {
        public ProductCategoriesController(IStoreUow uow)
        {
            Uow = uow;
        }

        private bool ProductCategoryExists(int key)
        {
            return Uow.ProductCategories.GetAll()
                .Any(p => p.ProductCategoryId == key);
        }

        [EnableQuery]
        public IQueryable<ProductCategoryDto> GetProductCategories()
        {
            return Uow.ProductCategories.GetAll()
                .OrderBy(p => p.ProductCategoryName)
                .ProjectTo<ProductCategoryDto>();//use Automapper.QueryableExtension namespace
        }
        
        [EnableQuery]
        public async Task<IHttpActionResult> GetProductCategory([FromODataUri] int key)
        {
            var result = await Uow.ProductCategories.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<ProductCategoryDto>(result));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> CreateProductCategory(ProductCategoryDto productCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productCategoryEntity = Mapper.Map<ProductCategory>(productCategoryDto);
            Uow.ProductCategories.Add(productCategoryEntity);
            await Uow.CommitAsync();

            return Created(productCategoryDto);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> UpdateProductCategory([FromODataUri] int key, Delta<ProductCategoryDto> productCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await Uow.ProductCategories.GetByIdAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            var productCategoryEntity = Mapper.Map<Delta<ProductCategory>>(productCategoryDto);
            productCategoryEntity.Patch(entity);

            try
            {
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(key))
                {
                    return NotFound();
                }

                throw;
            }

            return Updated(entity);
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> DeleteProductCategory([FromODataUri] int key)
        {
            var productCategoryEntity = await Uow.ProductCategories.GetByIdAsync(key);

            if (productCategoryEntity == null)
            {
                return NotFound();
            }

            Uow.ProductCategories.Delete(productCategoryEntity);
            await Uow.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}