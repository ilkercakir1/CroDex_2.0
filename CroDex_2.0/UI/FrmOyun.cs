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
    public partial class FrmOyun : Form
    {
        public FrmOyun()
        {
            InitializeComponent();
        }

        public Oyun Oyun { get; set; }
        public bool Güncelleme { get; set; } = false;



        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtOyun)) return;
            if (!ErrorControl(txtFirma)) return;
            if (!ErrorControl(cbKategori)) return;
            if (!ErrorControl(nmFiyat)) return;
            if (!ErrorControl(txtDetay)) return;

            Oyun.Ad = txtOyun.Text;
            Oyun.Firma = txtOyun.Text;
            Oyun.Aciklama = txtDetay.Text;
            Oyun.Kategori = cbKategori.Text;
            Oyun.Cyili = dtTarih.Value;
            Oyun.Fiyat = (double)nmFiyat.Value;



            DialogResult = DialogResult.OK;
        }


        private bool ErrorControl(Control c)
        {
            if (c is TextBox || c is ComboBox)
            {
                if (c.Text == "")
                {
                    errorProvider1.SetError(c, "Lütfen Bütün alanları doldurunuz");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;

                }
            }

            if (c is NumericUpDown)
            {
                if (((NumericUpDown)c).Value == 0)
                {
                    errorProvider1.SetError(c, "Lütfen Bütün alanları doldurunuz");
                    c.Focus();
                    return false;
                }
                else
                {
                    errorProvider1.SetError(c, "");
                    return true;

                }
            }

            return true;

        }


        private void FrmOyun_Load(object sender, EventArgs e)
        {
            txtID.Text = Oyun.ID.ToString();
            if (Güncelleme)
            {
                txtOyun.Text = Oyun.Ad;
                txtFirma.Text = Oyun.Firma;
                    cbKategori.Text = Oyun.Kategori;
                    dtTarih.Value = Oyun.Cyili;
                nmFiyat.Value = (decimal)Oyun.Fiyat;
                txtDetay.Text = Oyun.Aciklama;

            }
        }
    }
}
