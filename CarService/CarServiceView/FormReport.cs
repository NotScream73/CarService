using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;

namespace CarServiceView
{
	public partial class FormReport : Form
	{
		private readonly IServiceLogic _logic;

		public FormReport(IServiceLogic logic)
		{
			InitializeComponent();
			_logic = logic;
		}

		private void FormReport_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				var list = _logic.GetMostPopular();
				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ButtonRef_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}
