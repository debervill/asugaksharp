<<<<<<< HEAD
using asugaksharp.Model;
using System.Windows.Forms;
=======
﻿
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0

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