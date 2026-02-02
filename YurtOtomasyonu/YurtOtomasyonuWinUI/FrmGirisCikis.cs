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
    public partial class FrmGirisCikis : Form
    {
        public FrmGirisCikis()
        {
            InitializeComponent();
        }
        YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();
        private void FrmGirisCikis_Load(object sender, EventArgs e)
        {
            
            var ogrenciler = db.Ogrenci.Select(x => new {
                x.OgrenciID,
                x.AdSoyad
            }).ToList();

            comboBox1.DisplayMember = "AdSoyad"; 
            comboBox1.ValueMember = "OgrenciID"; 
            comboBox1.DataSource = ogrenciler;

            
            comboBox2.Items.Add("Giriş");
            comboBox2.Items.Add("Çıkış");
            comboBox2.SelectedIndex = 0;

            Listele();
        }

        void Listele()
        {
            
            var hareketler = db.GirisCikis.Select(x => new
            {
                x.GirisCikisID,
                x.OgrenciID,
                x.IslemId,
                x.Tarih
            }).OrderByDescending(z => z.GirisCikisID).ToList();

            dataGridView1.DataSource = hareketler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GirisCikis g = new GirisCikis();
            g.OgrenciID = (int)comboBox1.SelectedValue; 
            g.IslemId = comboBox2.SelectedIndex + 1; 
            g.Tarih = dateTimePicker1.Value; 

            db.GirisCikis.Add(g);
            db.SaveChanges();

            MessageBox.Show("Hareket kaydı tamamlandı.");
            Listele();
        }
    }
}
