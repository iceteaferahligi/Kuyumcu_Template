using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Kuyumcu
{
    [Table("StokHareket")]
    public class StokHareket
    {
        
        public DateTime Tarih { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IslemNo { get; set; }
        
        public int? FisNo { get; set; }       
        public string StokId { get; set; } //Barkod
        public string StokAdi { get; set; }
        
        public string Hesaplama { get; set; } //Adet, Gram
        public string Turu { get; set; }
        public double? Miktar { get; set; }
        public double? DonusumMiktar { get; set; }
        public double? IscilikCM { get; set; }
        public double? IscilikGram { get; set; }
        public double? IscilikCmG { get; set; }
        public double? HasNet { get; set; } //HasNet Satis
        public double? BirimFiyati { get; set; }
        public double? Maliyet { get; set; }
        public double? SatisTutari { get; set; }
        public double? Fire { get; set; }
        public string MusteriAdi { get; set; }
        public string HareketTuru { get; set; } // Giriş, Çıkış, Emanet, Borç
        public string HareketTipi { get; set; } //Toptancidan İade, Ürün İade, Hızlı Üretim
        public double? Kar { get; set; }
        public string SubeNo { get; set; }
        public string Islemci { get; set; } //işlemi gerçekleştiren kullanıcı
        public bool Onay { get; set; }
        public double KomisyonOrani { get; set; }
        public string Aciklama { get; set; }
        public int Taksit { get; set; }
        public string Ozellik4 { get; set; }
    }
}