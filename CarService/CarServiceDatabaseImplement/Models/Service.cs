using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceDatabaseImplement.Models
{
	public class Service : IServiceModel
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; } = string.Empty;
		[Required]
		public double Price { get; set; }
		[ForeignKey("ServiceId")]
		public virtual List<ContractService> ContractServices { get; set; } = new();

		public static Service? Create(ServiceBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Service()
			{
				Id = model.Id,
				Title = model.Title,
				Price = model.Price
			};
		}

		public static Service Create(ServiceViewModel model)
		{
			return new Service
			{
				Id = model.Id,
				Title = model.Title,
				Price = model.Price
			};
		}

		public void Update(ServiceBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			Title = model.Title;
			Price = model.Price;
		}

		public ServiceViewModel GetViewModel => new()
		{
			Id = Id,
			Title = Title,
			Price = Price
		};
	}
}