using asugaksharp.Forms;
using asugaksharp.Model;

namespace asugaksharp
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _context;

        public Form1(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void btnNaprPodg_Click(object sender, EventArgs e)
        {
            using var form = new NapravleniaPogotovkiForm(_context);
            form.ShowDialog();
        }

        private void btnProfiliPodg_Click(object sender, EventArgs e)
        {
            using var form = new ProfiliPodgootovkiForm(_context);
            form.ShowDialog();
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            using var form = new StudentsForm(_context);
            form.ShowDialog();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            using var form = new AddPersonForm(_context);
            form.ShowDialog();
        }

        private void btnOplata_Click(object sender, EventArgs e)
        {
            using var form = new OplataMainForm(_context);
            form.ShowDialog();
        }

        private void btnGAK_Click(object sender, EventArgs e)
        {
            using var form = new GakForm(_context);
            form.ShowDialog();
        }

        private void btnAddPeriodZ_Click(object sender, EventArgs e)
        {
            using var form = new AddPeriodZasedaniaForm(_context);
            form.ShowDialog();
        }
    }
}