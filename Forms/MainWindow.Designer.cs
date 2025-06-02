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
            главнаяToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            комиссииToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem = new ToolStripMenuItem();
            гЭКиToolStripMenuItem = new ToolStripMenuItem();
            добавиьЛюдейToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem1 = new ToolStripMenuItem();
            справочныеДанныеToolStripMenuItem = new ToolStripMenuItem();
            направленияПодготовкиToolStripMenuItem = new ToolStripMenuItem();
            профилиПодготовкиToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            экспериментыToolStripMenuItem = new ToolStripMenuItem();
            листБоксToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { главнаяToolStripMenuItem, комиссииToolStripMenuItem, справочныеДанныеToolStripMenuItem, экспериментыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 2, 0, 2);
            menuStrip1.Size = new Size(700, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // главнаяToolStripMenuItem
            // 
            главнаяToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { настройкиToolStripMenuItem });
            главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            главнаяToolStripMenuItem.Size = new Size(63, 20);
            главнаяToolStripMenuItem.Text = "Главная";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(134, 22);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // комиссииToolStripMenuItem
            // 
            комиссииToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьToolStripMenuItem, гЭКиToolStripMenuItem, добавиьЛюдейToolStripMenuItem, добавитьToolStripMenuItem1 });
            комиссииToolStripMenuItem.Name = "комиссииToolStripMenuItem";
            комиссииToolStripMenuItem.Size = new Size(75, 20);
            комиссииToolStripMenuItem.Text = "Комиссии";
            // 
            // добавитьToolStripMenuItem
            // 
            добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            добавитьToolStripMenuItem.Size = new Size(174, 22);
            добавитьToolStripMenuItem.Text = "Период заседания";
            добавитьToolStripMenuItem.Click += добавитьToolStripMenuItem_Click_1;
            // 
            // гЭКиToolStripMenuItem
            // 
            гЭКиToolStripMenuItem.Name = "гЭКиToolStripMenuItem";
            гЭКиToolStripMenuItem.Size = new Size(174, 22);
            гЭКиToolStripMenuItem.Text = "ГЭКи";
            гЭКиToolStripMenuItem.Click += гЭКиToolStripMenuItem_Click;
            // 
            // добавиьЛюдейToolStripMenuItem
            // 
            добавиьЛюдейToolStripMenuItem.Name = "добавиьЛюдейToolStripMenuItem";
            добавиьЛюдейToolStripMenuItem.Size = new Size(174, 22);
            добавиьЛюдейToolStripMenuItem.Text = "Люди";
            добавиьЛюдейToolStripMenuItem.Click += добавиьЛюдейToolStripMenuItem_Click;
            // 
            // добавитьToolStripMenuItem1
            // 
            добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            добавитьToolStripMenuItem1.Size = new Size(174, 22);
            добавитьToolStripMenuItem1.Text = "Списки студентов";
            добавитьToolStripMenuItem1.Click += добавитьToolStripMenuItem1_Click;
            // 
            // справочныеДанныеToolStripMenuItem
            // 
            справочныеДанныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { направленияПодготовкиToolStripMenuItem, профилиПодготовкиToolStripMenuItem, toolStripMenuItem2 });
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
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem главнаяToolStripMenuItem;
        private ToolStripMenuItem комиссииToolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem добавиьЛюдейToolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem1;
        private Label label1;
        private ToolStripMenuItem гЭКиToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem экспериментыToolStripMenuItem;
        private ToolStripMenuItem листБоксToolStripMenuItem;
        private ToolStripMenuItem справочныеДанныеToolStripMenuItem;
        private ToolStripMenuItem направленияПодготовкиToolStripMenuItem;
        private ToolStripMenuItem профилиПодготовкиToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
    }
}
