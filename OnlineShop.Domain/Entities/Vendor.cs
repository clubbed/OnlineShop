namespace OnlineShop.Domain.Entities
{
    public class Vendor : AuditEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal? Discount { get; set; }
        public int TaxId { get; set; }

        public Tax Tax { get; set; }
    }
}
