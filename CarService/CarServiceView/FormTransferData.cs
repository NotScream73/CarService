using CarServiceBusinessLogic.BusinessLogics;
using CarServiceContracts.BusinessLogicsContracts;

namespace CarServiceView
{
    public partial class FormTransferData : Form
    {
        private IContractLogic _contractLogic;
        private IServiceLogic _serviceLogic;
        private ICarLogic _carLogic;
        private IEmployeeLogic _employeeLogic;
        private IClientLogic _clientLogic;
        public FormTransferData(IContractLogic contractLogic, ICarLogic carLogic, IClientLogic clientLogic, IEmployeeLogic employeeLogic, IServiceLogic serviceLogic)
        {
            InitializeComponent();
            _contractLogic = contractLogic;
            _carLogic = carLogic;
            _employeeLogic = employeeLogic;
            _clientLogic = clientLogic;
            _serviceLogic = serviceLogic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.ConnectPostgres();
            _contractLogic = Program.ServiceProvider.GetService(typeof(IContractLogic)) as ContractLogic;
            _carLogic = Program.ServiceProvider.GetService(typeof(ICarLogic)) as CarLogic;
            _employeeLogic = Program.ServiceProvider.GetService(typeof(IEmployeeLogic)) as EmployeeLogic;
            _clientLogic = Program.ServiceProvider.GetService(typeof(IClientLogic)) as ClientLogic;
            _serviceLogic = Program.ServiceProvider.GetService(typeof(IServiceLogic)) as ServiceLogic;

            var carlist = _carLogic.ReadList(null);
            var clientlist = _clientLogic.ReadList(null);
            var employeelist = _employeeLogic.ReadList(null);
            var servicelist = _serviceLogic.ReadList(null);
            var contractlist = _contractLogic.ReadList(null);

            Program.ConnectMongo();
            _contractLogic = Program.ServiceProvider.GetService(typeof(IContractLogic)) as ContractLogic;
            _carLogic = Program.ServiceProvider.GetService(typeof(ICarLogic)) as CarLogic;
            _employeeLogic = Program.ServiceProvider.GetService(typeof(IEmployeeLogic)) as EmployeeLogic;
            _clientLogic = Program.ServiceProvider.GetService(typeof(IClientLogic)) as ClientLogic;
            _serviceLogic = Program.ServiceProvider.GetService(typeof(IServiceLogic)) as ServiceLogic;

            _carLogic.AddAll(carlist);
            _employeeLogic.AddAll(employeelist);
            _clientLogic.AddAll(clientlist);
            _serviceLogic.AddAll(servicelist);
            _contractLogic.AddAll(contractlist);
            MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Program.ConnectPostgres();
        }
    }
}