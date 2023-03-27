using CarServiceDataModels.Models;

namespace CarServiceContracts.BindingModels
{
	public class ContractBindingModel : IContractModel
	{
		public int Id { get; set; }

		public double Cost { get; set; }

		public DateTime DateCreate { get; set; } = DateTime.Now;

		public int EmployeeId { get; set; }

		public int ClientId { get; set; }

		public int CarId { get; set; }
	}
}