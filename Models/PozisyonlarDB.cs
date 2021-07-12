using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Finans
{
    [Table("PozisyonlarDB")]
    public class PozisyonlarDB
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public double? MHas { get; set; }
        public double? MTL { get; set; }
        public double? MEURO { get; set; }
        public double? MUSD { get; set; }
        public double? MCHF { get; set; }
        public double? MSTRL { get; set; }
        public double? MCeyrek { get; set; }
        public double? MYi { get; set; }
        public string SubeNo { get; set; }

        public double? MHas2 { get; set; }
        public double? MTL2 { get; set; }
        public double? MEURO2 { get; set; }
        public double? MUSD2 { get; set; }
        public double? MCHF2 { get; set; }
        public double? MSTRL2 { get; set; }
        public double? MCeyrek2 { get; set; }
        public double? MYi2 { get; set; }

        public double? THas { get; set; }
        public double? TTL { get; set; }
        public double? TEURO { get; set; }
        public double? TUSD { get; set; }
        public double? TCHF { get; set; }
        public double? TSTRL { get; set; }
        public double? TCeyrek { get; set; }
        public double? TYi { get; set; }

        public double? THas2 { get; set; }
        public double? TTL2 { get; set; }
        public double? TEURO2 { get; set; }
        public double? TUSD2 { get; set; }
        public double? TCHF2 { get; set; }
        public double? TSTRL2 { get; set; }
        public double? TCeyrek2 { get; set; }
        public double? TYi2 { get; set; }

        public double? ToplamHasB { get; set; }
        public double? ToplamTLB { get; set; }
        public double? ToplamEUROB { get; set; }
        public double? ToplamUSDB { get; set; }
        public double? ToplamCHFB { get; set; }
        public double? ToplamSTRLB { get; set; }
        public double? ToplamCeyrekB { get; set; }
        public double? ToplamYiB { get; set; }

        public double? ToplamHasA { get; set; }
        public double? ToplamTLA { get; set; }
        public double? ToplamEUROA { get; set; }
        public double? ToplamUSDA { get; set; }
        public double? ToplamCHFA { get; set; }
        public double? ToplamSTRLA { get; set; }
        public double? ToplamCeyrekA { get; set; }
        public double? ToplamYiA { get; set; }

        public double? TL { get; set; }
        public double? USD { get; set; }
        public double? EURO { get; set; }
        public double? CHF { get; set; }
        public double? STRL { get; set; }

        public double? AcikTL { get; set; }
        public double? AcikUSD { get; set; }
        public double? AcikEURO { get; set; }
        public double? AcikSTRL { get; set; }
        public double? AcikCHF { get; set; }

        public double? FazlaTL { get; set; }
        public double? FazlaUSD { get; set; }
        public double? FazlaEURO { get; set; }
        public double? FazlaSTRL { get; set; }
        public double? FazlaCHF { get; set; }






    }
}