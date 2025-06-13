using asugaksharp.Model;

namespace asugaksharp.Forms
{
    public partial class GenPdfForm : Form
    {
        private readonly AppDbContext _context;

        public GenPdfForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}