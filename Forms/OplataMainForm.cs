using Microsoft.EntityFrameworkCore;
using System.Data;

namespace asugaksharp.Forms
{
    public partial class OplataMainForm : Form
    {
        public OplataMainForm()
        {
            InitializeComponent();
            LoadExistingData();
        }

        private void LoadExistingData()
        {
            using var db = new Model.AppDbContext();

            // Председатель
            var predsedat = db.Person
                .AsNoTracking()
                .Where(p => p.IsPredsed)
                .ToList();
            SetComboBoxData(PredseBox, predsedat);

            // Внешние члены
            var vneshmember = db.Person
                .AsNoTracking()
                .Where(p => p.IsVneshniy)
                .ToList();

            SetComboBoxData(FstMemberBox, vneshmember);
            SetComboBoxData(ScndMemberBox, vneshmember);
            SetComboBoxData(ThdMemberBox, vneshmember);
        }

        private void SetComboBoxData(ComboBox comboBox, object dataSource)
        {
            comboBox.DataSource = null;
            comboBox.ValueMember = "Id";
            comboBox.DisplayMember = "Name";
            comboBox.DataSource = dataSource;
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
