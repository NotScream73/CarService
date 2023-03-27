using CarServiceDataModels.Models;
using System.ComponentModel;

namespace CarServiceContracts.ViewModels
{
	public class ServiceViewModel : IServiceModel
	{
		public int Id { get; set; }
		[DisplayName("Название")]
		public string Title { get; set; } = string.Empty;
		[DisplayName("Стоимость")]
		public double Price { get; set; }
	}
}