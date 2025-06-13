<<<<<<< HEAD:Forms/AddPeriodZasedaniaForm.cs
using asugaksharp.Model;
using System.Windows.Forms;
=======
﻿using asugaksharp.Model;

>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0:Forms/PeriodZasedaniaForm.cs

namespace asugaksharp.Forms
{
    public partial class PeriodZasedaniaForm : Form
    {
<<<<<<< HEAD:Forms/AddPeriodZasedaniaForm.cs
        private readonly AppDbContext _context;

        public AddPeriodZasedaniaForm(AppDbContext context)
=======
        public PeriodZasedaniaForm()
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0:Forms/PeriodZasedaniaForm.cs
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