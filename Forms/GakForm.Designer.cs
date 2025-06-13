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
            label5 = new Label();
            label6 = new Label();
            NaprPodogotBox = new ComboBox();
            ProfilPodgotBox = new ComboBox();
            groupBox1 = new GroupBox();
            BtnDeleteMemberFromCommission = new Button();
            BtnAddMemberToCommision = new Button();
            ComssionsMemberList = new ListBox();
            AllPersonsList = new ListBox();
            personBindingSource = new BindingSource(components);
            label8 = new Label();
            PrepdsedBox = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)periodZasedaniaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)personBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 96);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 0;
            label1.Text = "ГЭКИ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 87);
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
            PerodZasedBox.Location = new Point(262, 117);
            PerodZasedBox.Name = "PerodZasedBox";
            PerodZasedBox.Size = new Size(366, 28);
            PerodZasedBox.TabIndex = 2;
            // 
            // periodZasedaniaBindingSource
            // 
            periodZasedaniaBindingSource.DataSource = typeof(Model.PeriodZasedania);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 125);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 3;
            label3.Text = "Набор заседаний";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(85, 96);
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
            kafedraBox.Location = new Point(262, 88);
            kafedraBox.Name = "kafedraBox";
            kafedraBox.Size = new Size(366, 28);
            kafedraBox.TabIndex = 4;
            kafedraBox.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // kafedraBindingSource
            // 
            kafedraBindingSource.DataSource = typeof(Model.Kafedra);
            // 
            // BtnAddZasedanie
            // 
            BtnAddZasedanie.Location = new Point(81, 865);
            BtnAddZasedanie.Name = "BtnAddZasedanie";
            BtnAddZasedanie.Size = new Size(137, 28);
            BtnAddZasedanie.TabIndex = 6;
            BtnAddZasedanie.Text = "Добавить заседание";
            BtnAddZasedanie.UseVisualStyleBackColor = true;
            BtnAddZasedanie.Click += BtnAddZasedanie_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(85, 154);
            label5.Name = "label5";
            label5.Size = new Size(147, 20);
            label5.TabIndex = 7;
            label5.Text = "Направление подготовки";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(85, 183);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 8;
            label6.Text = "Профиль подготовки";
            // 
            // NaprPodogotBox
            // 
            NaprPodogotBox.FormattingEnabled = true;
            NaprPodogotBox.Location = new Point(262, 146);
            NaprPodogotBox.Name = "NaprPodogotBox";
            NaprPodogotBox.Size = new Size(366, 28);
            NaprPodogotBox.TabIndex = 9;
            // 
            // ProfilPodgotBox
            // 
            ProfilPodgotBox.FormattingEnabled = true;
            ProfilPodgotBox.Location = new Point(262, 175);
            ProfilPodgotBox.Name = "ProfilPodgotBox";
            ProfilPodgotBox.Size = new Size(366, 28);
            ProfilPodgotBox.TabIndex = 10;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnDeleteMemberFromCommission);
            groupBox1.Controls.Add(BtnAddMemberToCommision);
            groupBox1.Controls.Add(ComssionsMemberList);
            groupBox1.Controls.Add(AllPersonsList);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(PrepdsedBox);
            groupBox1.Controls.Add(label7);
            groupBox1.Location = new Point(85, 226);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(580, 579);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Комиссия";
            // 
            // BtnDeleteMemberFromCommission
            // 
            BtnDeleteMemberFromCommission.Location = new Point(247, 276);
            BtnDeleteMemberFromCommission.Name = "BtnDeleteMemberFromCommission";
            BtnDeleteMemberFromCommission.Size = new Size(75, 28);
            BtnDeleteMemberFromCommission.TabIndex = 6;
            BtnDeleteMemberFromCommission.Text = "Удалить";
            BtnDeleteMemberFromCommission.UseVisualStyleBackColor = true;
            // 
            // BtnAddMemberToCommision
            // 
            BtnAddMemberToCommision.Location = new Point(247, 231);
            BtnAddMemberToCommision.Name = "BtnAddMemberToCommision";
            BtnAddMemberToCommision.Size = new Size(75, 28);
            BtnAddMemberToCommision.TabIndex = 5;
            BtnAddMemberToCommision.Text = "Добавить";
            BtnAddMemberToCommision.UseVisualStyleBackColor = true;
            // 
            // ComssionsMemberList
            // 
            ComssionsMemberList.FormattingEnabled = true;
            ComssionsMemberList.ItemHeight = 20;
            ComssionsMemberList.Location = new Point(358, 107);
            ComssionsMemberList.Name = "ComssionsMemberList";
            ComssionsMemberList.Size = new Size(185, 364);
            ComssionsMemberList.TabIndex = 4;
            // 
            // AllPersonsList
            // 
            AllPersonsList.DataSource = personBindingSource;
            AllPersonsList.FormattingEnabled = true;
            AllPersonsList.ItemHeight = 20;
            AllPersonsList.Location = new Point(19, 107);
            AllPersonsList.Name = "AllPersonsList";
            AllPersonsList.Size = new Size(185, 364);
            AllPersonsList.TabIndex = 3;
            // 
            // personBindingSource
            // 
            personBindingSource.DataSource = typeof(Model.Person);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 69);
            label8.Name = "label8";
            label8.Size = new Size(65, 20);
            label8.TabIndex = 2;
            label8.Text = "Участники";
            // 
            // PrepdsedBox
            // 
            PrepdsedBox.FormattingEnabled = true;
            PrepdsedBox.Location = new Point(177, 26);
            PrepdsedBox.Name = "PrepdsedBox";
            PrepdsedBox.Size = new Size(366, 28);
            PrepdsedBox.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 29);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 0;
            label7.Text = "Председатель";
            // 
            // GakForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 976);
            Controls.Add(groupBox1);
            Controls.Add(ProfilPodgotBox);
            Controls.Add(NaprPodogotBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(BtnAddZasedanie);
            Controls.Add(label4);
            Controls.Add(kafedraBox);
            Controls.Add(label3);
            Controls.Add(PerodZasedBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GakForm";
            Text = "Gak";
            ((System.ComponentModel.ISupportInitialize)periodZasedaniaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)personBindingSource).EndInit();
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
        private Label label5;
        private Label label6;
        private ComboBox NaprPodogotBox;
        private ComboBox ProfilPodgotBox;
        private GroupBox groupBox1;
        private Label label8;
        private ComboBox PrepdsedBox;
        private Label label7;
        private ListBox AllPersonsList;
        private Button BtnDeleteMemberFromCommission;
        private Button BtnAddMemberToCommision;
        private ListBox ComssionsMemberList;
        private BindingSource personBindingSource;
    }
}