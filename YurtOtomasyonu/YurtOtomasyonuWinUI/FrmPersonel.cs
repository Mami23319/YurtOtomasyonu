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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        YurtOtomasyonuEntities db = new YurtOtomasyonuEntities();
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Personel.Select(p => new
            {
                ID = p.PersonelID,
                Ad_Soyad = p.AdSoyad,
                TC_Kimlik = p.TCno,
                Gorev = p.Gorev,
                Yetki = p.Yetki,
                Kullanıcı_Adı = p.KullaniciAdi
            }).OrderBy(p => p.Ad_Soyad).ToList();
        }
    }
}
