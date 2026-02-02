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
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }

        YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();

        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            // Verileri çekiyoruz
            var ogrenciListesi = db.Ogrenci.Select(x => new
            {
                Id = x.OgrenciID, // Arkada tutulacak isim
                Ad = x.AdSoyad     // Ekranda görünecek isim
            }).ToList();

            // Ayarları ÖNCE yapıyoruz
            comboBox1.DisplayMember = "Ad";
            comboBox1.ValueMember = "Id";

            // Veriyi EN SON bağlıyoruz
            comboBox1.DataSource = ogrenciListesi;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Eğer bir seçim yapılmışsa ve ValueMember düzgün çalışıyorsa
            if (comboBox1.SelectedValue != null)
            {
                // SelectedValue bize yukarıda tanımladığımız "Id" değerini verir
                textBox1.Text = comboBox1.SelectedValue.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Odeme yeniKayit = new Odeme();

            
            yeniKayit.OgrenciID = int.Parse(textBox1.Text);
            yeniKayit.Tutar = decimal.Parse(textBox3.Text);

           
            yeniKayit.OdemeTarihi = DateTime.Now;
            yeniKayit.Ay = DateTime.Now.Month;
            yeniKayit.Yil = DateTime.Now.Year;

            db.Odeme.Add(yeniKayit);

           
            int secilenID = int.Parse(textBox1.Text);
            var ogr = db.Ogrenci.Find(secilenID);

            if (ogr != null)
            {
                ogr.Durum = "Aktif";
            }

            
            db.SaveChanges();

            MessageBox.Show("Ödeme başarıyla alındı. Öğrenci artık AKTİF.");

            
            textBox3.Clear();
        }

        
        private void label3_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
    }
}