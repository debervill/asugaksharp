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

        private void ñôîğìèğîâàòüÊîìèññèşToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void êîìñèèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void äîáàâèòüToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void äîáàâèòüToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Äîáàâëåíèå ïåğèîäà çàñåäàíèé

            AddPeriodZasedania form = new AddPeriodZasedania();
            form.Show();

        }

        private void äîáàâèüËşäåéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Äîáàâëåíèå ïåğñîí

            AddPerson form = new AddPerson();
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
            Students form = new Students();
            form.Show();
        }

        private void ãİÊèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GakForm form = new GakForm();
            form.Show();
        }

        private void íàïğàâëåíèÿÏîäãîòîâêèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NapravleniaPogotovki form = new NapravleniaPogotovki();
            form.Show();
        }

        private void ïğîôèëèÏîäãîòîâêèToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfiliPodgootovkiForm form = new ProfiliPodgootovkiForm();
            form.Show();
        }

        private void îïëàòàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OplataMainForm form = new OplataMainForm();
            form.Show();    
        }
    }
}
