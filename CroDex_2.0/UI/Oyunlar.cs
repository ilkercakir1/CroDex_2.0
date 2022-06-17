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
    public partial class Oyunlar : Form
    {



        public Oyunlar()
        {
            InitializeComponent();
        }

        public Oyun oyun { get; set; }





        private void btnOyunEkle_Click(object sender, EventArgs e)
        {
            FrmOyun frmOyun = new FrmOyun()
            {
                Text = "Oyun Ekle",
                Oyun = new Oyun() { ID = Guid.NewGuid().ToString() },
            };

        tekrar:
            var sonuc = frmOyun.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.OyunEkle(frmOyun.Oyun);

                if (b)
                {

                    DataSet ds = BLogic.OyunGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }
                else
                    goto tekrar;

            }
        }


        private void Oyunlar_Load(object sender, EventArgs e)
        {
            DataSet ds2 = BLogic.OyunGetir("");
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];
        }




        private void btnOyunBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.OyunGetir(toolStripTextBox2.Text);
            if (ds != null)
                dataGridView2.DataSource = ds.Tables[0];
        }


        private void btnOyunDüzenle_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = dataGridView2.SelectedRows[0];

            FrmOyun frm = new FrmOyun()
            {
                Text = "Oyun Güncelle",
                Güncelleme = true,
                Oyun = new Oyun()
                { 
                    ID = row.Cells[0].Value.ToString(),
                    Ad = row.Cells[1].Value.ToString(),
                    Firma = row.Cells[2].Value.ToString(),
                    Aciklama = row.Cells[3].Value.ToString(),
                    Kategori = row.Cells[4].Value.ToString(),
                    Cyili= DateTime.Parse(row.Cells[5].Value.ToString()),
                    Fiyat = double.Parse(row.Cells[6].Value.ToString()),

                },
            };

            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.OyunGuncelle(frm.Oyun);

                if (b)
                {
                    row.Cells[1].Value = frm.Oyun.Ad;
                    row.Cells[2].Value = frm.Oyun.Firma;
                    row.Cells[3].Value = frm.Oyun.Aciklama;
                    row.Cells[4].Value = frm.Oyun.Kategori;
                    row.Cells[5].Value = frm.Oyun.Cyili;
                    row.Cells[6 ].Value = frm.Oyun.Fiyat;


                }

            }
        }


        private void btnOyunSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();


            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi?", "Silmeyi onayla",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.OyunSil(ID);

                if (b)
                {

                    DataSet ds = BLogic.OyunGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];
                }

            }
        }




        private void btnSec_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];


            oyun = new Oyun()
            {
                ID = row.Cells[0].Value.ToString(),
                Ad = row.Cells[1].Value.ToString(),
                Firma = row.Cells[2].Value.ToString(),
                Aciklama = row.Cells[3].Value.ToString(),
                Kategori = row.Cells[4].Value.ToString(),
                Cyili = DateTime.Parse(row.Cells[5].Value.ToString()),
                Fiyat = double.Parse(row.Cells[6].Value.ToString()),


            };

            DialogResult = DialogResult.OK;
        }
    }
}
