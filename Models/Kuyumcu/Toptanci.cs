using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Kuyumcu
{
    [Table("Toptanci")]
    public class Toptanci
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string ToptanciId { get; set; } //toptanci cari kod
        public string ToptanciAdi { get; set; }
        public string ToptanciAdres { get; set; }
        public string ToptanciYetkili { get; set; }
        public string ToptanciTel { get; set; }
        public string MagazaNo { get; set; } //şube
        public string Turu { get; set; } // USD, EURO, HAS...
        public double Bakiye { get; set; }
        public double TlBakiye { get; set; }
        public double EuroBakiye { get; set; }
        public double UsdBakiye { get; set; }
        public double ChfBakiye { get; set; }
        public double StrlBakiye { get; set; }
        public double CeyrekBakiye { get; set; }
        public double YiAyarBakiye { get; set; }
        public double YiAyar { get; set; }       
        public string ToptanciTipi { get; set; } // genel, günlük
        public bool Durum { get; set; }
        public string KayitTuru { get; set; } // normal, konsinye
    }
}