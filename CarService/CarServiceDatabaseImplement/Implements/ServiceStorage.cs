using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;

namespace CarServiceDatabaseImplement.Implements
{
	public class ServiceStorage : IServiceStorage
	{
		public ServiceViewModel? Delete(ServiceBindingModel model)
		{
			using var context = new CarserviceContext();
			var element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Services.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}

		public ServiceViewModel? GetElement(ServiceSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Title) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new CarserviceContext();
			return context.Services
					.FirstOrDefault(x => (!string.IsNullOrEmpty(model.Title) && x.Title == model.Title) ||
										(model.Id.HasValue && x.Id == model.Id))
					?.GetViewModel;
		}

		public List<ServiceViewModel> GetFilteredList(ServiceSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Title))
			{
				return new();
			}
			using var context = new CarserviceContext();
			return context.Services
					.Where(x => x.Title.Contains(model.Title))
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ServiceViewModel> GetFullList()
		{
			using var context = new CarserviceContext();
			return context.Services
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public ServiceViewModel? Insert(ServiceBindingModel model)
		{
			using var context = new CarserviceContext();
			model.Id = context.Services.Count() > 0 ? context.Services.Max(x => x.Id) + 1 : 1;
			var newService = Service.Create(model);
			if (newService == null)
			{
				return null;
			}
			context.Services.Add(newService);
			context.SaveChanges();
			return newService.GetViewModel;
		}

		public ServiceViewModel? Update(ServiceBindingModel model)
		{
			using var context = new CarserviceContext();
			var service = context.Services.FirstOrDefault(x => x.Id == model.Id);
			if (service == null)
			{
				return null;
			}
			service.Update(model);
			context.SaveChanges();
			return service.GetViewModel;
		}
		public bool AddTest()
		{
			using var context = new CarserviceContext();
			List<string> listTitle = new();
			StreamReader f = new StreamReader("Titles.txt");
			while (!f.EndOfStream)
			{
				listTitle.Add(f.ReadLine());
			}
			f.Close();
			Random rand = new();
			int maxId = context.Services.Count() > 0 ? context.Services.Max(x => x.Id) + 1 : 1;
			for (int i = 0; i < listTitle.Count; i++)
			{
				int randPrice = rand.Next(1000, 999999);
				var newService = Service.Create(new ServiceBindingModel()
				{
					Id = maxId,
					Price = randPrice,
					Title = listTitle[i]
				}) ;
				maxId++;
				if (newService == null)
				{
					continue;
				}
				context.Services.Add(newService);
			}
			context.SaveChanges();
			return true;
		}
	}
}
