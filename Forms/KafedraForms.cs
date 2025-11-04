using asugaksharp.Model;
namespace asugaksharp.Forms
{
    public partial class KafedraForms : Form
    {
        private readonly AppDbContextFactory _dbFactory = new AppDbContextFactory();

        public KafedraForms()
        {
            InitializeComponent();
            LoadExistingData();
        }

        private void LoadExistingData()
        {
            using var db = _dbFactory.CreateDbContext(null);
            var data = db.Kafedra.ToList();
            KafedraGridView.DataSource = data;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Валидация ввода
            if (string.IsNullOrWhiteSpace(KafBox.Text))
            {
                MessageBox.Show("Введите название кафедры", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ИСПРАВЛЕНО: использование _dbFactory вместо создания нового контекста
            using var db = _dbFactory.CreateDbContext(null);

            var SomeKaf = new Kafedra
            {
                Name = KafBox.Text.Trim(),
            };

            db.Kafedra.Add(SomeKaf);
            db.SaveChanges();

            // Очистка поля ввода после добавления
            KafBox.Clear();

            LoadExistingData();
            MessageBox.Show("Кафедра успешно добавлена", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void KafedraGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Обработка клика по ячейке (если необходимо)
        }

        private void KafBox_TextChanged(object sender, EventArgs e)
        {
            // Обработка изменения текста (если необходимо)
        }

        private void kafedraBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}