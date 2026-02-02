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
    public partial class FrmIzinler : Form
    {
        public FrmIzinler()
        {
            InitializeComponent();
        }
        YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();
        private void FrmIzinler_Load(object sender, EventArgs e)
        {
            var ogrenciler = db.Ogrenci.Select(x => new { x.OgrenciID, x.AdSoyad }).ToList();
            comboBox1.DisplayMember = "AdSoyad";
            comboBox1.ValueMember = "OgrenciID";
            comboBox1.DataSource = ogrenciler;

            Listele();
        }
        void Listele()
        {
            
            dataGridView1.DataSource = db.IzinBasvuru.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IzinBasvuru i = new IzinBasvuru();
            i.OgrenciID = (int)comboBox1.SelectedValue;
            i.BaslangicTarihi = dateTimePicker1.Value;
            i.BitisTarihi = dateTimePicker2.Value;
            

            db.IzinBasvuru.Add(i);
            db.SaveChanges();

            MessageBox.Show("İzin talebi kaydedildi.");
            Listele();
        }
    }
}
