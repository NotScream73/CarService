using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceDatabaseImplement.Models
{
	public class Employee : IEmployeeModel
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public string Surname { get; set; } = string.Empty;
		[Required]
		public string Patronymic { get; set; } = string.Empty;
		[Required]
		public string Phone { get; set; } = string.Empty;
		[ForeignKey("EmployeeId")]
		public virtual List<Contract> Contracts { get; set; } = new();

		public static Employee Create(EmployeeBindingModel model)
		{
			return new Employee()
			{
				Id = model.Id,
				Name = model.Name,
				Surname = model.Surname,
				Patronymic = model.Patronymic,
				Phone = model.Phone
			};
		}

		public void Update(EmployeeBindingModel model)
		{
			Name = model.Name;
			Surname = model.Surname;
			Patronymic = model.Patronymic;
			Phone = model.Phone;
		}

		public EmployeeViewModel GetViewModel => new()
		{
			Id = Id,
			Name = Name,
			Surname = Surname,
			Patronymic = Patronymic,
			Phone = Phone
		};
	}
}
