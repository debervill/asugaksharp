using asugaksharp.Forms;
using asugaksharp.Model;
using System.Windows.Forms;

namespace asugaksharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

            AddPeriodZasedaniaForm form = new AddPeriodZasedaniaForm();
            form.Show();

        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //���������� ������

            AddPersonForm form = new AddPersonForm();
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
            GakForm form = new GakForm();
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
    }
}
