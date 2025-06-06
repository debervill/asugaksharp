namespace asugaksharp.Forms
{
    partial class AddPersonForm
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
            personBindingSource = new BindingSource(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            UchStepenBox = new ComboBox();
            DolgnostBox = new ComboBox();
            label4 = new Label();
            UchZvanBox = new ComboBox();
            label5 = new Label();
            FioText = new TextBox();
            ZavKafBox = new CheckBox();
            PredsedBox = new CheckBox();
            BtnAdd = new Button();
            BtnExit = new Button();
            IsSecretarBox = new CheckBox();
            PersonGridView = new DataGridView();
            isVeshnBox = new CheckBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            button1 = new Button();
            sqlDataAdapter1 = new Microsoft.Data.SqlClient.SqlDataAdapter();
            label17 = new Label();
            KafBox = new ComboBox();
            kafedraBindingSource = new BindingSource(components);
            personBindingSource1 = new BindingSource(components);
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stepenDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            zvanieDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dolgnostDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isPredsedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            isZavKafDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            isSecretarDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            isRecenzentDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            isVneshniyDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            kafedraIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kafedraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            zasedaniesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            docsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            diplomniksDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            oplatasDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gaksDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)personBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PersonGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)personBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // personBindingSource
            // 
            personBindingSource.DataSource = typeof(Model.Person);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(299, 9);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 0;
            label1.Text = "Добавление человека";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 119);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 1;
            label2.Text = "ФИО";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 186);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 2;
            label3.Text = "Учёная степень";
            // 
            // UchStepenBox
            // 
            UchStepenBox.DropDownStyle = ComboBoxStyle.DropDownList;
            UchStepenBox.FormattingEnabled = true;
            UchStepenBox.Items.AddRange(new object[] { "б/c", "к.т.н", "д.т.н" });
            UchStepenBox.Location = new Point(232, 183);
            UchStepenBox.Name = "UchStepenBox";
            UchStepenBox.Size = new Size(226, 23);
            UchStepenBox.TabIndex = 3;
            // 
            // DolgnostBox
            // 
            DolgnostBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DolgnostBox.FormattingEnabled = true;
            DolgnostBox.Items.AddRange(new object[] { "б/д", "старший преподаватель", "доцент", "профессор" });
            DolgnostBox.Location = new Point(232, 151);
            DolgnostBox.Name = "DolgnostBox";
            DolgnostBox.Size = new Size(226, 23);
            DolgnostBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 154);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 4;
            label4.Text = "Должность";
            // 
            // UchZvanBox
            // 
            UchZvanBox.DropDownStyle = ComboBoxStyle.DropDownList;
            UchZvanBox.FormattingEnabled = true;
            UchZvanBox.Items.AddRange(new object[] { "б/з", "доцент", "профессор" });
            UchZvanBox.Location = new Point(232, 221);
            UchZvanBox.Name = "UchZvanBox";
            UchZvanBox.Size = new Size(226, 23);
            UchZvanBox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(49, 224);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 6;
            label5.Text = "Учёная звание";
            // 
            // FioText
            // 
            FioText.Location = new Point(232, 116);
            FioText.Name = "FioText";
            FioText.Size = new Size(567, 23);
            FioText.TabIndex = 8;
            // 
            // ZavKafBox
            // 
            ZavKafBox.AutoSize = true;
            ZavKafBox.Location = new Point(487, 155);
            ZavKafBox.Name = "ZavKafBox";
            ZavKafBox.Size = new Size(149, 19);
            ZavKafBox.TabIndex = 10;
            ZavKafBox.Text = "Заведющий кафедрой";
            ZavKafBox.UseVisualStyleBackColor = true;
            // 
            // PredsedBox
            // 
            PredsedBox.AutoSize = true;
            PredsedBox.Location = new Point(487, 180);
            PredsedBox.Name = "PredsedBox";
            PredsedBox.Size = new Size(160, 19);
            PredsedBox.TabIndex = 11;
            PredsedBox.Text = "Председатель комиссии";
            PredsedBox.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(453, 520);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(75, 23);
            BtnAdd.TabIndex = 12;
            BtnAdd.Text = "Сохранить";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(573, 781);
            BtnExit.Name = "BtnExit";
            BtnExit.Size = new Size(75, 23);
            BtnExit.TabIndex = 13;
            BtnExit.Text = "Закрыть";
            BtnExit.UseVisualStyleBackColor = true;
            BtnExit.Click += BtnExit_Click;
            // 
            // IsSecretarBox
            // 
            IsSecretarBox.AutoSize = true;
            IsSecretarBox.Location = new Point(487, 205);
            IsSecretarBox.Name = "IsSecretarBox";
            IsSecretarBox.Size = new Size(104, 19);
            IsSecretarBox.TabIndex = 14;
            IsSecretarBox.Text = "Секретарь Гэк";
            IsSecretarBox.UseVisualStyleBackColor = true;
            // 
            // PersonGridView
            // 
            PersonGridView.AutoGenerateColumns = false;
            PersonGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PersonGridView.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, stepenDataGridViewTextBoxColumn, zvanieDataGridViewTextBoxColumn, dolgnostDataGridViewTextBoxColumn, isPredsedDataGridViewCheckBoxColumn, isZavKafDataGridViewCheckBoxColumn, isSecretarDataGridViewCheckBoxColumn, isRecenzentDataGridViewCheckBoxColumn, isVneshniyDataGridViewCheckBoxColumn, kafedraIDDataGridViewTextBoxColumn, kafedraDataGridViewTextBoxColumn, zasedaniesDataGridViewTextBoxColumn, docsDataGridViewTextBoxColumn, diplomniksDataGridViewTextBoxColumn, oplatasDataGridViewTextBoxColumn, gaksDataGridViewTextBoxColumn });
            PersonGridView.DataSource = personBindingSource1;
            PersonGridView.Location = new Point(35, 578);
            PersonGridView.Name = "PersonGridView";
            PersonGridView.Size = new Size(779, 150);
            PersonGridView.TabIndex = 15;
            // 
            // isVeshnBox
            // 
            isVeshnBox.AutoSize = true;
            isVeshnBox.Location = new Point(487, 230);
            isVeshnBox.Name = "isVeshnBox";
            isVeshnBox.Size = new Size(78, 19);
            isVeshnBox.TabIndex = 16;
            isVeshnBox.Text = "Внешний";
            isVeshnBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 317);
            label6.Name = "label6";
            label6.Size = new Size(144, 15);
            label6.TabIndex = 17;
            label6.Text = "Серия и номер паспорта";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(49, 363);
            label7.Name = "label7";
            label7.Size = new Size(114, 15);
            label7.TabIndex = 18;
            label7.Text = "Кем выдан паспорт";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(49, 399);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 19;
            label8.Text = "Снилс";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(49, 433);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 20;
            label9.Text = "ИНН";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(49, 276);
            label10.Name = "label10";
            label10.Size = new Size(103, 15);
            label10.TabIndex = 21;
            label10.Text = "Домашний адрес";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(486, 281);
            label11.Name = "label11";
            label11.Size = new Size(33, 15);
            label11.TabIndex = 22;
            label11.Text = "Банк";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(485, 363);
            label12.Name = "label12";
            label12.Size = new Size(62, 15);
            label12.TabIndex = 23;
            label12.Text = "Корр счёт";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(485, 317);
            label13.Name = "label13";
            label13.Size = new Size(77, 15);
            label13.TabIndex = 24;
            label13.Text = "Рассчёт счёт";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(487, 399);
            label14.Name = "label14";
            label14.Size = new Size(30, 15);
            label14.TabIndex = 25;
            label14.Text = "БИК";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(487, 441);
            label15.Name = "label15";
            label15.Size = new Size(56, 15);
            label15.TabIndex = 26;
            label15.Text = "Телефон";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(487, 477);
            label16.Name = "label16";
            label16.Size = new Size(41, 15);
            label16.TabIndex = 27;
            label16.Text = "E-mail";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(232, 273);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(226, 23);
            textBox1.TabIndex = 28;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(232, 309);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(226, 23);
            textBox2.TabIndex = 29;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(232, 355);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(226, 23);
            textBox3.TabIndex = 30;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(232, 391);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(226, 23);
            textBox4.TabIndex = 31;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(232, 425);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(226, 23);
            textBox5.TabIndex = 32;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(573, 276);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(226, 23);
            textBox6.TabIndex = 33;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(573, 314);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(226, 23);
            textBox7.TabIndex = 34;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(573, 355);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(226, 23);
            textBox8.TabIndex = 35;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(573, 391);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(226, 23);
            textBox9.TabIndex = 36;
            // 
            // textBox10
            // 
            textBox10.Location = new Point(573, 433);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(226, 23);
            textBox10.TabIndex = 37;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(573, 469);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(226, 23);
            textBox11.TabIndex = 38;
            // 
            // button1
            // 
            button1.Location = new Point(287, 781);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 39;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(49, 78);
            label17.Name = "label17";
            label17.Size = new Size(54, 15);
            label17.TabIndex = 40;
            label17.Text = "Кафедра";
            // 
            // KafBox
            // 
            KafBox.FormattingEnabled = true;
            KafBox.Location = new Point(232, 70);
            KafBox.Name = "KafBox";
            KafBox.Size = new Size(567, 23);
            KafBox.TabIndex = 41;
            // 
            // kafedraBindingSource
            // 
            kafedraBindingSource.DataSource = typeof(Model.Kafedra);
            // 
            // personBindingSource1
            // 
            personBindingSource1.DataSource = typeof(Model.Person);
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // stepenDataGridViewTextBoxColumn
            // 
            stepenDataGridViewTextBoxColumn.DataPropertyName = "Stepen";
            stepenDataGridViewTextBoxColumn.HeaderText = "Stepen";
            stepenDataGridViewTextBoxColumn.Name = "stepenDataGridViewTextBoxColumn";
            // 
            // zvanieDataGridViewTextBoxColumn
            // 
            zvanieDataGridViewTextBoxColumn.DataPropertyName = "Zvanie";
            zvanieDataGridViewTextBoxColumn.HeaderText = "Zvanie";
            zvanieDataGridViewTextBoxColumn.Name = "zvanieDataGridViewTextBoxColumn";
            // 
            // dolgnostDataGridViewTextBoxColumn
            // 
            dolgnostDataGridViewTextBoxColumn.DataPropertyName = "Dolgnost";
            dolgnostDataGridViewTextBoxColumn.HeaderText = "Dolgnost";
            dolgnostDataGridViewTextBoxColumn.Name = "dolgnostDataGridViewTextBoxColumn";
            // 
            // isPredsedDataGridViewCheckBoxColumn
            // 
            isPredsedDataGridViewCheckBoxColumn.DataPropertyName = "IsPredsed";
            isPredsedDataGridViewCheckBoxColumn.HeaderText = "IsPredsed";
            isPredsedDataGridViewCheckBoxColumn.Name = "isPredsedDataGridViewCheckBoxColumn";
            // 
            // isZavKafDataGridViewCheckBoxColumn
            // 
            isZavKafDataGridViewCheckBoxColumn.DataPropertyName = "IsZavKaf";
            isZavKafDataGridViewCheckBoxColumn.HeaderText = "IsZavKaf";
            isZavKafDataGridViewCheckBoxColumn.Name = "isZavKafDataGridViewCheckBoxColumn";
            // 
            // isSecretarDataGridViewCheckBoxColumn
            // 
            isSecretarDataGridViewCheckBoxColumn.DataPropertyName = "IsSecretar";
            isSecretarDataGridViewCheckBoxColumn.HeaderText = "IsSecretar";
            isSecretarDataGridViewCheckBoxColumn.Name = "isSecretarDataGridViewCheckBoxColumn";
            // 
            // isRecenzentDataGridViewCheckBoxColumn
            // 
            isRecenzentDataGridViewCheckBoxColumn.DataPropertyName = "IsRecenzent";
            isRecenzentDataGridViewCheckBoxColumn.HeaderText = "IsRecenzent";
            isRecenzentDataGridViewCheckBoxColumn.Name = "isRecenzentDataGridViewCheckBoxColumn";
            // 
            // isVneshniyDataGridViewCheckBoxColumn
            // 
            isVneshniyDataGridViewCheckBoxColumn.DataPropertyName = "IsVneshniy";
            isVneshniyDataGridViewCheckBoxColumn.HeaderText = "IsVneshniy";
            isVneshniyDataGridViewCheckBoxColumn.Name = "isVneshniyDataGridViewCheckBoxColumn";
            // 
            // kafedraIDDataGridViewTextBoxColumn
            // 
            kafedraIDDataGridViewTextBoxColumn.DataPropertyName = "KafedraID";
            kafedraIDDataGridViewTextBoxColumn.HeaderText = "KafedraID";
            kafedraIDDataGridViewTextBoxColumn.Name = "kafedraIDDataGridViewTextBoxColumn";
            // 
            // kafedraDataGridViewTextBoxColumn
            // 
            kafedraDataGridViewTextBoxColumn.DataPropertyName = "Kafedra";
            kafedraDataGridViewTextBoxColumn.HeaderText = "Kafedra";
            kafedraDataGridViewTextBoxColumn.Name = "kafedraDataGridViewTextBoxColumn";
            // 
            // zasedaniesDataGridViewTextBoxColumn
            // 
            zasedaniesDataGridViewTextBoxColumn.DataPropertyName = "Zasedanies";
            zasedaniesDataGridViewTextBoxColumn.HeaderText = "Zasedanies";
            zasedaniesDataGridViewTextBoxColumn.Name = "zasedaniesDataGridViewTextBoxColumn";
            // 
            // docsDataGridViewTextBoxColumn
            // 
            docsDataGridViewTextBoxColumn.DataPropertyName = "Docs";
            docsDataGridViewTextBoxColumn.HeaderText = "Docs";
            docsDataGridViewTextBoxColumn.Name = "docsDataGridViewTextBoxColumn";
            // 
            // diplomniksDataGridViewTextBoxColumn
            // 
            diplomniksDataGridViewTextBoxColumn.DataPropertyName = "Diplomniks";
            diplomniksDataGridViewTextBoxColumn.HeaderText = "Diplomniks";
            diplomniksDataGridViewTextBoxColumn.Name = "diplomniksDataGridViewTextBoxColumn";
            // 
            // oplatasDataGridViewTextBoxColumn
            // 
            oplatasDataGridViewTextBoxColumn.DataPropertyName = "Oplatas";
            oplatasDataGridViewTextBoxColumn.HeaderText = "Oplatas";
            oplatasDataGridViewTextBoxColumn.Name = "oplatasDataGridViewTextBoxColumn";
            // 
            // gaksDataGridViewTextBoxColumn
            // 
            gaksDataGridViewTextBoxColumn.DataPropertyName = "Gaks";
            gaksDataGridViewTextBoxColumn.HeaderText = "Gaks";
            gaksDataGridViewTextBoxColumn.Name = "gaksDataGridViewTextBoxColumn";
            // 
            // AddPersonForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 894);
            Controls.Add(KafBox);
            Controls.Add(label17);
            Controls.Add(button1);
            Controls.Add(textBox11);
            Controls.Add(textBox10);
            Controls.Add(textBox9);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(isVeshnBox);
            Controls.Add(PersonGridView);
            Controls.Add(IsSecretarBox);
            Controls.Add(BtnExit);
            Controls.Add(BtnAdd);
            Controls.Add(PredsedBox);
            Controls.Add(ZavKafBox);
            Controls.Add(FioText);
            Controls.Add(UchZvanBox);
            Controls.Add(label5);
            Controls.Add(DolgnostBox);
            Controls.Add(label4);
            Controls.Add(UchStepenBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddPersonForm";
            Text = "AddPerson";
            ((System.ComponentModel.ISupportInitialize)personBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)PersonGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)personBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource personBindingSource;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox UchStepenBox;
        private ComboBox DolgnostBox;
        private Label label4;
        private ComboBox UchZvanBox;
        private Label label5;
        private TextBox FioText;
        private CheckBox ZavKafBox;
        private CheckBox PredsedBox;
        private Button BtnAdd;
        private Button BtnExit;
        private CheckBox IsSecretarBox;
        private DataGridView PersonGridView;
        private CheckBox isVeshnBox;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private Button button1;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private Label label17;
        private ComboBox KafBox;
        private BindingSource kafedraBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stepenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn zvanieDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dolgnostDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isPredsedDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn isZavKafDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn isSecretarDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn isRecenzentDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn isVneshniyDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn kafedraIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kafedraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn zasedaniesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn docsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn diplomniksDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn oplatasDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gaksDataGridViewTextBoxColumn;
        private BindingSource personBindingSource1;
    }
}