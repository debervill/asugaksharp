using asugaksharp.Model;


namespace asugaksharp.Forms
{
    public partial class ProfiliPodgootovkiForm : Form
    {
        public ProfiliPodgootovkiForm()
        {

            InitializeComponent();
            LoadNapravleniesPodgotovki();


        }
        
        private void LoadNapravleniesPodgotovki() {
            
            using var db = new Model.AppDbContext();

            var CombboxData = db.NapravleniePodgotovki.ToList();
            NapravlenitBox.DataSource = CombboxData;
            NapravlenitBox.DisplayMember = "Nazvanie";
            NapravlenitBox.ValueMember = "Id";

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (NapravlenitBox.SelectedValue is Guid selectedId)
            {
               
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
