using Lab09API.DTOs;

namespace Lab09API.Services
{
    public interface IProductService
    {
        Task<ApiResponse<IEnumerable<ProductDto>>> GetAllProductsAsync();
        Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id);
        Task<ApiResponse<ProductDto>> CreateProductAsync(CreateProductDto createProductDto);
        Task<ApiResponse<ProductDto>> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
        Task<ApiResponse<bool>> DeleteProductAsync(int id);
    }
}

