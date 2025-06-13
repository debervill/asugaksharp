<<<<<<< HEAD
using asugaksharp.Model;
using System.Windows.Forms;

=======
﻿
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0
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