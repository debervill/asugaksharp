namespace asugaksharp.Forms
{
    partial class GakForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            PerodZasedBox = new ComboBox();
            periodZasedaniaBindingSource = new BindingSource(components);
            label3 = new Label();
            label4 = new Label();
            kafedraBox = new ComboBox();
            kafedraBindingSource = new BindingSource(components);
            BtnAddZasedanie = new Button();
            ((System.ComponentModel.ISupportInitialize)periodZasedaniaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(405, 36);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 0;
            label1.Text = "ГЭКИ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 87);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 1;
            label2.Text = "Добавить";
            // 
            // PerodZasedBox
            // 
            PerodZasedBox.DataSource = periodZasedaniaBindingSource;
            PerodZasedBox.DisplayMember = "Name";
            PerodZasedBox.FormattingEnabled = true;
            PerodZasedBox.Location = new Point(233, 124);
            PerodZasedBox.Margin = new Padding(3, 4, 3, 4);
            PerodZasedBox.Name = "PerodZasedBox";
            PerodZasedBox.Size = new Size(418, 28);
            PerodZasedBox.TabIndex = 2;

            // 
            // periodZasedaniaBindingSource
            // 
            periodZasedaniaBindingSource.DataSource = typeof(PeriodZasedania);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 128);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 3;
            label3.Text = "Набор заседаний";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 181);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 5;
            label4.Text = "Кафедра";
            // 
            // kafedraBox
            // 
            kafedraBox.DataSource = kafedraBindingSource;
            kafedraBox.DisplayMember = "Name";
            kafedraBox.FormattingEnabled = true;
            kafedraBox.Location = new Point(233, 177);
            kafedraBox.Margin = new Padding(3, 4, 3, 4);
            kafedraBox.Name = "kafedraBox";
            kafedraBox.Size = new Size(418, 28);
            kafedraBox.TabIndex = 4;
            kafedraBox.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // kafedraBindingSource
            // 
            kafedraBindingSource.DataSource = typeof(Kafedra);
            // 
            // BtnAddZasedanie
            // 
            BtnAddZasedanie.Location = new Point(93, 261);
            BtnAddZasedanie.Margin = new Padding(3, 4, 3, 4);
            BtnAddZasedanie.Name = "BtnAddZasedanie";
            BtnAddZasedanie.Size = new Size(86, 31);
            BtnAddZasedanie.TabIndex = 6;
            BtnAddZasedanie.Text = "Добавить заседание";
            BtnAddZasedanie.UseVisualStyleBackColor = true;
            BtnAddZasedanie.Click += BtnAddZasedanie_Click;
            // 
            // GakForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(BtnAddZasedanie);
            Controls.Add(label4);
            Controls.Add(kafedraBox);
            Controls.Add(label3);
            Controls.Add(PerodZasedBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GakForm";
            Text = "Gak";
            ((System.ComponentModel.ISupportInitialize)periodZasedaniaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox PerodZasedBox;
        private BindingSource periodZasedaniaBindingSource;
        private Label label3;
        private Label label4;
        private ComboBox kafedraBox;
        private BindingSource kafedraBindingSource;
        private Button BtnAddZasedanie;
    }
}