using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarServiceMongoDBImplement.Models
{
    /// <summary>
	/// Таблица машин
	/// </summary>
	public class Car
    {
        /// <summary>
        /// Уникальный идентификатор машины
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// Номер машины
        /// </summary>
        public string Number { get; set; } = string.Empty;

        public static Car Create(CarBindingModel model)
        {
            return new Car()
            {
                Id = model.MId,
                Number = model.Number
            };
        }

        public void Update(CarBindingModel model)
        {
            Number = model.Number;
        }

        public CarViewModel GetViewModel => new()
        {
            MId = Id,
            Number = Number
        };
    }
}
