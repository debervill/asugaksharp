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
            ((System.ComponentModel.ISupportInitialize)personBindingSource).BeginInit();
            SuspendLayout();
            // 
            // personBindingSource
            // 
            personBindingSource.DataSource = typeof(Model.Person);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(311, 9);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 0;
            label1.Text = "Добавление человека";
            label1.Click += label1_Click;
            // 
            // AddPerson
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Name = "AddPerson";
            Text = "AddPerson";
            ((System.ComponentModel.ISupportInitialize)personBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource personBindingSource;
        private Label label1;
    }
}