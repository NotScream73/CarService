namespace CarServiceDataModels.Models
{
    public interface IContractModel : IId
    {
        DateTime Date { get; }
        double Cost { get; }
        int EmployeeId { get; }
        int ClientId { get; }
        int CarId { get; }
        Dictionary<int, (IServiceModel, double)> ServiceContracts { get; }
    }
}