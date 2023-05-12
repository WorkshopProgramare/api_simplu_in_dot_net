using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Database;
using ProductsAPI.Dtos;
using ProductsAPI.Entities;

namespace ProductsAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly IMapper mapper;
        private readonly ProductDbContext productDbContext;

        public ProductsController(IMapper mapper, ProductDbContext productDbContext) {
            this.mapper = mapper;
            this.productDbContext = productDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody]ProductAddDto productAddDto) {
            var product = mapper.Map<Product>(productAddDto);
            productDbContext.Products.Add(product);
            await productDbContext.SaveChangesAsync();

            return Ok(product.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]int page, [FromQuery]int size) {
            var products = await productDbContext.Products
                .OrderBy(p => p.ProductName)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            var total = await productDbContext.Products
                .CountAsync();
            var mappedProducts = mapper.Map<List<ProductSummaryDto>>(products);
            var response = new PaginatedProductSummaries {
                Page = page,
                PageRecords = products.Count,
                Total = total,
                Products = mappedProducts
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute]Guid id) {
            var product = await productDbContext.Products.FindAsync(id);
            var mappedProduct = mapper.Map<ProductViewDto>(product);

            return Ok(mappedProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] Guid id, [FromBody]ProductEditDto productEditDto) {
            var product = await productDbContext.Products.FindAsync(id);

            if (product == null) {
                var mappedProduct = mapper.Map<Product>(productEditDto);
                productDbContext.Products.Add(mappedProduct);
            } else {
                mapper.Map(productEditDto, product);
            }

            await productDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id) {
            var product = await productDbContext.Products.FindAsync(id);

            if (product is not null) {
                productDbContext.Products.Remove(product);
                await productDbContext.SaveChangesAsync();
            }

            return Ok();
        }
    }
}
