using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceDatabaseImplement.Models
{
	public class Contract : IContractModel
	{
		public int Id { get; set; }
		[Required]
		public DateTime DateCreate { get; set; }
		[Required]
		public double Cost { get; set; }
		[Required]
		public int EmployeeId { get; set; }
		[Required]
		public int ClientId { get; set; }
		[Required]
		public int CarId { get; set; }

		public virtual Employee Employee { get; set; }

		public virtual Client Client { get; set; }

		public virtual Car Car { get; set; }
		
		private Dictionary<int, (IServiceModel, double)>? _contractServices = null;

		[NotMapped]
		public Dictionary<int, (IServiceModel, double)> ContractServices
		{
			get
			{
				if (_contractServices == null)
				{
					_contractServices = Services
							.ToDictionary(recPC => recPC.ServiceId, recPC => (recPC.Service as IServiceModel, recPC.Price));
				}
				return _contractServices;
			}
		}

		[ForeignKey("ContractId")]
		public virtual List<ContractService> Services { get; set; } = new();
		public static Contract? Create(CarServiceDatabase context, ContractBindingModel? model)
		{
			if (model == null)
			{
				return null;
			}
			return new Contract()
			{
				Id = model.Id,
				DateCreate = model.DateCreate,
				Cost = model.Cost,
				EmployeeId = model.EmployeeId,
				ClientId = model.ClientId,
				CarId = model.CarId,
				Services = model.ContractServices.Select(x => new ContractService
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
			DateCreate = DateCreate,
			CarId = CarId,
			CarNumber = Car.Number,
			EmployeeId = EmployeeId,
			EmployeeName = Employee.Name
		};

		public void UpdateServices(CarServiceDatabase context, ContractBindingModel model)
		{
			var contractServices = context.ContractServices.Where(rec => rec.ContractId == model.Id).ToList();
			if (contractServices != null && contractServices.Count > 0)
			{   // удалили те, которых нет в модели
				context.ContractServices.RemoveRange(contractServices.Where(rec => !model.ContractServices.ContainsKey(rec.ServiceId)));
				context.SaveChanges();
				// обновили количество у существующих записей
				foreach (var updateService in contractServices)
				{
					updateService.Price = model.ContractServices[updateService.ServiceId].Item2;
					model.ContractServices.Remove(updateService.ServiceId);
				}
				context.SaveChanges();
			}
			var contract = context.Contracts.First(x => x.Id == Id);
			foreach (var cs in model.ContractServices)
			{
				context.ContractServices.Add(new ContractService
				{
					Contract = contract,
					Service = context.Services.First(x => x.Id == cs.Key),
					Price = cs.Value.Item2
				});
				context.SaveChanges();
			}
			_contractServices = null;
		}
	}
}