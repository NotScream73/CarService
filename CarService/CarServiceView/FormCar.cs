using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;

namespace CarServiceView
{
    public partial class FormCar : Form
    {
        private readonly ICarLogic _logic;
        private int? _id;
        public int Id { set { _id = value; } }

        private string? _mid;
        public string MId { set { _mid = value; } }
        public FormCar(ICarLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormCar_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_mid))
            {
                try
                {
                    var view = _logic.ReadElement(new CarSearchModel
                    {
                        MId = _mid
                    });
                    if (view != null)
                    {
                        textBoxNumber.Text = view.Number;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_id.HasValue)
            {
                try
                {
                    var view = _logic.ReadElement(new CarSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxNumber.Text = view.Number;
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
            if (string.IsNullOrEmpty(textBoxNumber.Text))
            {
                MessageBox.Show("Заполните номер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var model = new CarBindingModel
                {
                    Id = _id ?? 0,
                    MId = _mid,
                    Number = textBoxNumber.Text,
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