using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Kuyumcu
{
    [Table("TabelaLoglari")]
    public class tabelalog
    {
        public DateTime tarih { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      
        public int StokId { get; set; } // ürün barkodu, fis no
        public string StokCinsi { get; set; } // Altın, Gümüş, Saat
        public double? AlisFiyati { get; set; } // 14 ayar, 22 ayar ...
        public double? SatisFiyati { get; set; } //24 ayar bilezik, 24 ayar altin
        public double? HsNet { get; set; } // Adet, Gram
        public double? HsNetSatis { get; set; }

    }
}