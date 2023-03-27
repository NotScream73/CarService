using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;
using ClientServiceContracts.StoragesContracts;

namespace CarServiceDatabaseImplement.Implements
{
	public class ClientStorage : IClientStorage
	{
		public ClientViewModel? Delete(ClientBindingModel model)
		{
			using var context = new CarServiceDatabase();
			var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Clients.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}

		public ClientViewModel? GetElement(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Phone) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new CarServiceDatabase();
			return context.Clients
					.FirstOrDefault(x => (!string.IsNullOrEmpty(model.Phone) && x.Phone == model.Phone) ||
										(model.Id.HasValue && x.Id == model.Id))
					?.GetViewModel;
		}

		public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Phone))
			{
				return new();
			}
			using var context = new CarServiceDatabase();
			return context.Clients
					.Where(x => x.Phone.Contains(model.Phone))
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ClientViewModel> GetFullList()
		{
			using var context = new CarServiceDatabase();
			return context.Clients
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			var newClient = Client.Create(model);
			if (newClient == null)
			{
				return null;
			}
			using var context = new CarServiceDatabase();
			context.Clients.Add(newClient);
			context.SaveChanges();
			return newClient.GetViewModel;
		}

		public ClientViewModel? Update(ClientBindingModel model)
		{
			using var context = new CarServiceDatabase();
			var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
			if (client == null)
			{
				return null;
			}
			client.Update(model);
			context.SaveChanges();
			return client.GetViewModel;
		}
	}
}