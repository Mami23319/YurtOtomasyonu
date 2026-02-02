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
    public partial class OgrenciListe : Form
    {
        public OgrenciListe()
        {
            InitializeComponent();
        }
        YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();
        private void OgrenciListe_Load(object sender, EventArgs e)
        {
            Listele();
        }

        public void Listele()
        {
            YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();

            dataGridView1.DataSource = db.Ogrenci
                .AsNoTracking()
                .Select(o => new
                {
                    ID = o.OgrenciID,
                    TC_No = o.TCno,
                    AdSoyad = o.AdSoyad,
                    Dogum_Tarihi = o.DogumTarihi,
                    Oda_No = o.OdaID,
                    Kayit_Tarihi = o.KayitTarihi,
                    Durum = o.Durum
                })
                .OrderBy(o => o.AdSoyad)
                .ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
