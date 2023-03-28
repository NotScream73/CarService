using System.ComponentModel.DataAnnotations;

namespace CarServiceDatabaseImplement.Models
{
	public class ContractService
	{
		public int ContractId { get; set; }

		public int ServiceId { get; set; }

		[Required]
		public double Price { get; set; }

		public virtual Service Service { get; set; } = new();

		public virtual Contract Contract { get; set; } = new();
	}
}