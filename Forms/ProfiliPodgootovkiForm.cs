using asugaksharp.Model;


namespace asugaksharp.Forms
{
    public partial class ProfiliPodgootovkiForm : Form
    {
        private readonly AppDbContext _context;

        public ProfiliPodgootovkiForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
            LoadNapravleniesPodgotovki();
        }
        
        private void LoadNapravleniesPodgotovki() 
        {
            var CombboxData = _context.NapravleniePodgotovki.ToList();
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