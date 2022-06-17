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
using CroDex_2._0.UI;


namespace CroDex_2._0
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        Uyeler uye = new Uyeler();
        Oyunlar oyun = new Oyunlar();

        private void btnOyunlar_Click(object sender, EventArgs e)
        {
            oyun.ShowDialog();
        }

        private void btnUyeler_Click(object sender, EventArgs e)
        {
            uye.ShowDialog();
        }

        private void btnSatısYap_Click(object sender, EventArgs e)
        {
            FrmSatis frm = new FrmSatis()
            {
                Text = "Satış Yap",
                Satis = new Satis() { ID = Guid.NewGuid().ToString() },
            };

        tekrar:
            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.SatisEkle(frm.Satis);

                if (b)
                {

                    DataSet ds1 = BLogic.SatisDetay();
                    if (ds1 != null)
                        dataGridView1.DataSource = ds1.Tables[0];
                }
                else
                    goto tekrar;

            }






        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            DataSet ds1 = BLogic.SatisDetay();
            if (ds1 != null)
                dataGridView1.DataSource = ds1.Tables[0];

        }

        private void btnSatışDüzenle_Click(object sender, EventArgs e)
        {

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            FrmSatis frm = new FrmSatis()
            {
                Text = "Satış Güncelle",
                Güncelleme = true,
                Satis = new Satis()
                {
                    ID = row.Cells[0].Value.ToString(),
                    UyeID = row.Cells[1].Value.ToString(),
                    OyunID = row.Cells[2].Value.ToString(),
                    Fiyat = double.Parse(row.Cells[7].Value.ToString()),
                    Tarih = DateTime.Parse(row.Cells[8].Value.ToString()),

                },
            };

            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.SatisGüncelle(frm.Satis);

                if (b)
                {
                    row.Cells[1].Value = frm.Satis.UyeID;
                    row.Cells[2].Value = frm.Satis.OyunID;
                    row.Cells[7].Value = frm.Satis.Fiyat;
                    row.Cells[8].Value = frm.Satis.Tarih;

                }

            }
        }

        private void btnSatisSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            var ID = row.Cells[0].Value.ToString();


            var sonuc = MessageBox.Show("Seçili kayıt silinsin mi?", "Silmeyi onayla",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.SatisSil(ID);

                if (b)
                {

                    DataSet ds = BLogic.SatisDetay();
                    if (ds != null)
                        dataGridView1.DataSource = ds.Tables[0];
                }

            }
        }

        private void btnMusteriBul_Click(object sender, EventArgs e)
        {

        }
    }
}
