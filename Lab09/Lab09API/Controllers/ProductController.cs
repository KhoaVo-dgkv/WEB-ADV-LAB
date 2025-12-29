using Microsoft.AspNetCore.Mvc;
using Lab09API.DTOs;
using Lab09API.Services;

namespace Lab09API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDto>>>> GetProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            
            if (!response.Success)
            {
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> GetProduct(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            
            if (!response.Success)
            {
                if (response.ErrorCode == ErrorCodes.PRODUCT_NOT_FOUND)
                {
                    return NotFound(response);
                }
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProductDto>>> CreateProduct([FromForm] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<ProductDto>.ErrorResponse(
                    ErrorCodes.VALIDATION_ERROR,
                    "Invalid model state."));
            }

            var response = await _productService.CreateProductAsync(createProductDto);
            
            if (!response.Success)
            {
                if (response.ErrorCode == ErrorCodes.VALIDATION_ERROR || 
                    response.ErrorCode == ErrorCodes.INVALID_FILE)
                {
                    return BadRequest(response);
                }
                if (response.ErrorCode == ErrorCodes.CATEGORY_NOT_FOUND)
                {
                    return NotFound(response);
                }
                return StatusCode(500, response);
            }

            return CreatedAtAction(nameof(GetProduct), new { id = response.Data!.Id }, response);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> UpdateProduct(int id, [FromForm] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<ProductDto>.ErrorResponse(
                    ErrorCodes.VALIDATION_ERROR,
                    "Invalid model state."));
            }

            var response = await _productService.UpdateProductAsync(id, updateProductDto);
            
            if (!response.Success)
            {
                if (response.ErrorCode == ErrorCodes.PRODUCT_NOT_FOUND ||
                    response.ErrorCode == ErrorCodes.CATEGORY_NOT_FOUND)
                {
                    return NotFound(response);
                }
                if (response.ErrorCode == ErrorCodes.VALIDATION_ERROR ||
                    response.ErrorCode == ErrorCodes.INVALID_FILE)
                {
                    return BadRequest(response);
                }
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProductAsync(id);
            
            if (!response.Success)
            {
                if (response.ErrorCode == ErrorCodes.PRODUCT_NOT_FOUND)
                {
                    return NotFound(response);
                }
                return StatusCode(500, response);
            }

            return Ok(response);
        }
    }
}

