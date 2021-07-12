using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Finans
{
    [Table("Kasa")]
    public class Kasa
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SubeNo { get; set; }
        public string KasaAdi { get; set; }
        public string DovizTuru { get; set; }
        public double? BaslangicBakiye { get; set; }
    }
}