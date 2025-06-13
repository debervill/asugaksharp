namespace asugaksharp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            обучениеToolStripMenuItem = new ToolStripMenuItem();
            направленияПодготовкиToolStripMenuItem = new ToolStripMenuItem();
            профилиПодготовкиToolStripMenuItem = new ToolStripMenuItem();
            студентыToolStripMenuItem = new ToolStripMenuItem();
            персоналToolStripMenuItem = new ToolStripMenuItem();
            добавитьСотрудникаToolStripMenuItem = new ToolStripMenuItem();
            гАКToolStripMenuItem = new ToolStripMenuItem();
            заседанияГЭКToolStripMenuItem = new ToolStripMenuItem();
            периодыЗаседанийToolStripMenuItem = new ToolStripMenuItem();
            финансыToolStripMenuItem = new ToolStripMenuItem();
            оплатаToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { обучениеToolStripMenuItem, персоналToolStripMenuItem, гАКToolStripMenuItem, финансыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(584, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // обучениеToolStripMenuItem
            // 
            обучениеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { направленияПодготовкиToolStripMenuItem, профилиПодготовкиToolStripMenuItem, студентыToolStripMenuItem });
            обучениеToolStripMenuItem.Name = "обучениеToolStripMenuItem";
            обучениеToolStripMenuItem.Size = new Size(74, 20);
            обучениеToolStripMenuItem.Text = "Обучение";
            // 
            // направленияПодготовкиToolStripMenuItem
            // 
            направленияПодготовкиToolStripMenuItem.Name = "направленияПодготовкиToolStripMenuItem";
            направленияПодготовкиToolStripMenuItem.Size = new Size(207, 22);
            направленияПодготовкиToolStripMenuItem.Text = "Направления подготовки";
            направленияПодготовкиToolStripMenuItem.Click += btnNaprPodg_Click;
            // 
            // профилиПодготовкиToolStripMenuItem
            // 
            профилиПодготовкиToolStripMenuItem.Name = "профилиПодготовкиToolStripMenuItem";
            профилиПодготовкиToolStripMenuItem.Size = new Size(207, 22);
            профилиПодготовкиToolStripMenuItem.Text = "Профили подготовки";
            профилиПодготовкиToolStripMenuItem.Click += btnProfiliPodg_Click;
            // 
            // студентыToolStripMenuItem
            // 
            студентыToolStripMenuItem.Name = "студентыToolStripMenuItem";
            студентыToolStripMenuItem.Size = new Size(207, 22);
            студентыToolStripMenuItem.Text = "Студенты";
            студентыToolStripMenuItem.Click += btnStudents_Click;
            // 
            // персоналToolStripMenuItem
            // 
            персоналToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьСотрудникаToolStripMenuItem });
            персоналToolStripMenuItem.Name = "персоналToolStripMenuItem";
            персоналToolStripMenuItem.Size = new Size(74, 20);
            персоналToolStripMenuItem.Text = "Персонал";
            // 
            // добавитьСотрудникаToolStripMenuItem
            // 
            добавитьСотрудникаToolStripMenuItem.Name = "добавитьСотрудникаToolStripMenuItem";
            добавитьСотрудникаToolStripMenuItem.Size = new Size(194, 22);
            добавитьСотрудникаToolStripMenuItem.Text = "Добавить сотрудника";
            добавитьСотрудникаToolStripMenuItem.Click += btnAddPerson_Click;
            // 
            // гАКToolStripMenuItem
            // 
            гАКToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { заседанияГЭКToolStripMenuItem, периодыЗаседанийToolStripMenuItem });
            гАКToolStripMenuItem.Name = "гАКToolStripMenuItem";
            гАКToolStripMenuItem.Size = new Size(39, 20);
            гАКToolStripMenuItem.Text = "ГАК";
            // 
            // заседанияГЭКToolStripMenuItem
            // 
            заседанияГЭКToolStripMenuItem.Name = "заседанияГЭКToolStripMenuItem";
            заседанияГЭКToolStripMenuItem.Size = new Size(180, 22);
            заседанияГЭКToolStripMenuItem.Text = "Заседания ГЭК";
            заседанияГЭКToolStripMenuItem.Click += btnGAK_Click;
            // 
            // периодыЗаседанийToolStripMenuItem
            // 
            периодыЗаседанийToolStripMenuItem.Name = "периодыЗаседанийToolStripMenuItem";
            периодыЗаседанийToolStripMenuItem.Size = new Size(180, 22);
            периодыЗаседанийToolStripMenuItem.Text = "Периоды заседаний";
            //периодыЗаседанийToolStripMenuItem.Click += btnAddPeriodZ_Click;
            // 
            // финансыToolStripMenuItem
            // 
            финансыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { оплатаToolStripMenuItem });
            финансыToolStripMenuItem.Name = "финансыToolStripMenuItem";
            финансыToolStripMenuItem.Size = new Size(71, 20);
            финансыToolStripMenuItem.Text = "Финансы";
            // 
            // оплатаToolStripMenuItem
            // 
            оплатаToolStripMenuItem.Name = "оплатаToolStripMenuItem";
            оплатаToolStripMenuItem.Size = new Size(180, 22);
            оплатаToolStripMenuItem.Text = "Оплата";
            оплатаToolStripMenuItem.Click += btnOplata_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "АСУ ГАК";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem обучениеToolStripMenuItem;
        private ToolStripMenuItem направленияПодготовкиToolStripMenuItem;
        private ToolStripMenuItem профилиПодготовкиToolStripMenuItem;
        private ToolStripMenuItem студентыToolStripMenuItem;
        private ToolStripMenuItem персоналToolStripMenuItem;
        private ToolStripMenuItem добавитьСотрудникаToolStripMenuItem;
        private ToolStripMenuItem гАКToolStripMenuItem;
        private ToolStripMenuItem заседанияГЭКToolStripMenuItem;
        private ToolStripMenuItem периодыЗаседанийToolStripMenuItem;
        private ToolStripMenuItem финансыToolStripMenuItem;
        private ToolStripMenuItem оплатаToolStripMenuItem;
    }
}