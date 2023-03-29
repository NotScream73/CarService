using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;
using System.Diagnostics;

namespace CarServiceDatabaseImplement.Implements
{
	public class EmployeeStorage : IEmployeeStorage
	{
		public EmployeeViewModel? Delete(EmployeeBindingModel model)
		{
			using var context = new CarserviceContext();
			var element = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Employees.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}

		public EmployeeViewModel? GetElement(EmployeeSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Phone) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new CarserviceContext();
			return context.Employees
					.FirstOrDefault(x => (!string.IsNullOrEmpty(model.Phone) && x.Phone == model.Phone) ||
										(model.Id.HasValue && x.Id == model.Id))
					?.GetViewModel;
		}

		public List<EmployeeViewModel> GetFilteredList(EmployeeSearchModel model)
		{
			if (string.IsNullOrEmpty(model.Phone))
			{
				return new();
			}
			using var context = new CarserviceContext();
			return context.Employees
					.Where(x => x.Phone.Contains(model.Phone))
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<EmployeeViewModel> GetFullList()
		{
			using var context = new CarserviceContext();
			return context.Employees
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public EmployeeViewModel? Insert(EmployeeBindingModel model)
		{
			using var context = new CarserviceContext();
			model.Id = context.Employees.Count() > 0 ? context.Employees.Max(x => x.Id) + 1 : 1;
			var newEmployee = Employee.Create(model);
			if (newEmployee == null)
			{
				return null;
			}
			context.Employees.Add(newEmployee);
			context.SaveChanges();
			return newEmployee.GetViewModel;
		}

		public EmployeeViewModel? Update(EmployeeBindingModel model)
		{
			using var context = new CarserviceContext();
			var employee = context.Employees.FirstOrDefault(x => x.Id == model.Id);
			if (employee == null)
			{
				return null;
			}
			employee.Update(model);
			context.SaveChanges();
			return employee.GetViewModel;
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
			int maxId = context.Employees.Count() > 0 ? context.Employees.Max(x => x.Id) + 1 : 1;
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
				var newEmployee = Employee.Create(new()
				{
					Id = maxId,
					Name = listName[randName],
					Surname = listSurname[randSurname],
					Patronymic = ListPatronymic[randPatronymic],
					Phone = result
				});
				maxId++;
				if (newEmployee == null)
				{
					continue;
				}
				context.Employees.Add(newEmployee);
			}
			Stopwatch stopwatch = new();
			stopwatch.Start();
			context.SaveChanges();
			stopwatch.Stop();
			return stopwatch.ElapsedMilliseconds;
		}
	}
}
