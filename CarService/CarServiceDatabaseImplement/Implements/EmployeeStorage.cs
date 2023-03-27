using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceDatabaseImplement.Implements
{
	public class EmployeeStorage : IEmployeeStorage
	{
		public EmployeeViewModel? Delete(EmployeeBindingModel model)
		{
			using var context = new CarServiceDatabase();
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
			using var context = new CarServiceDatabase();
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
			using var context = new CarServiceDatabase();
			return context.Employees
					.Where(x => x.Phone.Contains(model.Phone))
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<EmployeeViewModel> GetFullList()
		{
			using var context = new CarServiceDatabase();
			return context.Employees
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public EmployeeViewModel? Insert(EmployeeBindingModel model)
		{
			var newEmployee = Employee.Create(model);
			if (newEmployee == null)
			{
				return null;
			}
			using var context = new CarServiceDatabase();
			context.Employees.Add(newEmployee);
			context.SaveChanges();
			return newEmployee.GetViewModel;
		}

		public EmployeeViewModel? Update(EmployeeBindingModel model)
		{
			using var context = new CarServiceDatabase();
			var employee = context.Employees.FirstOrDefault(x => x.Id == model.Id);
			if (employee == null)
			{
				return null;
			}
			employee.Update(model);
			context.SaveChanges();
			return employee.GetViewModel;
		}
	}
}
