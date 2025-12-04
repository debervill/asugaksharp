using asugaksharp.ApplicationLayer.kafedra.DTO;

namespace asugaksharp.Presentation.Forms
{
    partial class KafedraForm
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
            kafnamebox = new TextBox();
            btnKafAdd = new Button();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kafedraDtoBindingSource = new BindingSource(components);
            BtnKafChange = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kafedraDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 40);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 0;
            label1.Text = "Название кафедры";
            // 
            // kafnamebox
            // 
            kafnamebox.Location = new Point(220, 33);
            kafnamebox.Name = "kafnamebox";
            kafnamebox.Size = new Size(519, 27);
            kafnamebox.TabIndex = 1;
            // 
            // btnKafAdd
            // 
            btnKafAdd.Location = new Point(382, 94);
            btnKafAdd.Name = "btnKafAdd";
            btnKafAdd.Size = new Size(94, 29);
            btnKafAdd.TabIndex = 2;
            btnKafAdd.Text = "Добавить";
            btnKafAdd.UseVisualStyleBackColor = true;
            btnKafAdd.Click += BtnKafAdd_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            dataGridView1.DataSource = kafedraDtoBindingSource;
            dataGridView1.Location = new Point(54, 139);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(685, 189);
            dataGridView1.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // kafedraDtoBindingSource
            // 
            kafedraDtoBindingSource.DataSource = typeof(KafedraDto);
            // 
            // BtnKafChange
            // 
            BtnKafChange.Location = new Point(382, 348);
            BtnKafChange.Name = "BtnKafChange";
            BtnKafChange.Size = new Size(94, 29);
            BtnKafChange.TabIndex = 4;
            BtnKafChange.Text = "Изменить";
            BtnKafChange.UseVisualStyleBackColor = true;
            BtnKafChange.Click += BtnKafEdit_Click;
            // 
            // KafedraForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 396);
            Controls.Add(BtnKafChange);
            Controls.Add(dataGridView1);
            Controls.Add(btnKafAdd);
            Controls.Add(kafnamebox);
            Controls.Add(label1);
            Name = "KafedraForm";
            Text = "KafedraForm";
            Load += KafedraForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)kafedraDtoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button btnKafAdd;
        private DataGridView dataGridView1;
        private Button BtnKafChange;
        private TextBox kafnamebox;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource kafedraDtoBindingSource;
    }
}