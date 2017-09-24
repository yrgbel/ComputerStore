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
        public IQueryable<ProductCategoryDto> Get()
        {
            return Uow.ProductCategories.GetAll()
                .OrderBy(p => p.ProductCategoryName)
                .ProjectTo<ProductCategoryDto>();//use Automapper.QueryableExtension namespace
        }
        
        [EnableQuery]
        public async Task<IHttpActionResult> Get([FromODataUri] int key)
        {
            var result = await Uow.ProductCategories.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<ProductCategoryDto>(result));
        }

        public async Task<IHttpActionResult> Post(ProductCategoryDto productCategoryDto)
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

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ProductCategoryDto> productCategoryDto)
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

        public async Task<IHttpActionResult> Put([FromODataUri] int key, ProductCategoryDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != updateDto.ProductCategoryId)
            {
                return BadRequest();
            }

            try
            {
                Uow.ProductCategories.Update(Mapper.Map<ProductCategory>(updateDto));
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

            return Updated(updateDto);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
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