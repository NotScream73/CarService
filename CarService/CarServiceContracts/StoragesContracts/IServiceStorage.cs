using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace CarServiceContracts.StoragesContracts
{
	public interface IServiceStorage
	{
		List<ServiceViewModel> GetFullList();

		List<ServiceViewModel> GetFilteredList(ServiceSearchModel model);

		ServiceViewModel? GetElement(ServiceSearchModel model);

		ServiceViewModel? Insert(ServiceBindingModel model);

		ServiceViewModel? Update(ServiceBindingModel model);

		ServiceViewModel? Delete(ServiceBindingModel model);
	}
}