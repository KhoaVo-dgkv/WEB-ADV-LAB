using Lab09API.DTOs;

namespace Lab09API.Services
{
    public interface ICategoryService
    {
        Task<ApiResponse<IEnumerable<CategoryDto>>> GetAllCategoriesAsync();
        Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id);
        Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryDto categoryDto);
        Task<ApiResponse<CategoryDto>> UpdateCategoryAsync(int id, CategoryDto categoryDto);
        Task<ApiResponse<bool>> DeleteCategoryAsync(int id);
    }
}

