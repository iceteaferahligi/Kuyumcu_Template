using Kuyumcu.Models.Kuyumcu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class BEhareket
    {
        public StokHareket hareket { get; set; }
        public List<string> Personel { get; set; }
        public List<string> Sarrafiye { get; set; }
        public StokHareket Temphareket { get; set; }
        public string MusteriAdi { get; set; }
    }
}