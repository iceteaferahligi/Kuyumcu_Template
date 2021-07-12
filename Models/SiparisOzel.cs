using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class SiparisOzel
    {
        public Siparis siparis { get; set; }
        public List<string> personel { get; set; }
        public List<string> musteriadi { get; set; }
    }
}