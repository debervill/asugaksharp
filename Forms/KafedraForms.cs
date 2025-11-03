using asugaksharp.Model;


namespace asugaksharp.Forms
{
    public partial class KafedraForms : Form
    {
        private readonly AppDbContextFactory _dbFactory = new AppDbContextFactory();

        public KafedraForms()
        {
            InitializeComponent();
            LoadExistingData();
            using var db = _dbFactory.CreateDbContext(null);
        }

        private void LoadExistingData()
        {

            
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

        private void KafedraGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KafBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
