using CarServiceDataModels.Models;

namespace CarServiceContracts.BindingModels
{
    public class CarBindingModel : ICarModel
    {
        public int Id { get; set; }

        public string? MId { get; set; }
        public string Number { get; set; } = string.Empty;
    }
}