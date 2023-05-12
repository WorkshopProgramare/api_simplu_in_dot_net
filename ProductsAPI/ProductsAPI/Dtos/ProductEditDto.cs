namespace ProductsAPI.Dtos
{
    public class ProductEditDto
    {
        public string ProductName { get; set; }
        public ProductSizeDto ProductSize { get; set; }
        public double ProductWeight { get; set; }
        public PriceDto Price { get; set; }
        public string Manufacturer { get; set; }
        public string? OriginCountry { get; set; }
    }
}
