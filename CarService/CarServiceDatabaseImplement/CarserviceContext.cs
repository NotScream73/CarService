using System;
using System.Collections.Generic;
using System.Configuration;
using CarServiceDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceDatabaseImplement
{
    public partial class CarserviceContext : DbContext
	{
		public CarserviceContext()
		{
		}

		public CarserviceContext(DbContextOptions<CarserviceContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Car> Cars { get; set; }

		public virtual DbSet<Client> Clients { get; set; }

		public virtual DbSet<Contract> Contracts { get; set; }

		public virtual DbSet<Employee> Employees { get; set; }

		public virtual DbSet<Service> Services { get; set; }

		public virtual DbSet<ServiceContract> ServiceContracts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectString = ConfigurationManager.AppSettings["connect"]!;
			optionsBuilder.UseNpgsql(connectString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Car>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("car_pkey");

				entity.ToTable("cars", tb => tb.HasComment("Таблица машин"));

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasComment("Уникальный идентификатор машины")
					.HasColumnName("id");
				entity.Property(e => e.Number)
					.HasMaxLength(9)
					.HasComment("Номер машины")
					.HasColumnName("number");
			});

			modelBuilder.Entity<Client>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("client_pkey");

				entity.ToTable("clients", tb => tb.HasComment("Таблица клиентов"));

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasComment("Уникальный идентификатор клиента")
					.HasColumnName("id");
				entity.Property(e => e.Name)
					.HasMaxLength(255)
					.HasComment("Имя клиента")
					.HasColumnName("name");
				entity.Property(e => e.Patronymic)
					.HasMaxLength(255)
					.HasDefaultValueSql("'неуказано'::character varying")
					.HasComment("Отчество клиента")
					.HasColumnName("patronymic");
				entity.Property(e => e.Phone)
					.HasMaxLength(11)
					.HasComment("Номер телефона клиента")
					.HasColumnName("phone");
				entity.Property(e => e.Surname)
					.HasMaxLength(255)
					.HasComment("Фамилия клиента")
					.HasColumnName("surname");
			});

			modelBuilder.Entity<Contract>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("contract_pkey");

				entity.ToTable("contracts", tb => tb.HasComment("Таблица договоров"));

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasComment("Уникальный идентификатор договора")
					.HasColumnName("id");
				entity.Property(e => e.CarId)
					.HasComment("Идентификатор машины")
					.HasColumnName("carId");
				entity.Property(e => e.ClientId)
					.HasComment("Идентификатор клиента")
					.HasColumnName("clientId");
				entity.Property(e => e.Cost)
					.HasPrecision(19, 2)
					.HasComment("Общая стоимость оказанных услуг")
					.HasColumnName("cost");
				entity.Property(e => e.Date)
					.HasComment("Дата оформления договора")
					.HasColumnType("timestamp without time zone")
					.HasColumnName("date");
				entity.Property(e => e.EmployeeId)
					.HasComment("Идентификатор сотрудника")
					.HasColumnName("employeeId");

				entity.HasOne(d => d.Car).WithMany(p => p.Contracts)
					.HasForeignKey(d => d.CarId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("carfk");

				entity.HasOne(d => d.Client).WithMany(p => p.Contracts)
					.HasForeignKey(d => d.ClientId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("clientfk");

				entity.HasOne(d => d.Employee).WithMany(p => p.Contracts)
					.HasForeignKey(d => d.EmployeeId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("employeefk");
			});

			modelBuilder.Entity<Employee>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("employee_pkey");

				entity.ToTable("employees", tb => tb.HasComment("Таблица сотрудников"));

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasComment("Уникальный идентификатор сотрудника")
					.HasColumnName("id");
				entity.Property(e => e.Name)
					.HasMaxLength(255)
					.HasComment("Имя сотрудника")
					.HasColumnName("name");
				entity.Property(e => e.Patronymic)
					.HasMaxLength(255)
					.HasDefaultValueSql("'неуказано'::character varying")
					.HasComment("Отчество сотрудника")
					.HasColumnName("patronymic");
				entity.Property(e => e.Phone)
					.HasMaxLength(11)
					.HasComment("Номер телефона сотрудника")
					.HasColumnName("phone");
				entity.Property(e => e.Surname)
					.HasMaxLength(255)
					.HasComment("Фамилия сотрудника")
					.HasColumnName("surname");
			});

			modelBuilder.Entity<Service>(entity =>
			{
				entity.HasKey(e => e.Id).HasName("service_pkey");

				entity.ToTable("services", tb => tb.HasComment("Таблица услуг"));

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasComment("Уникальный идентификатор услуги")
					.HasColumnName("id");
				entity.Property(e => e.Price)
					.HasPrecision(19, 2)
					.HasComment("Стоимость услуги")
					.HasColumnName("price");
				entity.Property(e => e.Title)
					.HasMaxLength(255)
					.HasComment("Название услуги")
					.HasColumnName("title");
			});

			modelBuilder.Entity<ServiceContract>(entity =>
			{
				entity.HasKey(e => new { e.ServiceId, e.ContractId }).HasName("serviccontract");

				entity.ToTable("service_contract", tb => tb.HasComment("Таблица оказанных услуг"));

				entity.Property(e => e.ServiceId)
					.HasComment("Идентификатор услуги")
					.HasColumnName("serviceId");
				entity.Property(e => e.ContractId)
					.HasComment("Идентификатор договора")
					.HasColumnName("contractId");
				entity.Property(e => e.Price)
					.HasPrecision(19, 2)
					.HasComment("Стоимость услуги на момент офорлмения договора")
					.HasColumnName("price");

				entity.HasOne(d => d.Contract).WithMany(p => p.Services)
					.HasForeignKey(d => d.ContractId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("contractfk");

				entity.HasOne(d => d.Service).WithMany(p => p.ContractServices)
					.HasForeignKey(d => d.ServiceId)
					.OnDelete(DeleteBehavior.Restrict)
					.HasConstraintName("servicefk");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}

}