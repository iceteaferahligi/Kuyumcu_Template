using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Finans
{
    [Table("Komisyonlar")]
    public class KomisyonTanim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BankaAdi { get; set; }
        public string HesapNumarasi { get; set; }
        public int Taksit { get; set; }
        public double? Komisyon { get; set; }
    }
}