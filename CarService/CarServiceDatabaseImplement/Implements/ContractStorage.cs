using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceDatabaseImplement.Implements
{
	public class ContractStorage : IContractStorage
	{
		public ContractViewModel? Delete(ContractBindingModel model)
		{
			using var context = new CarserviceContext();
			var element = context.Contracts
				.Include(x => x.Services)
				.Include(x => x.Car)
				.Include(x => x.Client)
				.Include(x => x.Employee)
				.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Contracts.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}

		public ContractViewModel? GetElement(ContractSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new CarserviceContext();
			return context.Contracts
				.Include(x => x.Car)
				.Include(x => x.Client)
				.Include(x => x.Employee)
				.Include(x => x.Services)
				.ThenInclude(x => x.Service)
				.FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
				?.GetViewModel;
		}

		public List<ContractViewModel> GetFilteredList(ContractSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new CarserviceContext();
			return context.Contracts
					.Include(x => x.Car)
					.Include(x => x.Client)
					.Include(x => x.Employee)
					.Include(x => x.Services)
					.ThenInclude(x => x.Service)
					.Where(x => model.Id.HasValue && x.Id == model.Id)
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ContractViewModel> GetFullList()
		{
			using var context = new CarserviceContext();
			return context.Contracts
					.Include(x => x.Car)
					.Include(x => x.Client)
					.Include(x => x.Employee)
					.Include(x => x.Services)
					.ThenInclude(x => x.Service)
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public ContractViewModel? Insert(ContractBindingModel model)
		{
			using var context = new CarserviceContext();
			model.Id = context.Contracts.Count() > 0 ? context.Contracts.Max(x => x.Id) + 1 : 1;
			var newContract = Contract.Create(context, model);
			if (newContract == null)
			{
				return null;
			}
			context.Contracts.Add(newContract);
			context.SaveChanges();
			return context.Contracts
					      .Include(x => x.Car)
					      .Include(x => x.Client)
					      .Include(x => x.Employee)
					      .Include(x => x.Services)
					      .ThenInclude(x => x.Service)
						  .FirstOrDefault(x => x.Id == newContract.Id)
						  ?.GetViewModel;
		}

		public ContractViewModel? Update(ContractBindingModel model)
		{
			using var context = new CarserviceContext();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var contract = context.Contracts.FirstOrDefault(rec => rec.Id == model.Id);
				if (contract == null)
				{
					return null;
				}
				contract.Update(model);
				context.SaveChanges();
				contract.UpdateServices(context, model);
				transaction.Commit();
				return contract.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}
	}
}