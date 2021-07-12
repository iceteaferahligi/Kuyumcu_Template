using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Kuyumcu
{
    [Table("BarkodsuzStokKart")]
    public class BarkodsuzStokKart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StokId { get; set; }
        public string StokCinsi { get; set; } // Altın, Gümüş, Saat
        public string Hesaplama { get; set; } // Adet, Gram
        public string Turu { get; set; } // USD, EURO, HAS...
        public double? AlisFiyati { get; set; }
        public double? SatisFiyati { get; set; }
        public double? Miktar { get; set; }
        public double? Emanet { get; set; }
        public double? HsNet { get; set; }
        public double? HsNetSatis { get; set; }
    }
}