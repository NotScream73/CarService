using CarServiceDataModels.Models;

namespace CarServiceContracts.BindingModels
{
	public class ServiceBindingModel : IServiceModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public double Price { get; set; }
	}
}