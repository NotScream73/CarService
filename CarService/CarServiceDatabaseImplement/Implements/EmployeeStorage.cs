﻿using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceDatabaseImplement.Models;

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
	}
}
