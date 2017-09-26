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

        // Reverse navigation

        /// <summary>
        /// Child CusomerPhones where [CusomerPhone].[CustomerId] point to this entity (Customer_CustomerPhone)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<CusomerPhoneDto> CusomerPhones { get; set; } // CusomerPhone.Customer_CustomerPhone
        /// <summary>
        /// Child OrderProducts where [OrderProduct].[CustomerId] point to this entity (Customer_OrderProduct)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<OrderProductDto> OrderProducts { get; set; } // OrderProduct.Customer_OrderProduct

        public CustomerDto()
        {
            CusomerPhones = new System.Collections.Generic.List<CusomerPhoneDto>();
            OrderProducts = new System.Collections.Generic.List<OrderProductDto>();
        }
    }
}
