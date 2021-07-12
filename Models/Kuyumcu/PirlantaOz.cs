using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Kuyumcu
{
    [Table("PirlantaOzellikleri")]
    public class PirlantaOz
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Stokid { get; set; }
        public double? MetalGr { get; set; }
        public double? Carat1 { get; set; }
        public double? Carat2 { get; set; }
        public double? Carat3 { get; set; }
        public double? Carat4 { get; set; }
        public double? Carat5 { get; set; }
        public string TCinsi1 { get; set; }
        public string TCinsi2 { get; set; }
        public string TCinsi3 { get; set; }
        public string TCinsi4 { get; set; }
        public string TCinsi5 { get; set; }
        public string Ayrinti1 { get; set; }
        public string Ayrinti2 { get; set; }
        public string Ayrinti3 { get; set; }
        public string Ayrinti4 { get; set; }
        public string Ayrinti5 { get; set; }
    }
}