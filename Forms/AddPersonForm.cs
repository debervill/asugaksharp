using asugaksharp.Model;
using System.Diagnostics;


namespace asugaksharp.Forms
{
    public partial class AddPersonForm : Form
    {   
        public AddPersonForm()
        {
            InitializeComponent();
            LoadKafExistingData();
            KafBox.SelectedValueChanged += KafBox_SelectedValueChanged;
            //LoadPersonExistingData();
        }

        private void LoadKafExistingData()
        {
            using var db = new AppDbContext();
          
            var kafedras = db.Kafedra.
                OrderBy(x => x.Name).
                ToList();
            KafBox.DataSource = kafedras;
            KafBox.DisplayMember = "Name";
            KafBox.ValueMember = "Id";

            Guid kafId = kafedras.First().Id;

           var people = db.Person
                        .Where(p => p.KafedraID == kafId)
                        .ToList();

            Debug.WriteLine(people);

             PersonGridView.DataSource = people;

           
        }

        private void LoadPersonExistingData() {


            if (KafBox.SelectedValue is Guid selectedId)
            {
                using var db = new AppDbContext();
                var people = db.Person
                               .Where(p => p.KafedraID == selectedId)
                               .ToList();

                PersonGridView.DataSource = people;
            }



        }

        private void KafBox_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadPersonExistingData();
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using var db = new Model.AppDbContext();
            Guid kafid = (Guid)KafBox.SelectedValue;

            var SomePerson = new Person
            {
                Name = FioText.Text,
                Stepen = UchStepenBox.Text,
                Zvanie = UchZvanBox.Text,
                Dolgnost = DolgnostBox.Text,
                IsPredsed = PredsedBox.Checked,
                IsZavKaf = ZavKafBox.Checked,
                IsSecretar = IsSecretarBox.Checked,
                IsVneshniy = isVeshnBox.Checked,
                KafedraID = kafid


                };

            db.Person.Add(SomePerson);
            db.SaveChanges();

            LoadPersonExistingData();
            MessageBox.Show("Добавлено");
            // TODO: Сделать очистку формы после добавления в базу 
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        
    }
}
