using CarServiceDataModels.Models;
using System.ComponentModel;

namespace CarServiceContracts.ViewModels
{
    public class EmployeeViewModel : IEmployeeModel
    {
        public int Id { get; set; }
        public string MId { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Фамилия")]
        public string Surname { get; set; } = string.Empty;
        [DisplayName("Отчество")]
        public string Patronymic { get; set; } = string.Empty;
        [DisplayName("Номер телефона")]
        public string Phone { get; set; } = string.Empty;
    }
}