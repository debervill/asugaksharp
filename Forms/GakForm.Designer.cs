namespace asugaksharp.Forms
{
    partial class GakForm
    {
        
        private System.ComponentModel.IContainer components = null;

        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        

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