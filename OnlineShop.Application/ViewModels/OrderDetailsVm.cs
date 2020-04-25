namespace OnlineShop.Application.ViewModels
{
    public class OrderDetailsVm
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Qty { get; set; }
        public int TaxId { get; set; }
        public decimal? Discount { get; set; }
        public decimal Price { get; set; }
    }
}
