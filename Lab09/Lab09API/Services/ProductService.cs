using Microsoft.AspNetCore.Hosting;
using Lab09API.DTOs;
using Lab09API.Models;
using Lab09API.Repositories;

namespace Lab09API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ApiResponse<IEnumerable<ProductDto>>> GetAllProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                var productDtos = products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category?.Name
                });

                return ApiResponse<IEnumerable<ProductDto>>.SuccessResponse(productDtos);
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<ProductDto>>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while retrieving products: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProductDto>> GetProductByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    return ApiResponse<ProductDto>.ErrorResponse(
                        ErrorCodes.PRODUCT_NOT_FOUND,
                        $"Product with ID {id} not found.");
                }

                var productDto = new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category?.Name
                };

                return ApiResponse<ProductDto>.SuccessResponse(productDto);
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductDto>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while retrieving product: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            try
            {
                // Validate category exists
                var category = await _categoryRepository.GetByIdAsync(createProductDto.CategoryId);
                if (category == null)
                {
                    return ApiResponse<ProductDto>.ErrorResponse(
                        ErrorCodes.CATEGORY_NOT_FOUND,
                        $"Category with ID {createProductDto.CategoryId} not found.");
                }

                // Validate input
                if (string.IsNullOrWhiteSpace(createProductDto.Name))
                {
                    return ApiResponse<ProductDto>.ErrorResponse(
                        ErrorCodes.VALIDATION_ERROR,
                        "Product name is required.");
                }

                if (createProductDto.Price <= 0)
                {
                    return ApiResponse<ProductDto>.ErrorResponse(
                        ErrorCodes.VALIDATION_ERROR,
                        "Product price must be greater than 0.");
                }

                // Handle file upload
                string imageUrl = await SaveImageAsync(createProductDto.Image);

                var product = new Product
                {
                    Name = createProductDto.Name,
                    Price = createProductDto.Price,
                    CategoryId = createProductDto.CategoryId,
                    ImageUrl = imageUrl
                };

                var createdProduct = await _productRepository.CreateAsync(product);
                await _productRepository.GetByIdAsync(createdProduct.Id); // Reload with category

                var result = new ProductDto
                {
                    Id = createdProduct.Id,
                    Name = createdProduct.Name,
                    Price = createdProduct.Price,
                    ImageUrl = createdProduct.ImageUrl,
                    CategoryId = createdProduct.CategoryId,
                    CategoryName = category.Name
                };

                return ApiResponse<ProductDto>.SuccessResponse(result, "Product created successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductDto>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while creating product: {ex.Message}");
            }
        }

        public async Task<ApiResponse<ProductDto>> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    return ApiResponse<ProductDto>.ErrorResponse(
                        ErrorCodes.PRODUCT_NOT_FOUND,
                        $"Product with ID {id} not found.");
                }

                // Validate category exists
                var category = await _categoryRepository.GetByIdAsync(updateProductDto.CategoryId);
                if (category == null)
                {
                    return ApiResponse<ProductDto>.ErrorResponse(
                        ErrorCodes.CATEGORY_NOT_FOUND,
                        $"Category with ID {updateProductDto.CategoryId} not found.");
                }

                // Validate input
                if (string.IsNullOrWhiteSpace(updateProductDto.Name))
                {
                    return ApiResponse<ProductDto>.ErrorResponse(
                        ErrorCodes.VALIDATION_ERROR,
                        "Product name is required.");
                }

                if (updateProductDto.Price <= 0)
                {
                    return ApiResponse<ProductDto>.ErrorResponse(
                        ErrorCodes.VALIDATION_ERROR,
                        "Product price must be greater than 0.");
                }

                // Handle file upload if new image provided
                if (updateProductDto.Image != null)
                {
                    // Delete old image
                    DeleteImage(product.ImageUrl);
                    // Save new image
                    product.ImageUrl = await SaveImageAsync(updateProductDto.Image);
                }

                product.Name = updateProductDto.Name;
                product.Price = updateProductDto.Price;
                product.CategoryId = updateProductDto.CategoryId;

                var updatedProduct = await _productRepository.UpdateAsync(product);
                var reloadedProduct = await _productRepository.GetByIdAsync(updatedProduct.Id);

                var result = new ProductDto
                {
                    Id = reloadedProduct!.Id,
                    Name = reloadedProduct.Name,
                    Price = reloadedProduct.Price,
                    ImageUrl = reloadedProduct.ImageUrl,
                    CategoryId = reloadedProduct.CategoryId,
                    CategoryName = reloadedProduct.Category?.Name
                };

                return ApiResponse<ProductDto>.SuccessResponse(result, "Product updated successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<ProductDto>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while updating product: {ex.Message}");
            }
        }

        public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    return ApiResponse<bool>.ErrorResponse(
                        ErrorCodes.PRODUCT_NOT_FOUND,
                        $"Product with ID {id} not found.");
                }

                // Delete associated image
                DeleteImage(product.ImageUrl);

                var deleted = await _productRepository.DeleteAsync(id);
                if (!deleted)
                {
                    return ApiResponse<bool>.ErrorResponse(
                        ErrorCodes.INTERNAL_ERROR,
                        "Failed to delete product.");
                }

                return ApiResponse<bool>.SuccessResponse(true, "Product deleted successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse(
                    ErrorCodes.INTERNAL_ERROR,
                    $"An error occurred while deleting product: {ex.Message}");
            }
        }

        private async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            // Validate file
            if (imageFile == null || imageFile.Length == 0)
            {
                throw new ArgumentException("Image file is required.");
            }

            // Validate file extension
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {
                throw new ArgumentException("Invalid file type. Allowed types: jpg, jpeg, png, gif, bmp");
            }

            // Generate unique file name
            var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
            var imagesPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            
            // Ensure directory exists
            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            var filePath = Path.Combine(imagesPath, uniqueFileName);

            // Save file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            // Return relative URL
            return $"/images/{uniqueFileName}";
        }

        private void DeleteImage(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return;

            try
            {
                var fileName = Path.GetFileName(imageUrl);
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch
            {
                // Log error but don't throw - image deletion failure shouldn't break the operation
            }
        }
    }
}

