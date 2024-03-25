namespace Contracts.ResponseModels.Customer
{
    public class DeleteCustomerDataResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
