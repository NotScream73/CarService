using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace CarServiceContracts.StoragesContracts
{
	public interface IContractStorage
	{
		List<ContractViewModel> GetFullList();

		List<ContractViewModel> GetFilteredList(ContractSearchModel model);

		ContractViewModel? GetElement(ContractSearchModel model);

		ContractViewModel? Insert(ContractBindingModel model);

		ContractViewModel? Update(ContractBindingModel model);

		ContractViewModel? Delete(ContractBindingModel model);
	}
}