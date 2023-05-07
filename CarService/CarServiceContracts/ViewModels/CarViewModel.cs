using CarServiceDataModels.Models;
using System.ComponentModel;

namespace CarServiceContracts.ViewModels
{
    public class CarViewModel : ICarModel
    {
        public int Id { get; set; }
        public string? MId { get; set; }
        [DisplayName("Номер машины")]
        public string Number { get; set; } = string.Empty;
    }
}