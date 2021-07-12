using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class Siparis
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string MusteriAdi { get; set; }
        public string TelNo { get; set; }
        public string UrunId { get; set; }
        public string Olcu { get; set; }
        public string Renk { get; set; }
        public double? Gram { get; set; }
        public double? Kapora { get; set; }
        public double? Kalan { get; set; }
        public double? SatisTutari { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public string TeslimAlan { get; set; }
        public string Aciklama { get; set; }
        public string SubeNo { get; set; }
        public string islemci { get; set; }


    }
}