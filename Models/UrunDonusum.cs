using Kuyumcu.Models.Kuyumcu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class UrunDonusum
    {
        public StokKart Barkodlu { get; set; } //HURDA > ÜRÜN
        public StokKart Barkodlu1 { get; set; } //ÜRÜN > HURDA
        public StokKart Barkodlu2 { get; set; } //SARRAFİYE > HURDA
        public List<Toptanci> Toptanci { get; set; }
        public string StokCinsi { get; set; }
        public BarkodsuzStokKart Barkodsuz { get; set; } //HURDA > ÜRÜN
        public BarkodsuzStokKart Barkodsuz1 { get; set; } //ÜRÜN > HURDA
        public BarkodsuzStokKart Barkodsuz2 { get; set; } //SARRAFİYE > HURDA
        public BarkodsuzStokKart Barkodsuz3 { get; set; } //SARRAFİYE > HURDA
        public List<string> Cinsler { get; set; }
        public List<string> HurdaCinsler { get; set; }
        public List<string> Gruplar { get; set; }
        public List<string> AltGruplar { get; set; }
        public List<string> Sarrafiye { get; set; }
        public List<double> Milyemler { get; set; }
        public List<string> Ozellik1 { get; set; }
        public List<string> Ozellik2 { get; set; }
        public List<string> Ozellik3 { get; set; }
        public double HUmiktar { get; set; }
        public double SHcikisMiktar { get; set; }
        public double SHgirisMiktar { get; set; }
        public int RafOmru { get; set; }
    }
}