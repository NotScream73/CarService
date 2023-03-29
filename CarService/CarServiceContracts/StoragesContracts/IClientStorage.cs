using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace ClientServiceContracts.StoragesContracts
{
	public interface IClientStorage
	{
		List<ClientViewModel> GetFullList();

		List<ClientViewModel> GetFilteredList(ClientSearchModel model);

		ClientViewModel? GetElement(ClientSearchModel model);

		ClientViewModel? Insert(ClientBindingModel model);

		ClientViewModel? Update(ClientBindingModel model);

		ClientViewModel? Delete(ClientBindingModel model);
		bool AddTest(int count);
	}
}