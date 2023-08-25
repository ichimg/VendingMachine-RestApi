using Microsoft.AspNetCore.Mvc;
using VendingMachine.Domain;
using VendingMachine.Domain.Abstractions;
using VendingMachine.Domain.ApiModels;
using VendingMachine.Domain.ApiModels.Requests;
using VendingMachine.Logic.Exceptions;

namespace VendingMachine.RestApi.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService) 
        {
            this.productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var results = await productService.GetProducts();

            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int id)
        {
            ProductDto result;
            try
            {
                result = await productService.GetProductById(id);
            }
            catch(InvalidColumnException ex)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct(CreateOrUpdateProductRequest request)
        {
            await productService.CreateProduct(request);

            return Created(string.Empty, request.Id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id, CreateOrUpdateProductRequest request)
        {
            try
            {
                await productService.UpdateProduct(id, request);
            }
            catch(InvalidColumnException ex)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
                await productService.DeleteProduct(id);
            }
            catch(InvalidColumnException ex) 
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
