using Kuyumcu.Models.Kuyumcu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{

    public class Ozellik
    {
        public Toptanci Toptanci { get; set; }
        public UrunCins Cins { get; set; }
        public UrunOzellik UrunOzellik { get; set; }
        public List<string> Gruplar { get; set; }
        public string ToptanciAdi { get; set; }
        public int id { get; set; }

    }
}