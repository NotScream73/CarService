using CarServiceContracts.BusinessLogicsContracts;

namespace CarServiceView
{
	public partial class FormTest : Form
	{
		private readonly IClientLogic _clientLogic;
		private readonly IEmployeeLogic _employeeLogic;
		private readonly IServiceLogic _serviceLogic;
		private readonly ICarLogic _carLogic;
		private readonly IContractLogic _contractLogic;

		public FormTest(IClientLogic clientLogic, IEmployeeLogic employeeLogic, IServiceLogic serviceLogic, ICarLogic carLogic, IContractLogic contractLogic)
		{
			InitializeComponent();
			_clientLogic = clientLogic;
			_employeeLogic = employeeLogic;
			_serviceLogic = serviceLogic;
			_carLogic = carLogic;
			_contractLogic = contractLogic;
		}

		private void buttonClient_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBoxClientCount.Text) && int.Parse(textBoxClientCount.Text) > 0)
			{
				try
				{
					var operationResult = _clientLogic.AddTest(int.Parse(textBoxClientCount.Text));
					MessageBox.Show("Сохранение прошло успешно, заняло времени: " + operationResult, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				   MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Укажите количество клиентов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonEmployee_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBoxEmployeeCount.Text) && int.Parse(textBoxEmployeeCount.Text) > 0)
			{
				try
				{
					var operationResult = _employeeLogic.AddTest(int.Parse(textBoxEmployeeCount.Text));
					MessageBox.Show("Сохранение прошло успешно, заняло времени: " + operationResult, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				   MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Укажите количество сотрудников", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonService_Click(object sender, EventArgs e)
		{
			try
			{
				var operationResult = _serviceLogic.AddTest();
				MessageBox.Show("Сохранение прошло успешно, заняло времени: " + operationResult, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}

		private void buttonCar_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBoxCarCount.Text) && int.Parse(textBoxCarCount.Text) > 0)
			{
				try
				{
					var operationResult = _carLogic.AddTest(int.Parse(textBoxCarCount.Text));
					MessageBox.Show("Сохранение прошло успешно, заняло времени: " + operationResult, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				   MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Укажите количество машин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void buttonContract_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textBoxContractCount.Text) && int.Parse(textBoxContractCount.Text) > 0)
			{
				try
				{
					var operationResult = _contractLogic.AddTest(int.Parse(textBoxContractCount.Text));
					MessageBox.Show("Сохранение прошло успешно, заняло времени: " + operationResult, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
				   MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Укажите количество контрактов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
