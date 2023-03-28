using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;
using CarServiceDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceDatabaseImplement.Models
{
	/// <summary>
	/// Таблица услуг
	/// </summary>
	public partial class Service : IServiceModel
	{
		/// <summary>
		/// Уникальный идентификатор услуги
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название услуги
		/// </summary>
		public string Title { get; set; } = null!;

		/// <summary>
		/// Стоимость услуги
		/// </summary>
		public double Price { get; set; }
		[ForeignKey("ServiceId")]
		public virtual List<ServiceContract> ContractServices { get; set; } = new();

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