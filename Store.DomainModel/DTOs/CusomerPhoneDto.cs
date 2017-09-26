namespace Store.DomainModel.DTOs
{
    public class CusomerPhoneDto
    {
        public int CustomerId { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int CustomerPhoneId { get; set; }

        // Foreign keys

        /// <summary>
        /// Parent Customer pointed by [CusomerPhone].([CustomerId]) (Customer_CustomerPhone)
        /// </summary>
        public virtual CustomerDto Customer { get; set; } // Customer_CustomerPhone
    }
}
