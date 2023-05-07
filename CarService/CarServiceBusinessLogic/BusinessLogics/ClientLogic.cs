using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;
using ClientServiceContracts.StoragesContracts;

namespace CarServiceBusinessLogic.BusinessLogics
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientStorage _clientStorage;

        public ClientLogic(IClientStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

        public bool Create(ClientBindingModel model)
        {
            CheckModel(model);
            if (_clientStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }

        public bool Delete(ClientBindingModel model)
        {
            CheckModel(model, false);
            if (_clientStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }

        public long AddTest(int count)
        {
            return _clientStorage.AddTest(count);
        }

        public ClientViewModel? ReadElement(ClientSearchModel? model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _clientStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }

        public List<ClientViewModel>? ReadList(ClientSearchModel? model)
        {
            var list = model == null ? _clientStorage.GetFullList() : _clientStorage.GetFilteredList(model);
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public bool Update(ClientBindingModel model)
        {
            CheckModel(model);
            if (_clientStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(ClientBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                throw new ArgumentNullException("Нет номера телефона клиента", nameof(model.Phone));
            }
            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentNullException("Нет имени клиента", nameof(model.Name));
            }
            if (string.IsNullOrEmpty(model.Surname))
            {
                throw new ArgumentNullException("Нет фамилии клиента", nameof(model.Surname));
            }
            var element = _clientStorage.GetElement(new ClientSearchModel
            {
                Phone = model.Phone
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Клиент с таким номером телефона уже есть");
            }
        }

        public bool AddAll(List<ClientViewModel> model)
        {
            return _clientStorage.InsertMany(model);
        }
    }
}
