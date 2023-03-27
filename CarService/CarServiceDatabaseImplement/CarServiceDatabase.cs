using CarServiceDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceDatabaseImplement
{
	public class CarServiceDatabase : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JS88CIM\SQLEXPRESS;Initial Catalog=IceCreamShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
			}
			base.OnConfiguring(optionsBuilder);
		}

		public virtual DbSet<Car> Cars { set; get; }

		public virtual DbSet<Client> Clients { set; get; }

		public virtual DbSet<Service> Services { set; get; }

		public virtual DbSet<Employee> Employees { get; set; }

		public virtual DbSet<Contract> Contracts { set; get; }

		public virtual DbSet<ContractService> ContractServices { set; get; }
	}
}