using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CroDex_2._0.BL;   

namespace CroDex_2._0.UI
{
    public partial class Uyeler : Form
    {


        public Uyeler()
        {
            InitializeComponent();
        }



        public Uye uye { get; set; }



        private void Uyeler_Load(object sender, EventArgs e)
        {
            DataSet ds = BLogic.UyeGetir("");
            if (ds != null)
                dataGridView1.DataSource = ds.Tables[0];

        }




        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            FrmUye frmUye = new FrmUye()
            {
                Text = "Üye Ekle",
                Uye = new Uye() { ID = Guid.NewGuid().ToString() },
            };


        tekrar:
            var sonuc = frmUye.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UyeEkle(frmUye.Uye);

                if (b)
                {

                    DataSet ds = BLogic.UyeGetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;
            }
        }






        private void btnUyeDüzenle_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            FrmUye frmUye = new FrmUye()
            {
                Text = "Uye Güncelle",
                Güncelleme = true,
                Uye = new Uye()
                {
                    ID = row.Cells[0].Value.ToString(),
                    Ad = row.Cells[1].Value.ToString(),
                    Soyad = row.Cells[2].Value.ToString(),
                    Telefon = row.Cells[3].Value.ToString(),
                    Mail = row.Cells[4].Value.ToString(),

                },
            };


            var sonuc = frmUye.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UyeGuncelle(frmUye.Uye);

                if (b)
                {
                    row.Cells[1].Value = frmUye.Uye.Ad;
                    row.Cells[2].Value = frmUye.Uye.Soyad;
                    row.Cells[3].Value = frmUye.Uye.Telefon;
                    row.Cells[4].Value = frmUye.Uye.Mail;

                }

            }


        }






        private void btnUyeBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.UyeGetir(toolStripTextBox1.Text);
            if (ds != null)
                dataGridView1.DataSource = ds.Tables[0];
        }




        private void btnUyeSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();


            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi?", "Silmeyi onayla",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UyeSil(ID);

                if (b)
                {

                    DataSet ds = BLogic.UyeGetir("");
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];


            uye = new Uye()
            {
                ID = row.Cells[0].Value.ToString(),
                Ad = row.Cells[1].Value.ToString(),
                Soyad = row.Cells[2].Value.ToString(),
                Telefon = row.Cells[3].Value.ToString(),
                Mail = row.Cells[4].Value.ToString(),
            };


            DialogResult = DialogResult.OK;
        }
    }
}
