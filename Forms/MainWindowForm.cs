using asugaksharp.Model;

namespace asugaksharp.Forms
{
    public partial class MainWindowForm : Form
    {
        private readonly AppDbContext _db;
        public MainWindowForm(AppDbContext db)
        {
            _db = db;
            //DInitializeComponent();
        }
        private readonly AppDbContext _context;
        private void MainWindowForm_Load(object sender, EventArgs e)
        {
            using var form = new NapravleniaPogotovkiForm(_context);
            form.ShowDialog();
        }

        private void btnNaprPodg_Click(object sender, EventArgs e)
        {

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
       }

       private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
       {

       }


       
       private void ��������ToolStripMenuItem_Click_1(object sender, EventArgs e)
       {
          //���������� ������� ���������

          PeriodZasedaniaForm form = new PeriodZasedaniaForm(_context);
          form.Show();

       }

       private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
       {
          //���������� ������

          PersonForm form = new PersonForm(_db);
          form.Show();
       }

       private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
       {
          Twolistbox form = new Twolistbox();
          form.Show();
       }

       private void ��������ToolStripMenuItem1_Click(object sender, EventArgs e)
       {
          //��������
          StudentsForm form = new StudentsForm(_context);
          form.Show();
       }

       private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
       {
          GakForm form = new GakForm(_db);
          form.Show();
       }

       private void ���������������������ToolStripMenuItem_Click(object sender, EventArgs e)
       {
          NapravleniaPogotovkiForm form = new NapravleniaPogotovkiForm(_context);
          form.Show();
       }

       private void �����������������ToolStripMenuItem_Click(object sender, EventArgs e)
       {
          ProfiliPodgootovkiForm form = new ProfiliPodgootovkiForm(_context);
          form.Show();
       }

       private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
       {
          OplataMainForm form = new OplataMainForm(_context);
          form.Show();
       }

       private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
       {
          KafedraForms forms = new KafedraForms();
          forms.Show();
       }


    }
}