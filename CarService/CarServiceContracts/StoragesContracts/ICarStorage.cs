using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;

namespace CarServiceContracts.StoragesContracts
{
	public interface ICarStorage
	{
		List<CarViewModel> GetFullList();

		List<CarViewModel> GetFilteredList(CarSearchModel model);

		CarViewModel? GetElement(CarSearchModel model);

		CarViewModel? Insert(CarBindingModel model);

		CarViewModel? Update(CarBindingModel model);

		CarViewModel? Delete(CarBindingModel model);
		bool AddTest(int count);
	}
}