
using NPetrovich;
using asugaksharp.Model;

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
            Gender StudGender = Sex.SelectedItem?.ToString() == "муж" ? Gender.Male : Gender.Female;

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