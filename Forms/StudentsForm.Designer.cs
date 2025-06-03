namespace asugaksharp.Forms
{
    partial class StudentsForm
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            NameImBox = new TextBox();
            OtchImbox = new TextBox();
            Famimbox = new TextBox();
            label6 = new Label();
            NameRodBox = new TextBox();
            OtchRodBox = new TextBox();
            FamRodBox = new TextBox();
            Sex = new ComboBox();
            diplomnikBindingSource = new BindingSource(components);
            personBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            fioImenDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fioRoditDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sexDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pagesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            temaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            origVkrDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            srballDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            BtnStudChange = new Button();
            BtnStudSclon = new Button();
            label7 = new Label();
            label8 = new Label();
            textBox1 = new TextBox();
            label9 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label10 = new Label();
            comboBox3 = new ComboBox();
            label11 = new Label();
            comboBox4 = new ComboBox();
            label12 = new Label();
            comboBox5 = new ComboBox();
            label13 = new Label();
            BtnChooseFile = new Button();
            BtnStudAdd = new Button();
            ImportFromFile = new GroupBox();
            BtnRunImport = new Button();
            ((System.ComponentModel.ISupportInitialize)diplomnikBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ImportFromFile.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(394, 17);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Студенты";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 101);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 1;
            label2.Text = "ИМя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 131);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 166);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 3;
            label4.Text = "Фамилия";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 198);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 4;
            label5.Text = "Пол";
            // 
            // NameImBox
            // 
            NameImBox.Location = new Point(154, 98);
            NameImBox.Name = "NameImBox";
            NameImBox.Size = new Size(354, 23);
            NameImBox.TabIndex = 5;
            // 
            // OtchImbox
            // 
            OtchImbox.Location = new Point(154, 132);
            OtchImbox.Name = "OtchImbox";
            OtchImbox.Size = new Size(354, 23);
            OtchImbox.TabIndex = 6;
            // 
            // Famimbox
            // 
            Famimbox.Location = new Point(154, 166);
            Famimbox.Name = "Famimbox";
            Famimbox.Size = new Size(354, 23);
            Famimbox.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(154, 55);
            label6.Name = "label6";
            label6.Size = new Size(92, 15);
            label6.TabIndex = 8;
            label6.Text = "Именительный";
            // 
            // NameRodBox
            // 
            NameRodBox.Location = new Point(531, 101);
            NameRodBox.Name = "NameRodBox";
            NameRodBox.Size = new Size(482, 23);
            NameRodBox.TabIndex = 9;
            // 
            // OtchRodBox
            // 
            OtchRodBox.Location = new Point(531, 132);
            OtchRodBox.Name = "OtchRodBox";
            OtchRodBox.Size = new Size(482, 23);
            OtchRodBox.TabIndex = 10;
            // 
            // FamRodBox
            // 
            FamRodBox.Location = new Point(531, 166);
            FamRodBox.Name = "FamRodBox";
            FamRodBox.Size = new Size(482, 23);
            FamRodBox.TabIndex = 11;
            // 
            // Sex
            // 
            Sex.Items.AddRange(new object[] { "муж", "жен" });
            Sex.Location = new Point(154, 198);
            Sex.Name = "Sex";
            Sex.Size = new Size(355, 23);
            Sex.TabIndex = 12;
            // 
            // diplomnikBindingSource
            // 
            diplomnikBindingSource.DataSource = typeof(Model.Diplomnik);
            // 
            // personBindingSource
            // 
            personBindingSource.DataSource = typeof(Model.Person);
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { fioImenDataGridViewTextBoxColumn, fioRoditDataGridViewTextBoxColumn, sexDataGridViewTextBoxColumn, pagesDataGridViewTextBoxColumn, temaDataGridViewTextBoxColumn, origVkrDataGridViewTextBoxColumn, srballDataGridViewTextBoxColumn });
            dataGridView1.DataSource = diplomnikBindingSource;
            dataGridView1.Location = new Point(67, 555);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1082, 289);
            dataGridView1.TabIndex = 13;
            // 
            // fioImenDataGridViewTextBoxColumn
            // 
            fioImenDataGridViewTextBoxColumn.DataPropertyName = "FioImen";
            fioImenDataGridViewTextBoxColumn.HeaderText = "FioImen";
            fioImenDataGridViewTextBoxColumn.Name = "fioImenDataGridViewTextBoxColumn";
            // 
            // fioRoditDataGridViewTextBoxColumn
            // 
            fioRoditDataGridViewTextBoxColumn.DataPropertyName = "FioRodit";
            fioRoditDataGridViewTextBoxColumn.HeaderText = "FioRodit";
            fioRoditDataGridViewTextBoxColumn.Name = "fioRoditDataGridViewTextBoxColumn";
            // 
            // sexDataGridViewTextBoxColumn
            // 
            sexDataGridViewTextBoxColumn.DataPropertyName = "Sex";
            sexDataGridViewTextBoxColumn.HeaderText = "Sex";
            sexDataGridViewTextBoxColumn.Name = "sexDataGridViewTextBoxColumn";
            // 
            // pagesDataGridViewTextBoxColumn
            // 
            pagesDataGridViewTextBoxColumn.DataPropertyName = "Pages";
            pagesDataGridViewTextBoxColumn.HeaderText = "Pages";
            pagesDataGridViewTextBoxColumn.Name = "pagesDataGridViewTextBoxColumn";
            // 
            // temaDataGridViewTextBoxColumn
            // 
            temaDataGridViewTextBoxColumn.DataPropertyName = "Tema";
            temaDataGridViewTextBoxColumn.HeaderText = "Tema";
            temaDataGridViewTextBoxColumn.Name = "temaDataGridViewTextBoxColumn";
            // 
            // origVkrDataGridViewTextBoxColumn
            // 
            origVkrDataGridViewTextBoxColumn.DataPropertyName = "OrigVkr";
            origVkrDataGridViewTextBoxColumn.HeaderText = "OrigVkr";
            origVkrDataGridViewTextBoxColumn.Name = "origVkrDataGridViewTextBoxColumn";
            // 
            // srballDataGridViewTextBoxColumn
            // 
            srballDataGridViewTextBoxColumn.DataPropertyName = "Srball";
            srballDataGridViewTextBoxColumn.HeaderText = "Srball";
            srballDataGridViewTextBoxColumn.Name = "srballDataGridViewTextBoxColumn";
            // 
            // BtnStudChange
            // 
            BtnStudChange.Location = new Point(611, 1001);
            BtnStudChange.Name = "BtnStudChange";
            BtnStudChange.Size = new Size(75, 23);
            BtnStudChange.TabIndex = 15;
            BtnStudChange.Text = "Изменить";
            BtnStudChange.UseVisualStyleBackColor = true;
            BtnStudChange.Click += BtnStudChange_Click;
            // 
            // BtnStudSclon
            // 
            BtnStudSclon.Location = new Point(532, 204);
            BtnStudSclon.Name = "BtnStudSclon";
            BtnStudSclon.Size = new Size(481, 23);
            BtnStudSclon.TabIndex = 16;
            BtnStudSclon.Text = "Склонять";
            BtnStudSclon.UseVisualStyleBackColor = true;
            BtnStudSclon.Click += BtnStudSclon_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(532, 55);
            label7.Name = "label7";
            label7.Size = new Size(68, 15);
            label7.TabIndex = 17;
            label7.Text = "Дательный";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(68, 235);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 18;
            label8.Text = "Тема ВКР";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(154, 235);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(859, 23);
            textBox1.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(68, 270);
            label9.Name = "label9";
            label9.Size = new Size(83, 15);
            label9.TabIndex = 20;
            label9.Text = "Руководитель";
            // 
            // comboBox1
            // 
            comboBox1.DataSource = personBindingSource;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(156, 269);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(459, 23);
            comboBox1.TabIndex = 21;
            // 
            // comboBox2
            // 
            comboBox2.DataSource = personBindingSource;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(156, 311);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(459, 23);
            comboBox2.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(68, 312);
            label10.Name = "label10";
            label10.Size = new Size(85, 15);
            label10.TabIndex = 22;
            label10.Text = "Консультант 1";
            // 
            // comboBox3
            // 
            comboBox3.DataSource = personBindingSource;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(156, 355);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(459, 23);
            comboBox3.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(68, 356);
            label11.Name = "label11";
            label11.Size = new Size(85, 15);
            label11.TabIndex = 24;
            label11.Text = "Консультант 2";
            // 
            // comboBox4
            // 
            comboBox4.DataSource = personBindingSource;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(156, 443);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(459, 23);
            comboBox4.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(68, 444);
            label12.Name = "label12";
            label12.Size = new Size(63, 15);
            label12.TabIndex = 28;
            label12.Text = "Рецензент";
            // 
            // comboBox5
            // 
            comboBox5.DataSource = personBindingSource;
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(156, 399);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(459, 23);
            comboBox5.TabIndex = 27;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(68, 400);
            label13.Name = "label13";
            label13.Size = new Size(85, 15);
            label13.TabIndex = 26;
            label13.Text = "Консультант 3";
            // 
            // BtnChooseFile
            // 
            BtnChooseFile.Location = new Point(29, 31);
            BtnChooseFile.Name = "BtnChooseFile";
            BtnChooseFile.Size = new Size(150, 23);
            BtnChooseFile.TabIndex = 30;
            BtnChooseFile.Text = "Выбрать фай";
            BtnChooseFile.UseVisualStyleBackColor = true;
            // 
            // BtnStudAdd
            // 
            BtnStudAdd.Location = new Point(497, 501);
            BtnStudAdd.Name = "BtnStudAdd";
            BtnStudAdd.Size = new Size(75, 23);
            BtnStudAdd.TabIndex = 14;
            BtnStudAdd.Text = "Сохранить";
            BtnStudAdd.UseVisualStyleBackColor = true;
            BtnStudAdd.Click += BtnStudAdd_Click;
            // 
            // ImportFromFile
            // 
            ImportFromFile.Controls.Add(BtnRunImport);
            ImportFromFile.Controls.Add(BtnChooseFile);
            ImportFromFile.Location = new Point(731, 294);
            ImportFromFile.Name = "ImportFromFile";
            ImportFromFile.Size = new Size(200, 100);
            ImportFromFile.TabIndex = 31;
            ImportFromFile.TabStop = false;
            ImportFromFile.Text = "Импорт из файла";
            // 
            // BtnRunImport
            // 
            BtnRunImport.Location = new Point(29, 60);
            BtnRunImport.Name = "BtnRunImport";
            BtnRunImport.Size = new Size(150, 23);
            BtnRunImport.TabIndex = 31;
            BtnRunImport.Text = "Запустить импорт";
            BtnRunImport.UseVisualStyleBackColor = true;
            // 
            // Students
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 1168);
            Controls.Add(ImportFromFile);
            Controls.Add(comboBox4);
            Controls.Add(label12);
            Controls.Add(comboBox5);
            Controls.Add(label13);
            Controls.Add(comboBox3);
            Controls.Add(label11);
            Controls.Add(comboBox2);
            Controls.Add(label10);
            Controls.Add(comboBox1);
            Controls.Add(label9);
            Controls.Add(textBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(BtnStudSclon);
            Controls.Add(BtnStudChange);
            Controls.Add(BtnStudAdd);
            Controls.Add(dataGridView1);
            Controls.Add(Sex);
            Controls.Add(FamRodBox);
            Controls.Add(OtchRodBox);
            Controls.Add(NameRodBox);
            Controls.Add(label6);
            Controls.Add(Famimbox);
            Controls.Add(OtchImbox);
            Controls.Add(NameImBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Students";
            Text = "Students";
            ((System.ComponentModel.ISupportInitialize)diplomnikBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)personBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ImportFromFile.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox NameImBox;
        private TextBox OtchImbox;
        private TextBox Famimbox;
        private Label label6;
        private TextBox NameRodBox;
        private TextBox OtchRodBox;
        private TextBox FamRodBox;
        private ComboBox Sex;
        private BindingSource diplomnikBindingSource;
        private BindingSource personBindingSource;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn fioImenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fioRoditDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sexDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pagesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn temaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn origVkrDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn srballDataGridViewTextBoxColumn;
        private Button BtnStudChange;
        private Button BtnStudSclon;
        private Label label7;
        private Label label8;
        private TextBox textBox1;
        private Label label9;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label10;
        private ComboBox comboBox3;
        private Label label11;
        private ComboBox comboBox4;
        private Label label12;
        private ComboBox comboBox5;
        private Label label13;
        private Button BtnChooseFile;
        private Button BtnStudAdd;
        private GroupBox ImportFromFile;
        private Button BtnRunImport;
    }
}