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
        public string CustomerPhoneNumber { get; set; }
        public int CustomerPhoneId { get; set; }
    }
}
