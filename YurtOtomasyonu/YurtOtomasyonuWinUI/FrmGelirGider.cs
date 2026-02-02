using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using YurtOtomasyonuWinUI.Models;

namespace YurtOtomasyonuWinUI
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }

        YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            
            var kisiler = db.Ogrenci.Select(x => x.AdSoyad).ToList();
            comboBox2.DataSource = kisiler;

            
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("Gelir");
                comboBox1.Items.Add("Gider");
            }
            comboBox1.SelectedIndex = 0;

            Listele();
        }

        void Listele()
        {
            
            var veriler = db.GelirGider.Select(x => new
            {
                x.GelirGiderID,
                x.Tur,
                x.Aciklama, 
                x.Tutar,
                x.Tarih
            }).OrderByDescending(z => z.GelirGiderID).ToList();

            dataGridView1.DataSource = veriler;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox1.Text) || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tutar giriniz ve bir kişi seçiniz.");
                return;
            }

            GelirGider g = new GelirGider();
            g.Tur = comboBox1.Text;
            g.Aciklama = comboBox2.Text; 
            g.Tutar = decimal.Parse(textBox1.Text);
            g.Tarih = dateTimePicker1.Value;

            db.GelirGider.Add(g);
            db.SaveChanges();

            MessageBox.Show("Finansal kayıt başarıyla eklendi!");
            Listele();

           
            textBox1.Clear();
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }
    }
}