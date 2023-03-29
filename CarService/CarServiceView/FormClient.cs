using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;

namespace CarServiceView
{
	public partial class FormClient : Form
	{
		private readonly IClientLogic _logic;
		private int? _id;
		public int Id { set { _id = value; } }

		public FormClient(IClientLogic logic)
		{
			InitializeComponent();
			_logic = logic;
		}

		private void FormClient_Load(object sender, EventArgs e)
		{
			if (_id.HasValue)
			{
				try
				{
					var view = _logic.ReadElement(new ClientSearchModel
					{
						Id = _id.Value
					});
					if (view != null)
					{
						textBoxName.Text = view.Name;
						textBoxSurname.Text = view.Surname;
						textBoxPatronymic.Text = view.Patronymic;
						textBoxPhone.Text = view.Phone;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxName.Text))
			{
				MessageBox.Show("Заполните имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(textBoxSurname.Text))
			{
				MessageBox.Show("Заполните фамилию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (string.IsNullOrEmpty(textBoxPhone.Text))
			{
				MessageBox.Show("Заполните номер телефона", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				var model = new ClientBindingModel
				{
					Id = _id ?? 0,
					Name = textBoxName.Text,
					Surname = textBoxSurname.Text,
					Patronymic = textBoxPatronymic.Text,
					Phone = textBoxPhone.Text
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
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
			   MessageBoxIcon.Error);
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}