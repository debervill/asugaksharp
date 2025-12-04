//using asugaksharp.ApplicationLayer.Interface;

using asugaksharp.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace asugaksharp.Presentation
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        // ✅ Конструктор с DI
        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            кафедраToolStripMenuItem = new ToolStripMenuItem();
            кафедраToolStripMenuItem1 = new ToolStripMenuItem();
            направлениеПодготовкиToolStripMenuItem = new ToolStripMenuItem();
            профильПодготовкиToolStripMenuItem = new ToolStripMenuItem();
            дипломникToolStripMenuItem = new ToolStripMenuItem();
            оплатаToolStripMenuItem = new ToolStripMenuItem();
            personToolStripMenuItem = new ToolStripMenuItem();
            добавитьЧеловекаToolStripMenuItem = new ToolStripMenuItem();
            разноеТестовоеToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { кафедраToolStripMenuItem, оплатаToolStripMenuItem, personToolStripMenuItem, разноеТестовоеToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(830, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // кафедраToolStripMenuItem
            // 
            кафедраToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { кафедраToolStripMenuItem1, направлениеПодготовкиToolStripMenuItem, профильПодготовкиToolStripMenuItem, дипломникToolStripMenuItem });
            кафедраToolStripMenuItem.Name = "кафедраToolStripMenuItem";
            кафедраToolStripMenuItem.Size = new Size(83, 24);
            кафедраToolStripMenuItem.Text = "Кафедра";
            // 
            // кафедраToolStripMenuItem1
            // 
            кафедраToolStripMenuItem1.Name = "кафедраToolStripMenuItem1";
            кафедраToolStripMenuItem1.Size = new Size(271, 26);
            кафедраToolStripMenuItem1.Text = "Кафедра";
            кафедраToolStripMenuItem1.Click += кафедраToolStripMenuItem1_Click;
            // 
            // направлениеПодготовкиToolStripMenuItem
            // 
            направлениеПодготовкиToolStripMenuItem.Name = "направлениеПодготовкиToolStripMenuItem";
            направлениеПодготовкиToolStripMenuItem.Size = new Size(271, 26);
            направлениеПодготовкиToolStripMenuItem.Text = "Направление подготовки";
            // 
            // профильПодготовкиToolStripMenuItem
            // 
            профильПодготовкиToolStripMenuItem.Name = "профильПодготовкиToolStripMenuItem";
            профильПодготовкиToolStripMenuItem.Size = new Size(271, 26);
            профильПодготовкиToolStripMenuItem.Text = "Профиль подготовки";
            // 
            // дипломникToolStripMenuItem
            // 
            дипломникToolStripMenuItem.Name = "дипломникToolStripMenuItem";
            дипломникToolStripMenuItem.Size = new Size(271, 26);
            дипломникToolStripMenuItem.Text = "Дипломник";
            // 
            // оплатаToolStripMenuItem
            // 
            оплатаToolStripMenuItem.Name = "оплатаToolStripMenuItem";
            оплатаToolStripMenuItem.Size = new Size(73, 24);
            оплатаToolStripMenuItem.Text = "Оплата";
            // 
            // personToolStripMenuItem
            // 
            personToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьЧеловекаToolStripMenuItem });
            personToolStripMenuItem.Name = "personToolStripMenuItem";
            personToolStripMenuItem.Size = new Size(66, 24);
            personToolStripMenuItem.Text = "Person";
            // 
            // добавитьЧеловекаToolStripMenuItem
            // 
            добавитьЧеловекаToolStripMenuItem.Name = "добавитьЧеловекаToolStripMenuItem";
            добавитьЧеловекаToolStripMenuItem.Size = new Size(227, 26);
            добавитьЧеловекаToolStripMenuItem.Text = "Добавить человека";
            // 
            // разноеТестовоеToolStripMenuItem
            // 
            разноеТестовоеToolStripMenuItem.Name = "разноеТестовоеToolStripMenuItem";
            разноеТестовоеToolStripMenuItem.Size = new Size(137, 24);
            разноеТестовоеToolStripMenuItem.Text = "Разное тестовое";
            // 
            // MainForm
            // 
            ClientSize = new Size(830, 362);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        private MenuStrip menuStrip1;
        private ToolStripMenuItem кафедраToolStripMenuItem;
        private ToolStripMenuItem кафедраToolStripMenuItem1;
        private ToolStripMenuItem направлениеПодготовкиToolStripMenuItem;
        private ToolStripMenuItem профильПодготовкиToolStripMenuItem;
        private ToolStripMenuItem дипломникToolStripMenuItem;
        private ToolStripMenuItem оплатаToolStripMenuItem;
        private ToolStripMenuItem personToolStripMenuItem;
        private ToolStripMenuItem добавитьЧеловекаToolStripMenuItem;
        private ToolStripMenuItem разноеТестовоеToolStripMenuItem;

        private void кафедраToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var kafedraForm = _serviceProvider.GetRequiredService<KafedraForm>();
                kafedraForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}