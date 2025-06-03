using asugaksharp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asugaksharp.Forms
{
    public partial class KafedraForms : Form
    {
        public KafedraForms()
        {
            InitializeComponent();
        }

        private void LoadExistingData() {

            using var db = new Model.AppDbContext();
            var data = db.Kafedra.ToList();
            KafedraGridView.DataSource = data;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            using var db = new Model.AppDbContext();

            var SomeKaf = new Kafedra
            {
                Name = KafBox.Text,
               

            };

            db.Kafedra.Add(SomeKaf);
            db.SaveChanges();

            LoadExistingData();
            MessageBox.Show("Добавлено");

        }
    }
}
