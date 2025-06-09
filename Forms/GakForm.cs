using asugaksharp.Model;

namespace asugaksharp.Forms
{
    public partial class GakForm : Form
    {
        private readonly AppDbContext _db;
        public GakForm(AppDbContext db)
        {
            _db = db;
            InitializeComponent();
            LoadKaf();
        }

      

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadKaf() {
            var kafedras = _db.Kafedra.
                    OrderBy(x => x.Name).
                    ToList();
            KafBox.DataSource = kafedras;
            KafBox.DisplayMember = "Name";
            KafBox.ValueMember = "Id";

            Guid kafId = kafedras.First().Id;
 
        }

        private void BtnAddZasedanie_Click(object sender, EventArgs e)
        {
            ZasedanieForm form = new ZasedanieForm();   
            form.ShowDialog();
        }
    }
}
