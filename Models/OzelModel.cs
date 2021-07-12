using Kuyumcu.Models.Finans;
using Kuyumcu.Models.Kuyumcu;
using Kuyumcu.Models.Musteri_Islemleri;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class OzelModel
    {
        public double? CeyrekA { get; set; }
        public double? CeyrekS { get; set; }
        public double? CeyrekM { get; set; }
        public double? CeyrekH { get; set; }
        public double? YarimA { get; set; }
        public double? YarimS { get; set; }
        public double? YarimM { get; set; }
        public double? YarimH { get; set; }
        public double? AtatekA { get; set; }
        public double? AtatekS { get; set; }
        public double? AtatekM { get; set; }
        public double? AtatekH { get; set; }
        public double? IkibucukluA { get; set; }
        public double? IkibucukluS { get; set; }
        public double? IkibucukluM { get; set; }
        public double? IkibucukluH { get; set; }
        public double? CliraA { get; set; }
        public double? CliraS { get; set; }
        public double? CliraM { get; set; }
        public double? CliraH { get; set; }
        public double? YirmiIkiGramA { get; set; }
        public double? YirmiIkiGramS { get; set; }
        public double? YirmiIkiGramM { get; set; }
        public double? YirmiIkiGramH { get; set; }
        public double? YirmiDortGramA { get; set; }
        public double? YirmiDortGramS { get; set; }
        public double? YirmiDortGramM { get; set; }
        public double? YirmiDortGramH { get; set; }

        public double? YirmiBirGramA { get; set; }
        public double? YirmiBirGramS { get; set; }
        public double? YirmiBirGramM { get; set; }
        public double? YirmiBirGramH { get; set; }
        public double? HamitLiraA { get; set; }
        public double? HamitLiraS { get; set; }
        public double? HamitLiraM { get; set; }
        public double? HamitLiraH { get; set; }
        public double? ResatBesliA { get; set; }
        public double? ResatBesliS { get; set; }
        public double? ResatBesliM { get; set; }
        public double? ResatBesliH { get; set; }
        public double? HamitBesliA { get; set; }
        public double? HamitBesliS { get; set; }
        public double? HamitBesliM { get; set; }
        public double? HamitBesliH { get; set; }
        public double? CUMBesliA { get; set; }
        public double? CUMBesliS { get; set; }
        public double? CUMBesliM { get; set; }
        public double? CUMBesliH { get; set; }
        public double? ResatLiraA { get; set; }
        public double? ResatLiraS { get; set; }
        public double? ResatLiraM { get; set; }
        public double? ResatLiraH { get; set; }
        public double? SekhurdaA { get; set; }
        public double? SekhurdaS { get; set; }
        public double? SekhurdaM { get; set; }
        public double? SekhurdaH { get; set; }
        public double? OndorthurdaA { get; set; }
        public double? OndorthurdaS { get; set; }
        public double? OndorthurdaM { get; set; }
        public double? OndorthurdaH { get; set; }
        public double? OnsekhurdaA { get; set; }
        public double? OnsekhurdaS { get; set; }
        public double? OnsekhurdaM { get; set; }
        public double? OnsekhurdaH { get; set; }
        public double? YirbirhurdaA { get; set; }
        public double? YirbirhurdaM { get; set; }
        public double? YirbirhurdaS { get; set; }
        public double? YirbirhurdaH { get; set; }
        public double? YirmiikihurdaA { get; set; }
        public double? YirmiikihurdaM { get; set; }
        public double? YirmiikihurdaS { get; set; }
        public double? YirmiikihurdaH { get; set; }
        public double? KulceA { get; set; }
        public double? KulceS { get; set; }
        public double? DolarA { get; set; }
        public double? DolarS { get; set; }
        public double? EuroA { get; set; }
        public double? EuroS { get; set; }
        public double? IsvicFranA { get; set; }
        public double? IsvicFranS { get; set; }
        public double? DankronA { get; set; }
        public double? DankronS { get; set; }
        public double? SterlinA { get; set; }
        public double? SterlinS { get; set; }
        public double? TLA { get; set; }
        public double? TLS { get; set; }


        public double? IsvecKronuA { get; set; }
        public double? IsvecKronuS { get; set; }
        public double? NorvecKronuA { get; set; }
        public double? NorvecKronuS { get; set; }
        public double? JaponYeniA { get; set; }
        public double? JaponYeniS { get; set; }
        public double? KanDolariA { get; set; }
        public double? KanDolariS { get; set; }
        public double? AvusDolariA { get; set; }
        public double? AvusDolariS { get; set; }
        public double? RusRubleA { get; set; }
        public double? RusRubleS { get; set; }
        public double? RiyalA { get; set; }
        public double? RiyalS { get; set; }

        public float Toplam { get; set; }
        public int id { get; set; }

        [Required(ErrorMessage = "Müşteri Ad Soyad Veri Tabanında Bulunamadı!")]
        public string MusteriAdSoyad { get; set; }
        public DateTime Tarih { get; set; }
        public string StokId { get; set; } //Barkod
        public string StokAdi { get; set; }
        public string Hesaplama { get; set; } //Adet, Gram
        public double? Miktar { get; set; }
        public double? IscilikCM { get; set; }
        public double? IscilikGram { get; set; }
        public double? HasNet { get; set; }
        public double? BirimFiyati { get; set; }
        public double? Maliyet { get; set; }
        public double? SatisTutari { get; set; }
        public string HareketTuru { get; set; } // Giriş, Çıkış, Emanet, Borç
        public string HareketTipi { get; set; } //Toptancidan İade, Ürün İade, Hızlı Üretim
        public double? Kar { get; set; }
        public string SubeNo { get; set; }
        public string Islemci { get; set; } //işlemi gerçekleştiren kullanıcı
        public bool Onay { get; set; }

        public string PersonelId { get; set; }        
        public DateTime Logtarih { get; set; }
        public string Saat { get; set; }
        public List<string> Saatler { get; set; }


        public KomisyonTanim Komisyon { get; set; }
        public List<string> Hesaplar { get; set; }
        public List<string> Personel { get; set; }
        public List<string> Bankalar { get; set; }
        public List<int> Taksitler { get; set; }
        public List<string> Musteriler { get; set; }
        public int Taksit { get; set; }

        public double? SekAyarA { get; set; }
        public double? SekAyarS { get; set; }
        public double? SekAyarM { get; set; }
        public double? SekAyarH { get; set; }
        public double? OdAyarA { get; set; }
        public double? OdAyarS { get; set; }
        public double? OdAyarM { get; set; }
        public double? OdAyarH { get; set; }
        public double? OsAyarA { get; set; }
        public double? OsAyarS { get; set; }
        public double? OsAyarM { get; set; }
        public double? OsAyarH { get; set; }
        public double? YiAyarA { get; set; }
        public double? YiAyarS { get; set; }
        public double? YiAyarM { get; set; }
        public double? YiAyarH { get; set; }
        public double? BilezikA { get; set; }
        public double? BilezikS { get; set; }
        public double? BilezikM { get; set; }
        public double? BilezikH { get; set; }


    }




}