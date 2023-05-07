namespace CarServiceDatabaseImplement.Models
{
    /// <summary>
    /// Таблица оказанных услуг
    /// </summary>
    public partial class ServiceContract
    {
        /// <summary>
        /// Идентификатор услуги
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Идентификатор договора
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// Стоимость услуги на момент офорлмения договора
        /// </summary>
        public double Price { get; set; }

        public virtual Contract Contract { get; set; } = null!;

        public virtual Service Service { get; set; } = null!;
    }

}