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
    public partial class FrmUye : Form
    {
        public FrmUye()
        {
            InitializeComponent();
        }



        public Uye Uye { get; set; }
        public bool Güncelleme { get; set; } = false;




        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ErrorControl(txtAd)) return;
            if (!ErrorControl(txtSoy)) return;
            if (!ErrorControl(txtTel)) return;
            if (!ErrorControl(txtMail)) return;

            Uye.Ad = txtAd.Text;
            Uye.Soyad = txtSoy.Text;
            Uye.Telefon = txtTel.Text;
            Uye.Mail = txtMail.Text;

            DialogResult = DialogResult.OK;
        }
        private bool ErrorControl(Control c)
        {
            if (c is TextBox)
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

            if (c is MaskedTextBox)
            {
                if (!((MaskedTextBox)c).MaskFull)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmUye_Load(object sender, EventArgs e)
        {
            txtID.Text = Uye.ID.ToString();
            if (Güncelleme)
            {
                txtAd.Text = Uye.Ad;
                txtSoy.Text = Uye.Soyad;
                txtTel.Text = Uye.Telefon;
                txtMail.Text = Uye.Mail;

            }


        }
    }
}
