using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace CarServiceContracts.BusinessLogicsContracts
{
	public interface ICarLogic
	{
		List<CarViewModel>? ReadList(CarSearchModel? model);

		CarViewModel? ReadElement(CarSearchModel model);

		bool Create(CarBindingModel model);

		bool Update(CarBindingModel model);

		bool Delete(CarBindingModel model);
		bool AddTest(int count);
	}
}