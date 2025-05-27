using asugaksharp.Model;
using System.Reflection.Metadata;

namespace asugaksharp.Forms
{
    public partial class AddPerson : Form
    {
        public AddPerson()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using var db = new Model.AppDbContext();

            var SomePerson = new Person
            {
                Name = FioText.Text,
                Stepen = UchStepenBox.Text,
                Zvanie = UchZvanBox.Text,
                Dolgnost = DolgnostBox.Text,
                IsPredsed = PredsedBox.Checked,
                IsZavKaf = ZavKafBox.Checked,
                IsSecretar = IsSecretarBox.Checked

            };

            db.Person.Add(SomePerson);
            db.SaveChanges();

            MessageBox.Show("Добавлено");
            // TODO: Сделать очистку формы после добавления в базу 
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPerson_Load(object sender, EventArgs e)
        {

        }
    }
}
