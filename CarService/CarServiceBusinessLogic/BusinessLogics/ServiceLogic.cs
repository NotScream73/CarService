using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;

namespace CarServiceBusinessLogic.BusinessLogics
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly IServiceStorage _serviceStorage;

        public ServiceLogic(IServiceStorage serviceStorage)
        {
            _serviceStorage = serviceStorage;
        }

        public bool AddAll(List<ServiceViewModel> model)
        {

            return _serviceStorage.InsertMany(model);
        }

        public long AddTest()
        {
            return _serviceStorage.AddTest();
        }
        public bool Create(ServiceBindingModel model)
        {
            CheckModel(model);
            if (_serviceStorage.Insert(model) == null)
            {
                return false;
            }
            return true;
        }

        public bool Delete(ServiceBindingModel model)
        {
            CheckModel(model, false);
            if (_serviceStorage.Delete(model) == null)
            {
                return false;
            }
            return true;
        }

        public List<ReportViewModel> GetMostPopular()
        {
            return _serviceStorage.GetMostPopularList();
        }

        public ServiceViewModel? ReadElement(ServiceSearchModel? model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var element = _serviceStorage.GetElement(model);
            if (element == null)
            {
                return null;
            }
            return element;
        }

        public List<ServiceViewModel>? ReadList(ServiceSearchModel? model)
        {
            var list = model == null ? _serviceStorage.GetFullList() : _serviceStorage.GetFilteredList(model);
            if (list == null)
            {
                return null;
            }
            return list;
        }

        public bool Update(ServiceBindingModel model)
        {
            CheckModel(model);
            if (_serviceStorage.Update(model) == null)
            {
                return false;
            }
            return true;
        }
        private void CheckModel(ServiceBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new ArgumentNullException("Нет названия услуги", nameof(model.Title));
            }
            if (model.Price <= 0)
            {
                throw new ArgumentException("Стоимость услуги должна быть больше 0", nameof(model.Price));
            }
            var element = _serviceStorage.GetElement(new ServiceSearchModel
            {
                Title = model.Title
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Такая услуга уже есть");
            }
        }
    }
}
