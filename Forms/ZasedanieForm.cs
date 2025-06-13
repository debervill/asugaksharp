using asugaksharp.Model;
using System.Windows.Forms;

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
    }
}