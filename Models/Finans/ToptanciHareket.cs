using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Finans
{
    public class ToptanciHareket
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime? Tarih { get; set; }
        public string FisNo { get; set; }
        public string StokId { get; set; } //Barkod
        public string StokAdi { get; set; }
        public string Hesaplama { get; set; } //Adet, Gram
        public string Turu { get; set; }
        public double? Miktar { get; set; }
        public double? Donusum { get; set; }
        public double? Milyem { get; set; }
        public double? IscilikCM { get; set; }
        public double? IscilikGram { get; set; }
        public double? IscilikCmG { get; set; }
        public double? TopIscilik { get; set; }
        public double? UrunAdedi { get; set; }
        public double? BrutHasNet { get; set; }
        public double? ToplamHas { get; set; }
        public double? BirimHas { get; set; }
        public double? IscilikZarar { get; set; }
        public string ToptanciiAdi { get; set; }
        public string HareketTuru { get; set; } // Giriş, Çıkış, Emanet, Borç
        public string HareketTipi { get; set; } //Toptancidan İade, Ürün İade, Hızlı Üretim
        public string SubeNo { get; set; }
        public string Islemci { get; set; } //işlemi gerçekleştiren kullanıcı
        public string Aciklama { get; set; }
       
    }
}