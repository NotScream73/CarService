using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceDatabaseImplement.Models
{
    /// <summary>
    /// Таблица клиентов
    /// </summary>
    public partial class Client : IClientModel
    {
        /// <summary>
        /// Уникальный идентификатор клиента
        /// </summary>
        public int Id { get; set; }

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
        [ForeignKey("ClientId")]
        public virtual List<Contract> Contracts { get; set; } = new();
        public static Client Create(ClientBindingModel model)
        {
            return new Client()
            {
                Id = model.Id,
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
            Id = Id,
            Name = Name,
            Surname = Surname,
            Patronymic = Patronymic,
            Phone = Phone
        };
    }
}