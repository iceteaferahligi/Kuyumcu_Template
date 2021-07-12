using Kuyumcu.Models.Finans;
using Kuyumcu.Models.Kuyumcu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class Toptancilar
    {
        public Toptanci toptanci { get; set; }
        public Toptanci toptanci2 { get; set; }
        public List<string> liste { get; set; }
        public List<double> Milyemler { get; set; }
        public ToptanciHareket Hareket { get; set; }
        public List<string> Personel { get; set; }
        public List<string> UrunKodu { get; set; }


        public string barkodNo { get; set; } //Barkod
        public double? miktar { get; set; }
        public double? iscilikCM { get; set; } //Adet, Gram
        public double? girisIscilik { get; set; }
        public double? iscilikGr { get; set; }
        public double? hasNet { get; set; }
        public double? maliyet { get; set; }
        public string turu { get; set; }
        public double? satisTutari { get; set; }
        public string toptancii { get; set; }

        public string ToptanciiAdi { get; set; }
        public string Islemci { get; set; }
        //public double? IscilikCM { get; set; }
        public string Aciklama { get; set; }
        public double? BrutHasNet { get; set; }
        public double? TopIscilik { get; set; }
        public double? ToplamHas { get; set; }
        public double? IscilikZarar { get; set; }

    }
}