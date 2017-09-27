using System.Data.Entity;
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
    public class CustomerController : ODataControllerBase
    {
        public CustomerController(IStoreUow uow)
        {
            Uow = uow;
        }

        private bool CustomerExists(int key)
        {
            return Uow.Customers.GetAll()
                .Any(p => p.CustomerId == key);
        }

        [EnableQuery]
        public IQueryable<ProductDto> GetCustomers()
        {
            var dbset = (DbSet<Customer>)Uow.Customers.GetAll();
            // add eager loading
            return dbset
                .Include(c => c.CusomerPhones)
                .OrderBy(p => p.CustomerName)
                .ProjectTo<ProductDto>();//use Automapper.QueryableExtension namespace
        }

        [EnableQuery]
        public async Task<IHttpActionResult> GetCustomer([FromODataUri] int key)
        {
            var result = await Uow.Customers.GetByIdAsync(key);

            if (result == null)
                return NotFound();

            return Ok(Mapper.Map<CustomerDto>(result));
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerEntity = Mapper.Map<Customer>(customerDto);
            Uow.Customers.Add(customerEntity);
            await Uow.CommitAsync();

            return Created(Mapper.Map<CustomerDto>(customerEntity));
        }

        [HttpPatch]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> UpdateCustomer([FromODataUri] int key, Delta<CustomerDto> customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await Uow.Customers.GetByIdAsync(key);

            if (entity == null)
            {
                return NotFound();
            }

            var customerEntity = Mapper.Map<Delta<Customer>>(customerDto);
            customerEntity.Patch(entity);

            try
            {
                await Uow.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(key))
                {
                    return NotFound();
                }

                throw;
            }
            return Updated(Mapper.Map<ProductDto>(entity));
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IHttpActionResult> DeleteCustomer([FromODataUri] int key)
        {
            var customer = await Uow.Customers.GetByIdAsync(key);

            if (customer == null)
            {
                return NotFound();
            }

            Uow.Customers.Delete(customer);
            await Uow.CommitAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}