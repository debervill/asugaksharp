using asugaksharp.Core.Entities;

namespace asugaksharp.Forms
{
    partial class ProfiliPodgootovkiForm
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
            NapravlenitBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            shifrPodgotDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            profilPodgotovkiBindingSource = new BindingSource(components);
            label3 = new Label();
            ShifrBox = new TextBox();
            NazvanieBox = new TextBox();
            label4 = new Label();
            BtnSave = new Button();
            BtnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)profilPodgotovkiBindingSource).BeginInit();
            SuspendLayout();
            // 
            // NapravlenitBox
            // 
            NapravlenitBox.FormattingEnabled = true;
            NapravlenitBox.Location = new Point(275, 126);
            NapravlenitBox.Name = "NapravlenitBox";
            NapravlenitBox.Size = new Size(382, 23);
            NapravlenitBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(100, 129);
            label1.Name = "label1";
            label1.Size = new Size(147, 15);
            label1.TabIndex = 1;
            label1.Text = "Направление подготовки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(364, 20);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 2;
            label2.Text = "Профили подготовк";
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { shifrPodgotDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            dataGridView1.DataSource = profilPodgotovkiBindingSource;
            dataGridView1.Location = new Point(105, 300);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(557, 150);
            dataGridView1.TabIndex = 3;
            // 
            // shifrPodgotDataGridViewTextBoxColumn
            // 
            shifrPodgotDataGridViewTextBoxColumn.DataPropertyName = "ShifrPodgot";
            shifrPodgotDataGridViewTextBoxColumn.HeaderText = "ShifrPodgot";
            shifrPodgotDataGridViewTextBoxColumn.Name = "shifrPodgotDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.FillWeight = 400F;
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 400;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 400;
            // 
            // profilPodgotovkiBindingSource
            // 
            profilPodgotovkiBindingSource.DataSource = typeof(ProfilPodgotovki);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(105, 174);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 4;
            label3.Text = "Шифр";
            // 
            // ShifrBox
            // 
            ShifrBox.Location = new Point(166, 166);
            ShifrBox.Name = "ShifrBox";
            ShifrBox.Size = new Size(491, 23);
            ShifrBox.TabIndex = 5;
            // 
            // NazvanieBox
            // 
            NazvanieBox.Location = new Point(166, 215);
            NazvanieBox.Name = "NazvanieBox";
            NazvanieBox.Size = new Size(491, 23);
            NazvanieBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(105, 223);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 6;
            label4.Text = "Название";
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(379, 268);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(75, 23);
            BtnSave.TabIndex = 8;
            BtnSave.Text = "Сохранить";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Location = new Point(393, 462);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(75, 23);
            BtnEdit.TabIndex = 9;
            BtnEdit.Text = "Изменить";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // ProfiliPodgootovkiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 531);
            Controls.Add(BtnEdit);
            Controls.Add(BtnSave);
            Controls.Add(NazvanieBox);
            Controls.Add(label4);
            Controls.Add(ShifrBox);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NapravlenitBox);
            Name = "ProfiliPodgootovkiForm";
            Text = "ProfiliPodgootovki";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)profilPodgotovkiBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox NapravlenitBox;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn shifrPodgotDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource profilPodgotovkiBindingSource;
        private Label label3;
        private TextBox ShifrBox;
        private TextBox NazvanieBox;
        private Label label4;
        private Button BtnSave;
        private Button BtnEdit;
    }
}