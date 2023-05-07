using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace CarServiceMongoDBImplement.Models
{
    public class Contract
    {
        /// <summary>
		/// Уникальный идентификатор договора
		/// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Дата оформления договора
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Общая стоимость оказанных услуг
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Идентификатор машины
        /// </summary>
        public Car Car { get; set; }
        public List<ServiceContract> Services { get; set; }
        public static Contract? Create(CarServiceConnect context, ContractBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Contract()
            {
                Id = model.MId,
                Date = model.Date,
                Cost = model.Cost,
                Employee = context.ConnectToMongo<Employee>("employees").Find(x => x.Id == model.Employee).FirstOrDefault(),
                Client = context.ConnectToMongo<Client>("clients").Find(x => x.Id == model.Client).FirstOrDefault(),
                Car = context.ConnectToMongo<Car>("cars").Find(x => x.Id == model.Car).FirstOrDefault(),
                Services = model.MServiceContracts.Select(x => new ServiceContract { Price = x.Value.Item2, Service = context.ConnectToMongo<Service>("services").Find(y => y.Id == x.Key).FirstOrDefault() }).ToList()
            };
        }

        public void Update(ContractBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            Cost = model.Cost;
        }

        public ContractViewModel GetViewModel => new()
        {
            MId = Id,
            ClientName = Client.Name,
            Cost = Cost,
            Date = Date,
            CarNumber = Car.Number,
            EmployeeName = Employee.Name,
            MServiceContracts = Services.ToDictionary(recPC => recPC.Service.Id, recPC => (recPC.Service as IServiceModel, recPC.Price))
        };
    }
}
