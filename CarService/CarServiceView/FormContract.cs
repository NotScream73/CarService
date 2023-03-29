using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;
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

		public FormContract(IContractLogic logic, IClientLogic clientLogic, IEmployeeLogic employeeLogic, ICarLogic carLogic)
		{
			InitializeComponent();
			_logic = logic;
			_clientLogic = clientLogic;
			_employeeLogic = employeeLogic;
			_carLogic = carLogic;
			_contractServices = new Dictionary<int, (IServiceModel, double)>();
		}

		private void FormContract_Load(object sender, EventArgs e)
		{
			if (_id.HasValue)
			{
				try
				{
					var view = _logic.ReadElement(new ContractSearchModel
					{
						Id = _id.Value
					});
					if (view != null)
					{
						dateTimePicker1.Value = view.Date;
						textBoxPrice.Text = view.Cost.ToString();
						_contractServices = view.ServiceContracts ?? new Dictionary<int, (IServiceModel, double)>();
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
					comboBoxClient.DisplayMember = "Surname";
					comboBoxClient.ValueMember = "Id";
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
					comboBoxEmployee.DisplayMember = "Surname";
					comboBoxEmployee.ValueMember = "Id";
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
					comboBoxCar.DisplayMember = "Number";
					comboBoxCar.ValueMember = "Id";
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
				if (_contractServices != null)
				{
					dataGridView.Rows.Clear();
					foreach (var element in _contractServices)
					{
						dataGridView.Rows.Add(new object[] { element.Key, element.Value.Item1.Title, element.Value.Item2 });
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
				if (form.ShowDialog() == DialogResult.OK)
				{
					if (form.ServiceModel == null)
					{
						return;
					}
					if (_contractServices.ContainsKey(form.Id))
					{
						_contractServices[form.Id] = (form.ServiceModel, form.Price);
					}
					else
					{
						_contractServices.Add(form.Id, (form.ServiceModel, form.Price));
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
					form.Id = id;
					form.Price = _contractServices[id].Item2;
					if (form.ShowDialog() == DialogResult.OK)
					{
						if (form.ServiceModel == null)
						{
							return;
						}
						_contractServices[form.Id] = (form.ServiceModel, form.Price);
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
						_contractServices?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
			if (_contractServices == null || _contractServices.Count == 0)
			{
				MessageBox.Show("Выберите услуги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
				var model = new ContractBindingModel
				{
					Id = _id ?? 0,
					Date = dateTimePicker1.Value,
					CarId = Convert.ToInt32(comboBoxCar.SelectedValue),
					ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
					EmployeeId = Convert.ToInt32(comboBoxEmployee.SelectedValue),
					Cost = Convert.ToDouble(textBoxPrice.Text),
					ServiceContracts = _contractServices
				};
				var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
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
			foreach (var elem in _contractServices)
			{
				price += elem.Value.Item2;
			}
			return Math.Round(price * 1.1, 2);
		}
	}
}
