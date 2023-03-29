using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;
using ClientServiceContracts.StoragesContracts;
using System.Diagnostics;

namespace CarServiceDatabaseImplement.Implements
{
	public class ClientStorage : IClientStorage
	{
		public ClientViewModel? Delete(ClientBindingModel model)
		{
			using var context = new CarserviceContext();
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
			using var context = new CarserviceContext();
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
			using var context = new CarserviceContext();
			return context.Clients
					.Where(x => x.Phone.Contains(model.Phone))
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<ClientViewModel> GetFullList()
		{
			using var context = new CarserviceContext();
			return context.Clients
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public ClientViewModel? Insert(ClientBindingModel model)
		{
			using var context = new CarserviceContext();
			model.Id = context.Clients.Count() > 0 ? context.Clients.Max(x => x.Id) + 1 : 1;
			var newClient = Client.Create(model);
			if (newClient == null)
			{
				return null;
			}
			context.Clients.Add(newClient);
			context.SaveChanges();
			return newClient.GetViewModel;
		}

		public ClientViewModel? Update(ClientBindingModel model)
		{
			using var context = new CarserviceContext();
			var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
			if (client == null)
			{
				return null;
			}
			client.Update(model);
			context.SaveChanges();
			return client.GetViewModel;
		}

		public long AddTest(int count)
		{
			using var context = new CarserviceContext();
			List<string> listName = new();
			StreamReader f = new StreamReader("Names.txt");
			while (!f.EndOfStream)
			{
				listName.Add(f.ReadLine());
			}
			f.Close();
			List<string> listSurname = new();
			f = new StreamReader("Surnames.txt");
			while (!f.EndOfStream)
			{
				listSurname.Add(f.ReadLine());
			}
			f.Close();
			List<string> ListPatronymic = new();
			f = new StreamReader("Patronymics.txt");
			while (!f.EndOfStream)
			{
				ListPatronymic.Add(f.ReadLine());
			}
			f.Close();
			Random rand = new Random();
			int maxId = context.Clients.Count() > 0 ? context.Clients.Max(x => x.Id) + 1 : 1;
			for (int i = 0; i < count; i++)
			{
				int randName = rand.Next(0, 100);
				int randSurname = rand.Next(0, 100);
				int randPatronymic = rand.Next(0, 100);
				int num1 = rand.Next(001, 999);
				int num2 = rand.Next(000, 999);
				int num3 = rand.Next(00, 99);
				int num4 = rand.Next(00, 99);
				string result = "8" + num1.ToString() + num2.ToString() + num3.ToString() + num4.ToString();
				var newClient = Client.Create(new()
				{
					Id = maxId,
					Name = listName[randName],
					Surname = listSurname[randSurname],
					Patronymic = ListPatronymic[randPatronymic],
					Phone = result
				}) ;
				maxId++;
				if (newClient == null)
				{
					continue;
				}
				context.Clients.Add(newClient);
			}
			Stopwatch stopwatch = new();
			stopwatch.Start();
			context.SaveChanges();
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}
	}
}