using CarServiceContracts.BindingModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceDatabaseImplement.Models
{
    /// <summary>
    /// Таблица сотрудников
    /// </summary>
    public partial class Employee : IEmployeeModel
    {
        /// <summary>
        /// Уникальный идентификатор сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string Surname { get; set; } = null!;

        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Номер телефона сотрудника
        /// </summary>
        public string Phone { get; set; } = null!;
        [ForeignKey("EmployeeId")]
        public virtual List<Contract> Contracts { get; set; } = new();

        public static Employee Create(EmployeeBindingModel model)
        {
            return new Employee()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Patronymic = model.Patronymic,
                Phone = model.Phone
            };
        }

        public void Update(EmployeeBindingModel model)
        {
            Name = model.Name;
            Surname = model.Surname;
            Patronymic = model.Patronymic;
            Phone = model.Phone;
        }

        public EmployeeViewModel GetViewModel => new()
        {
            Id = Id,
            Name = Name,
            Surname = Surname,
            Patronymic = Patronymic,
            Phone = Phone
        };
    }
}