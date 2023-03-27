using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceDatabaseImplement.Models
{
	public class Car : ICarModel
	{
		public int Id { get; set; }
		[Required]
		public string Number { get; set; } = string.Empty;
		[ForeignKey("CarId")]
		public virtual List<Contract> Contracts { get; set; } = new();

		public static Car Create(CarBindingModel model)
		{
			return new Car()
			{
				Id = model.Id,
				Number = model.Number
			};
		}

		public void Update(CarBindingModel model)
		{
			Number = model.Number;
		}

		public CarViewModel GetViewModel => new()
		{
			Id = Id,
			Number = Number
		};
	}
}
