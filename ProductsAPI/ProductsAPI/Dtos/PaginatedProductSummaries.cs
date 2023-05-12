namespace ProductsAPI.Dtos
{
    public class PaginatedProductSummaries
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int PageRecords { get; set; }
        public List<ProductSummaryDto> Products { get; set; }
    }
}
