using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using LogicLayer;
using DataAccessLayer;

namespace Staff_Project
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PersonelListe = LogicPersonel.lgcPersonelListesi();
            dataGridView1.DataSource = PersonelListe;   
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            EntityPersonel entit = new EntityPersonel();
            entit.Ad = txtAd.Text;
            entit.Soyad = txtSoyad.Text;
            entit.Sehir = txtSehir.Text;
            entit.Maas = short.Parse(txtMaas.Text);
            entit.Gorev = txtGorev.Text;
            LogicPersonel.Pers_Ekle(entit);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id  = Convert.ToInt32(txtId.Text);
            LogicPersonel.LPer_Sil(ent.Id);
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(txtId.Text);
            ent.Ad = txtAd.Text;
            ent.Soyad = txtSoyad.Text;
            ent.Sehir = txtSehir.Text;
            ent.Gorev = txtGorev.Text;
            ent.Maas = short.Parse (txtMaas.Text);
            LogicPersonel.LPersonelGuncelle(ent);
        }
    }
}
