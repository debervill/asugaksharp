using asugaksharp.Model;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace asugaksharp.Forms
{
    public partial class AddPersonForm : Form
    {
        public AddPersonForm()
        {
            InitializeComponent();
            LoadKafExistingData();
        }

        private void LoadKafExistingData()
        {
            using var db = new Model.AppDbContext();
          
            var kafedras = db.Kafedra.ToList();
            KafBox.DataSource = kafedras;
            KafBox.DisplayMember = "Name";
            KafBox.ValueMember = "Id";


        }

        private void LoadPersonExistingData() {
            if (KafBox.SelectedValue is Guid selectedId)
            {

                using var db = new Model.AppDbContext();
                var people = db.Person
                         .Where(p => p.Id == selectedId)
                         .ToList();

                PersonGridView.DataSource = people;
            }

         }

        private void KafBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KafBox.SelectedValue is Guid selectedId)
            {
                // Здесь у тебя есть Id выбранной кафедры
                Console.WriteLine($"Выбранная кафедра: {selectedId}");

                // Можешь, например, загрузить связанные данные в DataGridView
                using var db = new Model.AppDbContext();
                var people = db.Person
                    .Where(p => p.Id == selectedId)
                    .ToList();

                PersonGridView.DataSource = people;
            }
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
                IsSecretar = IsSecretarBox.Checked,
                IsVneshniy = isVeshnBox.Checked

            };

            db.Person.Add(SomePerson);
            db.SaveChanges();

            LoadPersonExistingData();
            MessageBox.Show("Добавлено");
            // TODO: Сделать очистку формы после добавления в базу 
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
