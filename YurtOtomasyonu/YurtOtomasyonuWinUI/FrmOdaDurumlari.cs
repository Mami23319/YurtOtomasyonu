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
    public partial class FrmOdaDurumlari : Form
    {
        public FrmOdaDurumlari()
        {
            InitializeComponent();
        }
        YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();
        private void FrmOdaDurumlari_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele()
        {
           
            var odalar = db.Oda.Select(x => new
            {
                x.OdaID,
                x.OdaNumarasi,
                x.Kapasite,
                x.Kat,
                x.MevcutKisiSayisi
            }).ToList();

            dataGridView1.DataSource = odalar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Oda o = new Oda();
            o.OdaNumarasi = textBox1.Text;
            o.Kapasite = int.Parse(textBox2.Text);
            o.Kat = int.Parse(textBox3.Text);
            o.MevcutKisiSayisi = int.Parse(textBox4.Text);

            db.Oda.Add(o);
            db.SaveChanges();
            MessageBox.Show("Yeni oda eklendi.");
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secilenId = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var guncellenecekOda = db.Oda.Find(secilenId);

            guncellenecekOda.OdaNumarasi = textBox1.Text;
            guncellenecekOda.Kapasite = int.Parse(textBox2.Text);
            guncellenecekOda.Kat = int.Parse(textBox3.Text);
            guncellenecekOda.MevcutKisiSayisi = int.Parse(textBox4.Text);

            db.SaveChanges();
            MessageBox.Show("Oda bilgileri güncellendi.");
            Listele();
        }
    }
}
