using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;

namespace CarServiceBusinessLogic.BusinessLogics
{
	public class CarLogic : ICarLogic
	{
		private readonly ICarStorage _carStorage;

		public CarLogic(ICarStorage carStorage)
		{
			_carStorage = carStorage;
		}

		public bool Create(CarBindingModel model)
		{
			CheckModel(model);
			if (_carStorage.Insert(model) == null)
			{
				return false;
			}
			return true;
		}

		public bool AddTest(int count)
		{
			return _carStorage.AddTest(count);
		}
		public bool Delete(CarBindingModel model)
		{
			CheckModel(model, false);
			if (_carStorage.Delete(model) == null)
			{
				return false;
			}
			return true;
		}

		public CarViewModel? ReadElement(CarSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			var element = _carStorage.GetElement(model);
			if (element == null)
			{
				return null;
			}
			return element;
		}

		public List<CarViewModel>? ReadList(CarSearchModel? model)
		{
			var list = model == null ? _carStorage.GetFullList() : _carStorage.GetFilteredList(model);
			if (list == null)
			{
				return null;
			}
			return list;
		}

		public bool Update(CarBindingModel model)
		{
			CheckModel(model);
			if (_carStorage.Update(model) == null)
			{
				return false;
			}
			return true;
		}

		private void CheckModel(CarBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (string.IsNullOrEmpty(model.Number))
			{
				throw new ArgumentNullException("Нет номера машины", nameof(model.Number));
			}
			var element = _carStorage.GetElement(new CarSearchModel
			{
				Number = model.Number
			});
			if (element != null && element.Id != model.Id)
			{
				throw new InvalidOperationException("Машина с такими номерами уже есть");
			}
		}
	}
}
