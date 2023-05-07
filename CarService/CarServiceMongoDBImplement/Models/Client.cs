using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarServiceMongoDBImplement.Models
{
    public class Client
    {
        /// <summary>
		/// Уникальный идентификатор клиента
		/// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Имя клиента
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Фамилия клиента
        /// </summary>
        public string Surname { get; set; } = null!;

        /// <summary>
        /// Отчество клиента
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Номер телефона клиента
        /// </summary>
        public string Phone { get; set; } = null!;
        public static Client Create(ClientBindingModel model)
        {
            return new Client()
            {
                Id = model.MId,
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                Phone = model.Phone
            };
        }

        public void Update(ClientBindingModel model)
        {
            Name = model.Name;
            Surname = model.Surname;
            Patronymic = model.Patronymic;
            Phone = model.Phone;
        }

        public ClientViewModel GetViewModel => new()
        {
            MId = Id,
            Name = Name,
            Surname = Surname,
            Patronymic = Patronymic,
            Phone = Phone
        };
    }
}
