using Kuyumcu.Models.Kuyumcu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class TempModelUrunEkle
    {
        public List<Toptanci> Toptanci { get; set; }
        public StokKart StokKart { get; set; }
        public PirlantaOz Pirlanta { get; set; }
        public string SelectedItem { get; set; }
        public double? Bakiye { get; set; }
        public List<string> Cinsler { get; set; }
        public List<string> Gruplar { get; set; }
        public List<string> AltGruplar { get; set; }
        public List<double> Milyemler { get; set; }
        public List<string> Ozellik1 { get; set; }
        public List<string> Ozellik2 { get; set; }
        public List<string> Ozellik3 { get; set; }
        public string id { get; set; }
        public int RafOmru { get; set; }
    }
}