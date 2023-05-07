using CarServiceDataModels.Models;

namespace CarServiceContracts.BindingModels
{
    public class EmployeeBindingModel : IEmployeeModel
    {
        public int Id { get; set; }
        public string MId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Patronymic { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}