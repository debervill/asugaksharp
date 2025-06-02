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
    public partial class GakForm : Form
    {
        public GakForm()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnAddZasedanie_Click(object sender, EventArgs e)
        {
            Zasedanie form = new Zasedanie();   
            form.ShowDialog();
        }
    }
}
