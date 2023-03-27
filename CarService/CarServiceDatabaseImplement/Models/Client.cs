using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace CarServiceDatabaseImplement.Models
{
	public class Client : IClientModel
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
		[ForeignKey("ClientId")]
		public virtual List<Contract> Contracts { get; set; } = new();
		public static Client Create(ClientBindingModel model)
		{
			return new Client()
			{
				Id = model.Id,
				Name = model.Name,
				Surname = model.Surname,
				Patronymic = model.Patronymic,
				Phone = model.Phone
			};
		}

		public void Update(ClientBindingModel model)
		{
			Name = model.Name;
			Surname = model.Surname;
			Patronymic = model.Patronymic;
			Phone = model.Phone;
		}

		public ClientViewModel GetViewModel => new()
		{
			Id = Id,
			Name = Name,
			Surname = Surname,
			Patronymic = Patronymic,
			Phone = Phone
		};
	}
}