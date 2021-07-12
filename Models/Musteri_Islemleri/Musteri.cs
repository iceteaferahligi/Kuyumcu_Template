using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Musteri_Islemleri
{
    [Table("Musteri")]
    public class Musteri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string TCNo { get; set; }
        public string AdSoyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime EvlilikTarihi { get; set; }
        public string Meslek { get; set; }
        public string CalistigiFirma { get; set; }
        public string EsAdi { get; set; }
        public DateTime EsDogumTarihi { get; set; }
        public string EsMeslek { get; set; }
        public string EvTel { get; set; }
        public string IsTel { get; set; }
        public string CepTel { get; set; }
        public string EsCepTel { get; set; }
        public string Email { get; set; }
        public string Cinsiyet { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Semt { get; set; }
        public string Ulke { get; set; }
        public string PostaKodu { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string Fax { get; set; }
        public string WebSitesi { get; set; }
        public string MusteriEk { get; set; }
        public string MusteriMemnuniyet { get; set; }

        public double ÇEYREK { get; set; }
        public double YARIM { get; set; }
        public double ATATEK { get; set; }
        public double IkıBucuklU { get; set; }
        public double CLİRA { get; set; }
        public double YiAyarGRAM { get; set; }
        public double YdAyarGRAM { get; set; }
        public double HLira { get; set; }
        public double SHurda { get; set; }
        public double ODHurda { get; set; }
        public double OSHurda { get; set; }
        public double YBHurda { get; set; }
        public double YIhurda { get; set; }
        public double RBesli { get; set; }
        public double HBesli { get; set; }
        public double CBesli { get; set; }
        public double RLira { get; set; }
        public double USD { get; set; }
        public double EURO { get; set; }
        public double CHF { get; set; }
        public double DKK { get; set; }
        public double STRL { get; set; }
        public double SEK { get; set; }
        public double NOK { get; set; }
        public double JPY { get; set; }
        public double KD { get; set; }
        public double AD { get; set; }
        public double RB { get; set; }
        public double RY { get; set; }
        public double HAS { get; set; }
        public double TL { get; set; }
        public double YiAyar { get; set; }
    }
}