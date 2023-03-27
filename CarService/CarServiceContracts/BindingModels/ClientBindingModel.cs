using CarServiceDataModels.Models;

namespace CarServiceContracts.BindingModels
{
	public class ClientBindingModel : IClientModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Surname { get; set; } = string.Empty;

		public string Patronymic { get; set; } = string.Empty;

		public string Phone { get; set; } = string.Empty;
	}
}