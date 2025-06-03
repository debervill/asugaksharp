using asugaksharp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asugaksharp.Forms
{
    public partial class NapravleniaPogotovkiForm : Form
    {
        public NapravleniaPogotovkiForm()
        {
            InitializeComponent();
            InitializeData();
            LoadExistingData();
        }
        public BindingList<NapravleniePodgotovki> napravleniaList;

        private void InitializeData()
        {
            napravleniaList = new BindingList<NapravleniePodgotovki>();

            // Привязываем к существующему BindingSource из дизайнера
            napravleniePodgotovkiBindingSource.DataSource = napravleniaList;
        }

        private void LoadExistingData() {
            using var db = new Model.AppDbContext();
            // Загружаем все записи из базы данных
            var data = db.NapravleniePodgotovki.ToList();

            dataGridView1.DataSource = data;


        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;
            string shifr = ShifrBox.Text.Trim();
            string nazvanie = NazvanieBox.Text.Trim();

            CreateNewRecord(shifr, nazvanie);
            LoadExistingData();
            ClearFields();


        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }



        private void CreateNewRecord(string shifr, string nazvanie)
        {
            var newNapravlenie = new NapravleniePodgotovki
            {
                
                ShifrNapr = shifr,
                Nazvanie = nazvanie
            };

            using var db = new Model.AppDbContext();

            db.NapravleniePodgotovki.Add(newNapravlenie);
            db.SaveChanges();



            napravleniaList.Add(newNapravlenie);
            MessageBox.Show("Направление добавлено!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(ShifrBox.Text))
            {
                MessageBox.Show("Введите шифр направления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShifrBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(NazvanieBox.Text))
            {
                MessageBox.Show("Введите название направления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NazvanieBox.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            ShifrBox.Clear();
            NazvanieBox.Clear();
            //editingId = null;
            ShifrBox.Focus();
        }

    }
}
