using asugaksharp.Model;
using System.Windows.Forms;

namespace asugaksharp.Forms
{
    public partial class AddPeriodZasedaniaForm : Form
    {
        private readonly AppDbContext _context;

        public AddPeriodZasedaniaForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void BntSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NazvanieText.Text))
            {
                MessageBox.Show("Введите название периода", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NazvanieText.Focus();
                return;
            }

            var period = new PeriodZasedania
            {
                DateStart = DateOnly.FromDateTime(dateStartPicker.Value),
                DateEnd = DateOnly.FromDateTime(dateEndPicker.Value),
                Name = NazvanieText.Text.Trim(),
                Primechanie = PrimechanieText.Text?.Trim() ?? string.Empty,
            };

            _context.PeriodZasedania.Add(period);
            _context.SaveChanges();
            MessageBox.Show("Изменения внесены");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}