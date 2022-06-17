using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CroDex_2._0.UI
{
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }


        public Oyun Oyun { get; set; }
        public Uye Uye { get; set; }




        public Satis Satis { get; set; }
        public bool Güncelleme { get; set; } = false;



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (nmFiyat.Value == 0)
            {
                errorProvider1.SetError(nmFiyat, "Lütfen fiyat giriniz!");
                nmFiyat.Focus();
                return;

            }
            else
            {
                errorProvider1.SetError(nmFiyat, "");
            }

            Satis.Tarih = dtTarih.Value;
            Satis.Fiyat = (double)nmFiyat.Value;
            Satis.OyunID = txtOyun.Text;
            Satis.UyeID = txtUye.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }



        private void FrmSatis_Load(object sender, EventArgs e)
        {
            txtID.Text = Satis.ID.ToString();
            if (Güncelleme)
            {
                txtUye.Text = Satis.UyeID.ToString();
                txtOyun.Text = Satis.OyunID.ToString();
                nmFiyat.Value = (decimal)Satis.Fiyat;
                dtTarih.Value = Satis.Tarih;
            }
        }

        private void btnUyeSec_Click(object sender, EventArgs e)
        {
            Uyeler frm = new Uyeler();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtUye.Text = frm.uye.Ad.ToString();
            }
        }

        private void btnOyunSec_Click(object sender, EventArgs e)
        {
            Oyunlar frm = new Oyunlar();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtOyun.Text = frm.oyun.Ad.ToString();
            }
        }
    }
}
