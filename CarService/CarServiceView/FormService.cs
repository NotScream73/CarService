using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;

namespace CarServiceView
{
    public partial class FormService : Form
    {
        private readonly IServiceLogic _logic;
        private int? _id;
        public int Id { set { _id = value; } }

        private string? _mid;
        public string MId { set { _mid = value; } }
        public FormService(IServiceLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormService_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    var view = _logic.ReadElement(new ServiceSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        textBoxPrice.Text = view.Price.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (!string.IsNullOrEmpty(_mid))
            {
                try
                {
                    var view = _logic.ReadElement(new ServiceSearchModel
                    {
                        Id = _id.Value,
                        MId = _mid
                    });
                    if (view != null)
                    {
                        textBoxTitle.Text = view.Title;
                        textBoxPrice.Text = view.Price.ToString();
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
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                MessageBox.Show("Заполните название услуги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Укажите стоимость услуги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var model = new ServiceBindingModel
                {
                    Id = _id ?? 0,
                    MId = _mid,
                    Title = textBoxTitle.Text,
                    Price = Convert.ToDouble(textBoxPrice.Text)
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
