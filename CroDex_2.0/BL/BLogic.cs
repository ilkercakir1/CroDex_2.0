using CroDex_2._0.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CroDex_2._0.BL
{
    public static class BLogic
    {   



        public static bool UyeEkle(Uye u)
        {
            try
            {
                int res = DataLayer.UyeEkle(u);

                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return false;
            }

        }


        internal static DataSet UyeGetir(string filtre)
        {
            try
            {
                DataSet ds = DataLayer.UyeGetir(filtre);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return null;
            }


        }


        internal static bool UyeGuncelle(Uye u)
        {
            try
            {
                int res = DataLayer.UyeGuncelle(u);

                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return false;
            }
        }

        public static bool SatisEkle(Satis s)
        {
            try
            {
                int res = DataLayer.SatisEkle(s);

                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return false;
            }
        }

        internal static DataSet SatisDetay()
        {
            try
            {
                DataSet ds = DataLayer.SatisDetay();

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return null;
            }
        }

        internal static bool UyeSil(string id)
        {
            try
            {
                int res = DataLayer.UyeSil(id);

                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return false;
            }

        }





        internal static DataSet OyunGetir(string filtre)
        {
            try
            {
                DataSet ds = DataLayer.OyunGetir(filtre);

                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return null;
            }
        }

        internal static bool SatisGüncelle(Satis s)
        {
            try
            {
                int res = DataLayer.SatisGüncelle(s);

                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return false;
            }
        }

        public static bool OyunEkle(Oyun o)
        {
            try
            {
                int res = DataLayer.OyunEkle(o);

                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return false;
            }
        }

        internal static bool SatisSil(string id)
        {
            try
            {
                int res = DataLayer.SatisSil(id);

                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return false;
            }
        }

        internal static bool OyunGuncelle(Oyun o)
        {
            try
            {
                int res = DataLayer.OyunGuncelle(o);

                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return false;
            }
        }


        internal static bool OyunSil(string id)
        {
            try
            {
                int res = DataLayer.OyunSil(id);

                return (res > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu:" + ex.Message);
                return false;
            }
        }
    }
}
