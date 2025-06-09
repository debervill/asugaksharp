using asugaksharp.Model;


namespace asugaksharp.Forms
{
    public partial class PeriodZasedaniaForm : Form
    {
        public PeriodZasedaniaForm()
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
