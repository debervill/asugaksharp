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
            комиссииToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem = new ToolStripMenuItem();
            добавиьЛюдейToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem1 = new ToolStripMenuItem();
            label1 = new Label();
            гЭКиToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { главнаяToolStripMenuItem, комиссииToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 2, 0, 2);
            menuStrip1.Size = new Size(700, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // главнаяToolStripMenuItem
            // 
            главнаяToolStripMenuItem.Name = "главнаяToolStripMenuItem";
            главнаяToolStripMenuItem.Size = new Size(63, 20);
            главнаяToolStripMenuItem.Text = "Главная";
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
            // добавиьЛюдейToolStripMenuItem
            // 
            добавиьЛюдейToolStripMenuItem.Name = "добавиьЛюдейToolStripMenuItem";
            добавиьЛюдейToolStripMenuItem.Size = new Size(174, 22);
            добавиьЛюдейToolStripMenuItem.Text = "Люди";
            // 
            // добавитьToolStripMenuItem1
            // 
            добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            добавитьToolStripMenuItem1.Size = new Size(174, 22);
            добавитьToolStripMenuItem1.Text = "Списки студентов";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 55F);
            label1.Location = new Point(78, 110);
            label1.Name = "label1";
            label1.Size = new Size(516, 99);
            label1.TabIndex = 1;
            label1.Text = "ДА БУДЕТ ГЭК";
            // 
            // гЭКиToolStripMenuItem
            // 
            гЭКиToolStripMenuItem.Name = "гЭКиToolStripMenuItem";
            гЭКиToolStripMenuItem.Size = new Size(174, 22);
            гЭКиToolStripMenuItem.Text = "ГЭКи";
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
    }
}
