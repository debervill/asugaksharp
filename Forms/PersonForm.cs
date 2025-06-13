using asugaksharp.Model;
using System.Diagnostics;


namespace asugaksharp.Forms
{

    public partial class PersonForm : Form
    {
        private readonly AppDbContext _db;

        private bool isEditMode = false;
       
        private Guid? editingPersonId = null; // null — значит создаём нового

        public PersonForm(AppDbContext db)
        {
            _db = db;
            InitializeComponent();
            LoadKafExistingData();
            KafBox.SelectedValueChanged += KafBox_SelectedValueChanged;

        }

        private void LoadKafExistingData()
        {


            var kafedras = _db.Kafedra.
                OrderBy(x => x.Name).
                ToList();
            KafBox.DataSource = kafedras;
            KafBox.DisplayMember = "Name";
            KafBox.ValueMember = "Id";

            Guid kafId = kafedras.First().Id;

            var people = _db.Person
                         .Where(p => p.KafedraID == kafId)
                         .ToList();


            PersonGridView.DataSource = people;


        }

        private void LoadPersonExistingData()
        {


            if (KafBox.SelectedValue is Guid selectedId)
            {

                var people = _db.Person
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

            Guid kafid = (Guid)KafBox.SelectedValue;

            if (editingPersonId == null)
            {
                // Добавление нового
                var newPerson = new Person
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

                _db.Person.Add(newPerson);
                _db.SaveChanges();
                MessageBox.Show("Добавлено");
            }
            else
            {
                // Обновление существующего
                var person = _db.Person.FirstOrDefault(p => p.Id == editingPersonId.Value);
                if (person == null)
                {
                    MessageBox.Show("Ошибка: объект для редактирования не найден.");
                    return;
                }

                person.Name = FioText.Text;
                person.Stepen = UchStepenBox.Text;
                person.Zvanie = UchZvanBox.Text;
                person.Dolgnost = DolgnostBox.Text;
                person.IsPredsed = PredsedBox.Checked;
                person.IsZavKaf = ZavKafBox.Checked;
                person.IsSecretar = IsSecretarBox.Checked;
                person.IsVneshniy = isVeshnBox.Checked;
                person.KafedraID = kafid;

                _db.SaveChanges();
                MessageBox.Show("Изменения сохранены");
            }

            // Очистка и сброс
            editingPersonId = null;
            BtnAdd.Text = "Сохранить";
            //TODO: дописать метод очистки формы чтобы она очищала 

            ClearForm();
            LoadPersonExistingData();
        }

        private void ClearForm()
        {
            // Очистка текстовых полей
            FioText.Clear();
            textBox1.Clear(); // Адрес
            textBox2.Clear(); // Паспорт серия/номер
            textBox3.Clear(); // Кем выдан
            textBox4.Clear(); // СНИЛС
            textBox5.Clear(); // ИНН
            textBox6.Clear(); // Банк
            textBox7.Clear(); // Расчёт счёт
            textBox8.Clear(); // Корр. счёт
            textBox9.Clear(); // БИК
            textBox10.Clear(); // Телефон
            textBox11.Clear(); // Email

            // Сброс ComboBox'ов
            UchStepenBox.SelectedIndex = -1;
            UchZvanBox.SelectedIndex = -1;
            DolgnostBox.SelectedIndex = -1;
            KafBox.SelectedIndex = KafBox.Items.Count > 0 ? 0 : -1;

            // Сброс CheckBox'ов
            PredsedBox.Checked = false;
            ZavKafBox.Checked = false;
            IsSecretarBox.Checked = false;
            isVeshnBox.Checked = false;
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PersonGridView.CurrentRow?.DataBoundItem is not Person selectedPerson)
            {
                MessageBox.Show("Выберите строку для редактирования.");
                return;
            }

            editingPersonId = selectedPerson.Id;

            FioText.Text = selectedPerson.Name;
            UchStepenBox.Text = selectedPerson.Stepen;
            UchZvanBox.Text = selectedPerson.Zvanie;
            DolgnostBox.Text = selectedPerson.Dolgnost;
            PredsedBox.Checked = selectedPerson.IsPredsed;
            ZavKafBox.Checked = selectedPerson.IsZavKaf;
            IsSecretarBox.Checked = selectedPerson.IsSecretar;
            isVeshnBox.Checked = selectedPerson.IsVneshniy;
            KafBox.SelectedValue = selectedPerson.KafedraID;

            BtnAdd.Text = "Сохранить изменения";
        }
    }
}
