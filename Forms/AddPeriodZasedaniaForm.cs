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
    public partial class AddPeriodZasedaniaForm : Form
    {
        public AddPeriodZasedaniaForm()
        {
            InitializeComponent();
        }



        private void BntSave_Click(object sender, EventArgs e)
        {
            using var db = new Model.AppDbContext();

            var period = new PeriodZasedania
            {
                DateStart = DateOnly.FromDateTime(dateStartPicker.Value),
                DateEnd = DateOnly.FromDateTime(dateEndPicker.Value),
                Name = NazvanieText.Text,
                Primechanie = PrimechanieText.Text,

            };
            db.PeriodZasedania.Add(period);
            db.SaveChanges();
            MessageBox.Show("Изменения внесены");



        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
