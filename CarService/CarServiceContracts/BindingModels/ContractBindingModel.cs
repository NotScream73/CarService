using CarServiceDataModels.Models;

namespace CarServiceContracts.BindingModels
{
    public class ContractBindingModel : IContractModel
    {
        public int Id { get; set; }
        public string? MId { get; set; }

        public double Cost { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int EmployeeId { get; set; }

        public int ClientId { get; set; }

        public int CarId { get; set; }
        public string Employee { get; set; }
        public string Client { get; set; }
        public string Car { get; set; }
        public Dictionary<int, (IServiceModel, double)> ServiceContracts { get; set; } = new();
        public Dictionary<string, (IServiceModel, double)> MServiceContracts { get; set; } = new();
    }
}