using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models
{
    public class Bugun
    {
        public DateTime Datetime { get; set; }
        public double? YiBilezikS { get; set; }
        public double? YiBilezikA { get; set; }
        public double? YiFantaziS { get; set; }
        public double? YiFantaziA { get; set; }
        public double? OnSekAyarS { get; set; }
        public double? OnSekAyarA { get; set; }
        public double? OnDortAyarS { get; set; }
        public double? OnDortAyarA { get; set; }
        public double? SekAyarS { get; set; }
        public double? SekAyarA { get; set; }
        public double? PirlantaA { get; set; }
        public double? InciA { get; set; }
        public double? SaatA { get; set; }
        public double? PirlantaS { get; set; }
        public double? InciS { get; set; }
        public double? SaatS { get; set; }
        public double? CeyrekA { get; set; }
        public double? YarimA { get; set; }
        public double? ZiynetA { get; set; }
        public double? AtaA { get; set; }
        public double? CeyrekS { get; set; }
        public double? YarimS { get; set; }
        public double? ZiynetS { get; set; }
        public double? AtaS { get; set; }
        public string SubeNo { get; set; }

        public double? YiBilezikSF { get; set; }
        public double? YiBilezikAF { get; set; }
        public double? YiFantaziSF { get; set; }
        public double? YiFantaziAF { get; set; }
        public double? OnSekAyarSF { get; set; }
        public double? OnSekAyarAF { get; set; }
        public double? OnDortAyarSF { get; set; }
        public double? OnDortAyarAF { get; set; }
        public double? SekAyarSF { get; set; }
        public double? SekAyarAF { get; set; }
        public double? PirlantaAF { get; set; }
        public double? InciAF { get; set; }
        public double? SaatAF { get; set; }
        public double? PirlantaSF { get; set; }
        public double? InciSF { get; set; }
        public double? SaatSF { get; set; }
        public double? CeyrekAF { get; set; }
        public double? YarimAF { get; set; }
        public double? ZiynetAF { get; set; }
        public double? AtaAF { get; set; }
        public double? CeyrekSF { get; set; }
        public double? YarimSF { get; set; }
        public double? ZiynetSF { get; set; }
        public double? AtaSF { get; set; }

        public double? HasnetTA { get; set; }
        public double? HasnetTAF { get; set; }
        public double? HasnetTS { get; set; }
        public double? HasnetTSF { get; set; }

        public double? SekToplam { get; set; }
        public double? OnDortToplam { get; set; }
        public double? OnSekToplam { get; set; }
        public double? YiToplam { get; set; }
        public double? YiBToplam { get; set; }
        public double? PirToplam { get; set; }
        public double? InciToplam { get; set; }
        public double? SaatToplam { get; set; }

        public double? SekHGirisB { get; set; }
        public double? SekHCikisB { get; set; }
        public double? SekHMevcut { get; set; }
        public double? SekHDevir { get; set; }

        public double? ODHGirisB { get; set; }
        public double? ODHCikisB { get; set; }
        public double? ODHMevcut { get; set; }
        public double? ODHDevir { get; set; }

        public double? ONSekHGirisB { get; set; }
        public double? ONSekHCikisB { get; set; }
        public double? ONSekHMevcut { get; set; }
        public double? ONSekHDevir { get; set; }

        public double? YBkHGirisB { get; set; }
        public double? YBkHCikisB { get; set; }
        public double? YBkHMevcut { get; set; }
        public double? YBkHDevir { get; set; }

        public double? YikHGirisB { get; set; }
        public double? YikHCikisB { get; set; }
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

        public double? GCeyrek { get; set; }
        public double? GYarim { get; set; }
        public double? GAtatek { get; set; }
        public double? GIkibuc { get; set; }
        public double? GClira { get; set; }
        public double? GYigram { get; set; }
        public double? GYdgram { get; set; }
        public double? GHlira { get; set; }
        public double? GHbesli { get; set; }
        public double? GCbesli { get; set; }
        public double? GKulce { get; set; }
        public double? GRbesli { get; set; }
        public double? GRlira { get; set; }

        public double? CCeyrek { get; set; }
        public double? CYarim { get; set; }
        public double? CAtatek { get; set; }
        public double? CIkibuc { get; set; }
        public double? CClira { get; set; }
        public double? CYigram { get; set; }
        public double? CYdgram { get; set; }
        public double? CHlira { get; set; }
        public double? CHbesli { get; set; }
        public double? CCbesli { get; set; }
        public double? CKulce { get; set; }
        public double? CRbesli { get; set; }
        public double? CRlira { get; set; }

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

        public double? GTL { get; set; }
        public double? GUSD { get; set; }
        public double? GEURO { get; set; }
        public double? GCHF { get; set; }
        public double? GDKK { get; set; }
        public double? GSTRL { get; set; }
        public double? GSEK { get; set; }
        public double? GNOK { get; set; }
        public double? GJPY { get; set; }
        public double? GAD { get; set; }
        public double? GKD { get; set; }
        public double? GRB { get; set; }
        public double? GRY { get; set; }
    
        public double? CTL { get; set; }
        public double? CUSD { get; set; }
        public double? CEURO { get; set; }
        public double? CCHF { get; set; }
        public double? CDKK { get; set; }
        public double? CSTRL { get; set; }
        public double? CSEK { get; set; }
        public double? CNOK { get; set; }
        public double? CJPY { get; set; }
        public double? CAD { get; set; }
        public double? CKD { get; set; }
        public double? CRB { get; set; }
        public double? CRY { get; set; }



    }
}