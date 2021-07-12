using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Finans
{
    [Table("Fatura")]
    public class Fatura
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? FisNo { get; set; }
        public DateTime Tarih { get; set; } //Barkod
        public string Islemci { get; set; }
        public string Musteri { get; set; } //Adet, Gram
        public double? SatisTutari { get; set; }
        public double? AlimTutari { get; set; }
        public double? KrediKarti { get; set; }
        public double? Nakit { get; set; }
        public double? Fark { get; set; }
    }
}