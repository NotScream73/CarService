namespace CarServiceDataModels.Models
{
	public interface IContractModel : IId
	{
		DateTime DateCreate { get; }
		double Cost { get; }
		int EmployeeId { get; }
		int ClientId { get; }
		int CarId { get; }
	}
}