using asugaksharp.Model;
using Microsoft.EntityFrameworkCore;
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
    public partial class twolistbox : Form
    {
        public twolistbox()
        {
            InitializeComponent();
            this.Load += new EventHandler(Twolistbox_Load);

        }
        private BindingList<Person> availablePeople;
        private BindingList<Person> selectedPeople;
        private async void Twolistbox_Load(object sender, EventArgs e) {

            using var db = new Model.AppDbContext();

            var people = await db.Person.ToListAsync();

            availablePeople = new BindingList<Person>(people);
            selectedPeople = new BindingList<Person>();

            listBox1.DataSource = availablePeople;
            listBox1.DisplayMember = "Name";

            listBox2.DataSource = selectedPeople;
            listBox2.DisplayMember = "Name";

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1 && listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1 && listBox2.Items.Count > 0)
                listBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem is Person person)
            {
                selectedPeople.Add(person);
                availablePeople.Remove(person);
            }

            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedItems = listBox2.SelectedItems.Cast<object>().ToList();

            if (listBox2.SelectedItem is Person person)
            {
                availablePeople.Add(person);
                selectedPeople.Remove(person);
            }

            if (listBox2.Items.Count > 0)
                listBox2.SelectedIndex = 0;
        }
    }
}
