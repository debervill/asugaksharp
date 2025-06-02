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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
