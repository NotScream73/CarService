using CarServiceContracts.BusinessLogicsContracts;
using CarServiceContracts.SearchModels;
using CarServiceContracts.ViewModels;
using CarServiceDataModels.Models;

namespace CarServiceView
{
    public partial class FormContractService : Form
    {
        private readonly IServiceLogic _logic;
        private readonly List<ServiceViewModel>? _list;
        public bool Mongo;
        public int Id
        {
            get
            {
                return Convert.ToInt32(comboBoxService.SelectedValue);
            }
            set
            {
                comboBoxService.SelectedValue = value;
            }
        }
        public string MId
        {
            get
            {
                return Convert.ToString(comboBoxService.SelectedValue);
            }
            set
            {
                comboBoxService.SelectedValue = value;
            }
        }
        public IServiceModel? ServiceModel
        {
            get
            {
                if (_list == null)
                {
                    return null;
                }
                if (Mongo)
                {
                    foreach (var elem in _list)
                    {
                        if (elem.MId == MId)
                        {
                            return elem;
                        }
                    }
                }
                else
                {
                    foreach (var elem in _list)
                    {
                        if (elem.Id == Id)
                        {
                            return elem;
                        }
                    }
                }
                return null;
            }
        }
        public double Price
        {
            get
            {
                return Convert.ToInt32(textBoxPrice.Text);
            }
            set
            {
                textBoxPrice.Text = value.ToString();
            }
        }

        public FormContractService(IServiceLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            _list = logic.ReadList(null);
            if (_list != null)
            {
                if (_list.Any(x => !string.IsNullOrEmpty(x.MId)))
                {
                    Mongo = true;
                    comboBoxService.ValueMember = "MId";
                }
                else
                {
                    comboBoxService.ValueMember = "Id";
                }
                comboBoxService.DisplayMember = "Title";
                comboBoxService.DataSource = _list;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxService.SelectedValue == null)
            {
                MessageBox.Show("Выберите услугу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboBoxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxService.SelectedValue != null)
            {
                try
                {
                    if (Mongo)
                    {
                        string mid = Convert.ToString(comboBoxService.SelectedValue);
                        var temp = new ServiceSearchModel
                        {
                            MId = mid
                        };
                        var service = _logic.ReadElement(temp);
                        if (service == null)
                        {
                            return;
                        }
                        textBoxPrice.Text = service.Price.ToString();
                    }
                    else
                    {
                        int id = Convert.ToInt32(comboBoxService.SelectedValue);
                        var temp = new ServiceSearchModel
                        {
                            Id = id
                        };
                        var service = _logic.ReadElement(temp);
                        if (service == null)
                        {
                            return;
                        }
                        textBoxPrice.Text = service.Price.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
