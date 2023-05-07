using System.ComponentModel;

namespace CarServiceContracts.ViewModels
{
    public class ReportViewModel
    {
        [DisplayName("Название услуги")]
        public string Title { get; set; } = string.Empty;
        [DisplayName("Общая стоимость")]
        public double TotalCount { get; set; }
    }
}
