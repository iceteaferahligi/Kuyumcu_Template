using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Finans
{
    [Table("Bankalar")]
    public class Banka
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SubeAdi { get; set; }
        public string BankaAdi { get; set; }
        public string BankaSubeAdi { get; set; }
        public string HesapNumarasi { get; set; }
        public string HesapDovizTuru { get; set; }
        public string BankaTelefon { get; set; }
        public string FaxNo { get; set; }
        public string BankaAciklama { get; set; }
        public double? EsnekBakiyeLimiti { get; set; }
        public double? Bakiye { get; set; }
    }
}