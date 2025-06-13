using asugaksharp.Model;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace asugaksharp.Forms
{
    public partial class AddPersonForm : Form
    {   
        private readonly AppDbContext _context;

        public AddPersonForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
            LoadKafExistingData();
            KafBox.SelectedValueChanged += KafBox_SelectedValueChanged;
        }

        private void LoadKafExistingData()
        {
            var kafedras = _context.Kafedra
                .OrderBy(x => x.Name)
                .ToList();

            if (!kafedras.Any())
            {
                MessageBox.Show("Нет доступных кафедр. Пожалуйста, добавьте кафедры сначала.", 
                    "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            KafBox.DataSource = kafedras;
            KafBox.DisplayMember = "Name";
            KafBox.ValueMember = "Id";

            var kafId = kafedras.First().Id;
            var people = _context.Person
                        .Where(p => p.KafedraID == kafId)
                        .ToList();

            Debug.WriteLine(people);
            PersonGridView.DataSource = people;
        }

        private void LoadPersonExistingData()
        {
            if (KafBox.SelectedValue is Guid selectedId)
            {
                var people = _context.Person
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
            if (string.IsNullOrWhiteSpace(FioText.Text))
            {
                MessageBox.Show("Введите ФИО", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FioText.Focus();
                return;
            }

            if (KafBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите кафедру", "Предупреждение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KafBox.Focus();
                return;
            }

            var kafid = (Guid)KafBox.SelectedValue;

            var SomePerson = new Person
            {
                Name = FioText.Text.Trim(),
                Stepen = UchStepenBox.Text?.Trim() ?? string.Empty,
                Zvanie = UchZvanBox.Text?.Trim() ?? string.Empty,
                Dolgnost = DolgnostBox.Text?.Trim() ?? string.Empty,
                IsPredsed = PredsedBox.Checked,
                IsZavKaf = ZavKafBox.Checked,
                IsSecretar = IsSecretarBox.Checked,
                IsVneshniy = isVeshnBox.Checked,
                KafedraID = kafid
            };

            _context.Person.Add(SomePerson);
            _context.SaveChanges();

            LoadPersonExistingData();
            MessageBox.Show("Добавлено");
            ClearFields();
        }

        private void ClearFields()
        {
            FioText.Clear();
            UchStepenBox.Text = "";
            UchZvanBox.Text = "";
            DolgnostBox.Text = "";
            PredsedBox.Checked = false;
            ZavKafBox.Checked = false;
            IsSecretarBox.Checked = false;
            isVeshnBox.Checked = false;
            FioText.Focus();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}