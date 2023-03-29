using CarServiceBusinessLogic.BusinessLogics;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.StoragesContracts;
using CarServiceDatabaseImplement.Implements;
using ClientServiceContracts.StoragesContracts;
using Microsoft.Extensions.DependencyInjection;

namespace CarServiceView
{
	internal static class Program
	{
		private static ServiceProvider? _serviceProvider;
		public static ServiceProvider? ServiceProvider => _serviceProvider;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			var services = new ServiceCollection();
			ConfigureServices(services);
			_serviceProvider = services.BuildServiceProvider();
			Application.Run(_serviceProvider.GetRequiredService<FormContracts>());
		}
		private static void ConfigureServices(ServiceCollection services)
		{
			services.AddTransient<ICarStorage, CarStorage>();
			services.AddTransient<IClientStorage, ClientStorage>();
			services.AddTransient<IContractStorage, ContractStorage>();
			services.AddTransient<IEmployeeStorage, EmployeeStorage>();
			services.AddTransient<IServiceStorage, ServiceStorage>();

			services.AddTransient<ICarLogic, CarLogic>();
			services.AddTransient<IClientLogic, ClientLogic>();
			services.AddTransient<IContractLogic, ContractLogic>();
			services.AddTransient<IEmployeeLogic, EmployeeLogic>();
			services.AddTransient<IServiceLogic, ServiceLogic>();

			services.AddTransient<FormCars>();
			services.AddTransient<FormCar>();
			services.AddTransient<FormClients>();
			services.AddTransient<FormClient>();
			services.AddTransient<FormEmployees>();
			services.AddTransient<FormEmployee>();
			services.AddTransient<FormService>();
			services.AddTransient<FormServices>();
			services.AddTransient<FormContracts>();
			services.AddTransient<FormContract>();
			services.AddTransient<FormContractService>();
			services.AddTransient<FormTest>();
			services.AddTransient<FormReport>();
		}
	}
}