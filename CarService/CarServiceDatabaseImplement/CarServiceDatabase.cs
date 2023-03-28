using CarServiceDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CarServiceDatabaseImplement
{
	public class CarServiceDatabase : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				string connectString = ConfigurationManager.AppSettings["connect"];
				optionsBuilder.UseNpgsql(connectString);
			}
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ContractService>()
				.HasKey(c => new { c.ServiceId, c.ContractId });
		}
		public virtual DbSet<Car> Cars { set; get; }

		public virtual DbSet<Client> Clients { set; get; }

		public virtual DbSet<Service> Services { set; get; }

		public virtual DbSet<Employee> Employees { get; set; }

		public virtual DbSet<Contract> Contracts { set; get; }

		public virtual DbSet<ContractService> ContractServices { set; get; }
	}
}