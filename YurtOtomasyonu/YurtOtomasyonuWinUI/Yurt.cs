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
    public partial class Yurt : Form
    {
        public Yurt()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
        
            string personelIsmi = textBox1.Text;
            string sifre = textBox2.Text;

            if ((string.IsNullOrEmpty(personelIsmi)) || (string.IsNullOrEmpty(sifre)))
            {
                MessageBox.Show("İsim veya Şifre Boş Geçilemez.", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (YurtOtomasyonuEntities db = new YurtOtomasyonuEntities())
                {
          
                    var personel = db.Personel.Where(x => x.AdSoyad == personelIsmi && x.Sifre == sifre).FirstOrDefault();

                    if (personel == null)
                    {
                        MessageBox.Show("Personel İsmi veya Şifre Hatalı", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Giriş Başarılı\nHoşgeldiniz: {personel.AdSoyad}",
                            "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AnaEkran anaEkran = new AnaEkran();
                        this.Hide();
                        anaEkran.ShowDialog();
                    }
                }
            }
        }
    }
}
