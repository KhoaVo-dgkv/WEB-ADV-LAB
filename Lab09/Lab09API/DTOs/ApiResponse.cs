namespace Lab09API.DTOs
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? ErrorCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string? message = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static ApiResponse<T> ErrorResponse(string errorCode, string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                ErrorCode = errorCode,
                Message = message
            };
        }
    }

    public static class ErrorCodes
    {
        public const string NOT_FOUND = "NOT_FOUND";
        public const string VALIDATION_ERROR = "VALIDATION_ERROR";
        public const string INTERNAL_ERROR = "INTERNAL_ERROR";
        public const string CATEGORY_NOT_FOUND = "CATEGORY_NOT_FOUND";
        public const string PRODUCT_NOT_FOUND = "PRODUCT_NOT_FOUND";
        public const string INVALID_FILE = "INVALID_FILE";
    }
}

