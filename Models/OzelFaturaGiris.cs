using Kuyumcu.Models.Kuyumcu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class OzelFaturaGiris
    {
        public StokHareket Hareket { get; set; }
        public List<string> Personel { get; set; }
        public List<string> Musteri { get; set; }
        public List<string> Urunler { get; set; }
        public List<string> Bankalar { get; set; }
        public List<int> Taksitler { get; set; }
        public double Toplam { get; set; }
        public string MusteriAdSoyad { get; set; }
        public DateTime Tarih { get; set; }
        public string StokId { get; set; } //Barkod
        public double? Miktar { get; set; }
        public double? BirimFiyati { get; set; }
        public double? SatisTutari { get; set; }
        public string HareketTuru { get; set; } // Giriş, Çıkış, Emanet, Borç
        public string Islemci { get; set; } //işlemi gerçekleştiren kullanıcı
        public string Aciklama { get; set; }

        public string MusteriAdSoyad2 { get; set; }
        public DateTime Tarih2 { get; set; }
        public string StokId2 { get; set; } //Barkod
        public double? Miktar2 { get; set; }
        public double? BirimFiyati2 { get; set; }
        public double? SatisTutari2 { get; set; }
        public string HareketTuru2 { get; set; } // Giriş, Çıkış, Emanet, Borç
        public string Islemci2 { get; set; } //işlemi gerçekleştiren kullanıcı
        public int Taksit { get; set; }
        public string Aciklama2 { get; set; }

    }
}