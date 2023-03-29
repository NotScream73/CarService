using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;

namespace CarServiceBusinessLogic.BusinessLogics
{
	public class EmployeeLogic : IEmployeeLogic
	{
		private readonly IEmployeeStorage _employeeStorage;

		public EmployeeLogic(IEmployeeStorage employeeStorage)
		{
			_employeeStorage = employeeStorage;
		}

		public long AddTest(int count)
		{
			return _employeeStorage.AddTest(count);
		}

		public bool Create(EmployeeBindingModel model)
		{
			CheckModel(model);
			if (_employeeStorage.Insert(model) == null)
			{
				return false;
			}
			return true;
		}

		public bool Delete(EmployeeBindingModel model)
		{
			CheckModel(model, false);
			if (_employeeStorage.Delete(model) == null)
			{
				return false;
			}
			return true;
		}

		public EmployeeViewModel? ReadElement(EmployeeSearchModel? model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			var element = _employeeStorage.GetElement(model);
			if (element == null)
			{
				return null;
			}
			return element;
		}

		public List<EmployeeViewModel>? ReadList(EmployeeSearchModel? model)
		{
			var list = model == null ? _employeeStorage.GetFullList() : _employeeStorage.GetFilteredList(model);
			if (list == null)
			{
				return null;
			}
			return list;
		}

		public bool Update(EmployeeBindingModel model)
		{
			CheckModel(model);
			if (_employeeStorage.Update(model) == null)
			{
				return false;
			}
			return true;
		}
		private void CheckModel(EmployeeBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (string.IsNullOrEmpty(model.Phone))
			{
				throw new ArgumentNullException("Нет номера телефона сотрудника", nameof(model.Phone));
			}
			if (string.IsNullOrEmpty(model.Name))
			{
				throw new ArgumentNullException("Нет имени сотрудника", nameof(model.Name));
			}
			if (string.IsNullOrEmpty(model.Surname))
			{
				throw new ArgumentNullException("Нет фамилии сотрудника", nameof(model.Surname));
			}
			var element = _employeeStorage.GetElement(new EmployeeSearchModel
			{
				Phone = model.Phone
			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Сотрудник с таким номером телефона уже есть");
			}
		}
	}
}
