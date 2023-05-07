using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;

namespace CarServiceView
{
    public partial class FormContract : Form
    {
        private readonly IContractLogic _logic;
        private readonly IClientLogic _clientLogic;
        private readonly IEmployeeLogic _employeeLogic;
        private readonly ICarLogic _carLogic;
        private int? _id;
        private Dictionary<int, (IServiceModel, double)> _contractServices;
        public int Id { set { _id = value; } }
        public bool Mongo { get; set; }
        private string? _mid;
        private Dictionary<string, (IServiceModel, double)> _mcontractServices;
        public string MId { set { _mid = value; } }
        public FormContract(IContractLogic logic, IClientLogic clientLogic, IEmployeeLogic employeeLogic, ICarLogic carLogic)
        {
            InitializeComponent();
            _logic = logic;
            _clientLogic = clientLogic;
            _employeeLogic = employeeLogic;
            _carLogic = carLogic;
            _contractServices = new Dictionary<int, (IServiceModel, double)>();
            _mcontractServices = new Dictionary<string, (IServiceModel, double)>();
        }

        private void FormContract_Load(object sender, EventArgs e)
        {
            if (_id.HasValue || !string.IsNullOrEmpty(_mid))
            {
                try
                {
                    ContractViewModel view;
                    if (Mongo)
                    {
                        view = _logic.ReadElement(new ContractSearchModel
                        {
                            MId = _mid
                        });
                    }
                    else
                    {
                        view = _logic.ReadElement(new ContractSearchModel
                        {
                            Id = _id.Value
                        });
                    }
                    if (view != null)
                    {
                        dateTimePicker1.Value = view.Date;
                        textBoxPrice.Text = view.Cost.ToString();
                        if (Mongo)
                        {
                            _mcontractServices = view.MServiceContracts ?? new Dictionary<string, (IServiceModel, double)>();
                        }
                        else
                        {
                            _contractServices = view.ServiceContracts ?? new Dictionary<int, (IServiceModel, double)>();
                        }
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            try
            {
                var list = _clientLogic.ReadList(null);
                if (list != null)
                {
                    if (list.Any(x => !string.IsNullOrEmpty(x.MId)))
                    {
                        comboBoxClient.ValueMember = "MId";
                    }
                    else
                    {
                        comboBoxClient.ValueMember = "Id";
                    }
                    comboBoxClient.DisplayMember = "Surname";
                    comboBoxClient.DataSource = list;
                    comboBoxClient.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                var list = _employeeLogic.ReadList(null);
                if (list != null)
                {
                    if (list.Any(x => !string.IsNullOrEmpty(x.MId)))
                    {
                        comboBoxEmployee.ValueMember = "MId";
                    }
                    else
                    {
                        comboBoxEmployee.ValueMember = "Id";
                    }
                    comboBoxEmployee.DisplayMember = "Surname";
                    comboBoxEmployee.DataSource = list;
                    comboBoxEmployee.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                var list = _carLogic.ReadList(null);
                if (list != null)
                {
                    if (list.Any(x => !string.IsNullOrEmpty(x.MId)))
                    {
                        comboBoxCar.ValueMember = "MId";
                    }
                    else
                    {
                        comboBoxCar.ValueMember = "Id";
                    }
                    comboBoxCar.DisplayMember = "Number";
                    comboBoxCar.DataSource = list;
                    comboBoxCar.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                if (_contractServices != null || _mcontractServices != null)
                {
                    dataGridView.Rows.Clear();
                    if (Mongo)
                    {
                        foreach (var element in _mcontractServices)
                        {
                            dataGridView.Rows.Add(new object[] { element.Key, element.Value.Item1.Title, element.Value.Item2 });
                        }
                    }
                    else
                    {
                        foreach (var element in _contractServices)
                        {
                            dataGridView.Rows.Add(new object[] { element.Key, element.Value.Item1.Title, element.Value.Item2 });
                        }
                    }
                    textBoxPrice.Text = CalcPrice().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormContractService));
            if (service is FormContractService form)
            {
                form.Mongo = Mongo;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ServiceModel == null)
                    {
                        return;
                    }
                    if (Mongo)
                    {
                        if (_mcontractServices.ContainsKey(form.MId))
                        {
                            _mcontractServices[form.MId] = (form.ServiceModel, form.Price);
                        }
                        else
                        {
                            _mcontractServices.Add(form.MId, (form.ServiceModel, form.Price));
                        }
                    }
                    else
                    {
                        if (_contractServices.ContainsKey(form.Id))
                        {
                            _contractServices[form.Id] = (form.ServiceModel, form.Price);
                        }
                        else
                        {
                            _contractServices.Add(form.Id, (form.ServiceModel, form.Price));
                        }
                    }
                    LoadData();
                }
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormContractService));
                if (service is FormContractService form)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    string mid = Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                    form.MId = mid;
                    form.Mongo = Mongo;
                    if (Mongo)
                    {
                        form.Price = _mcontractServices[mid].Item2;
                    }
                    else
                    {
                        form.Price = _contractServices[id].Item2;
                    }
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.ServiceModel == null)
                        {
                            return;
                        }
                        if (Mongo)
                        {
                            _mcontractServices[form.MId] = (form.ServiceModel, form.Price);
                        }
                        else
                        {
                            _contractServices[form.Id] = (form.ServiceModel, form.Price);
                        }
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
                    try
                    {
                        if (Mongo)
                        {
                            _mcontractServices?.Remove(Convert.ToString(dataGridView.SelectedRows[0].Cells[0].Value));
                        }
                        else
                        {
                            _contractServices?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Выберите дату", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxEmployee.SelectedValue == null)
            {
                MessageBox.Show("Выберите сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCar.SelectedValue == null)
            {
                MessageBox.Show("Выберите машину", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ContractBindingModel model;
                if (!Mongo)
                {
                    model = new ContractBindingModel
                    {
                        Id = _id ?? 0,
                        Date = dateTimePicker1.Value,
                        CarId = Convert.ToInt32(comboBoxCar.SelectedValue),
                        ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
                        EmployeeId = Convert.ToInt32(comboBoxEmployee.SelectedValue),
                        Cost = Convert.ToDouble(textBoxPrice.Text),
                        ServiceContracts = _contractServices ?? null
                    };
                }
                else
                {
                    model = new ContractBindingModel
                    {
                        MId = _mid ?? string.Empty,
                        Date = dateTimePicker1.Value,
                        Car = Convert.ToString(comboBoxCar.SelectedValue),
                        Client = Convert.ToString(comboBoxClient.SelectedValue),
                        Employee = Convert.ToString(comboBoxEmployee.SelectedValue),
                        Cost = Convert.ToDouble(textBoxPrice.Text),
                        MServiceContracts = _mcontractServices ?? null
                    };
                }
                bool operationResult;
                if (Mongo)
                {
                    operationResult = !string.IsNullOrEmpty(_mid) ? _logic.Update(model) : _logic.Create(model);
                }
                else
                {
                    operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
                }
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private double CalcPrice()
        {
            double price = 0;
            if (Mongo)
            {
                foreach (var elem in _mcontractServices)
                {
                    price += elem.Value.Item2;
                }
            }
            else
            {
                foreach (var elem in _contractServices)
                {
                    price += elem.Value.Item2;
                }
            }
            return Math.Round(price * 1.1, 2);
        }
    }
}
