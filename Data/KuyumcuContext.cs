using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Kuyumcu.Models.Musteri_Islemleri;
using Kuyumcu.Models.Kuyumcu;
using Kuyumcu.Models;
using Kuyumcu.Models.Personel_Takip;
using Kuyumcu.Models.Finans;
using Kuyumcu.Models.Kuyumcu_Sorgu;

namespace Kuyumcu.Data
{
    public class KuyumcuContext : DbContext
    {
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<StokKart> StokKartlari { get; set; }
        public DbSet<Giris> Girisler { get; set; }
        public DbSet<StokHareket> StokHareketleri { get; set; }
        public DbSet<Toptanci> Toptancilar { get; set; }
        public DbSet<BarkodsuzStokKart> BarkodsuzStokKartlari { get; set; }
        public DbSet<Ajanda> Ajandas { get; set; }
        public DbSet<UrunCins> Cins { get; set; }
        public DbSet<personelEkle> Personel { get; set; }
        public DbSet<tabelalog> TabelaLoglari { get; set; }
        public DbSet<Banka> Bankalar { get; set; }
        public DbSet<UrunOzellik> Ozellikler { get; set; }
        public DbSet<KomisyonTanim> Komisyonlar { get; set; }
        public DbSet<Kasa> Kasalar { get; set; }
        public DbSet<GelirGiderKalemleri> GelirGiderKalemleri { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<ToptanciHareket> ToptanciHareketler { get; set; }
        public DbSet<ToptanciIade> ToptanciIadeleri { get; set; }
        public DbSet<StokKartSatilan> StokKartSatilanlar { get; set; }
        public DbSet<barkodsuzstok> BarkodsuzStok { get; set; }
        public DbSet<PirlantaOz> PirlantaOz { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Tamirat> Tamir { get; set; }
        public DbSet<PozisyonlarDB> PozisyonlarDB { get; set; }
    }
}