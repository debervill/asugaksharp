<<<<<<< HEAD
using asugaksharp.Model;
using NPetrovich;
using System.Windows.Forms;
=======
﻿
using NPetrovich;

>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0

namespace asugaksharp.Forms
{
    public partial class StudentsForm : Form
    {
        private readonly AppDbContext _context;

        public StudentsForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void BtnStudAdd_Click(object sender, EventArgs e)
        {
        }

        private void BtnStudChange_Click(object sender, EventArgs e)
        {
        }

        private void BtnStudSclon_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            var selectedGender = Sex.SelectedItem?.ToString();
            var StudGender = (!string.IsNullOrEmpty(selectedGender) && selectedGender == "муж") ? Gender.Male : Gender.Female;

            if (string.IsNullOrEmpty(NameImBox.Text) || string.IsNullOrEmpty(Famimbox.Text) || string.IsNullOrEmpty(OtchImbox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля имени", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
=======
            Gender StudGender = Sex.SelectedItem?.ToString() == "муж" ? Gender.Male : Gender.Female;
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0

            MessageBox.Show(StudGender.ToString());

            var petrovich = new Petrovich()
            {
                FirstName = NameImBox.Text,
                LastName = Famimbox.Text,
                MiddleName = OtchImbox.Text,
                //AutoDetectGender = true
                Gender = StudGender
            };

            var inflected = petrovich.InflectTo(Case.Dative);

            MessageBox.Show($"Дательный падеж: {inflected.FirstName} {inflected.MiddleName} {inflected.LastName}");
        }
    }
}