using Microsoft.AspNetCore.Mvc;
using Lab09API.DTOs;
using Lab09API.Services;

namespace Lab09API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CategoryDto>>>> GetCategories()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            
            if (!response.Success)
            {
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CategoryDto>>> GetCategory(int id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);
            
            if (!response.Success)
            {
                if (response.ErrorCode == ErrorCodes.CATEGORY_NOT_FOUND)
                {
                    return NotFound(response);
                }
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<ActionResult<ApiResponse<CategoryDto>>> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<CategoryDto>.ErrorResponse(
                    ErrorCodes.VALIDATION_ERROR,
                    "Invalid model state."));
            }

            var response = await _categoryService.CreateCategoryAsync(categoryDto);
            
            if (!response.Success)
            {
                if (response.ErrorCode == ErrorCodes.VALIDATION_ERROR)
                {
                    return BadRequest(response);
                }
                return StatusCode(500, response);
            }

            return CreatedAtAction(nameof(GetCategory), new { id = response.Data!.Id }, response);
        }

        // PUT: api/categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<CategoryDto>>> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<CategoryDto>.ErrorResponse(
                    ErrorCodes.VALIDATION_ERROR,
                    "Invalid model state."));
            }

            var response = await _categoryService.UpdateCategoryAsync(id, categoryDto);
            
            if (!response.Success)
            {
                if (response.ErrorCode == ErrorCodes.CATEGORY_NOT_FOUND)
                {
                    return NotFound(response);
                }
                if (response.ErrorCode == ErrorCodes.VALIDATION_ERROR)
                {
                    return BadRequest(response);
                }
                return StatusCode(500, response);
            }

            return Ok(response);
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCategory(int id)
        {
            var response = await _categoryService.DeleteCategoryAsync(id);
            
            if (!response.Success)
            {
                if (response.ErrorCode == ErrorCodes.CATEGORY_NOT_FOUND)
                {
                    return NotFound(response);
                }
                return StatusCode(500, response);
            }

            return Ok(response);
        }
    }
}

