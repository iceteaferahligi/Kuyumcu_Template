using Kuyumcu.Models.Finans;
using Kuyumcu.Models.Kuyumcu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class KKBanka
    {
        public List<string> Personel { get; set; }
        public List<string> Bankalar { get; set; }
        public StokHareket hareket { get; set; }
        public StokHareket hareket1 { get; set; }
    }
}