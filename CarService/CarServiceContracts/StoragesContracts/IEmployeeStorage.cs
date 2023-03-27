using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace CarServiceContracts.StoragesContracts
{
	public interface IEmployeeStorage
	{
		List<EmployeeViewModel> GetFullList();

		List<EmployeeViewModel> GetFilteredList(EmployeeSearchModel model);

		EmployeeViewModel? GetElement(EmployeeSearchModel model);

		EmployeeViewModel? Insert(EmployeeBindingModel model);

		EmployeeViewModel? Update(EmployeeBindingModel model);

		EmployeeViewModel? Delete(EmployeeBindingModel model);

	}
}