using asugaksharp.Forms;
using asugaksharp.Model;
using System.Windows.Forms;

namespace asugaksharp
{
    public partial class MainWindowForm : Form
    {
        private readonly AppDbContext _db;
        public MainWindowForm(AppDbContext db)
        {
            _db = db;
            InitializeComponent();
        }

        private void MainWindowForm_Load(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void ��������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void ��������ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //���������� ������� ���������

            PeriodZasedaniaForm form = new PeriodZasedaniaForm();
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
            twolistbox form = new twolistbox();
            form.Show();
        }

        private void ��������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //��������
            StudentsForm form = new StudentsForm();
            form.Show();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GakForm form = new GakForm(_db);
            form.Show();
        }

        private void ���������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NapravleniaPogotovkiForm form = new NapravleniaPogotovkiForm();
            form.Show();
        }

        private void �����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfiliPodgootovkiForm form = new ProfiliPodgootovkiForm();
            form.Show();
        }

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OplataMainForm form = new OplataMainForm();
            form.Show();
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KafedraForms forms = new KafedraForms();
            forms.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
