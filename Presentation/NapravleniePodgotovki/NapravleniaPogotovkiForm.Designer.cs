using asugaksharp.Core.Entities;

namespace asugaksharp.Forms
{
    partial class NapravleniaPogotovkiForm
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
            ShifrBox = new TextBox();
            NazvanieBox = new TextBox();
            napravleniePodgotovkiBindingSource = new BindingSource(components);
            kafedraBindingSource = new BindingSource(components);
            periodZasedaniaBindingSource = new BindingSource(components);
            dataGridView1 = new DataGridView();
            shifrNaprDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nazvanieDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            BtnSave = new Button();
            BtnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)napravleniePodgotovkiBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)periodZasedaniaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(244, 24);
            label1.Name = "label1";
            label1.Size = new Size(141, 15);
            label1.TabIndex = 0;
            label1.Text = "Направления подготоки";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 84);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Шифр";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 131);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 2;
            label3.Text = "Название";
            // 
            // ShifrBox
            // 
            ShifrBox.Location = new Point(219, 84);
            ShifrBox.Name = "ShifrBox";
            ShifrBox.Size = new Size(243, 23);
            ShifrBox.TabIndex = 3;
            // 
            // NazvanieBox
            // 
            NazvanieBox.Location = new Point(219, 123);
            NazvanieBox.Name = "NazvanieBox";
            NazvanieBox.Size = new Size(243, 23);
            NazvanieBox.TabIndex = 4;
            // 
            // napravleniePodgotovkiBindingSource
            // 
            napravleniePodgotovkiBindingSource.DataSource = typeof(NapravleniePodgotovki);
            // 
            // kafedraBindingSource
            // 
            kafedraBindingSource.DataSource = typeof(Kafedra);
            // 
            // periodZasedaniaBindingSource
            // 
            periodZasedaniaBindingSource.DataSource = typeof(PeriodZasedania);
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { shifrNaprDataGridViewTextBoxColumn, nazvanieDataGridViewTextBoxColumn });
            dataGridView1.DataSource = napravleniePodgotovkiBindingSource;
            dataGridView1.Location = new Point(37, 227);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(567, 150);
            dataGridView1.TabIndex = 5;
            // 
            // shifrNaprDataGridViewTextBoxColumn
            // 
            shifrNaprDataGridViewTextBoxColumn.DataPropertyName = "ShifrNapr";
            shifrNaprDataGridViewTextBoxColumn.HeaderText = "ShifrNapr";
            shifrNaprDataGridViewTextBoxColumn.MinimumWidth = 100;
            shifrNaprDataGridViewTextBoxColumn.Name = "shifrNaprDataGridViewTextBoxColumn";
            // 
            // nazvanieDataGridViewTextBoxColumn
            // 
            nazvanieDataGridViewTextBoxColumn.DataPropertyName = "Nazvanie";
            nazvanieDataGridViewTextBoxColumn.FillWeight = 400F;
            nazvanieDataGridViewTextBoxColumn.HeaderText = "Nazvanie";
            nazvanieDataGridViewTextBoxColumn.MinimumWidth = 400;
            nazvanieDataGridViewTextBoxColumn.Name = "nazvanieDataGridViewTextBoxColumn";
            nazvanieDataGridViewTextBoxColumn.Width = 400;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(297, 184);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(75, 23);
            BtnSave.TabIndex = 6;
            BtnSave.Text = "Сохранить";
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Location = new Point(297, 383);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(75, 23);
            BtnEdit.TabIndex = 7;
            BtnEdit.Text = "Изменить";
            BtnEdit.UseVisualStyleBackColor = true;
            BtnEdit.Click += BtnEdit_Click;
            // 
            // NapravleniaPogotovki
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 450);
            Controls.Add(BtnEdit);
            Controls.Add(BtnSave);
            Controls.Add(dataGridView1);
            Controls.Add(NazvanieBox);
            Controls.Add(ShifrBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NapravleniaPogotovki";
            Text = "NapravleniaPogotovki";
            ((System.ComponentModel.ISupportInitialize)napravleniePodgotovkiBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)periodZasedaniaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox ShifrBox;
        private TextBox NazvanieBox;
        private BindingSource kafedraBindingSource;
        private BindingSource napravleniePodgotovkiBindingSource;
        private BindingSource periodZasedaniaBindingSource;
        private DataGridView dataGridView1;
        private Button BtnSave;
        private Button BtnEdit;
        private DataGridViewTextBoxColumn shifrNaprDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nazvanieDataGridViewTextBoxColumn;
    }
}