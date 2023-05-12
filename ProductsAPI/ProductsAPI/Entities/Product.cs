namespace ProductsAPI.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public decimal ProductWeight { get; set; }
        public string Currency { get; set; }
        public decimal Value { get; set; }
        public string Manufacturer { get; set; }
        public string? OriginCountry { get; set; }
    }
}
