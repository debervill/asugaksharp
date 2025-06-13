using asugaksharp.Model;
using System.ComponentModel;
using System.Windows.Forms;

namespace asugaksharp.Forms
{
    public partial class NapravleniaPogotovkiForm : Form
    {
        private readonly AppDbContext _context;
        public BindingList<NapravleniePodgotovki> napravleniaList;

        public NapravleniaPogotovkiForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
            InitializeData();
            LoadExistingData();
        }

        private void InitializeData()
        {
            napravleniaList = new BindingList<NapravleniePodgotovki>();
            napravleniePodgotovkiBindingSource.DataSource = napravleniaList;
        }

        private void LoadExistingData() 
        {
            var data = _context.NapravleniePodgotovki.ToList();
            dataGridView1.DataSource = data;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;
                
            string shifr = ShifrBox.Text.Trim();
            string nazvanie = NazvanieBox.Text.Trim();

            CreateNewRecord(shifr, nazvanie);
            LoadExistingData();
            ClearFields();
        }

        private void CreateNewRecord(string shifr, string nazvanie)
        {
            var newNapravlenie = new NapravleniePodgotovki
            {
                ShifrNapr = shifr,
                Nazvanie = nazvanie
            };

            _context.NapravleniePodgotovki.Add(newNapravlenie);
            _context.SaveChanges();

            napravleniaList.Add(newNapravlenie);
            MessageBox.Show("Направление добавлено!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(ShifrBox.Text))
            {
                MessageBox.Show("Введите шифр направления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShifrBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(NazvanieBox.Text))
            {
                MessageBox.Show("Введите название направления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NazvanieBox.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            ShifrBox.Clear();
            NazvanieBox.Clear();
            ShifrBox.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
        }
    }
}