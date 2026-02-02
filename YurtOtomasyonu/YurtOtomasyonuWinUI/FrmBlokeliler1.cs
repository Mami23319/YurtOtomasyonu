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
    public partial class FrmBlokeliler1 : Form
    {
        public FrmBlokeliler1()
        {
            InitializeComponent();
        }
        YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();
        private void FrmBlokeliler_Load(object sender, EventArgs e)
        {
            var blokeliListesi = db.Ogrenci
                .Where(x => x.Durum == "Blokeli")
                .Select(x => new
                {
                    x.OgrenciID,
                    x.AdSoyad,
                    x.TCno, 
                    x.KayitTarihi, 
                    x.Durum
                }).ToList();

            dataGridView1.DataSource = blokeliListesi;
        }

       
    }
}
