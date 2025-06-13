using asugaksharp.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;


namespace asugaksharp.Forms
{
    public partial class Twolistbox : Form
    {
        public Twolistbox()
        {
            //InitializeComponent();
            this.Load += new EventHandler(Twolistbox_Load);

        }
        private BindingList<Person> availablePeople;
        private BindingList<Person> selectedPeople;
        private async void Twolistbox_Load(object sender, EventArgs e) {

            using var db = new Model.AppDbContext();

            var people = await db.Person.ToListAsync();

            availablePeople = new BindingList<Person>(people);
            selectedPeople = new BindingList<Person>();

           

        }


        
        
    }
}
