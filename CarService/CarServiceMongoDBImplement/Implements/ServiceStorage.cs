using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceMongoDBImplement.Models;
using MongoDB.Driver;

namespace CarServiceMongoDBImplement.Implements
{
    public class ServiceStorage : IServiceStorage
    {
        private CarServiceConnect connect = new();
        public long AddTest()
        {
            var servicesCollection = connect.ConnectToMongo<Service>("services");
            List<string> listTitle = new();
            StreamReader f = new StreamReader("Titles.txt");
            while (!f.EndOfStream)
            {
                listTitle.Add(f.ReadLine());
            }
            f.Close();
            Random rand = new();
            for (int i = 0; i < listTitle.Count; i++)
            {
                int randPrice = rand.Next(1000, 999999);
                var newService = Service.Create(new ServiceBindingModel()
                {
                    Price = randPrice,
                    Title = listTitle[i]
                });
                if (newService == null)
                {
                    continue;
                }
                servicesCollection.InsertOne(newService);
            }
            return 1L;
        }

        public ServiceViewModel? Delete(ServiceBindingModel model)
        {
            var servicesCollection = connect.ConnectToMongo<Service>("services");
            var element = servicesCollection.Find(rec => rec.Id == model.MId).FirstOrDefault();
            if (element != null)
            {
                servicesCollection.DeleteOne(x => x.Id == model.MId);
                return element.GetViewModel;
            }
            return null;
        }

        public ServiceViewModel? GetElement(ServiceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Title) && string.IsNullOrEmpty(model.MId))
            {
                return null;
            }
            var servicesCollection = connect.ConnectToMongo<Service>("services");
            var temp = servicesCollection.Find(x => x.Id == model.MId)
                                    .FirstOrDefault()
                                    ?.GetViewModel;
            return temp;
        }

        public List<ServiceViewModel> GetFilteredList(ServiceSearchModel model)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                return new();
            }
            var servicesCollection = connect.ConnectToMongo<Service>("services");
            return servicesCollection.Find(x => x.Title.Contains(model.Title))
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public List<ServiceViewModel> GetFullList()
        {
            var servicesCollection = connect.ConnectToMongo<Service>("services");
            return servicesCollection.Find(_ => true)
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public List<ReportViewModel> GetMostPopularList()
        {
            var contractsCollection = connect.ConnectToMongo<Contract>("contracts");
            var list = contractsCollection.Find(_ => true).ToList().Select(x => x.Services).ToList();
            Dictionary<string, double> dict = new();
            foreach (var elem in list)
            {
                foreach (var el in elem)
                {
                    if (dict.ContainsKey(el.Service.Title))
                    {
                        dict[el.Service.Title] += el.Price;
                    }
                    else
                    {
                        dict[el.Service.Title] = el.Price;
                    }
                }
            }
            return dict.Select(x => new ReportViewModel() { Title = x.Key, TotalCount = x.Value }).OrderByDescending(x => x.TotalCount).ToList();
        }

        public ServiceViewModel? Insert(ServiceBindingModel model)
        {
            var servicesCollection = connect.ConnectToMongo<Service>("services");
            var newService = Service.Create(model);
            if (newService == null)
            {
                return null;
            }
            servicesCollection.InsertOne(newService);
            return newService.GetViewModel;
        }

        public bool InsertMany(List<ServiceViewModel> model)
        {

            var servicesCollection = connect.ConnectToMongo<Service>("services");
            List<Service> models = model.Select(x => Service.Create(new() { Title = x.Title, Price = x.Price })).ToList();
            servicesCollection.InsertMany(models);
            return true;
        }

        public ServiceViewModel? Update(ServiceBindingModel model)
        {
            var servicesCollection = connect.ConnectToMongo<Service>("services");
            var service = servicesCollection.Find(x => x.Id == model.MId).FirstOrDefault();
            if (service == null)
            {
                return null;
            }
            service.Update(model);
            var filter = Builders<Service>.Filter.Eq("Id", model.MId);
            servicesCollection.ReplaceOne(filter, service, new ReplaceOptions { IsUpsert = true });
            return service.GetViewModel;
        }
    }
}
