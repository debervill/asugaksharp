namespace asugaksharp.Forms
{
    partial class MainWindowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
<<<<<<< HEAD
            btnNaprPodg = new Button();
            btnProfiliPodg = new Button();
            btnStudents = new Button();
            btnAddPerson = new Button();
            btnOplata = new Button();
            btnGAK = new Button();
            btnAddPeriodZ = new Button();
            
=======
            menuStrip1 = new MenuStrip();
            главнаяToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            комиссииToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem = new ToolStripMenuItem();
            гЭКиToolStripMenuItem = new ToolStripMenuItem();
            добавиьЛюдейToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem1 = new ToolStripMenuItem();
            оплатаToolStripMenuItem = new ToolStripMenuItem();
            справочныеДанныеToolStripMenuItem = new ToolStripMenuItem();
            направленияПодготовкиToolStripMenuItem = new ToolStripMenuItem();
            профилиПодготовкиToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            кафедрыToolStripMenuItem = new ToolStripMenuItem();
            экспериментыToolStripMenuItem = new ToolStripMenuItem();
            листБоксToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0
            // 
            // btnNaprPodg
            // 
            btnNaprPodg.Location = new Point(12, 12);
            btnNaprPodg.Name = "btnNaprPodg";
            btnNaprPodg.Size = new Size(200, 29);
            btnNaprPodg.Text = "Направления подготовки";
            btnNaprPodg.Click += btnNaprPodg_Click;
            // 
            // btnProfiliPodg
            // 
            btnProfiliPodg.Location = new Point(12, 47);
            btnProfiliPodg.Name = "btnProfiliPodg";
            btnProfiliPodg.Size = new Size(200, 29);
            btnProfiliPodg.Text = "Профили подготовки";
            btnProfiliPodg.Click += btnProfiliPodg_Click;
            // 
            // btnStudents
            // 
<<<<<<< HEAD
            btnStudents.Location = new Point(12, 82);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(200, 29);
            btnStudents.Text = "Студенты";
            btnStudents.Click += btnStudents_Click;
=======
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(180, 22);
            настройкиToolStripMenuItem.Text = "Настройки";
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0
            // 
            // btnAddPerson
            // 
            btnAddPerson.Location = new Point(12, 117);
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.Size = new Size(200, 29);
            btnAddPerson.Text = "Добавить участника ГАК";
            btnAddPerson.Click += btnAddPerson_Click;
            // 
            // btnOplata
            // 
            btnOplata.Location = new Point(12, 152);
            btnOplata.Name = "btnOplata";
            btnOplata.Size = new Size(200, 29);
            btnOplata.Text = "Оплата";
            btnOplata.Click += btnOplata_Click;
            // 
            // btnGAK
            // 
            btnGAK.Location = new Point(12, 187);
            btnGAK.Name = "btnGAK";
            btnGAK.Size = new Size(200, 29);
            btnGAK.Text = "ГАК";
            btnGAK.Click += btnGAK_Click;
            // 
            // btnAddPeriodZ
            // 
            btnAddPeriodZ.Location = new Point(12, 222);
            btnAddPeriodZ.Name = "btnAddPeriodZ";
            btnAddPeriodZ.Size = new Size(200, 29);
            btnAddPeriodZ.Text = "Добавить период заседания";
            btnAddPeriodZ.Click += btnAddPeriodZ_Click;
            // 
            // MainWindowForm
            // 
<<<<<<< HEAD
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 264);
            Controls.Add(btnNaprPodg);
            Controls.Add(btnProfiliPodg);
            Controls.Add(btnStudents);
            Controls.Add(btnAddPerson);
            Controls.Add(btnOplata);
            Controls.Add(btnGAK);
            Controls.Add(btnAddPeriodZ);
            Name = "MainWindowForm";
            Text = "Главное окно";
=======
            добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            добавитьToolStripMenuItem1.Size = new Size(174, 22);
            добавитьToolStripMenuItem1.Text = "Списки студентов";
            добавитьToolStripMenuItem1.Click += добавитьToolStripMenuItem1_Click;
            // 
            // оплатаToolStripMenuItem
            // 
            оплатаToolStripMenuItem.Name = "оплатаToolStripMenuItem";
            оплатаToolStripMenuItem.Size = new Size(174, 22);
            оплатаToolStripMenuItem.Text = "Оплата";
            оплатаToolStripMenuItem.Click += оплатаToolStripMenuItem_Click;
            // 
            // справочныеДанныеToolStripMenuItem
            // 
            справочныеДанныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { направленияПодготовкиToolStripMenuItem, профилиПодготовкиToolStripMenuItem, toolStripMenuItem2, кафедрыToolStripMenuItem });
            справочныеДанныеToolStripMenuItem.Name = "справочныеДанныеToolStripMenuItem";
            справочныеДанныеToolStripMenuItem.Size = new Size(133, 20);
            справочныеДанныеToolStripMenuItem.Text = "Справочные данные";
            // 
            // направленияПодготовкиToolStripMenuItem
            // 
            направленияПодготовкиToolStripMenuItem.Name = "направленияПодготовкиToolStripMenuItem";
            направленияПодготовкиToolStripMenuItem.Size = new Size(214, 22);
            направленияПодготовкиToolStripMenuItem.Text = "Направления подготовки";
            направленияПодготовкиToolStripMenuItem.Click += направленияПодготовкиToolStripMenuItem_Click;
            // 
            // профилиПодготовкиToolStripMenuItem
            // 
            профилиПодготовкиToolStripMenuItem.Name = "профилиПодготовкиToolStripMenuItem";
            профилиПодготовкиToolStripMenuItem.Size = new Size(214, 22);
            профилиПодготовкиToolStripMenuItem.Text = "Профили подготовки";
            профилиПодготовкиToolStripMenuItem.Click += профилиПодготовкиToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(214, 22);
            toolStripMenuItem2.Text = "Звания и стпени";
            // 
            // кафедрыToolStripMenuItem
            // 
            кафедрыToolStripMenuItem.Name = "кафедрыToolStripMenuItem";
            кафедрыToolStripMenuItem.Size = new Size(214, 22);
            кафедрыToolStripMenuItem.Text = "Кафедры";
            кафедрыToolStripMenuItem.Click += кафедрыToolStripMenuItem_Click;
            // 
            // экспериментыToolStripMenuItem
            // 
            экспериментыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { листБоксToolStripMenuItem });
            экспериментыToolStripMenuItem.Name = "экспериментыToolStripMenuItem";
            экспериментыToolStripMenuItem.Size = new Size(101, 20);
            экспериментыToolStripMenuItem.Text = "Эксперименты";
            // 
            // листБоксToolStripMenuItem
            // 
            листБоксToolStripMenuItem.Name = "листБоксToolStripMenuItem";
            листБоксToolStripMenuItem.Size = new Size(140, 22);
            листБоксToolStripMenuItem.Text = "2 лист бокс ";
            листБоксToolStripMenuItem.Click += листБоксToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 55F);
            label1.Location = new Point(94, 114);
            label1.Name = "label1";
            label1.Size = new Size(516, 99);
            label1.TabIndex = 1;
            label1.Text = "ДА БУДЕТ ГЭК";
       
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += MainWindowForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
>>>>>>> 83269766ffcc4605752b2bcc29b8478ea34000e0
        }

        #endregion

        private Button btnNaprPodg;
        private Button btnProfiliPodg;
        private Button btnStudents;
        private Button btnAddPerson;
        private Button btnOplata;
        private Button btnGAK;
        private Button btnAddPeriodZ;
    }
}