using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace CarServiceContracts.BusinessLogicsContracts
{
    public interface IContractLogic
    {
        List<ContractViewModel>? ReadList(ContractSearchModel? model);

        ContractViewModel? ReadElement(ContractSearchModel? model);

        bool Create(ContractBindingModel model);

        bool Update(ContractBindingModel model);

        bool Delete(ContractBindingModel model);
        bool AddAll(List<ContractViewModel> model);
        long AddTest(int count);
    }
}