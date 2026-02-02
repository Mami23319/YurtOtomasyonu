using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YurtOtomasyonuWinUI.Models;

namespace YurtOtomasyonuWinUI
{
    public partial class OgrenciKayit : Form
    {
        public OgrenciKayit()
        {
            InitializeComponent();
        }

        YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();

        private void OgrenciKayit_Load(object sender, EventArgs e)
        {
            var OdaListesi = db.Oda.ToList();

            comboBox1.DataSource = OdaListesi;
            comboBox1.DisplayMember = "OdaNumarasi";
            comboBox1.ValueMember = "OdaID";
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Aktif");
            comboBox2.Items.Add("Blokeli");
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AdSoyad = [" + textBox1.Text + "]");

            string tc = maskedTextBox1.Text;
            string adSoyad = textBox1.Text;
            DateTime dogum = dateTimePicker1.Value;
            string durum = comboBox2.Text;
            var ogrenciKontrol = db.Ogrenci.Where(x => x.TCno == tc).FirstOrDefault();

            if (ogrenciKontrol != null)
            {
                MessageBox.Show(tc + " TC Numarası ile zaten bir kayıt mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                maskedTextBox1.SelectAll();
            }
            else
            {
                Ogrenci yeniOgr = new Ogrenci()
                {
                    TCno = tc,
                    AdSoyad = adSoyad,
                    DogumTarihi = dogum,
                    KayitTarihi = DateTime.Now,
                    Durum = durum,
                 
                    OdaID = comboBox1.SelectedValue != null ? (int)comboBox1.SelectedValue : (int?)null
                };

          
                db.Ogrenci.Add(yeniOgr);


                int sonuc = db.SaveChanges();

                if (sonuc > 0)
                {
                    MessageBox.Show("Öğrenci Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                }
            } 
        } 

       
        void Temizle()
        {
            maskedTextBox1.Clear();
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Now;

            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            maskedTextBox1.Focus();
        }

    } 
} 