using asugaksharp.Model;


namespace asugaksharp.Forms
{
    public partial class KafedraForms : Form
    {
        public KafedraForms()
        {
            InitializeComponent();
            LoadExistingData();
        }

        private void LoadExistingData() {

            using var db = new AppDbContext();
            var data = db.Kafedra.ToList();
            KafedraGridView.DataSource = data;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            using var db = new AppDbContext();

            var SomeKaf = new Kafedra
            {
                Name = KafBox.Text,
               

            };

            db.Kafedra.Add(SomeKaf);
            db.SaveChanges();

            LoadExistingData();
            MessageBox.Show("Добавлено");

        }
    }
}
