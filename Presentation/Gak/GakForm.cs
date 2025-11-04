using asugaksharp.Core.Entities;
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
            //InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Загрузка кафедр
                var kafedras = _context.Kafedra
                    .OrderBy(x => x.Name)
                    .ToList();
                
                if (kafedras.Any())
                {
                    kafedraBindingSource.DataSource = kafedras;
                    kafedraBox.ValueMember = "Id";
                    kafedraBox.DisplayMember = "Name";

                    // При выборе кафедры обновляем список персонала
                    kafedraBox.SelectedIndexChanged += (s, e) =>
                    {
                        if (kafedraBox.SelectedItem is Kafedra selectedKafedra)
                        {
                            LoadPersonnel(selectedKafedra.Id);
                        }
                    };
                }
                else
                {
                    MessageBox.Show("Таблица кафедр пуста. Пожалуйста, добавьте данные.");
                }

                // Загрузка периодов заседаний
                var periods = _context.PeriodZasedania.ToList();
                
                /*
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
                */
                // Инициализация списка для председателя
                PrepdsedBox.DisplayMember = "Name";
                PrepdsedBox.ValueMember = "Id";

                // Добавление обработчиков для кнопок
                BtnAddMemberToCommision.Click += (s, e) =>
                {
                    if (AllPersonsList.SelectedItem is Person selectedPerson)
                    {
                        if (!ComssionsMemberList.Items.Contains(selectedPerson))
                        {
                            ComssionsMemberList.Items.Add(selectedPerson);
                        }
                    }
                };

                BtnDeleteMemberFromCommission.Click += (s, e) =>
                {
                    if (ComssionsMemberList.SelectedItem is Person selectedPerson)
                    {
                        ComssionsMemberList.Items.Remove(selectedPerson);
                    }
                };

                // Если есть выбранная кафедра, загрузим её персонал
                if (kafedraBox.SelectedItem is Kafedra selectedKafedra)
                {
                    LoadPersonnel(selectedKafedra.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}\n\nStackTrace:\n{ex.StackTrace}");
            }
        }

        private void LoadPersonnel(Guid kafedraId)
        {
            try
            {
                var personnel = _context.Person
                    .Where(p => p.KafedraID == kafedraId)
                    .OrderBy(p => p.Name)
                    .ToList();

                personBindingSource.DataSource = personnel;
                PrepdsedBox.DataSource = new List<Person>(personnel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке персонала: {ex.Message}");
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