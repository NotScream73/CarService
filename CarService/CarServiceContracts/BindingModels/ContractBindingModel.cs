using CarServiceDataModels.Models;

namespace CarServiceContracts.BindingModels
{
	public class ContractBindingModel : IContractModel
	{
		public int Id { get; set; }

		public double Cost { get; set; }

		public DateTime Date { get; set; } = DateTime.Now;

		public int EmployeeId { get; set; }

		public int ClientId { get; set; }

		public int CarId { get; set; }

		public Dictionary<int, (IServiceModel, double)> ServiceContracts { get; set; } = new();
	}
}