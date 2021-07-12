using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Kuyumcu_Sorgu
{
    public class Tamirat
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string MusteriAdi { get; set; }
        public string TelNo { get; set; }
        public string mail { get; set; }
        public string adres1 { get; set; }
        public string adres2 { get; set; }
        public string ayar { get; set; }
        public double? agirlik { get; set; }
        public double? ucret { get; set; }
        public string islemci { get; set; }
        public string aciklama { get; set; }
        public string subeno { get; set; }
        public DateTime tarih { get; set; }

    }
}