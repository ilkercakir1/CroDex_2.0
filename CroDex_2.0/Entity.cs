using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroDex_2._0
{
    public class Uye 
    {

        public string ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }

        public override string ToString()
        {
            return $"{Ad} {Soyad}";
        }


    }

    public class Oyun 
    {
        public string ID { get; set; }
        public string Ad { get; set; }
        public string Firma { get; set; }
        public string Aciklama { get; set; }
        public string Kategori { get; set; }
        public double Fiyat { get; set; }
        public DateTime Cyili { get; set; }

        public override string ToString()
        {
            return $"{Ad} {Aciklama}";
        }

    }

    public class Satis 
    {

        public string ID { get; set; }
        public string UyeID { get; set; }
        public string OyunID { get; set; }
        public DateTime Tarih { get; set; }
        public double Fiyat { get; set; }


    }

}
