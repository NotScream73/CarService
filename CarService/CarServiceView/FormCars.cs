using CarServiceContracts.BindingModels;
using CarServiceContracts.BusinessLogicsContracts;

namespace CarServiceView
{
    public partial class FormCars : Form
    {
        private readonly ICarLogic _logic;

        public FormCars(ICarLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormCars_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.ReadList(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["MId"].Visible = false;
                    dataGridView.Columns["Id"].Visible = false;
                    dataGridView.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormCar));
            if (service is FormCar form)
            {
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
                var service = Program.ServiceProvider?.GetService(typeof(FormCar));
                if (service is FormCar form)
                {
                    form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    form.MId = Convert.ToString(dataGridView.SelectedRows[0].Cells["MId"].Value);
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
                    string mid = Convert.ToString(dataGridView.SelectedRows[0].Cells["MId"].Value);
                    try
                    {
                        if (!_logic.Delete(new CarBindingModel
                        {
                            Id = id,
                            MId = mid
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
    }
}
