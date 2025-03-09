namespace CardActionService.Models
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static BaseResponse<T> SuccessResponse(T data)
        {
            return new BaseResponse<T> { Success = true, Data = data };
        }

        public static BaseResponse<T> ErrorResponse(string message)
        {
            return new BaseResponse<T> { Success = false, Message = message };
        }
    }
}
