using System.Collections.Generic;

namespace Store.DomainModel.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPatronymic { get; set; }
        public string CustomerLastName { get; set; }
        public int? UserId { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerRegion { get; set; }
        public string CustomerCountry { get; set; }
        public int OrderCount { get; set; }

        public virtual ICollection<CustomerPhoneDto> CusomerPhones { get; set; } // CusomerPhone.Customer_CustomerPhone
        public virtual ICollection<OrderProductDto> OrderProducts { get; set; } // OrderProduct.Customer_OrderProduct

        public CustomerDto()
        {
            CusomerPhones = new List<CustomerPhoneDto>();
            OrderProducts = new List<OrderProductDto>();
        }
    }
}
