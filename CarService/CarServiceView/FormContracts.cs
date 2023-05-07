using CarServiceBusinessLogic.BusinessLogics;
using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using System.Diagnostics;

namespace CarServiceView
{
    public partial class FormContracts : Form
    {
        private IContractLogic _logic;
        private bool _mongo;
        public FormContracts(IContractLogic contractLogic)
        {
            InitializeComponent();
            _logic = contractLogic;
        }

        private void FormContracts_Load(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void LoadData()
        {
            try
            {
                Stopwatch stopwatch = new();
                stopwatch.Start();
                var list = _logic.ReadList(null);
                stopwatch.Stop();
                MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    if (list.Any(x => !string.IsNullOrEmpty(x.MId)))
                    {
                        dataGridView.Columns["Id"].Visible = false;
                        dataGridView.Columns["MId"].Visible = true;
                    }
                    else
                    {
                        dataGridView.Columns["MId"].Visible = false;
                        dataGridView.Columns["Id"].Visible = true;
                    }
                    dataGridView.Columns["ClientId"].Visible = false;
                    dataGridView.Columns["ClientPhone"].Visible = false;
                    dataGridView.Columns["EmployeePhone"].Visible = false;
                    dataGridView.Columns["EmployeeId"].Visible = false;
                    dataGridView.Columns["CarId"].Visible = false;
                    dataGridView.Columns["ServiceContracts"].Visible = false;
                    dataGridView.Columns["MServiceContracts"].Visible = false;
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormCars));
            if (service is FormCars form)
            {
                form.ShowDialog();
            }
        }

        private void ClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormClients));
            if (service is FormClients form)
            {
                form.ShowDialog();
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormContract));
            if (service is FormContract form)
            {
                form.Mongo = _mongo;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormContract));
                if (service is FormContract form)
                {
                    form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    try
                    {
                        if (!_logic.Delete(new ContractBindingModel
                        {
                            Id = id
                        }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void EmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormEmployees));
            if (service is FormEmployees form)
            {
                form.ShowDialog();
            }
        }

        private void ServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormServices));
            if (service is FormServices form)
            {
                form.ShowDialog();
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormTest));
            if (service is FormTest form)
            {
                form.ShowDialog();
            }
        }

        private void отчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReport));
            if (service is FormReport form)
            {
                form.ShowDialog();
            }
        }
        private void buttonPostgres_Click(object sender, EventArgs e)
        {
            _mongo = false;
            Program.ConnectPostgres();
            _logic = Program.ServiceProvider.GetService(typeof(IContractLogic)) as ContractLogic;
        }

        private void buttonMongo_Click(object sender, EventArgs e)
        {
            _mongo = true;
            Program.ConnectMongo();
            _logic = Program.ServiceProvider.GetService(typeof(IContractLogic)) as ContractLogic;
        }

        private void buttonTransferData_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormTransferData));
            if (service is FormTransferData form)
            {
                form.ShowDialog();
            }
        }
    }
}
