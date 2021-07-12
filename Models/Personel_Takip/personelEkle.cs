using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Kuyumcu.Models.Personel_Takip
{

    [Table("Personel")]
    public class personelEkle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AdiSoyadi { get; set; }
        
        public DateTime? DogumTarihi { get; set; }
        public string EsAdi { get; set; }
        
        public DateTime? EsDogumTarihi { get; set; }
        public string TelNo { get; set; }
        public string EsTelefon { get; set; }
        public string Email { get; set; }
        public string Cinsiyet { get; set; }
        public string Adres1 { get; set; }
        public string Adres2 { get; set; }
        public string Semt { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string PostaKodu { get; set; }
        public string SubeNo { get; set; }
        public string SigortaNo { get; set; }
      
        public DateTime? GirisTarihi { get; set; }
        public double? Maas { get; set; }
        public double? Prim { get; set; }
        public string Departman { get; set; }
        public string Gorevi { get; set; }
        public string Not { get; set; }
        public string AdiSoyadi2 { get; set; }

    }
}