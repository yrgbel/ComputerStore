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
    public class ProductSubCategoriesController : ODataControllerBase
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
        public IQueryable<ProductSubCategoryDto> Get()
        {
            return Uow.ProductSubCategories.GetAll()
                .OrderBy(p => p.ProductSubCategoryName)
                .ProjectTo<ProductSubCategoryDto>();//use Automapper.QueryableExtension namespace
        }

        [EnableQuery]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var result = await Uow.ProductSubCategories.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<ProductSubCategoryDto>(result));
        }

        public async Task<IHttpActionResult> Post(ProductSubCategoryDto productSubCategoryDto)
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

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ProductSubCategoryDto> productSubCategoryDto)
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

        public async Task<IHttpActionResult> Put([FromODataUri] int key, ProductSubCategoryDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != updateDto.ProductSubCategoryId)
            {
                return BadRequest();
            }

            try
            {
                Uow.ProductSubCategories.Update(Mapper.Map<ProductSubCategory>(updateDto));
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

            return Updated(updateDto);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
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