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
            комсиияToolStripMenuItem = new ToolStripMenuItem();
            оплатаToolStripMenuItem = new ToolStripMenuItem();
            настройкиToolStripMenuItem = new ToolStripMenuItem();
            добавитьКомиссиюToolStripMenuItem = new ToolStripMenuItem();
            добавитьПреподавателяToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { главнаяToolStripMenuItem, комсиияToolStripMenuItem, оплатаToolStripMenuItem, настройкиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1000, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // главнаяToolStripMenuItem
            // 
            главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            главнаяToolStripMenuItem.Size = new Size(92, 29);
            главнаяToolStripMenuItem.Text = "Главная";
            // 
            // комсиияToolStripMenuItem
            // 
            комсиияToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьКомиссиюToolStripMenuItem, добавитьПреподавателяToolStripMenuItem });
            комсиияToolStripMenuItem.Name = "комсиияToolStripMenuItem";
            комсиияToolStripMenuItem.Size = new Size(99, 29);
            комсиияToolStripMenuItem.Text = "Комсиия";
            // 
            // оплатаToolStripMenuItem
            // 
            оплатаToolStripMenuItem.Name = "оплатаToolStripMenuItem";
            оплатаToolStripMenuItem.Size = new Size(86, 29);
            оплатаToolStripMenuItem.Text = "Оплата";
            // 
            // настройкиToolStripMenuItem
            // 
            настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            настройкиToolStripMenuItem.Size = new Size(116, 29);
            настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // добавитьКомиссиюToolStripMenuItem
            // 
            добавитьКомиссиюToolStripMenuItem.Name = "добавитьКомиссиюToolStripMenuItem";
            добавитьКомиссиюToolStripMenuItem.Size = new Size(320, 34);
            добавитьКомиссиюToolStripMenuItem.Text = "Добавить комиссию";
            // 
            // добавитьПреподавателяToolStripMenuItem
            // 
            добавитьПреподавателяToolStripMenuItem.Name = "добавитьПреподавателяToolStripMenuItem";
            добавитьПреподавателяToolStripMenuItem.Size = new Size(320, 34);
            добавитьПреподавателяToolStripMenuItem.Text = "Добавить преподавателя";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(menuStrip1);
            Margin = new Padding(4);
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
        private ToolStripMenuItem комсиияToolStripMenuItem;
        private ToolStripMenuItem оплатаToolStripMenuItem;
        private ToolStripMenuItem настройкиToolStripMenuItem;
        private ToolStripMenuItem добавитьКомиссиюToolStripMenuItem;
        private ToolStripMenuItem добавитьПреподавателяToolStripMenuItem;
    }
}
