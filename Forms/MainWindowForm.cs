using asugaksharp.Model;

namespace asugaksharp.Forms
{
    public partial class MainWindowForm : Form
    {
<<<<<<< HEAD
        private readonly AppDbContext _context;

        public MainWindowForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void btnNaprPodg_Click(object sender, EventArgs e)
=======
        private readonly AppDbContext _db;
        public MainWindowForm(AppDbContext db)
        {
            _db = db;
            InitializeComponent();
        }

        private void MainWindowForm_Load(object sender, EventArgs e)
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0
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
<<<<<<< HEAD
            using var form = new AddPeriodZasedaniaForm(_context);
            form.ShowDialog();
=======
        }

        private void äîáàâèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void äîáàâèòüToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Äîáàâëåíèå ïåðèîäà çàñåäàíèé

            PeriodZasedaniaForm form = new PeriodZasedaniaForm();
            form.Show();

        }

        private void äîáàâèüËþäåéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Äîáàâëåíèå ïåðñîí

            PersonForm form = new PersonForm(_db);
            form.Show();
        }

        private void ëèñòÁîêñToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twolistbox form = new twolistbox();
            form.Show();
        }

        private void äîáàâèòüToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Ñòóäåíòû
            StudentsForm form = new StudentsForm();
            form.Show();
        }

        private void ãÝÊèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GakForm form = new GakForm(_db);
            form.Show();
        }

        private void íàïðàâëåíèÿÏîäãîòîâêèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NapravleniaPogotovkiForm form = new NapravleniaPogotovkiForm();
            form.Show();
        }

        private void ïðîôèëèÏîäãîòîâêèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfiliPodgootovkiForm form = new ProfiliPodgootovkiForm();
            form.Show();
        }

        private void îïëàòàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OplataMainForm form = new OplataMainForm();
            form.Show();
        }

        private void êàôåäðûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KafedraForms forms = new KafedraForms();
            forms.Show();
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}