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
            comboBox1 = new ComboBox();
            periodZasedaniaBindingSource = new BindingSource(components);
            label3 = new Label();
            label4 = new Label();
            comboBox2 = new ComboBox();
            kafedraBindingSource = new BindingSource(components);
            BtnAddZasedanie = new Button();
            ((System.ComponentModel.ISupportInitialize)periodZasedaniaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(354, 27);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 0;
            label1.Text = "ГЭКИ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 65);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Добавить";
            // 
            // comboBox1
            // 
            comboBox1.DataSource = periodZasedaniaBindingSource;
            comboBox1.DisplayMember = "Name";
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(204, 93);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(366, 23);
            comboBox1.TabIndex = 2;
            // 
            // periodZasedaniaBindingSource
            // 
            periodZasedaniaBindingSource.DataSource = typeof(Model.PeriodZasedania);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 96);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 3;
            label3.Text = "Набор заседаний";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(81, 136);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 5;
            label4.Text = "Кафедра";
            
            // 
            // comboBox2
            // 
            comboBox2.DataSource = kafedraBindingSource;
            comboBox2.DisplayMember = "Name";
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(204, 133);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(366, 23);
            comboBox2.TabIndex = 4;
            comboBox2.SelectedIndexChanged +=  comboBox2_SelectedIndexChanged;
            // 
            // kafedraBindingSource
            // 
            kafedraBindingSource.DataSource = typeof(Model.Kafedra);
            // 
            // BtnAddZasedanie
            // 
            BtnAddZasedanie.Location = new Point(81, 196);
            BtnAddZasedanie.Name = "BtnAddZasedanie";
            BtnAddZasedanie.Size = new Size(75, 23);
            BtnAddZasedanie.TabIndex = 6;
            BtnAddZasedanie.Text = "Добавить заседание";
            BtnAddZasedanie.UseVisualStyleBackColor = true;
            BtnAddZasedanie.Click += BtnAddZasedanie_Click;
            // 
            // Gak
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtnAddZasedanie);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Gak";
            Text = "Gak";
            ((System.ComponentModel.ISupportInitialize)periodZasedaniaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private BindingSource periodZasedaniaBindingSource;
        private Label label3;
        private Label label4;
        private ComboBox comboBox2;
        private BindingSource kafedraBindingSource;
        private Button BtnAddZasedanie;
    }
}