namespace ProductsAPI.Dtos
{
    public class ProductViewDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public ProductSizeDto ProductSize { get; set; }
        public double ProductWeight { get; set; }
        public PriceDto Price { get; set; }
        public string Manufacturer { get; set; }
        public string? OriginCountry { get; set; }
    }
}
