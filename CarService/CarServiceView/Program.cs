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
        public static ServiceCollection _serviceCollection;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            _serviceCollection = new ServiceCollection();
            ConfigureServices(_serviceCollection);
            _serviceProvider = _serviceCollection.BuildServiceProvider();
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
            services.AddTransient<FormTransferData>();
        }

        public static void ConnectPostgres()
        {
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ICarStorage)));
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IClientStorage)));
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IContractStorage)));
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IEmployeeStorage)));
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IServiceStorage)));
            _serviceCollection.AddTransient<ICarStorage, CarStorage>();
            _serviceCollection.AddTransient<IClientStorage, ClientStorage>();
            _serviceCollection.AddTransient<IContractStorage, ContractStorage>();
            _serviceCollection.AddTransient<IEmployeeStorage, EmployeeStorage>();
            _serviceCollection.AddTransient<IServiceStorage, ServiceStorage>();
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }
        public static void ConnectMongo()
        {
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ICarStorage)));
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IClientStorage)));
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IContractStorage)));
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IEmployeeStorage)));
            _serviceCollection.Remove(_serviceCollection.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IServiceStorage)));
            _serviceCollection.AddTransient<ICarStorage, CarServiceMongoDBImplement.Implements.CarStorage>();
            _serviceCollection.AddTransient<IClientStorage, CarServiceMongoDBImplement.Implements.ClientStorage>();
            _serviceCollection.AddTransient<IContractStorage, CarServiceMongoDBImplement.Implements.ContractStorage>();
            _serviceCollection.AddTransient<IEmployeeStorage, CarServiceMongoDBImplement.Implements.EmployeeStorage>();
            _serviceCollection.AddTransient<IServiceStorage, CarServiceMongoDBImplement.Implements.ServiceStorage>();
            _serviceProvider = _serviceCollection.BuildServiceProvider();
        }
    }
}