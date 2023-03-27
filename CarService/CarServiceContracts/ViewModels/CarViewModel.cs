using CarServiceDataModels.Models;
using System.ComponentModel;

namespace CarServiceContracts.ViewModels
{
	public class CarViewModel : ICarModel
	{
		public int Id { get; set; }
		[DisplayName("Номер машины")]
		public string Number { get; set; } = string.Empty;
	}
}