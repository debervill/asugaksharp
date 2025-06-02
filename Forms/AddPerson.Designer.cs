namespace asugaksharp.Forms
{
    partial class AddPerson
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
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)personBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            label2.Location = new Point(40, 67);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 1;
            label2.Text = "ФИО";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 134);
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
            UchStepenBox.Location = new Point(150, 131);
            UchStepenBox.Name = "UchStepenBox";
            UchStepenBox.Size = new Size(159, 23);
            UchStepenBox.TabIndex = 3;
            // 
            // DolgnostBox
            // 
            DolgnostBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DolgnostBox.FormattingEnabled = true;
            DolgnostBox.Items.AddRange(new object[] { "б/д", "старший преподаватель", "доцент", "профессор" });
            DolgnostBox.Location = new Point(150, 99);
            DolgnostBox.Name = "DolgnostBox";
            DolgnostBox.Size = new Size(159, 23);
            DolgnostBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 102);
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
            UchZvanBox.Location = new Point(150, 169);
            UchZvanBox.Name = "UchZvanBox";
            UchZvanBox.Size = new Size(159, 23);
            UchZvanBox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 172);
            label5.Name = "label5";
            label5.Size = new Size(86, 15);
            label5.TabIndex = 6;
            label5.Text = "Учёная звание";
            // 
            // FioText
            // 
            FioText.Location = new Point(150, 64);
            FioText.Name = "FioText";
            FioText.Size = new Size(507, 23);
            FioText.TabIndex = 8;
            // 
            // ZavKafBox
            // 
            ZavKafBox.AutoSize = true;
            ZavKafBox.Location = new Point(405, 103);
            ZavKafBox.Name = "ZavKafBox";
            ZavKafBox.Size = new Size(149, 19);
            ZavKafBox.TabIndex = 10;
            ZavKafBox.Text = "Заведющий кафедрой";
            ZavKafBox.UseVisualStyleBackColor = true;
            // 
            // PredsedBox
            // 
            PredsedBox.AutoSize = true;
            PredsedBox.Location = new Point(405, 135);
            PredsedBox.Name = "PredsedBox";
            PredsedBox.Size = new Size(160, 19);
            PredsedBox.TabIndex = 11;
            PredsedBox.Text = "Председатель комиссии";
            PredsedBox.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(317, 220);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(75, 23);
            BtnAdd.TabIndex = 12;
            BtnAdd.Text = "Сохранить";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnExit
            // 
            BtnExit.Location = new Point(600, 518);
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
            IsSecretarBox.Location = new Point(405, 168);
            IsSecretarBox.Name = "IsSecretarBox";
            IsSecretarBox.Size = new Size(104, 19);
            IsSecretarBox.TabIndex = 14;
            IsSecretarBox.Text = "Секретарь Гэк";
            IsSecretarBox.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(69, 299);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(588, 150);
            dataGridView1.TabIndex = 15;
            // 
            // AddPerson
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 563);
            Controls.Add(dataGridView1);
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
            Name = "AddPerson";
            Text = "AddPerson";
            ((System.ComponentModel.ISupportInitialize)personBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private DataGridView dataGridView1;
    }
}