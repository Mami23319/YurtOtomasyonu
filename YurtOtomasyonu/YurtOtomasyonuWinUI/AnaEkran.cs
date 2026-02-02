using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtOtomasyonuWinUI
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        private void öğrenciİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AnaEkran_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void personelListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonel fr = new FrmPersonel();
            fr.MdiParent = this;
            fr.Show();
        }

        private void öğrenciListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciListe fr = new OgrenciListe();
            fr.MdiParent = this;
            fr.Show();
        }

        private void öğrenciKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OgrenciKayit fr = new OgrenciKayit();
            fr.MdiParent = this;
            fr.Show();
        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {

        }

        private void ödemelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOdemeler fr = new FrmOdemeler();
            fr.MdiParent = this; 
            fr.Show();
        }

        private void blokeliÖğrencilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBlokeliler1 fr = new FrmBlokeliler1();
            fr.MdiParent = this; 
            fr.Show();
        }

        private void blokelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBlokeliler1 fr = new FrmBlokeliler1();
            fr.MdiParent = this;
            fr.Show();
        }

      

        private void gelirGiderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGelirGider fr = new FrmGelirGider();

            fr.MdiParent = this;

            fr.Show();
        }

        private void gelirGiderKayıtlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGelirGider fr = new FrmGelirGider();
            fr.MdiParent = this;
            fr.Show();
        }

        private void odaDurumlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOdaDurumlari fr = new FrmOdaDurumlari();
            fr.MdiParent = this; 
            fr.Show();
        }

        private void girişÇıkışKayıtlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGirisCikis fr = new FrmGirisCikis();
            fr.MdiParent = this; 
            fr.Show();
        }

        
            private void izinTalepleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIzinler fr = new FrmIzinler();
            fr.MdiParent = this; 
            fr.Show();
        }
    
    }
}
