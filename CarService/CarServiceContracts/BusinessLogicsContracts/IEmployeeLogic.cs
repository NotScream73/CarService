using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace CarServiceContracts.BusinessLogicsContracts
{
	public interface IEmployeeLogic
	{
		List<EmployeeViewModel>? ReadList(EmployeeSearchModel? model);

		EmployeeViewModel? ReadElement(EmployeeSearchModel? model);

		bool Create(EmployeeBindingModel model);

		bool Update(EmployeeBindingModel model);

		bool Delete(EmployeeBindingModel model);
		long AddTest(int count);
	}
}