using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarServiceMongoDBImplement.Models
{
    public class Service
    {/// <summary>
     /// Уникальный идентификатор машины
     /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// Название услуги
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Стоимость услуги
        /// </summary>
        public double Price { get; set; }

        public static Service? Create(ServiceBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Service()
            {
                Id = model.MId,
                Title = model.Title,
                Price = model.Price
            };
        }

        public Service Create(ServiceViewModel model)
        {
            return new Service
            {
                Id = model.MId,
                Title = model.Title,
                Price = model.Price
            };
        }

        public void Update(ServiceBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Title = model.Title;
            Price = model.Price;
        }

        public ServiceViewModel GetViewModel => new()
        {
            MId = Id,
            Title = Title,
            Price = Price
        };
    }
}
