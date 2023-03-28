using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceDatabaseImplement.Models
{
	/// <summary>
	/// Таблица машин
	/// </summary>
	public partial class Car /*: ICarModel*/
	{
		/// <summary>
		/// Уникальный идентификатор машины
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Номер машины
		/// </summary>
		public string Number { get; set; } = null!;
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