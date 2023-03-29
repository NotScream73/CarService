using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace CarServiceContracts.BusinessLogicsContracts
{
	public interface IClientLogic
	{
		List<ClientViewModel>? ReadList(ClientSearchModel? model);

		ClientViewModel? ReadElement(ClientSearchModel? model);

		bool Create(ClientBindingModel model);

		bool Update(ClientBindingModel model);

		bool Delete(ClientBindingModel model);
		bool AddTest(int count);
	}
}