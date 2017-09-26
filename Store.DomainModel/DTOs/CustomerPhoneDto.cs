namespace Store.DomainModel.DTOs
{
    public class CustomerPhoneDto
    {
        public int CustomerId { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int CustomerPhoneId { get; set; }
        public virtual CustomerDto Customer { get; set; } // Customer_CustomerPhone
    }
}
