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
            оплатаToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            персоныToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { главнаяToolStripMenuItem, оплатаToolStripMenuItem, настройкиToolStripMenuItem, персоныToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // главнаяToolStripMenuItem
            // 
            главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            главнаяToolStripMenuItem.Size = new Size(79, 24);
            главнаяToolStripMenuItem.Text = "Главная";
            // 
            // оплатаToolStripMenuItem
            // 
            оплатаToolStripMenuItem.Name = "оплатаToolStripMenuItem";
            оплатаToolStripMenuItem.Size = new Size(73, 24);
            оплатаToolStripMenuItem.Text = "Оплата";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(98, 24);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // персоныToolStripMenuItem
            // 
            персоныToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьToolStripMenuItem });
            персоныToolStripMenuItem.Name = "персоныToolStripMenuItem";
            персоныToolStripMenuItem.Size = new Size(87, 24);
            персоныToolStripMenuItem.Text = "Персоны";
            // 
            // добавитьToolStripMenuItem
            // 
            добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            добавитьToolStripMenuItem.Size = new Size(224, 26);
            добавитьToolStripMenuItem.Text = "Добавить";
            добавитьToolStripMenuItem.Click += добавитьToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
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
        private ToolStripMenuItem оплатаToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem персоныToolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem;
    }
}
