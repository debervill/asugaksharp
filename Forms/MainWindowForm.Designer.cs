namespace asugaksharp.Forms
{
    partial class MainWindowForm
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
            btnNaprPodg = new Button();
            btnProfiliPodg = new Button();
            btnStudents = new Button();
            btnAddPerson = new Button();
            btnOplata = new Button();
            btnGAK = new Button();
            btnAddPeriodZ = new Button();
            
            // 
            // btnNaprPodg
            // 
            btnNaprPodg.Location = new Point(12, 12);
            btnNaprPodg.Name = "btnNaprPodg";
            btnNaprPodg.Size = new Size(200, 29);
            btnNaprPodg.Text = "Направления подготовки";
            //btnNaprPodg.Click += btnNaprPodg_Click;
            // 
            // btnProfiliPodg
            // 
            btnProfiliPodg.Location = new Point(12, 47);
            btnProfiliPodg.Name = "btnProfiliPodg";
            btnProfiliPodg.Size = new Size(200, 29);
            btnProfiliPodg.Text = "Профили подготовки";
            //btnProfiliPodg.Click += btnProfiliPodg_Click;
            // 
            // btnStudents
            // 
            btnStudents.Location = new Point(12, 82);
            btnStudents.Name = "btnStudents";
            btnStudents.Size = new Size(200, 29);
            btnStudents.Text = "Студенты";
           // btnStudents.Click += btnStudents_Click;
            // 
            // btnAddPerson
            // 
            btnAddPerson.Location = new Point(12, 117);
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.Size = new Size(200, 29);
            btnAddPerson.Text = "Добавить участника ГАК";
            //btnAddPerson.Click += btnAddPerson_Click;
            // 
            // btnOplata
            // 
            btnOplata.Location = new Point(12, 152);
            btnOplata.Name = "btnOplata";
            btnOplata.Size = new Size(200, 29);
            btnOplata.Text = "Оплата";
            //btnOplata.Click += btnOplata_Click;
            // 
            // btnGAK
            // 
            btnGAK.Location = new Point(12, 187);
            btnGAK.Name = "btnGAK";
            btnGAK.Size = new Size(200, 29);
            btnGAK.Text = "ГАК";
            //btnGAK.Click += btnGAK_Click;
            // 
            // btnAddPeriodZ
            // 
            btnAddPeriodZ.Location = new Point(12, 222);
            btnAddPeriodZ.Name = "btnAddPeriodZ";
            btnAddPeriodZ.Size = new Size(200, 29);
            btnAddPeriodZ.Text = "Добавить период заседания";
            //btnAddPeriodZ.Click += btnAddPeriodZ_Click;
            // 
            // MainWindowForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 264);
            Controls.Add(btnNaprPodg);
            Controls.Add(btnProfiliPodg);
            Controls.Add(btnStudents);
            Controls.Add(btnAddPerson);
            Controls.Add(btnOplata);
            Controls.Add(btnGAK);
            Controls.Add(btnAddPeriodZ);
            Name = "MainWindowForm";
            Text = "Главное окно";
        }

        #endregion

        private Button btnNaprPodg;
        private Button btnProfiliPodg;
        private Button btnStudents;
        private Button btnAddPerson;
        private Button btnOplata;
        private Button btnGAK;
        private Button btnAddPeriodZ;
    }
}