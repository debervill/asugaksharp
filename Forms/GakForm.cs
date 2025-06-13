using asugaksharp.Model;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace asugaksharp.Forms
{
    public partial class GakForm : Form
    {
        private readonly AppDbContext _context;

        public GakForm(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Загрузка кафедр
                var kafedras = _context.Kafedra.ToList();
                MessageBox.Show($"Загружено кафедр: {kafedras.Count}");
                
                if (kafedras.Any())
                {
                    kafedraBindingSource.DataSource = kafedras;
                    kafedraBox.ValueMember = "Id";
                    kafedraBox.DisplayMember = "Name";
                }
                else
                {
                    MessageBox.Show("Таблица кафедр пуста. Пожалуйста, добавьте данные.");
                }

                // Загрузка периодов заседаний
                var periods = _context.PeriodZasedania.ToList();
                MessageBox.Show($"Загружено периодов: {periods.Count}");
                
                if (periods.Any())
                {
                    periodZasedaniaBindingSource.DataSource = periods;
                    PerodZasedBox.ValueMember = "Id";
                    PerodZasedBox.DisplayMember = "Name";
                }
                else
                {
                    MessageBox.Show("Таблица периодов заседаний пуста. Пожалуйста, добавьте данные.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}\n\nStackTrace:\n{ex.StackTrace}");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void BtnAddZasedanie_Click(object sender, EventArgs e)
        {
            ZasedanieForm form = new ZasedanieForm(_context);   
            form.ShowDialog();
        }
    }
}