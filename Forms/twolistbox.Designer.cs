
namespace asugaksharp.Forms
{
    partial class twolistbox
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
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "Item11", "Item12", "Item13", "Item14", "Item15", "Item16", "Item17", "Item18", "Item19" });
            listBox1.Location = new Point(85, 36);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 334);
            listBox1.TabIndex = 0;
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Items.AddRange(new object[] { "Item21", "Item22", "Item23", "Item24", "Item25", "Item26", "Item27", "Item28" });
            listBox2.Location = new Point(363, 36);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(120, 334);
            listBox2.TabIndex = 1;
            listBox2.SelectionMode = SelectionMode.MultiExtended;
            // 
            // button1
            // 
            button1.Location = new Point(249, 167);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Туда >";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(249, 210);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "< Сюда";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // twolistbox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 423);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Name = "twolistbox";
            Text = "twolistbox";
            ResumeLayout(false);
        }



        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private Button button1;
        private Button button2;
    }
}