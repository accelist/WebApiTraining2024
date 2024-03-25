namespace Contracts.ResponseModels.Cart
{
    public class UpdateCartResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
