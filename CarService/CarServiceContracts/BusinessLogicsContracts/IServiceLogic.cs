using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace CarServiceContracts.BusinessLogicsContracts
{
	public interface IServiceLogic
	{
		List<ServiceViewModel>? ReadList(ServiceSearchModel? model);

		ServiceViewModel? ReadElement(ServiceSearchModel? model);

		bool Create(ServiceBindingModel model);

		bool Update(ServiceBindingModel model);

		bool Delete(ServiceBindingModel model);
		long AddTest();
	}
}