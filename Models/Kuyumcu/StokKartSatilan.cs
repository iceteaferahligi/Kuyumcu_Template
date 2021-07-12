using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Kuyumcu
{
    [Table("StokKartSatilan")]
    public class StokKartSatilan
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string StokId { get; set; } // ürün barkodu, fis no
        public string StokCinsi { get; set; } // Altın, Gümüş, Saat
        public string StokGrubu { get; set; } // 14 ayar, 22 ayar ...
        public string StokAltGrubu { get; set; } //24 ayar bilezik, 24 ayar altin
        public string Hesaplama { get; set; } // Adet, Gram
        public string Sertifika { get; set; }
        public double Miktar { get; set; }
        public double Milyem { get; set; }
        public double IscilikCm { get; set; }
        public double IscilikCmG { get; set; }
        public double IscilikGr { get; set; }
        public double HasNet { get; set; }
        public double BirimFiyat { get; set; }
        public double Maliyet { get; set; }
        public double? Fire { get; set; }
        public string Turu { get; set; } // USD, EURO, HAS...
        public double Kar { get; set; }
        public double SatisTutari { get; set; }
        public string ToptanciAdi { get; set; }
        public DateTime Tarih { get; set; }
        public string Ozellik1 { get; set; }  // mm, incili, taşlı, taşsız
        public string Ozellik2 { get; set; } // 40,42,48,... beyaz renk, 2 renk
        public string Ozellik3 { get; set; }
        public string Ozellik4 { get; set; } // bay, bayan, fantazi
        public string Ozellik5 { get; set; }
        public string Ozellik6 { get; set; }
        public string Ozellik7 { get; set; }
        public string Ozellik8 { get; set; }
        public string Ozellik9 { get; set; }
        public string Ozellik10 { get; set; }
        public string MagazaNo { get; set; } // Şube 
        public DateTime RafOmru { get; set; }
        public string Image { get; set; }
        public int Emanet { get; set; }
        public string MusteriAdi { get; set; }
        public string Islemci { get; set; }
        public double EtiketFiyat { get; set; }
     
    
    }
}