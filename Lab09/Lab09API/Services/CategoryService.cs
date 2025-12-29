using Lab09API.DTOs;
using Lab09API.Models;
using Lab09API.Repositories;

namespace Lab09API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ApiResponse<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                var categoryDtos = categories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                });

                return ApiResponse<IEnumerable<CategoryDto>>.SuccessResponse(categoryDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<CategoryDto>>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while retrieving categories: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return ApiResponse<CategoryDto>.ErrorResponse(
                        ErrorCodes.CATEGORY_NOT_FOUND,
                        $"Category with ID {id} not found.");
                }

                var categoryDto = new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                };

                return ApiResponse<CategoryDto>.SuccessResponse(categoryDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<CategoryDto>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while retrieving category: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryDto categoryDto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoryDto.Name))
                {
                    return ApiResponse<CategoryDto>.ErrorResponse(
                        ErrorCodes.VALIDATION_ERROR,
                        "Category name is required.");
                }

                var category = new Category
                {
                    Name = categoryDto.Name
                };

                var createdCategory = await _categoryRepository.CreateAsync(category);

                var result = new CategoryDto
                {
                    Id = createdCategory.Id,
                    Name = createdCategory.Name
                };

                return ApiResponse<CategoryDto>.SuccessResponse(result, "Category created successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<CategoryDto>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while creating category: {ex.Message}");
            }
        }

        public async Task<ApiResponse<CategoryDto>> UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return ApiResponse<CategoryDto>.ErrorResponse(
                        ErrorCodes.CATEGORY_NOT_FOUND,
                        $"Category with ID {id} not found.");
                }

                if (string.IsNullOrWhiteSpace(categoryDto.Name))
                {
                    return ApiResponse<CategoryDto>.ErrorResponse(
                        ErrorCodes.VALIDATION_ERROR,
                        "Category name is required.");
                }

                category.Name = categoryDto.Name;
                var updatedCategory = await _categoryRepository.UpdateAsync(category);

                var result = new CategoryDto
                {
                    Id = updatedCategory.Id,
                    Name = updatedCategory.Name
                };

                return ApiResponse<CategoryDto>.SuccessResponse(result, "Category updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<CategoryDto>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while updating category: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    return ApiResponse<bool>.ErrorResponse(
                        ErrorCodes.CATEGORY_NOT_FOUND,
                        $"Category with ID {id} not found.");
                }

                var deleted = await _categoryRepository.DeleteAsync(id);
                if (!deleted)
                {
                    return ApiResponse<bool>.ErrorResponse(
                        ErrorCodes.INTERNAL_ERROR,
                        "Failed to delete category.");
                }

                return ApiResponse<bool>.SuccessResponse(true, "Category deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while deleting category: {ex.Message}");
            }
        }
    }
}

