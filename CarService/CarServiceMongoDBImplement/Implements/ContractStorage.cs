using CarServiceContracts.BindingModels;
using CarServiceContracts.SearchModels;
using CarServiceContracts.StoragesContracts;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using CarServiceMongoDBImplement.Models;
using MongoDB.Driver;
using System.Diagnostics;

namespace CarServiceMongoDBImplement.Implements
{
    public class ContractStorage : IContractStorage
    {
        private CarServiceConnect connect = new();
        public long AddTest(int count)
        {
            var contractsCollection = connect.ConnectToMongo<Contract>("contracts");
            List<string> carIds = connect.ConnectToMongo<Car>("cars").Find(_ => true).ToList().Select(x => x.Id).ToList();
            List<string> clientIds = connect.ConnectToMongo<Client>("clients").Find(_ => true).ToList().Select(x => x.Id).ToList();
            List<string> employeeIds = connect.ConnectToMongo<Employee>("employees").Find(_ => true).ToList().Select(x => x.Id).ToList();
            Random rand = new Random();
            for (int i = 0; i < count; i++)
            {
                int countService = rand.Next(1, 10);
                var serviceContracts = connect.ConnectToMongo<Service>("services").Find(_ => true).ToList();
                List<ServiceContract> temp = new();
                for (int j = 0; j < countService; j++)
                {
                    var te = serviceContracts[rand.Next(0, serviceContracts.Count)];
                    if (!temp.Select(x => x.Service).ToList().Contains(te))
                    {
                        temp.Add(new()
                        {
                            Service = te,
                            Price = te.Price
                        });
                    }
                }
                var newContract = Contract.Create(connect, new()
                {
                    Car = carIds[rand.Next(0, carIds.Count)],
                    Client = clientIds[rand.Next(0, clientIds.Count)],
                    Employee = employeeIds[rand.Next(0, employeeIds.Count)],
                    Cost = 1.1 * temp.Sum(x => x.Price)
                });
                newContract.Services = temp;
                if (newContract == null)
                {
                    continue;
                }
                contractsCollection.InsertOne(newContract);
            }
            return 1L;
        }

        public ContractViewModel? Delete(ContractBindingModel model)
        {
            var contractsCollection = connect.ConnectToMongo<Contract>("contracts");
            contractsCollection.DeleteOne(x => x.Id == model.MId);
            return new();
        }

        public ContractViewModel? GetElement(ContractSearchModel model)
        {
            if (string.IsNullOrEmpty(model.MId))
            {
                return null;
            }
            var contractsCollection = connect.ConnectToMongo<Contract>("contracts");
            return contractsCollection.Find(x => !string.IsNullOrEmpty(model.MId) && x.Id == model.MId)
                                    .FirstOrDefault()
                                    ?.GetViewModel;
        }

        public List<ContractViewModel> GetFilteredList(ContractSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            var contractsCollection = connect.ConnectToMongo<Contract>("contracts");
            return contractsCollection.Find(x => !string.IsNullOrEmpty(model.MId) && x.Id == model.MId)
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public List<ContractViewModel> GetFullList()
        {
            var contractsCollection = connect.ConnectToMongo<Contract>("contracts");
            return contractsCollection.Find(_ => true)
                                 .ToList()
                                 .Select(x => x.GetViewModel)
                                 .ToList();
        }

        public ContractViewModel? Insert(ContractBindingModel model)
        {
            var contractsCollection = connect.ConnectToMongo<Contract>("contracts");
            var newContract = Contract.Create(connect, model);
            if (newContract == null)
            {
                return null;
            }
            contractsCollection.InsertOne(newContract);
            return newContract.GetViewModel;
        }

        public bool InsertMany(List<ContractViewModel> model)
        {
            var clientsCollection = connect.ConnectToMongo<Client>("clients");
            var carsCollection = connect.ConnectToMongo<Car>("cars");
            var employeesCollection = connect.ConnectToMongo<Employee>("employees");
            var servicesCollection = connect.ConnectToMongo<Service>("services");
            var contractsCollection = connect.ConnectToMongo<Contract>("contracts");
            List<Contract> models = new();
            foreach (var elem in model)
            {
                var bmodel = new ContractBindingModel();
                bmodel.Date = elem.Date;
                bmodel.Cost = elem.Cost;
                bmodel.Car = carsCollection.Find(x => x.Number == elem.CarNumber).FirstOrDefault().Id;
                bmodel.Client = clientsCollection.Find(x => x.Phone == elem.ClientPhone).FirstOrDefault().Id;
                bmodel.Employee = employeesCollection.Find(x => x.Phone == elem.EmployeePhone).FirstOrDefault().Id;
                foreach (var contract in elem.ServiceContracts)
                {
                    var service = servicesCollection.Find(x => x.Title == contract.Value.Item1.Title).FirstOrDefault();
                    if (bmodel.MServiceContracts.ContainsKey(service.Id))
                    {
                        bmodel.MServiceContracts[service.Id] = (service as IServiceModel, contract.Value.Item2);
                    }
                    else
                    {
                        bmodel.MServiceContracts[service.Id] = (service as IServiceModel, contract.Value.Item2);
                    }
                }
                models.Add(Contract.Create(connect, bmodel));
            }
            Stopwatch stopwatch = new();
            stopwatch.Start();
            contractsCollection.InsertMany(models);
            stopwatch.Stop();
            return true;
        }

        public ContractViewModel? Update(ContractBindingModel model)
        {
            var contractsCollection = connect.ConnectToMongo<Contract>("contracts");
            var contract = contractsCollection.Find(x => x.Id == model.MId).FirstOrDefault();
            if (contract == null)
            {
                return null;
            }
            contract.Update(model);
            var filter = Builders<Contract>.Filter.Eq("Id", model.MId);
            contractsCollection.ReplaceOne(filter, contract, new ReplaceOptions { IsUpsert = true });
            return contract.GetViewModel;
        }
    }
}
