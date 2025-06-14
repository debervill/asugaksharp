<<<<<<< HEAD
using asugaksharp.Model;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
=======
﻿using Microsoft.EntityFrameworkCore;
using System.Data;
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0

namespace asugaksharp.Forms
{
    public partial class OplataMainForm : Form
    {
        private readonly AppDbContext _context;

        public OplataMainForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
            LoadExistingData();
        }

        private void LoadExistingData()
        {
            // Председатель
            var predsedat = _context.Person
                .AsNoTracking()
                .Where(p => p.IsPredsed)
                .ToList();
            SetComboBoxData(PredseBox, predsedat);

            // Внешние члены
            var vneshmember = _context.Person
                .AsNoTracking()
                .Where(p => p.IsVneshniy)
                .ToList();

            SetComboBoxData(FstMemberBox, vneshmember);
            SetComboBoxData(ScndMemberBox, vneshmember);
            SetComboBoxData(ThdMemberBox, vneshmember);
        }

        private void SetComboBoxData(ComboBox comboBox, object dataSource)
        {
            comboBox.DataSource = null;
            comboBox.ValueMember = "Id";
            comboBox.DisplayMember = "Name";
            comboBox.DataSource = dataSource;
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}