namespace asugaksharp.Forms
{
    partial class PeriodZasedaniaForm
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
            label1 = new Label();
            label2 = new Label();
            NazvanieText = new TextBox();
            label3 = new Label();
            dateStartPicker = new DateTimePicker();
            dateEndPicker = new DateTimePicker();
            label4 = new Label();
            bntSave = new Button();
            btnExit = new Button();
            label5 = new Label();
            PrimechanieText = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(318, 22);
            label1.Name = "label1";
            label1.Size = new Size(224, 15);
            label1.TabIndex = 0;
            label1.Text = "Добавление проведения заседаний ГЭК";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(258, 78);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Название";
            // 
            // NazvanieText
            // 
            NazvanieText.Location = new Point(333, 75);
            NazvanieText.Name = "NazvanieText";
            NazvanieText.Size = new Size(248, 23);
            NazvanieText.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(106, 139);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 3;
            label3.Text = "Дата начала";
            // 
            // dateStartPicker
            // 
            dateStartPicker.Location = new Point(199, 134);
            dateStartPicker.Name = "dateStartPicker";
            dateStartPicker.Size = new Size(137, 23);
            dateStartPicker.TabIndex = 4;
            // 
            // dateEndPicker
            // 
            dateEndPicker.Location = new Point(529, 134);
            dateEndPicker.Name = "dateEndPicker";
            dateEndPicker.Size = new Size(133, 23);
            dateEndPicker.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(409, 139);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 6;
            label4.Text = "Дата окончания";
            // 
            // bntSave
            // 
            bntSave.Location = new Point(280, 239);
            bntSave.Name = "bntSave";
            bntSave.Size = new Size(75, 23);
            bntSave.TabIndex = 7;
            bntSave.Text = "Сохранить";
            bntSave.UseVisualStyleBackColor = true;
            bntSave.Click += BntSave_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(467, 239);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 8;
            btnExit.Text = "Выйти";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(106, 191);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 9;
            label5.Text = "Примечаение";
            // 
            // PrimechanieText
            // 
            PrimechanieText.Location = new Point(199, 188);
            PrimechanieText.Name = "PrimechanieText";
            PrimechanieText.Size = new Size(464, 23);
            PrimechanieText.TabIndex = 10;
            // 
            // AddPeriodZasedania
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 302);
            Controls.Add(PrimechanieText);
            Controls.Add(label5);
            Controls.Add(btnExit);
            Controls.Add(bntSave);
            Controls.Add(label4);
            Controls.Add(dateEndPicker);
            Controls.Add(dateStartPicker);
            Controls.Add(label3);
            Controls.Add(NazvanieText);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddPeriodZasedania";
            Text = "AddPeriodZasedania";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox NazvanieText;
        private Label label3;
        private DateTimePicker dateStartPicker;
        private DateTimePicker dateEndPicker;
        private Label label4;
        private Button bntSave;
        private Button btnExit;
        private Label label5;
        private TextBox PrimechanieText;
    }
}