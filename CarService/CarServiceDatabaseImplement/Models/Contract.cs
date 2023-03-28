using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceDatabaseImplement.Models
{
	/// <summary>
	/// Таблица договоров
	/// </summary>
	public partial class Contract : IContractModel
	{
		/// <summary>
		/// Уникальный идентификатор договора
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Дата оформления договора
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Общая стоимость оказанных услуг
		/// </summary>
		public double Cost { get; set; }

		/// <summary>
		/// Идентификатор сотрудника
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// Идентификатор клиента
		/// </summary>
		public int ClientId { get; set; }

		/// <summary>
		/// Идентификатор машины
		/// </summary>
		public int CarId { get; set; }

		public virtual Car Car { get; set; } = null!;

		public virtual Client Client { get; set; } = null!;

		public virtual Employee Employee { get; set; } = null!;

		private Dictionary<int, (IServiceModel, double)>? _serviceContracts = null;

		[NotMapped]
		public Dictionary<int, (IServiceModel, double)> ServiceContracts
		{
			get
			{
				if (_serviceContracts == null)
				{
					_serviceContracts = Services
							.ToDictionary(recPC => recPC.ServiceId, recPC => (recPC.Service as IServiceModel, recPC.Price));
				}
				return _serviceContracts;
			}
		}

		[ForeignKey("ContractId")]
		public virtual List<ServiceContract> Services { get; set; } = new();
		public static Contract? Create(CarserviceContext context, ContractBindingModel? model)
		{
			if (model == null)
			{
				return null;
			}
			return new Contract()
			{
				Id = model.Id,
				Date = model.Date,
				Cost = model.Cost,
				EmployeeId = model.EmployeeId,
				ClientId = model.ClientId,
				CarId = model.CarId,
				Services = model.ServiceContracts.Select(x => new ServiceContract
				{
					Service = context.Services.First(y => y.Id == x.Key),
					Price = x.Value.Item2
				}).ToList()
			};
		}

		public void Update(ContractBindingModel? model)
		{
			if (model == null)
			{
				return;
			}
			Cost = model.Cost;
		}

		public ContractViewModel GetViewModel => new()
		{
			Id = Id,
			ClientId = ClientId,
			ClientName = Client.Name,
			Cost = Cost,
			Date = Date,
			CarId = CarId,
			CarNumber = Car.Number,
			EmployeeId = EmployeeId,
			EmployeeName = Employee.Name
		};

		public void UpdateServices(CarserviceContext context, ContractBindingModel model)
		{
			var contractServices = context.ServiceContracts.Where(rec => rec.ContractId == model.Id).ToList();
			if (contractServices != null && contractServices.Count > 0)
			{   // удалили те, которых нет в модели
				context.ServiceContracts.RemoveRange(contractServices.Where(rec => !model.ServiceContracts.ContainsKey(rec.ServiceId)));
				context.SaveChanges();
				// обновили количество у существующих записей
				foreach (var updateService in contractServices)
				{
					updateService.Price = model.ServiceContracts[updateService.ServiceId].Item2;
					model.ServiceContracts.Remove(updateService.ServiceId);
				}
				context.SaveChanges();
			}
			var contract = context.Contracts.First(x => x.Id == Id);
			foreach (var cs in model.ServiceContracts)
			{
				context.ServiceContracts.Add(new ServiceContract
				{
					Contract = contract,
					Service = context.Services.First(x => x.Id == cs.Key),
					Price = cs.Value.Item2
				});
				context.SaveChanges();
			}
			_serviceContracts = null;
		}
	}
}