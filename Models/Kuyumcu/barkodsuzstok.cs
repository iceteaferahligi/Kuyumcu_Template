using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Kuyumcu
{
    [Table("BarkodsuzStok")]
    public class barkodsuzstok
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public double? SekHMevcut { get; set; }
        public double? SekHDevir { get; set; }
        public double? ODHMevcut { get; set; }
        public double? ODHDevir { get; set; }
        public double? ONSekHMevcut { get; set; }
        public double? ONSekHDevir { get; set; }
        public double? YBkHMevcut { get; set; }
        public double? YBkHDevir { get; set; }
        public double? YikHMevcut { get; set; }
        public double? YikHDevir { get; set; }
        public double? MCeyrek { get; set; }
        public double? MYarim { get; set; }
        public double? MAtatek { get; set; }
        public double? MIkibuc { get; set; }
        public double? MClira { get; set; }
        public double? MYigram { get; set; }
        public double? MYdgram { get; set; }
        public double? MHlira { get; set; }
        public double? MHbesli { get; set; }
        public double? MCbesli { get; set; }
        public double? MKulce { get; set; }
        public double? MRbesli { get; set; }
        public double? MRlira { get; set; }
        public double? DCeyrek { get; set; }
        public double? DYarim { get; set; }
        public double? DAtatek { get; set; }
        public double? DIkibuc { get; set; }
        public double? DClira { get; set; }
        public double? DYigram { get; set; }
        public double? DYdgram { get; set; }
        public double? DHlira { get; set; }
        public double? DHbesli { get; set; }
        public double? DCbesli { get; set; }
        public double? DKulce { get; set; }
        public double? DRbesli { get; set; }
        public double? DRlira { get; set; }
        public double? MTL { get; set; }
        public double? MUSD { get; set; }
        public double? MEURO { get; set; }
        public double? MCHF { get; set; }
        public double? MDKK { get; set; }
        public double? MSTRL { get; set; }
        public double? MSEK { get; set; }
        public double? MNOK { get; set; }
        public double? MJPY { get; set; }
        public double? MAD { get; set; }
        public double? MKD { get; set; }
        public double? MRB { get; set; }
        public double? MRY { get; set; }

        public double? DTL { get; set; }
        public double? DUSD { get; set; }
        public double? DEURO { get; set; }
        public double? DCHF { get; set; }
        public double? DDKK { get; set; }
        public double? DSTRL { get; set; }
        public double? DSEK { get; set; }
        public double? DNOK { get; set; }
        public double? DJPY { get; set; }
        public double? DAD { get; set; }
        public double? DKD { get; set; }
        public double? DRB { get; set; }
        public double? DRY { get; set; }

    }
}