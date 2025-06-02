

using NPetrovich;
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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }


        private void BtnStudAdd_Click(object sender, EventArgs e)
        {


        }

        private void BtnStudChange_Click(object sender, EventArgs e)
        {

        }

        private void BtnStudSclon_Click(object sender, EventArgs e)
        {
            var StudGender = Sex.SelectedItem?.ToString() == "муж" ? Gender.Male : Gender.Female;

            MessageBox.Show(StudGender.ToString());

            var petrovich = new Petrovich()
            {
                FirstName = NameImBox.Text,
                LastName = Famimbox.Text,
                MiddleName = OtchImbox.Text,
                Gender = StudGender
            };

            var inflected = petrovich.InflectTo(Case.Dative);



            MessageBox.Show($"Дательный падеж: {inflected.FirstName} {inflected.MiddleName} {inflected.LastName}");
        }


    }
}
