using CarServiceDataModels.Models;
using System.ComponentModel;

namespace CarServiceContracts.ViewModels
{
    public class ContractViewModel : IContractModel
    {
        [DisplayName("Номер")]
        public int Id { get; set; }
        [DisplayName("Номер")]
        public string? MId { get; set; }
        [DisplayName("Дата оформления")]
        public DateTime Date { get; set; } = DateTime.Now;
        [DisplayName("Стоимость")]
        public double Cost { get; set; }

        public int EmployeeId { get; set; }
        [DisplayName("Фамилия Сотрудника")]
        public string EmployeeName { get; set; } = string.Empty;

        public int ClientId { get; set; }
        [DisplayName("Фамилия Клиента")]
        public string ClientName { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty;
        public string EmployeePhone { get; set; } = string.Empty;

        public int CarId { get; set; }
        [DisplayName("Номер машины")]
        public string CarNumber { get; set; } = string.Empty;

        public Dictionary<int, (IServiceModel, double)> ServiceContracts { get; set; } = new();
        public Dictionary<string, (IServiceModel, double)> MServiceContracts { get; set; } = new();
    }
}