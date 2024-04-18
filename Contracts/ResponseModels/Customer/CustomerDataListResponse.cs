namespace Contracts.ResponseModels.Customer
{
	public class CustomerDataListResponse
	{
		public List<CustomerData> CustomerDatas { get; set;} = new List<CustomerData>();
		public int TotalData { get; set; }
	}

	public class CustomerData
	{
		public Guid CustomerID { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;
	}
}
