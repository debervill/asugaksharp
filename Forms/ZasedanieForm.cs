using asugaksharp.Model;
namespace asugaksharp.Forms
{
    public partial class ZasedanieForm : Form
    {
        private readonly AppDbContext _context;

        public ZasedanieForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void ZasedanieForm_Load(object sender, EventArgs e)
        {

        }
    }
}