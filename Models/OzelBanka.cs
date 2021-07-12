using Kuyumcu.Models.Finans;
using Kuyumcu.Models.Kuyumcu;
using Kuyumcu.Models.Personel_Takip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class OzelBanka
    {
        public List<Banka> Banka { get; set; }
        public KomisyonTanim Komisyon { get; set; }
        public Banka Bank { get; set; }
        public string HesapNo { get; set; }
        public List<string> Hesaplar { get; set; }
        public List<Kasa> Kasalar { get; set; }
        public List<string> KasaAdi { get; set; }
        public Kasa ekle { get; set; }
        public double TL { get; set; }
        public int? Fisno { get; set; }
        public List<string> GelirAc { get; set; }
        public GelirGiderKalemleri gelirEkle { get; set; }
        public GelirGiderKalemleri giderEkle { get; set; }
        public List<string> GiderAc { get; set; }
        public StokHareket Hareket1 { get; set; }
        public StokHareket Hareket2 { get; set; }
        public List<string> Personel { get; set; }
        public List<string> Musteriler { get; set; }
        public List<string> Bankalar { get; set; }
        public List<string> DovizTuru { get; set; }
        public double Toplam { get; set; }
    }
}