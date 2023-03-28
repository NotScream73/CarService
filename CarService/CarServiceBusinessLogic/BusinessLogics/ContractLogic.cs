using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;

namespace CarServiceBusinessLogic.BusinessLogics
{
	public class ContractLogic : IContractLogic
	{
		private readonly IContractStorage _contractStorage;
		public ContractLogic(IContractStorage contractStorage)
		{
			_contractStorage = contractStorage;
		}
		public bool Create(ContractBindingModel model)
		{
			CheckModel(model);
			if (_contractStorage.Insert(model) == null)
			{
				return false;
			}
			return true;
		}

		public bool Delete(ContractBindingModel model)
		{
			CheckModel(model, false);
			if (_contractStorage.Delete(model) == null)
			{
				return false;
			}
			return true;
		}

		public ContractViewModel? ReadElement(ContractSearchModel? model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			var element = _contractStorage.GetElement(model);
			if (element == null)
			{
				return null;
			}
			return element;
		}

		public List<ContractViewModel>? ReadList(ContractSearchModel? model)
		{
			var list = model == null ? _contractStorage.GetFullList() : _contractStorage.GetFilteredList(model);
			if (list == null)
			{
				return null;
			}
			return list;
		}

		public bool Update(ContractBindingModel model)
		{
			CheckModel(model);
			if (_contractStorage.Update(model) == null)
			{
				return false;
			}
			return true;
		}
		private void CheckModel(ContractBindingModel model, bool withParams = true)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (!withParams)
			{
				return;
			}
			if (model.DateCreate == DateTime.MinValue)
			{
				throw new ArgumentNullException("Нет даты создания чека", nameof(model.DateCreate));
			}
			if (model.Cost <= 0)
			{
				throw new ArgumentException("Сумма услуг должна быть больше 0", nameof(model.Cost));
			}
			if (model.CarId < 0)
			{
				throw new ArgumentNullException("Нет машины с таким ид", nameof(model.CarId));
			}
			if (model.ClientId < 0)
			{
				throw new ArgumentNullException("Нет клиента с таким ид", nameof(model.ClientId));
			}
			if (model.EmployeeId < 0)
			{
				throw new ArgumentNullException("Нет сотрудника с таким ид", nameof(model.EmployeeId));
			}
		}
	}
}
