namespace asugaksharp.Forms
{
    partial class KafedraForms
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
            KafBox = new TextBox();
            KafedraGridView = new DataGridView();
            kafedraBindingSource = new BindingSource(components);
            BtnAdd = new Button();
            BtnEdit = new Button();
            BtnClose = new Button();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)KafedraGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(446, 52);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "Кафедра";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 136);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Название";
            // 
            // KafBox
            // 
            KafBox.Location = new Point(177, 132);
            KafBox.Margin = new Padding(3, 4, 3, 4);
            KafBox.Name = "KafBox";
            KafBox.Size = new Size(605, 27);
            KafBox.TabIndex = 2;
            
            // 
            // KafedraGridView
            // 
            KafedraGridView.AllowUserToAddRows = false;
            KafedraGridView.AllowUserToDeleteRows = false;
            KafedraGridView.AutoGenerateColumns = false;
            KafedraGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            KafedraGridView.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn });
            KafedraGridView.DataSource = kafedraBindingSource;
            KafedraGridView.Location = new Point(78, 268);
            KafedraGridView.Margin = new Padding(3, 4, 3, 4);
            KafedraGridView.MinimumSize = new Size(600, 0);
            KafedraGridView.Name = "KafedraGridView";
            KafedraGridView.ReadOnly = true;
            KafedraGridView.RowHeadersWidth = 51;
            KafedraGridView.Size = new Size(733, 168);
            KafedraGridView.TabIndex = 3;
            // 
            // kafedraBindingSource
            // 
            kafedraBindingSource.DataSource = typeof(Model.Kafedra);
            // 
            // BtnAdd
            // 
            BtnAdd.Location = new Point(446, 191);
            BtnAdd.Margin = new Padding(3, 4, 3, 4);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(86, 31);
            BtnAdd.TabIndex = 4;
            BtnAdd.Text = "Добавить";
            BtnAdd.UseVisualStyleBackColor = true;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnEdit
            // 
            BtnEdit.Location = new Point(272, 483);
            BtnEdit.Margin = new Padding(3, 4, 3, 4);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(86, 31);
            BtnEdit.TabIndex = 5;
            BtnEdit.Text = "Изменить";
            BtnEdit.UseVisualStyleBackColor = true;
            // 
            // BtnClose
            // 
            BtnClose.Location = new Point(577, 483);
            BtnClose.Margin = new Padding(3, 4, 3, 4);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(86, 31);
            BtnClose.TabIndex = 6;
            BtnClose.Text = "Закрыть";
            BtnClose.UseVisualStyleBackColor = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 600;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 600;
            // 
            // KafedraForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(BtnClose);
            Controls.Add(BtnEdit);
            Controls.Add(BtnAdd);
            Controls.Add(KafedraGridView);
            Controls.Add(KafBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "KafedraForms";
            Text = "KafedraForms";
            ((System.ComponentModel.ISupportInitialize)KafedraGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)kafedraBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox KafBox;
        private DataGridView KafedraGridView;
        private BindingSource kafedraBindingSource;
        private Button BtnAdd;
        private Button BtnEdit;
        private Button BtnClose;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}