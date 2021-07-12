using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Kuyumcu
{
    public class UrunCins
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Cins { get; set; }
        public string Grup { get; set; }
        public string AltGrup { get; set; }
        public string Adi { get; set; }
        public double Milyem { get; set; }
        public string Tur { get; set; } //HAS, USD...
    }
}