using CarServiceContracts.BusinessLogicsContracts;
using System.Diagnostics;

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
                Stopwatch stopwatch = new();
                stopwatch.Start();
                var list = _logic.GetMostPopular();
                stopwatch.Stop();
                MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
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
