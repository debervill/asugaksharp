namespace asugaksharp.Forms
{
    partial class Students
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
            BtnStudAdd = new Button();
            BtnStudChange = new Button();
            BtnStudSclon = new Button();
            ((System.ComponentModel.ISupportInitialize)diplomnikBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            NameImBox.Size = new Size(100, 23);
            NameImBox.TabIndex = 5;
            // 
            // OtchImbox
            // 
            OtchImbox.Location = new Point(154, 132);
            OtchImbox.Name = "OtchImbox";
            OtchImbox.Size = new Size(100, 23);
            OtchImbox.TabIndex = 6;
            // 
            // Famimbox
            // 
            Famimbox.Location = new Point(154, 166);
            Famimbox.Name = "Famimbox";
            Famimbox.Size = new Size(100, 23);
            Famimbox.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(158, 55);
            label6.Name = "label6";
            label6.Size = new Size(92, 15);
            label6.TabIndex = 8;
            label6.Text = "Именительный";
            // 
            // NameRodBox
            // 
            NameRodBox.Location = new Point(286, 101);
            NameRodBox.Name = "NameRodBox";
            NameRodBox.Size = new Size(100, 23);
            NameRodBox.TabIndex = 9;
            // 
            // OtchRodBox
            // 
            OtchRodBox.Location = new Point(286, 132);
            OtchRodBox.Name = "OtchRodBox";
            OtchRodBox.Size = new Size(100, 23);
            OtchRodBox.TabIndex = 10;
            // 
            // FamRodBox
            // 
            FamRodBox.Location = new Point(286, 166);
            FamRodBox.Name = "FamRodBox";
            FamRodBox.Size = new Size(100, 23);
            FamRodBox.TabIndex = 11;
            // 
            // Sex
            // 
            Sex.Items.AddRange(new object[] { "М", "Ж" });
            Sex.Location = new Point(154, 198);
            Sex.Name = "Sex";
            Sex.Size = new Size(101, 23);
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
            dataGridView1.Location = new Point(42, 253);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(746, 289);
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
            // BtnStudAdd
            // 
            BtnStudAdd.Location = new Point(310, 561);
            BtnStudAdd.Name = "BtnStudAdd";
            BtnStudAdd.Size = new Size(75, 23);
            BtnStudAdd.TabIndex = 14;
            BtnStudAdd.Text = "Сохранить";
            BtnStudAdd.UseVisualStyleBackColor = true;
            BtnStudAdd.Click += BtnStudAdd_Click;
            // 
            // BtnStudChange
            // 
            BtnStudChange.Location = new Point(418, 561);
            BtnStudChange.Name = "BtnStudChange";
            BtnStudChange.Size = new Size(75, 23);
            BtnStudChange.TabIndex = 15;
            BtnStudChange.Text = "Изменить";
            BtnStudChange.UseVisualStyleBackColor = true;
            BtnStudChange.Click += BtnStudChange_Click;
            // 
            // BtnStudSclon
            // 
            BtnStudSclon.Location = new Point(287, 204);
            BtnStudSclon.Name = "BtnStudSclon";
            BtnStudSclon.Size = new Size(99, 23);
            BtnStudSclon.TabIndex = 16;
            BtnStudSclon.Text = "Склонять";
            BtnStudSclon.UseVisualStyleBackColor = true;
            // 
            // Students
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 606);
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
        private Button BtnStudAdd;
        private Button BtnStudChange;
        private Button BtnStudSclon;
    }
}