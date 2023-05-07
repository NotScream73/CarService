namespace CarServiceMongoDBImplement.Models
{
    public class ServiceContract
    {

        /// <summary>
        /// Идентификатор услуги
        /// </summary>
        public Service Service { get; set; }

        /// <summary>
        /// Стоимость услуги на момент офорлмения договора
        /// </summary>
        public double Price { get; set; }
    }
}
