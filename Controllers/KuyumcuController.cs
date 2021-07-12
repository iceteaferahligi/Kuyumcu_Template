using Kuyumcu.Data;
using Kuyumcu.Models;
using Kuyumcu.Models.Kuyumcu;
using Kuyumcu.Models.Musteri_Islemleri;
using Kuyumcu.Models.Personel_Takip;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DevExpress.XtraReports.UI;
using System.IO;
using Kuyumcu.Models.Finans;
using DevExpress.XtraPrinting;
using IronBarCode;
using System.Drawing;
using DevExpress.Utils.CodedUISupport;
using DevExpress.Web.ASPxScheduler.Internal;
using DevExpress.Utils.Extensions;
using DevExpress.XtraPrinting.Export.Pdf;
using System.Drawing.Printing;
using DevExpress.XtraEditors.ButtonPanel;
using DevExpress.XtraCharts;
using System.Security.Principal;
using System.Printing;

namespace Kuyumcu.Controllers
{
    public class KuyumcuController : Controller
    {
        // GET: Kuyumcu
        public ActionResult Kuyumcu()
        {
            return View();
        }

        public ActionResult HizliAlimSatim()
        {
            BarkodsuzStokKart bs = new BarkodsuzStokKart();
            KuyumcuContext db = new KuyumcuContext();
            OzelModel model = new OzelModel();

            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "ÇEYREK").FirstOrDefault();
            model.CeyrekA = bs.AlisFiyati;
            model.CeyrekS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "YARIM").FirstOrDefault();
            model.YarimA = bs.AlisFiyati;
            model.YarimS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "ATATEK").FirstOrDefault();
            model.AtatekA = bs.AlisFiyati;
            model.AtatekS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "2.5'LU").FirstOrDefault();
            model.IkibucukluA = bs.AlisFiyati;
            model.IkibucukluS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "C.LİRA").FirstOrDefault();
            model.CliraA = bs.AlisFiyati;
            model.CliraS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR GRAM").FirstOrDefault();
            model.YirmiIkiGramA = bs.AlisFiyati;
            model.YirmiIkiGramS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "24 AYAR GRAM").FirstOrDefault();
            model.YirmiDortGramA = bs.AlisFiyati;
            model.YirmiDortGramS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "HAMİT LİRA").FirstOrDefault();
            model.HamitLiraA = bs.AlisFiyati;
            model.HamitLiraS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 HURDA").FirstOrDefault();
            model.SekhurdaA = bs.AlisFiyati;
            model.SekhurdaS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 HURDA").FirstOrDefault();
            model.OndorthurdaA = bs.AlisFiyati;
            model.OndorthurdaS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 HURDA").FirstOrDefault();
            model.OnsekhurdaA = bs.AlisFiyati;
            model.OnsekhurdaS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "21 HURDA").FirstOrDefault();
            model.YirbirhurdaA = bs.AlisFiyati;
            model.YirbirhurdaS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 HURDA").FirstOrDefault();
            model.YirmiikihurdaA = bs.AlisFiyati;
            model.YirmiikihurdaS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "AMERİKAN DOLARI").FirstOrDefault();
            model.DolarA = bs.AlisFiyati;
            model.DolarS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "EURO").FirstOrDefault();
            model.EuroA = bs.AlisFiyati;
            model.EuroS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İSVİÇRE FRANGI").FirstOrDefault();
            model.IsvicFranA = bs.AlisFiyati;
            model.IsvicFranS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "DANİMARKA KRONU").FirstOrDefault();
            model.DankronA = bs.AlisFiyati;
            model.DankronS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İNGİLİZ STERLİNİ").FirstOrDefault();
            model.SterlinA = bs.AlisFiyati;
            model.SterlinS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "TÜRK LİRASI").FirstOrDefault();
            model.TLA = bs.AlisFiyati;
            model.TLS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "REŞAT BEŞLİ").FirstOrDefault();
            model.ResatBesliA = bs.AlisFiyati;
            model.ResatBesliS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "HAMİT BEŞLİ").FirstOrDefault();
            model.HamitBesliA = bs.AlisFiyati;
            model.HamitBesliS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "CUMHURİYET BEŞLİ").FirstOrDefault();
            model.CUMBesliA = bs.AlisFiyati;
            model.CUMBesliS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "REŞAT LİRA").FirstOrDefault();
            model.ResatLiraA = bs.AlisFiyati;
            model.ResatLiraS = bs.SatisFiyati;

            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İSVEÇ KRONU").FirstOrDefault();
            model.IsvecKronuA = bs.AlisFiyati;
            model.IsvecKronuS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "NORVEÇ KRONU").FirstOrDefault();
            model.NorvecKronuA = bs.AlisFiyati;
            model.NorvecKronuS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "JAPON YENİ").FirstOrDefault();
            model.JaponYeniA = bs.AlisFiyati;
            model.JaponYeniS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KANADA DOLARI").FirstOrDefault();
            model.KanDolariA = bs.AlisFiyati;
            model.KanDolariS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "AVUSTRALYA DOLARI").FirstOrDefault();
            model.AvusDolariA = bs.AlisFiyati;
            model.AvusDolariS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "RUS RUBLESİ").FirstOrDefault();
            model.RusRubleA = bs.AlisFiyati;
            model.RusRubleS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "RİYAL").FirstOrDefault();
            model.RiyalA = bs.AlisFiyati;
            model.RiyalS = bs.SatisFiyati;


            model.Hesaplar = db.Bankalar.Select(x => x.HesapNumarasi).ToList();
            model.Taksitler = db.Komisyonlar.Select(x => x.Taksit).ToList();
            model.Musteriler = db.Musteriler.Select(x => x.AdSoyad).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult HizliAlimSatim(List<OzelModel> model, float toplam, string personel, string KrediKarti, string tur, int taksit)
        {
            KuyumcuContext db = new KuyumcuContext();
            Fatura fatura = new Fatura();
            fatura.AlimTutari = 0;
            fatura.Fark = 0;
            fatura.KrediKarti = 0;
            fatura.Nakit = 0;
            fatura.SatisTutari = 0;
            var kulce = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KÜLÇE ALTIN").FirstOrDefault();

            List<StokHareket> Stokhareket = new List<StokHareket>();
            int? id = getid();
            StokKart yeni = new StokKart();
            personelEkle calisan = new personelEkle();
            Kasa kasa = new Kasa();
            Musteri musteri = new Musteri();
            calisan = db.Personel.Where(x => x.AdiSoyadi == personel).FirstOrDefault();




            for (int i = 0; i < model.Count; i++)
            {

                BarkodsuzStokKart kart = new BarkodsuzStokKart();
                BarkodsuzStokKart brkart = new BarkodsuzStokKart();
                StokKartSatilan sks = new StokKartSatilan();

                string y = model[i].StokAdi;
                yeni = db.StokKartlari.Where(x => x.StokId == y).FirstOrDefault();
                brkart = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == y).FirstOrDefault();
                StokHareket Hareket = new StokHareket();

                if (yeni != null)
                {

                    Hareket.MusteriAdi = model[i].MusteriAdSoyad;
                    fatura.Musteri = Hareket.MusteriAdi;
                    Hareket.StokId = model[i].StokAdi;
                    Hareket.StokAdi = model[i].StokAdi;
                    Hareket.Tarih = model[i].Tarih;
                    Hareket.Hesaplama = "Adet";
                    Hareket.Turu = "HAS";
                    Hareket.Miktar = Math.Round(Convert.ToDouble(model[i].Miktar), 3);

                    Hareket.IscilikCM = yeni.IscilikCm;
                    Hareket.IscilikGram = yeni.IscilikGr;
                    Hareket.IscilikCmG = yeni.IscilikCmG;
                    Hareket.HasNet = yeni.HasNet;
                    Hareket.BirimFiyati = yeni.BirimFiyat;
                    Hareket.Maliyet = yeni.Maliyet;

                    if (yeni.Ozellik4 == "FANTAZİ")
                    {
                        Hareket.Ozellik4 = yeni.Ozellik4;
                    }
                    else if (yeni.Ozellik4 == "KONSİNYE")
                    {
                        Hareket.Ozellik4 = yeni.Ozellik4;
                    }
                    else if (yeni.Ozellik4 == "BAY")
                    {
                        Hareket.Ozellik4 = yeni.Ozellik4;
                    }
                    else if (yeni.Ozellik4 == "BAYAN")
                    {
                        Hareket.Ozellik4 = yeni.Ozellik4;
                    }
                    Hareket.Kar = yeni.Kar;

                    Hareket.SatisTutari = Math.Round(Convert.ToDouble(model[i].SatisTutari), 3);
                    Hareket.FisNo = id;

                    Hareket.HareketTuru = model[i].HareketTuru;
                    Hareket.HareketTipi = tur;

                    Hareket.SubeNo = "NO1";
                    if (calisan != null)
                    {
                        Hareket.Islemci = personel;
                        fatura.Islemci = personel;
                    }
                    else
                    {
                        Hareket.Islemci = null;
                        Hareket.Onay = false;
                        Stokhareket.Add(Hareket);
                        model[i].Tarih.AddSeconds(1);
                    }

                }
                else if (brkart != null)
                {
                    string MusteriAdi = model[i].MusteriAdSoyad;
                    if (MusteriAdi != null)
                    {
                        musteri = db.Musteriler.Where(x => x.AdSoyad == MusteriAdi).FirstOrDefault();
                    }

                    var Urun = model[i].StokAdi;
                    var Miktar = Convert.ToDouble(model[i].Miktar);

                    if (musteri != null)
                    {
                        if (model[i].HareketTuru == "BORÇ" || model[i].HareketTuru == "A BORÇ")
                        {
                            if (Urun == "ÇEYREK")
                            {
                                musteri.ÇEYREK = musteri.ÇEYREK - Miktar;
                            }
                            else if (Urun == "ATATEK")
                            {
                                musteri.ATATEK = musteri.ATATEK - Miktar;
                            }
                            else if (Urun == "YARIM")
                            {
                                musteri.YARIM = musteri.YARIM - Miktar;
                            }
                            else if (Urun == "2.5'LU")
                            {
                                musteri.IkıBucuklU = musteri.IkıBucuklU - Miktar;
                            }
                            else if (Urun == "C.LİRA")
                            {
                                musteri.CLİRA = musteri.CLİRA - Miktar;
                            }
                            else if (Urun == "22 AYAR GRAM")
                            {
                                musteri.YiAyarGRAM = musteri.YiAyarGRAM - Miktar;
                            }
                            else if (Urun == "24 AYAR GRAM")
                            {
                                musteri.YdAyarGRAM = musteri.YdAyarGRAM - Miktar;
                            }
                            else if (Urun == "HAMİT LİRA")
                            {
                                musteri.HLira = musteri.HLira - Miktar;
                            }
                            else if (Urun == "8 HURDA")
                            {
                                musteri.SHurda = musteri.SHurda - Miktar;
                            }
                            else if (Urun == "14 HURDA")
                            {
                                musteri.ODHurda = musteri.ODHurda - Miktar;
                            }
                            else if (Urun == "18 HURDA")
                            {
                                musteri.OSHurda = musteri.OSHurda - Miktar;
                            }
                            else if (Urun == "21 HURDA")
                            {
                                musteri.YBHurda = musteri.YBHurda - Miktar;
                            }
                            else if (Urun == "22 HURDA")
                            {
                                musteri.YIhurda = musteri.YIhurda - Miktar;
                            }
                            else if (Urun == "AMERİKAN DOLARI")
                            {
                                musteri.USD = musteri.USD - Miktar;
                            }
                            else if (Urun == "İSVİÇRE FRANGI")
                            {
                                musteri.CHF = musteri.CHF - Miktar;
                            }
                            else if (Urun == "DANİMARKA KRONU")
                            {
                                musteri.DKK = musteri.DKK - Miktar;
                            }
                            else if (Urun == "İNGİLİZ STERLİNİ")
                            {
                                musteri.STRL = musteri.STRL - Miktar;
                            }
                            else if (Urun == "KÜLÇE ALTIN")
                            {
                                musteri.HAS = musteri.HAS - Miktar;
                            }
                            else if (Urun == "TÜRK LİRASI")
                            {
                                musteri.TL = musteri.TL - Miktar;
                            }
                            else if (Urun == "REŞAT BEŞLİ")
                            {
                                musteri.RBesli = musteri.RBesli - Miktar;
                            }
                            else if (Urun == "İSVEÇ KRONU")
                            {
                                musteri.SEK = musteri.SEK - Miktar;
                            }
                            else if (Urun == "NORVEÇ KRONU")
                            {
                                musteri.NOK = musteri.NOK - Miktar;
                            }
                            else if (Urun == "JAPON YENİ")
                            {
                                musteri.JPY = musteri.JPY - Miktar;
                            }
                            else if (Urun == "KANADA DOLARI")
                            {
                                musteri.KD = musteri.KD - Miktar;
                            }
                            else if (Urun == "AVUSTRALYA DOLARI")
                            {
                                musteri.AD = musteri.AD - Miktar;
                            }
                            else if (Urun == "RUS RUBLESİ")
                            {
                                musteri.RB = musteri.RB - Miktar;
                            }
                            else if (Urun == "RİYAL")
                            {
                                musteri.RY = musteri.RY - Miktar;
                            }
                            else if (Urun == "REŞAT LİRA")
                            {
                                musteri.RLira = musteri.RLira - Miktar;
                            }
                            else if (Urun == "HAMİT BEŞLİ")
                            {
                                musteri.HBesli = musteri.HBesli - Miktar;
                            }
                            else if (Urun == "CUMHURİYET BEŞLİ")
                            {
                                musteri.CBesli = musteri.CBesli - Miktar;
                            }
                            else if (Urun == "22 AYAR")
                            {
                                musteri.YiAyar = musteri.YiAyar - Miktar;
                            }
                            db.Entry(musteri).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else if (model[i].HareketTuru == "EMANET" || model[i].HareketTuru == "A EMANET")
                        {
                            if (Urun == "ÇEYREK")
                            {
                                musteri.ÇEYREK = musteri.ÇEYREK + Miktar;
                            }
                            else if (Urun == "YARIM")
                            {
                                musteri.YARIM = musteri.YARIM + Miktar;
                            }
                            else if (Urun == "2.5'LU")
                            {
                                musteri.IkıBucuklU = musteri.IkıBucuklU + Miktar;
                            }
                            else if (Urun == "C.LİRA")
                            {
                                musteri.CLİRA = musteri.CLİRA + Miktar;
                            }
                            else if (Urun == "22 AYAR GRAM")
                            {
                                musteri.YiAyarGRAM = musteri.YiAyarGRAM + Miktar;
                            }
                            else if (Urun == "24 AYAR GRAM")
                            {
                                musteri.YdAyarGRAM = musteri.YdAyarGRAM + Miktar;
                            }
                            else if (Urun == "HAMİT LİRA")
                            {
                                musteri.HLira = musteri.HLira + Miktar;
                            }
                            else if (Urun == "8 HURDA")
                            {
                                musteri.SHurda = musteri.SHurda + Miktar;
                            }
                            else if (Urun == "14 HURDA")
                            {
                                musteri.ODHurda = musteri.ODHurda + Miktar;
                            }
                            else if (Urun == "18 HURDA")
                            {
                                musteri.OSHurda = musteri.OSHurda + Miktar;
                            }
                            else if (Urun == "21 HURDA")
                            {
                                musteri.YBHurda = musteri.YBHurda + Miktar;
                            }
                            else if (Urun == "22 HURDA")
                            {
                                musteri.YIhurda = musteri.YIhurda + Miktar;
                            }
                            else if (Urun == "AMERİKAN DOLARI")
                            {
                                musteri.USD = musteri.USD + Miktar;
                            }
                            else if (Urun == "İSVİÇRE FRANGI")
                            {
                                musteri.CHF = musteri.CHF + Miktar;
                            }
                            else if (Urun == "DANİMARKA KRONU")
                            {
                                musteri.DKK = musteri.DKK + Miktar;
                            }
                            else if (Urun == "İNGİLİZ STERLİNİ")
                            {
                                musteri.STRL = musteri.STRL + Miktar;
                            }
                            else if (Urun == "KÜLÇE ALTIN")
                            {
                                musteri.HAS = musteri.HAS + Miktar;
                            }
                            else if (Urun == "TÜRK LİRASI")
                            {
                                musteri.TL = musteri.TL + Miktar;
                            }
                            else if (Urun == "REŞAT BEŞLİ")
                            {
                                musteri.RBesli = musteri.RBesli + Miktar;
                            }
                            else if (Urun == "İSVEÇ KRONU")
                            {
                                musteri.SEK = musteri.SEK + Miktar;
                            }
                            else if (Urun == "NORVEÇ KRONU")
                            {
                                musteri.NOK = musteri.NOK + Miktar;
                            }
                            else if (Urun == "JAPON YENİ")
                            {
                                musteri.JPY = musteri.JPY + Miktar;
                            }
                            else if (Urun == "KANADA DOLARI")
                            {
                                musteri.KD = musteri.KD + Miktar;
                            }
                            else if (Urun == "AVUSTRALYA DOLARI")
                            {
                                musteri.AD = musteri.AD + Miktar;
                            }
                            else if (Urun == "RUS RUBLESİ")
                            {
                                musteri.RB = musteri.RB + Miktar;
                            }
                            else if (Urun == "RİYAL")
                            {
                                musteri.RY = musteri.RY + Miktar;
                            }
                            else if (Urun == "ATATEK")
                            {
                                musteri.ATATEK = musteri.ATATEK + Miktar;
                            }
                            else if (Urun == "REŞAT LİRA")
                            {
                                musteri.RLira = musteri.RLira + Miktar;
                            }
                            else if (Urun == "HAMİT BEŞLİ")
                            {
                                musteri.HBesli = musteri.HBesli + Miktar;
                            }
                            else if (Urun == "CUMHURİYET BEŞLİ")
                            {
                                musteri.CBesli = musteri.CBesli + Miktar;
                            }
                            else if (Urun == "22 AYAR")
                            {
                                musteri.YiAyar = musteri.YiAyar + Miktar;
                            }
                            db.Entry(musteri).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    if (model[i].StokAdi == "AMERİKAN DOLARI" || model[i].StokAdi == "EURO" || model[i].StokAdi == "İSVİÇRE FRANGI" || model[i].StokAdi == "DANİMARKA KRONU" || model[i].StokAdi == "İNGİLİZ STERLİNİ" || model[i].StokAdi == "TÜRK LİRASI" || model[i].StokAdi == "İSVEÇ KRONU" || model[i].StokAdi == "NORVEÇ KRONU" || model[i].StokAdi == "JAPON YENİ" || model[i].StokAdi == "KANADA DOLARI" || model[i].StokAdi == "AVUSTRALYA DOLARI" || model[i].StokAdi == "RUS RUBLESİ" || model[i].StokAdi == "RİYAL")
                    {
                        Hareket.Turu = "DÖVİZ";
                        Hareket.HasNet = 0;

                        if (model[i].HareketTuru == "GİRİŞ")
                        {

                            if (Hareket.StokId == "AMERİKAN DOLARI")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "USD" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "EURO")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "EURO" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "İSVİÇRE FRANGI")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "CHF" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "İNGİLİZ STERLİNİ")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "STRL" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "DANİMARKA KRONU")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "DKK" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "İSVEÇ KRONU")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "SEK" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "NORVEÇ KRONU")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "NOK" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "JAPON YENİ")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "JPY" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "KANADA DOLARI")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "KD" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "AVUSTRALYA DOLARI")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "AD" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "RİYAL")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "RİYAL" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "RUS RUBLESİ")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "RB" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }

                        }
                        else
                        {
                            if (Hareket.StokId == "AMERİKAN DOLARI")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "USD" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "EURO")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "EURO" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "İSVİÇRE FRANGI")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "CHF" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "İNGİLİZ STERLİNİ")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "STRL" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "DANİMARKA KRONU")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "DKK" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "İSVEÇ KRONU")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "SEK" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "NORVEÇ KRONU")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "NOK" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "JAPON YENİ")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "JPY" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "KANADA DOLARI")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "KD" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "AVUSTRALYA DOLARI")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "AD" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "RİYAL")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "RİYAL" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else if (Hareket.StokId == "RUS RUBLESİ")
                            {
                                kasa = db.Kasalar.Where(x => x.DovizTuru == "RB" && x.SubeNo == "NO1").FirstOrDefault();
                                kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                                db.Entry(kasa).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            //else
                            //{
                            //    kasa = db.Kasalar.Where(x => x.DovizTuru == "TL" && x.SubeNo == "NO1").FirstOrDefault();
                            //    kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                            //    db.Entry(kasa).State = EntityState.Modified;
                            //    db.SaveChanges();
                            //}

                        }
                    }
                    else
                    {
                        Hareket.Turu = "HAS";
                        Hareket.HasNet = Math.Round(Convert.ToDouble((model[i].SatisTutari / model[i].Miktar)), 3) / kulce.SatisFiyati;

                    }
                    Hareket.MusteriAdi = model[i].MusteriAdSoyad;
                    fatura.Musteri = Hareket.MusteriAdi;
                    Hareket.StokId = model[i].StokAdi;
                    Hareket.StokAdi = model[i].StokAdi;
                    Hareket.Tarih = model[i].Tarih;
                    Hareket.Hesaplama = "Adet";
                    Hareket.Miktar = Math.Round(Convert.ToDouble(model[i].Miktar), 3);
                    Hareket.IscilikCM = null;
                    Hareket.IscilikGram = null;


                    Hareket.BirimFiyati = model[i].BirimFiyati;
                    Hareket.Maliyet = null;
                    Hareket.SatisTutari = Math.Round(Convert.ToDouble(model[i].SatisTutari), 3);
                    Hareket.FisNo = id;


                    Hareket.HareketTuru = model[i].HareketTuru;
                    Hareket.HareketTipi = tur;
                    Hareket.Kar = null;
                    Hareket.SubeNo = "NO1";
                    if (calisan != null)
                    {
                        Hareket.Islemci = personel;
                        fatura.Islemci = personel;
                    }
                    else
                    {
                        Hareket.Islemci = null;

                    }

                    Stokhareket.Add(Hareket);
                    model[i].Tarih.AddSeconds(1);
                }


                else if (model[i].StokAdi == "Kredi Karti")
                {
                    KomisyonTanim km = new KomisyonTanim();

                    var kmsyn = db.Komisyonlar.Where(x => x.Taksit == taksit && x.BankaAdi == KrediKarti).Select(x => x.Komisyon).FirstOrDefault();
                    Hareket.Turu = "BANKA";
                    Hareket.StokAdi = KrediKarti;
                    //Hareket.KomisyonOrani = Math.Round((Convert.ToDouble(((model[i].SatisTutari - model[i].Miktar) / model[i].Miktar) * 100)), 2);
                    Hareket.KomisyonOrani = Convert.ToDouble(kmsyn);
                    fatura.KrediKarti = Math.Round(Convert.ToDouble(fatura.KrediKarti + model[i].SatisTutari), 3);
                    fatura.AlimTutari = Math.Round(Convert.ToDouble(fatura.AlimTutari - fatura.KrediKarti), 3);

                    Hareket.Taksit = taksit;
                    Hareket.SatisTutari = Math.Round(Convert.ToDouble(model[i].SatisTutari), 3);
                    Hareket.Miktar = Math.Round(Convert.ToDouble(model[i].SatisTutari) - Convert.ToDouble((model[i].SatisTutari) * kmsyn / 100), 3);
                    Hareket.Onay = false;
                    Hareket.StokId = "KREDİ KARTI";
                    Hareket.BirimFiyati = 1;
                    //Hareket.FisNo = id;

                    string MusteriAdi = model[i].MusteriAdSoyad;
                    if (MusteriAdi != null)
                    {
                        musteri = db.Musteriler.Where(x => x.AdSoyad == MusteriAdi).FirstOrDefault();
                        Hareket.MusteriAdi = MusteriAdi;
                        fatura.Musteri = Hareket.MusteriAdi;
                    }
                    Hareket.Tarih = model[i].Tarih.AddSeconds(1);
                    Hareket.SubeNo = "NO1";
                    if (calisan != null)
                    {
                        Hareket.Islemci = personel;
                        fatura.Islemci = personel;
                    }

                    Stokhareket.Add(Hareket);

                }



                if (model[i].HareketTuru == "GİRİŞ")
                {
                    fatura.AlimTutari = Math.Round(Convert.ToDouble(fatura.AlimTutari + model[i].SatisTutari), 3);
                    if (brkart != null && model[i].StokAdi != "Kredi Karti")
                    {
                        var temp = model[i].Miktar;
                        brkart.Miktar = brkart.Miktar + temp;

                        db.Entry(brkart).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                    else
                    {
                        if (brkart != null)
                        {
                            var temp = model[i].Miktar;
                            brkart.Miktar = brkart.Miktar + temp;

                            db.Entry(brkart).State = EntityState.Modified;
                            db.SaveChanges();

                        }
                    }
                }
                else if (model[i].HareketTuru == "ÇIKIŞ")
                {
                    fatura.SatisTutari = Math.Round(Convert.ToDouble(fatura.SatisTutari + model[i].SatisTutari), 3);
                    if (brkart != null)
                    {
                        var temp = model[i].Miktar;
                        brkart.Miktar = brkart.Miktar - temp;

                        db.Entry(brkart).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                    else if (yeni != null)
                    {
                        sks.StokId = yeni.StokId;
                        sks.StokCinsi = yeni.StokCinsi;
                        sks.StokGrubu = yeni.StokGrubu;
                        sks.StokAltGrubu = yeni.StokAltGrubu;
                        sks.Hesaplama = yeni.Hesaplama;
                        sks.Sertifika = yeni.Sertifika;
                        sks.Miktar = yeni.Miktar;
                        sks.Milyem = yeni.Milyem;
                        sks.IscilikCm = yeni.IscilikCm;
                        sks.IscilikCmG = yeni.IscilikCmG;
                        sks.IscilikGr = yeni.IscilikGr;
                        sks.HasNet = yeni.HasNet;
                        sks.BirimFiyat = yeni.BirimFiyat;
                        sks.Maliyet = yeni.Maliyet;
                        sks.Fire = yeni.Fire;
                        sks.Turu = yeni.Turu;
                        sks.Kar = yeni.Kar;
                        sks.SatisTutari = yeni.SatisTutari;
                        sks.ToptanciAdi = yeni.ToptanciAdi;
                        sks.Tarih = yeni.Tarih;
                        sks.Ozellik1 = yeni.Ozellik1;
                        sks.Ozellik2 = yeni.Ozellik2;
                        sks.Ozellik3 = yeni.Ozellik3;
                        sks.RafOmru = yeni.RafOmru;
                        sks.EtiketFiyat = yeni.EtiketFiyat;

                        //db.Entry(yeni).State = EntityState.Deleted;
                        //db.SaveChanges();
                        db.Entry(sks).State = EntityState.Added;
                        db.SaveChanges();

                    }
                }
                else if (model[i].HareketTuru == "BORÇ" || model[i].HareketTuru == "A BORÇ")
                {
                    if (brkart != null)
                    {
                        var temp = model[i].Miktar;
                        brkart.Miktar = brkart.Miktar - temp;

                        db.Entry(brkart).State = EntityState.Modified;
                        db.SaveChanges();

                    }

                }



                fatura.Nakit = Math.Round(Convert.ToDouble(fatura.Nakit + model[i].SatisTutari), 3);
            }

            fatura.FisNo = Convert.ToInt32(id);
            fatura.Tarih = DateTime.Now;
            fatura.Nakit = fatura.SatisTutari - fatura.AlimTutari - fatura.KrediKarti;

            kasa = db.Kasalar.Where(x => x.DovizTuru == "TL").FirstOrDefault();
            kasa.BaslangicBakiye = kasa.BaslangicBakiye + fatura.Nakit;
            db.Entry(kasa).State = EntityState.Modified;
            db.SaveChanges();



            if (fatura.Nakit < 0)
            {
                StokHareket hareket2 = new StokHareket();
                hareket2.StokId = "TÜRK LİRASI";
                hareket2.StokAdi = "TÜRK LİRASI";
                hareket2.Tarih = model[model.Count - 1].Tarih.AddSeconds(1);
                hareket2.Hesaplama = "Adet";
                hareket2.Miktar = fatura.Nakit;
                hareket2.SatisTutari = fatura.Nakit;
                hareket2.BirimFiyati = 1;
                hareket2.HareketTuru = "ÇIKIŞ";
                hareket2.SubeNo = "NO1";
                hareket2.IscilikCM = null;
                hareket2.IscilikGram = null;
                hareket2.HasNet = 0;
                db.Entry(hareket2).State = EntityState.Added;
                db.SaveChanges();

            }
            else
            {
                StokHareket hareket2 = new StokHareket();
                //hareket2.MusteriAdi = model[0].MusteriAdSoyad;
                hareket2.StokId = "TÜRK LİRASI";
                hareket2.StokAdi = "TÜRK LİRASI";
                hareket2.Tarih = model[model.Count - 1].Tarih.AddSeconds(1);
                hareket2.Hesaplama = "Adet";
                hareket2.Miktar = fatura.Nakit;
                hareket2.SatisTutari = fatura.Nakit;
                hareket2.BirimFiyati = 1;
                hareket2.HareketTuru = "GİRİŞ";
                hareket2.SubeNo = "NO1";
                hareket2.IscilikCM = null;
                hareket2.IscilikGram = null;
                hareket2.HasNet = 0;
                db.Entry(hareket2).State = EntityState.Added;
                db.SaveChanges();

            }

            foreach (StokHareket i in Stokhareket)
            {
                db.StokHareketleri.Add(i);
                db.SaveChanges();
            }
            db.Faturalar.Add(fatura);
            db.SaveChanges();


            return Json(Url.Action("Print", "Kuyumcu", new { FisNo = id, Musteri = model[0].MusteriAdSoyad, Islemci = personel }));
        }

        [HttpGet]
        public ActionResult Print(int FisNo, string Musteri, string Islemci)
        {
            Fis report = new Fis();
            report.Parameters["FisNo"].Value = FisNo;
            report.Parameters["Musteri"].Value = Musteri;
            report.Parameters["Islemci"].Value = Islemci;
            using (MemoryStream ms = new MemoryStream())
            {
                report.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);

            }

        }
       
        private FileResult ExportDocument(byte[] document, string format, string fileName, bool isInline)
        {
            string contentType;
            string disposition = (isInline) ? "inline" : "attachment";

            switch (format.ToLower())
            {
                case "docx":
                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case "xls":
                    contentType = "application/vnd.ms-excel";
                    break;
                case "xlsx":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case "mht":
                    contentType = "message/rfc822";
                    break;
                case "html":
                    contentType = "text/html";
                    break;
                case "txt":
                case "csv":
                    contentType = "text/plain";
                    break;
                case "png":
                    contentType = "image/png";
                    break;
                default:
                    contentType = String.Format("application/{0}", format);
                    break;
            }

            Response.AddHeader("Content-Disposition", String.Format("{0}; filename={1}", disposition, fileName));              
            return File(document, contentType);
        }

        public int? getid()
        {
            KuyumcuContext db = new KuyumcuContext();
            int? id = (from a in db.StokHareketleri
                       select a.FisNo).Max();
            if (id == null)
                id = 1;
            return id + 1;
        }
        [HttpPost]
        public ActionResult HizliAlimSatim1(string AdSoyad)
        {
            KuyumcuContext db = new KuyumcuContext();
            Musteri musteri = new Musteri();
            musteri = db.Musteriler.Where(x => x.AdSoyad == AdSoyad || x.CepTel == AdSoyad).FirstOrDefault();
            if (musteri == null)
            {
                var x = "failed";
                return Json(x);
            }
            else if (db.Musteriler.Where(x => x.AdSoyad == AdSoyad).Count() > 1)
            {
                var x = "failed2";
                return Json(x);
            }
            return Json(musteri.AdSoyad);

        }

        [HttpPost]
        public ActionResult HizliAlimSatim2(string barkod)
        {
            KuyumcuContext db = new KuyumcuContext();

            StokKart yeni = new StokKart();
            yeni = db.StokKartlari.Where(x => x.id == Convert.ToInt32(barkod)).FirstOrDefault();
            if (yeni == null)
            {
                var x = "failed";
                return Json(x);
            }
            BarkodsuzStokKart kulce = new BarkodsuzStokKart();
            kulce = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KÜLÇE ALTIN").FirstOrDefault();
            var sekayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 AYAR").FirstOrDefault();
            var odayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 AYAR").FirstOrDefault();
            var osayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 AYAR").FirstOrDefault();
            var yiayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR").FirstOrDefault();
            var bilezik = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "BİLEZİK").FirstOrDefault();
            var usd = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "AMERİKAN DOLARI").FirstOrDefault();

            if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "8 AYAR" && yeni.StokId.Contains("BLZ") == false)
            {
                if (sekayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * sekayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "14 AYAR")
            {
                if (odayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * odayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "18 AYAR" && yeni.StokId.Contains("BLZ") == false)
            {
                if (osayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * osayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "22 AYAR" && yeni.StokId.Contains("BLZ") == false)
            {
                if (yiayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * yiayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokId.Contains("BLZ") == true)
            {
                if (bilezik.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * bilezik.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            else if (yeni.Turu == "USD")
            {
                yeni.SatisTutari = yeni.SatisTutari * Convert.ToDouble(usd.SatisFiyati);
                yeni.Turu = "TL";
            }

            string k = yeni.StokId + ", " + yeni.BirimFiyat + ", " + yeni.SatisTutari + ", " + yeni.Miktar;
            return Json(k);
        }
        [HttpPost]
        public ActionResult HizliAlimSatim3(string barkod)
        {
            KuyumcuContext db = new KuyumcuContext();
            personelEkle yeni = new personelEkle();
            int y = Convert.ToInt32(barkod);
            yeni = db.Personel.Where(x => x.Id == y).FirstOrDefault();
            if (yeni == null)
            {
                var x = "failed";
                return Json(x);
            }
            string k = yeni.AdiSoyadi;
            return Json(k);
        }

        [HttpPost]
        public ActionResult HizliAlimSatim4(string bankaadi, string SubeNo, int taksit)
        {
            KuyumcuContext db = new KuyumcuContext();
            string hesapNo = db.Bankalar.Where(x => x.BankaAdi == bankaadi && x.SubeAdi == SubeNo && x.HesapDovizTuru == "TL").Select(y => y.HesapNumarasi).FirstOrDefault();
            var komisyon = db.Komisyonlar.Where(x => x.BankaAdi == bankaadi && x.Taksit == taksit).Select(y => y.Komisyon).FirstOrDefault();
            return Json(komisyon);
        }
        [HttpPost]
        public ActionResult HizliAlimSatim5(string banka, string SubeNo)
        {
            KuyumcuContext db = new KuyumcuContext();
            OzelModel model = new OzelModel();
            string hesapNo = db.Bankalar.Where(x => x.BankaAdi == banka && x.SubeAdi == SubeNo && x.HesapDovizTuru == "TL").Select(y => y.HesapNumarasi).FirstOrDefault();
            model.Taksitler = db.Komisyonlar.Where(y => y.BankaAdi == banka).Select(x => x.Taksit).ToList();
            return Json(model.Taksitler);
        }
        [HttpPost]
        public ActionResult HizliAlimSatim6(string barkod)
        {
            KuyumcuContext db = new KuyumcuContext();
            StokKart yeni = new StokKart();

            yeni = db.StokKartlari.Where(x => x.id == Convert.ToInt32(barkod)).FirstOrDefault();
            if (yeni.StokId != null)
            {
                db.StokKartlari.Remove(yeni);
                db.SaveChanges();
            }
            return RedirectToAction("HizliAlimSatim", "Kuyumcu");
        }

        public ActionResult Tabela()
        {
            KuyumcuContext db = new KuyumcuContext();
            BarkodsuzStokKart bs = new BarkodsuzStokKart();
            OzelModel model = new OzelModel();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "ÇEYREK" && x.StokCinsi != null).FirstOrDefault();
            model.CeyrekA = bs.AlisFiyati;
            model.CeyrekS = bs.SatisFiyati;
            model.CeyrekM = bs.HsNet;
            model.CeyrekH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "YARIM" && x.StokCinsi != null).FirstOrDefault();
            model.YarimA = bs.AlisFiyati;
            model.YarimS = bs.SatisFiyati;
            model.YarimM = bs.HsNet;
            model.YarimH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "ATATEK" && x.StokCinsi != null).FirstOrDefault();
            model.AtatekA = bs.AlisFiyati;
            model.AtatekS = bs.SatisFiyati;
            model.AtatekM = bs.HsNet;
            model.AtatekH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "2.5'LU" && x.StokCinsi != null).FirstOrDefault();
            model.IkibucukluA = bs.AlisFiyati;
            model.IkibucukluS = bs.SatisFiyati;
            model.IkibucukluM = bs.HsNet;
            model.IkibucukluH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "C.LİRA" && x.StokCinsi != null).FirstOrDefault();
            model.CliraA = bs.AlisFiyati;
            model.CliraS = bs.SatisFiyati;
            model.CliraM = bs.HsNet;
            model.CliraH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR GRAM" && x.StokCinsi != null).FirstOrDefault();
            model.YirmiIkiGramA = bs.AlisFiyati;
            model.YirmiIkiGramS = bs.SatisFiyati;
            model.YirmiIkiGramM = bs.HsNet;
            model.YirmiIkiGramH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "24 AYAR GRAM" && x.StokCinsi != null).FirstOrDefault();
            model.YirmiDortGramA = bs.AlisFiyati;
            model.YirmiDortGramS = bs.SatisFiyati;
            model.YirmiDortGramM = bs.HsNet;
            model.YirmiDortGramH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "HAMİT LİRA" && x.StokCinsi != null).FirstOrDefault();
            model.HamitLiraA = bs.AlisFiyati;
            model.HamitLiraS = bs.SatisFiyati;
            model.HamitLiraH = bs.HsNetSatis;
            model.HamitLiraM = bs.HsNet;

            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "REŞAT BEŞLİ" && x.StokCinsi != null).FirstOrDefault();
            model.ResatBesliA = bs.AlisFiyati;
            model.ResatBesliS = bs.SatisFiyati;
            model.ResatBesliM = bs.HsNet;
            model.ResatBesliH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "HAMİT BEŞLİ" && x.StokCinsi != null).FirstOrDefault();
            model.HamitBesliA = bs.AlisFiyati;
            model.HamitBesliS = bs.SatisFiyati;
            model.HamitBesliM = bs.HsNet;
            model.HamitBesliH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "CUMHURİYET BEŞLİ" && x.StokCinsi != null).FirstOrDefault();
            model.CUMBesliA = bs.AlisFiyati;
            model.CUMBesliS = bs.SatisFiyati;
            model.CUMBesliM = bs.HsNet;
            model.CUMBesliH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "REŞAT LİRA" && x.StokCinsi != null).FirstOrDefault();
            model.ResatLiraA = bs.AlisFiyati;
            model.ResatLiraS = bs.SatisFiyati;
            model.ResatLiraH = bs.HsNetSatis;
            model.ResatLiraM = bs.HsNet;

            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 HURDA" && x.StokCinsi != null).FirstOrDefault();
            model.SekhurdaA = bs.AlisFiyati;
            model.SekhurdaS = bs.SatisFiyati;
            model.SekhurdaM = bs.HsNet;
            model.SekhurdaH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 HURDA" && x.StokCinsi != null).FirstOrDefault();
            model.OndorthurdaA = bs.AlisFiyati;
            model.OndorthurdaS = bs.SatisFiyati;
            model.OndorthurdaM = bs.HsNet;
            model.OndorthurdaH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 HURDA" && x.StokCinsi != null).FirstOrDefault();
            model.OnsekhurdaA = bs.AlisFiyati;
            model.OnsekhurdaS = bs.SatisFiyati;
            model.OnsekhurdaM = bs.HsNet;
            model.OnsekhurdaH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "21 HURDA" && x.StokCinsi != null).FirstOrDefault();
            model.YirbirhurdaA = bs.AlisFiyati;
            model.YirbirhurdaS = bs.SatisFiyati;
            model.YirbirhurdaM = bs.HsNet;
            model.YirbirhurdaH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 HURDA" && x.StokCinsi != null).FirstOrDefault();
            model.YirmiikihurdaA = bs.AlisFiyati;
            model.YirmiikihurdaS = bs.SatisFiyati;
            model.YirmiikihurdaM = bs.HsNet;
            model.YirmiikihurdaH = bs.HsNetSatis;


            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 AYAR" && x.StokCinsi != null).FirstOrDefault();
            model.SekAyarA = bs.AlisFiyati;
            model.SekAyarS = bs.SatisFiyati;
            model.SekAyarM = bs.HsNet;
            model.SekAyarH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 AYAR" && x.StokCinsi != null).FirstOrDefault();
            model.OdAyarA = bs.AlisFiyati;
            model.OdAyarS = bs.SatisFiyati;
            model.OdAyarM = bs.HsNet;
            model.OdAyarH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 AYAR" && x.StokCinsi != null).FirstOrDefault();
            model.OsAyarA = bs.AlisFiyati;
            model.OsAyarS = bs.SatisFiyati;
            model.OsAyarM = bs.HsNet;
            model.OsAyarH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR" && x.StokCinsi != null).FirstOrDefault();
            model.YiAyarA = bs.AlisFiyati;
            model.YiAyarS = bs.SatisFiyati;
            model.YiAyarM = bs.HsNet;
            model.YiAyarH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "BİLEZİK" && x.StokCinsi != null).FirstOrDefault();
            model.BilezikA = bs.AlisFiyati;
            model.BilezikS = bs.SatisFiyati;
            model.BilezikM = bs.HsNet;
            model.BilezikH = bs.HsNetSatis;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "21 AYAR" && x.StokCinsi != null).FirstOrDefault();
            model.YirmiBirGramA = bs.AlisFiyati;
            model.YirmiBirGramS = bs.SatisFiyati;
            model.YirmiBirGramM = bs.HsNet;
            model.YirmiBirGramH = bs.HsNetSatis;





            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "AMERİKAN DOLARI" && x.StokCinsi != null).FirstOrDefault();
            model.DolarA = bs.AlisFiyati;
            model.DolarS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "EURO" && x.StokCinsi != null).FirstOrDefault();
            model.EuroA = bs.AlisFiyati;
            model.EuroS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İSVİÇRE FRANGI" && x.StokCinsi != null).FirstOrDefault();
            model.IsvicFranA = bs.AlisFiyati;
            model.IsvicFranS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "DANİMARKA KRONU" && x.StokCinsi != null).FirstOrDefault();
            model.DankronA = bs.AlisFiyati;
            model.DankronS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İNGİLİZ STERLİNİ" && x.StokCinsi != null).FirstOrDefault();
            model.SterlinA = bs.AlisFiyati;
            model.SterlinS = bs.SatisFiyati;

            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İSVEÇ KRONU" && x.StokCinsi != null).FirstOrDefault();
            model.IsvecKronuA = bs.AlisFiyati;
            model.IsvecKronuS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "NORVEÇ KRONU" && x.StokCinsi != null).FirstOrDefault();
            model.NorvecKronuA = bs.AlisFiyati;
            model.NorvecKronuS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "JAPON YENİ" && x.StokCinsi != null).FirstOrDefault();
            model.JaponYeniA = bs.AlisFiyati;
            model.JaponYeniS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KANADA DOLARI" && x.StokCinsi != null).FirstOrDefault();
            model.KanDolariA = bs.AlisFiyati;
            model.KanDolariS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "AVUSTRALYA DOLARI" && x.StokCinsi != null).FirstOrDefault();
            model.AvusDolariA = bs.AlisFiyati;
            model.AvusDolariS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "RUS RUBLESİ" && x.StokCinsi != null).FirstOrDefault();
            model.RusRubleA = bs.AlisFiyati;
            model.RusRubleS = bs.SatisFiyati;
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "RİYAL" && x.StokCinsi != null).FirstOrDefault();
            model.RiyalA = bs.AlisFiyati;
            model.RiyalS = bs.SatisFiyati;

            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KÜLÇE ALTIN" && x.StokCinsi != null).FirstOrDefault();
            model.KulceA = bs.AlisFiyati;
            model.KulceS = bs.SatisFiyati;

            model.Saatler = new List<string>();
            foreach (DateTime i in db.TabelaLoglari.Select(x => x.tarih).Distinct().ToList())
            {
                var saat = i.ToString("HH:mm:ss");
                model.Saatler.Add(saat);
            }


            return View(model);
            //return textbox name to controller
        }

        [HttpPost]
        public ActionResult Tabela(OzelModel model)
        {
            BarkodsuzStokKart bs = new BarkodsuzStokKart();
            KuyumcuContext db = new KuyumcuContext();

            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "ÇEYREK").FirstOrDefault();
            bs.AlisFiyati = model.CeyrekA;
            bs.SatisFiyati = model.CeyrekS;
            bs.HsNet = model.CeyrekM;
            bs.HsNetSatis = model.CeyrekH;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "YARIM").FirstOrDefault();
            bs.AlisFiyati = model.YarimA;
            bs.SatisFiyati = model.YarimS;
            bs.HsNetSatis = model.YarimH;
            bs.HsNet = model.YarimM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "ATATEK").FirstOrDefault();
            bs.AlisFiyati = model.AtatekA;
            bs.SatisFiyati = model.AtatekS;
            bs.HsNetSatis = model.AtatekH;
            bs.HsNet = model.AtatekM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "2.5'LU").FirstOrDefault();
            bs.AlisFiyati = model.IkibucukluA;
            bs.SatisFiyati = model.IkibucukluS;
            bs.HsNetSatis = model.IkibucukluH;
            bs.HsNet = model.IkibucukluM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "C.LİRA").FirstOrDefault();
            bs.AlisFiyati = model.CliraA;
            bs.SatisFiyati = model.CliraS;
            bs.HsNetSatis = model.CliraH;
            bs.HsNet = model.CliraM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR GRAM").FirstOrDefault();
            bs.AlisFiyati = model.YirmiIkiGramA;
            bs.SatisFiyati = model.YirmiIkiGramS;
            bs.HsNetSatis = model.YirmiIkiGramH;
            bs.HsNet = model.YirmiIkiGramM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "24 AYAR GRAM").FirstOrDefault();
            bs.AlisFiyati = model.YirmiDortGramA;
            bs.SatisFiyati = model.YirmiDortGramS;
            bs.HsNetSatis = model.YirmiDortGramH;
            bs.HsNet = model.YirmiDortGramM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "HAMİT LİRA").FirstOrDefault();
            bs.AlisFiyati = model.HamitLiraA;
            bs.SatisFiyati = model.HamitLiraS;
            bs.HsNetSatis = model.HamitLiraH;
            bs.HsNet = model.HamitLiraM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();

            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "REŞAT BEŞLİ").FirstOrDefault();
            bs.AlisFiyati = model.ResatBesliA;
            bs.SatisFiyati = model.ResatBesliS;
            bs.HsNetSatis = model.ResatBesliH;
            bs.HsNet = model.ResatBesliM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "HAMİT BEŞLİ").FirstOrDefault();
            bs.AlisFiyati = model.HamitBesliA;
            bs.SatisFiyati = model.HamitBesliS;
            bs.HsNetSatis = model.HamitBesliH;
            bs.HsNet = model.HamitBesliM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "CUMHURİYET BEŞLİ").FirstOrDefault();
            bs.AlisFiyati = model.CUMBesliA;
            bs.SatisFiyati = model.CUMBesliS;
            bs.HsNetSatis = model.CUMBesliH;
            bs.HsNet = model.CUMBesliM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "REŞAT LİRA").FirstOrDefault();
            bs.AlisFiyati = model.ResatLiraA;
            bs.SatisFiyati = model.ResatLiraS;
            bs.HsNetSatis = model.ResatLiraH;
            bs.HsNet = model.ResatLiraM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();


            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 AYAR").FirstOrDefault();
            bs.AlisFiyati = model.SekAyarA;
            bs.SatisFiyati = model.SekAyarS;
            bs.HsNetSatis = model.SekAyarH;
            bs.HsNet = model.SekAyarM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 AYAR").FirstOrDefault();
            bs.AlisFiyati = model.OdAyarA;
            bs.SatisFiyati = model.OdAyarS;
            bs.HsNetSatis = model.OdAyarH;
            bs.HsNet = model.OdAyarM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 AYAR").FirstOrDefault();
            bs.AlisFiyati = model.OsAyarA;
            bs.SatisFiyati = model.OsAyarS;
            bs.HsNetSatis = model.OsAyarH;
            bs.HsNet = model.OsAyarM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR").FirstOrDefault();
            bs.AlisFiyati = model.YiAyarA;
            bs.SatisFiyati = model.YiAyarS;
            bs.HsNetSatis = model.YiAyarH;
            bs.HsNet = model.YiAyarM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "BİLEZİK").FirstOrDefault();
            bs.AlisFiyati = model.BilezikA;
            bs.SatisFiyati = model.BilezikS;
            bs.HsNetSatis = model.BilezikH;
            bs.HsNet = model.BilezikM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "21 AYAR").FirstOrDefault();
            bs.AlisFiyati = model.YirmiBirGramA;
            bs.SatisFiyati = model.YirmiBirGramS;
            bs.HsNetSatis = model.YirmiBirGramH;
            bs.HsNet = model.YirmiBirGramM;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();



            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 HURDA").FirstOrDefault();
            bs.AlisFiyati = model.SekhurdaA;
            bs.SatisFiyati = model.SekhurdaS;
            bs.HsNet = model.SekhurdaM;
            bs.HsNetSatis = model.SekhurdaH;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 HURDA").FirstOrDefault();
            bs.AlisFiyati = model.OndorthurdaA;
            bs.SatisFiyati = model.OndorthurdaS;
            bs.HsNet = model.OndorthurdaM;
            bs.HsNetSatis = model.OndorthurdaH;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 HURDA").FirstOrDefault();
            bs.AlisFiyati = model.OnsekhurdaA;
            bs.SatisFiyati = model.OnsekhurdaS;
            bs.HsNet = model.OnsekhurdaM;
            bs.HsNetSatis = model.OnsekhurdaH;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "21 HURDA").FirstOrDefault();
            bs.AlisFiyati = model.YirbirhurdaA;
            bs.SatisFiyati = model.YirbirhurdaS;
            bs.HsNet = model.YirbirhurdaM;
            bs.HsNetSatis = model.YirbirhurdaH;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 HURDA").FirstOrDefault();
            bs.AlisFiyati = model.YirmiikihurdaA;
            bs.SatisFiyati = model.YirmiikihurdaS;
            bs.HsNet = model.YirmiikihurdaM;
            bs.HsNetSatis = model.YirmiikihurdaH;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "AMERİKAN DOLARI").FirstOrDefault();
            bs.AlisFiyati = model.DolarA;
            bs.SatisFiyati = model.DolarS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "EURO").FirstOrDefault();
            bs.AlisFiyati = model.EuroA;
            bs.SatisFiyati = model.EuroS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İSVİÇRE FRANGI").FirstOrDefault();
            bs.AlisFiyati = model.IsvicFranA;
            bs.SatisFiyati = model.IsvicFranS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "DANİMARKA KRONU").FirstOrDefault();
            bs.AlisFiyati = model.DankronA;
            bs.SatisFiyati = model.DankronS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İNGİLİZ STERLİNİ").FirstOrDefault();
            bs.AlisFiyati = model.SterlinA;
            bs.SatisFiyati = model.SterlinS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();

            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İSVEÇ KRONU").FirstOrDefault();
            bs.AlisFiyati = model.IsvecKronuA;
            bs.SatisFiyati = model.IsvecKronuS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "NORVEÇ KRONU").FirstOrDefault();
            bs.AlisFiyati = model.NorvecKronuA;
            bs.SatisFiyati = model.NorvecKronuS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "JAPON YENİ").FirstOrDefault();
            bs.AlisFiyati = model.JaponYeniA;
            bs.SatisFiyati = model.JaponYeniS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KANADA DOLARI").FirstOrDefault();
            bs.AlisFiyati = model.KanDolariA;
            bs.SatisFiyati = model.KanDolariS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "AVUSTRALYA DOLARI").FirstOrDefault();
            bs.AlisFiyati = model.AvusDolariA;
            bs.SatisFiyati = model.AvusDolariS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "RUS RUBLESİ").FirstOrDefault();
            bs.AlisFiyati = model.RusRubleA;
            bs.SatisFiyati = model.RusRubleS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();
            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "RİYAL").FirstOrDefault();
            bs.AlisFiyati = model.RiyalA;
            bs.SatisFiyati = model.RiyalS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();


            bs = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KÜLÇE ALTIN").FirstOrDefault();
            bs.AlisFiyati = model.KulceA;
            bs.SatisFiyati = model.KulceS;
            db.Entry(bs).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Tabela", "Kuyumcu");
        }

        [HttpPost]
        public ActionResult Tabela1(DateTime tarih)
        {
            KuyumcuContext db = new KuyumcuContext();
            OzelModel model = new OzelModel();

            List<tabelalog> liste = new List<tabelalog>();
            liste = db.TabelaLoglari.Where(x => x.tarih.Day == tarih.Day && x.tarih.Month == tarih.Month && x.tarih.Year == tarih.Year).Distinct().ToList();

            model.Saatler = new List<string>();
            foreach (var i in liste)
            {
                var saat = i.tarih.ToString("HH:mm:ss");
                if (model.Saatler.Contains(saat) == false)
                {
                    model.Saatler.Add(saat);
                }
            }
            return Json(model.Saatler);
        }

        [HttpPost]
        public ActionResult Tabela2(string tarih, string time)
        {

            OzelModel model = new OzelModel();
            string y = tarih + " " + time;
            DateTime k = Convert.ToDateTime(y);
            tabelalog bs = new tabelalog();
            KuyumcuContext db = new KuyumcuContext();
            string data;

            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "ÇEYREK" && x.tarih == k).FirstOrDefault();
            model.CeyrekA = bs.AlisFiyati;
            data = model.CeyrekA + ", ";
            model.CeyrekS = bs.SatisFiyati;
            data = data + model.CeyrekS + ", ";
            model.CeyrekM = bs.HsNet;
            data = data + model.CeyrekM + ", ";
            model.CeyrekH = bs.HsNetSatis;
            data = data + model.CeyrekH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "YARIM" && x.tarih == k).FirstOrDefault();
            model.YarimA = bs.AlisFiyati;
            data = data + model.YarimA + ", ";
            model.YarimS = bs.SatisFiyati;
            data = data + model.YarimS + ", ";
            model.YarimM = bs.HsNet;
            data = data + model.YarimM + ", ";
            model.YarimH = bs.HsNetSatis;
            data = data + model.YarimH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "ATATEK" && x.tarih == k).FirstOrDefault();
            model.AtatekA = bs.AlisFiyati;
            data = data + model.AtatekA + ", ";
            model.AtatekS = bs.SatisFiyati;
            data = data + model.AtatekS + ", ";
            model.AtatekM = bs.HsNet;
            data = data + model.AtatekM + ", ";
            model.AtatekH = bs.HsNetSatis;
            data = data + model.AtatekH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "2.5'LU" && x.tarih == k).FirstOrDefault();
            model.IkibucukluA = bs.AlisFiyati;
            data = data + model.IkibucukluA + ", ";
            model.IkibucukluS = bs.SatisFiyati;
            data = data + model.IkibucukluS + ", ";
            model.IkibucukluM = bs.HsNet;
            data = data + model.IkibucukluM + ", ";
            model.IkibucukluH = bs.HsNetSatis;
            data = data + model.IkibucukluH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "C.LİRA" && x.tarih == k).FirstOrDefault();
            model.CliraA = bs.AlisFiyati;
            data = data + model.CliraA + ", ";
            model.CliraS = bs.SatisFiyati;
            data = data + model.CliraS + ", ";
            model.CliraM = bs.HsNet;
            data = data + model.CliraM + ", ";
            model.CliraH = bs.HsNetSatis;
            data = data + model.CliraH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "22 AYAR GRAM" && x.tarih == k).FirstOrDefault();
            model.YirmiIkiGramA = bs.AlisFiyati;
            data = data + model.YirmiIkiGramA + ", ";
            model.YirmiIkiGramS = bs.SatisFiyati;
            data = data + model.YirmiIkiGramS + ", ";
            model.YirmiIkiGramM = bs.HsNet;
            data = data + model.YirmiIkiGramM + ", ";
            model.YirmiIkiGramH = bs.HsNetSatis;
            data = data + model.YirmiIkiGramH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "24 AYAR GRAM" && x.tarih == k).FirstOrDefault();
            model.YirmiDortGramA = bs.AlisFiyati;
            data = data + +model.YirmiDortGramA + ", ";
            model.YirmiDortGramS = bs.SatisFiyati;
            data = data + +model.YirmiDortGramS + ", ";
            model.YirmiDortGramM = bs.HsNet;
            data = data + model.YirmiDortGramM + ", ";
            model.YirmiDortGramH = bs.HsNetSatis;
            data = data + model.YirmiDortGramH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "HAMİT LİRA" && x.tarih == k).FirstOrDefault();
            model.HamitLiraA = bs.AlisFiyati;
            data = data + model.HamitLiraA + ", ";
            model.HamitLiraS = bs.SatisFiyati;
            data = data + model.HamitLiraS + ", ";
            model.HamitLiraH = bs.HsNetSatis;
            data = data + model.HamitLiraH + ", ";
            model.HamitLiraM = bs.HsNet;
            data = data + model.HamitLiraM + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "8 HURDA" && x.tarih == k).FirstOrDefault();
            model.SekhurdaA = bs.AlisFiyati;
            data = data + model.SekhurdaA + ", ";
            model.SekhurdaS = bs.SatisFiyati;
            data = data + model.SekhurdaS + ", ";
            model.SekhurdaM = bs.HsNet;
            data = data + model.SekhurdaM + ", ";
            model.SekhurdaH = bs.HsNetSatis;
            data = data + model.SekhurdaH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "14 HURDA" && x.tarih == k).FirstOrDefault();
            model.OndorthurdaA = bs.AlisFiyati;
            data = data + model.OndorthurdaA + ", ";
            model.OndorthurdaS = bs.SatisFiyati;
            data = data + model.OndorthurdaS + ", ";
            model.OndorthurdaM = bs.HsNet;
            data = data + model.OndorthurdaM + ", ";
            model.OndorthurdaH = bs.HsNetSatis;
            data = data + model.OndorthurdaH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "18 HURDA" && x.tarih == k).FirstOrDefault();
            model.OnsekhurdaA = bs.AlisFiyati;
            data = data + model.OnsekhurdaA + ", ";
            model.OnsekhurdaS = bs.SatisFiyati;
            data = data + model.OnsekhurdaS + ", ";
            model.OnsekhurdaM = bs.HsNet;
            data = data + model.OnsekhurdaM + ", ";
            model.OnsekhurdaH = bs.HsNetSatis;
            data = data + model.OnsekhurdaH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "21 HURDA" && x.tarih == k).FirstOrDefault();
            model.YirbirhurdaA = bs.AlisFiyati;
            data = data + model.YirbirhurdaA + ", ";
            model.YirbirhurdaS = bs.SatisFiyati;
            data = data + model.YirbirhurdaS + ", ";
            model.YirbirhurdaM = bs.HsNet;
            data = data + model.YirbirhurdaM + ", ";
            model.YirbirhurdaH = bs.HsNetSatis;
            data = data + model.YirbirhurdaH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "22 HURDA" && x.tarih == k).FirstOrDefault();
            model.YirmiikihurdaA = bs.AlisFiyati;
            data = data + model.YirmiikihurdaA + ", ";
            model.YirmiikihurdaS = bs.SatisFiyati;
            data = data + model.YirmiikihurdaS + ", ";
            model.YirmiikihurdaM = bs.HsNet;
            data = data + model.YirmiikihurdaM + ", ";
            model.YirmiikihurdaH = bs.HsNetSatis;
            data = data + model.YirmiikihurdaH + ", ";





            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "AMERİKAN DOLARI" && x.tarih == k).FirstOrDefault();
            model.DolarA = bs.AlisFiyati;
            data = data + model.DolarA + ", ";
            model.DolarS = bs.SatisFiyati;
            data = data + model.DolarS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "EURO" && x.tarih == k).FirstOrDefault();
            model.EuroA = bs.AlisFiyati;
            data = data + model.EuroA + ", ";
            model.EuroS = bs.SatisFiyati;
            data = data + model.EuroS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "İSVİÇRE FRANGI" && x.tarih == k).FirstOrDefault();
            model.IsvicFranA = bs.AlisFiyati;
            data = data + model.IsvicFranA + ", ";
            model.IsvicFranS = bs.SatisFiyati;
            data = data + model.IsvicFranS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "DANİMARKA KRONU" && x.tarih == k).FirstOrDefault();
            model.DankronA = bs.AlisFiyati;
            data = data + model.DankronA + ", ";
            model.DankronS = bs.SatisFiyati;
            data = data + model.DankronS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "İNGİLİZ STERLİNİ" && x.tarih == k).FirstOrDefault();
            model.SterlinA = bs.AlisFiyati;
            data = data + model.SterlinA + ", ";
            model.SterlinS = bs.SatisFiyati;
            data = data + model.SterlinS + ", ";

            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "İSVEÇ KRONU" && x.tarih == k).FirstOrDefault();
            model.IsvecKronuA = bs.AlisFiyati;
            data = data + model.IsvecKronuA + ", ";
            model.IsvecKronuS = bs.SatisFiyati;
            data = data + model.IsvecKronuS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "NORVEÇ KRONU" && x.tarih == k).FirstOrDefault();
            model.NorvecKronuA = bs.AlisFiyati;
            data = data + model.NorvecKronuA + ", ";
            model.NorvecKronuS = bs.SatisFiyati;
            data = data + model.NorvecKronuS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "JAPON YENİ" && x.tarih == k).FirstOrDefault();
            model.JaponYeniA = bs.AlisFiyati;
            data = data + model.JaponYeniA + ", ";
            model.JaponYeniS = bs.SatisFiyati;
            data = data + model.JaponYeniS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "KANADA DOLARI" && x.tarih == k).FirstOrDefault();
            model.KanDolariA = bs.AlisFiyati;
            data = data + +model.KanDolariA + ", ";
            model.KanDolariS = bs.SatisFiyati;
            data = data + model.KanDolariS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "AVUSTRALYA DOLARI" && x.tarih == k).FirstOrDefault();
            model.AvusDolariA = bs.AlisFiyati;
            data = data + model.AvusDolariA + ", ";
            model.AvusDolariS = bs.SatisFiyati;
            data = data + model.AvusDolariS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "RUS RUBLESİ" && x.tarih == k).FirstOrDefault();
            model.RusRubleA = bs.AlisFiyati;
            data = data + model.RusRubleA + ", ";
            model.RusRubleS = bs.SatisFiyati;
            data = data + model.RusRubleS + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "RİYAL" && x.tarih == k).FirstOrDefault();
            model.RiyalA = bs.AlisFiyati;
            data = data + +model.RiyalA + ", ";
            model.RiyalS = bs.SatisFiyati;
            data = data + model.RiyalS + ", ";



            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "KÜLÇE ALTIN" && x.tarih == k).FirstOrDefault();
            model.KulceA = bs.AlisFiyati;
            data = data + model.KulceA + ", ";
            model.KulceS = bs.SatisFiyati;
            data = data + model.KulceS + ", ";

            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "REŞAT BEŞLİ" && x.tarih == k).FirstOrDefault();
            model.ResatBesliA = bs.AlisFiyati;
            data = data + model.ResatBesliA + ", ";
            model.ResatBesliS = bs.SatisFiyati;
            data = data + model.ResatBesliS + ", ";
            model.ResatBesliM = bs.HsNet;
            data = data + model.ResatBesliM + ", ";
            model.ResatBesliH = bs.HsNetSatis;
            data = data + model.ResatBesliH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "HAMİT BEŞLİ" && x.tarih == k).FirstOrDefault();
            model.HamitBesliA = bs.AlisFiyati;
            data = data + model.HamitBesliA + ", ";
            model.HamitBesliS = bs.SatisFiyati;
            data = data + model.HamitBesliS + ", ";
            model.HamitBesliM = bs.HsNet;
            data = data + model.HamitBesliM + ", ";
            model.HamitBesliH = bs.HsNetSatis;
            data = data + model.HamitBesliH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "CUMHURİYET BEŞLİ" && x.tarih == k).FirstOrDefault();
            model.CUMBesliA = bs.AlisFiyati;
            data = data + model.CUMBesliA + ", ";
            model.CUMBesliS = bs.SatisFiyati;
            data = data + model.CUMBesliS + ", ";
            model.CUMBesliM = bs.HsNet;
            data = data + model.CUMBesliM + ", ";
            model.CUMBesliH = bs.HsNetSatis;
            data = data + model.CUMBesliH + ", ";
            bs = db.TabelaLoglari.Where(x => x.StokCinsi == "REŞAT LİRA" && x.tarih == k).FirstOrDefault();
            model.ResatLiraA = bs.AlisFiyati;
            data = data + model.ResatLiraA + ", ";
            model.ResatLiraS = bs.SatisFiyati;
            data = data + model.ResatLiraS + ", ";
            model.ResatLiraM = bs.HsNetSatis;
            data = data + model.ResatLiraM + ", ";
            model.ResatLiraH = bs.HsNet;
            data = data + model.ResatLiraH + ", ";


            //bs = db.TabelaLoglari.Where(x => x.StokCinsi == "8 AYAR" && x.tarih == k).FirstOrDefault();
            //model.SekAyarA = bs.AlisFiyati;
            //data = model.SekAyarA + ", ";
            //model.SekAyarS = bs.SatisFiyati;
            //data = data + model.SekAyarS + ", ";
            //model.SekAyarM = bs.HsNet;
            //data = data + model.SekAyarM + ", ";
            //model.SekAyarH = bs.HsNetSatis;
            //data = data + model.SekAyarH + ", ";
            //bs = db.TabelaLoglari.Where(x => x.StokCinsi == "14 AYAR" && x.tarih == k).FirstOrDefault();
            //model.OdAyarA = bs.AlisFiyati;
            //data = model.OdAyarA + ", ";
            //model.OdAyarS = bs.SatisFiyati;
            //data = data + model.OdAyarS + ", ";
            //model.OdAyarM = bs.HsNet;
            //data = data + model.OdAyarM + ", ";
            //model.OdAyarH = bs.HsNetSatis;
            //data = data + model.OdAyarH + ", ";
            //bs = db.TabelaLoglari.Where(x => x.StokCinsi == "18 AYAR" && x.tarih == k).FirstOrDefault();
            //model.OsAyarA = bs.AlisFiyati;
            //data = model.OsAyarA + ", ";
            //model.OsAyarS = bs.SatisFiyati;
            //data = data + model.OsAyarS + ", ";
            //model.OsAyarM = bs.HsNet;
            //data = data + model.OsAyarM + ", ";
            //model.OsAyarH = bs.HsNetSatis;
            //data = data + model.OsAyarH + ", ";
            //bs = db.TabelaLoglari.Where(x => x.StokCinsi == "22 AYAR" && x.tarih == k).FirstOrDefault();
            //model.YiAyarA = bs.AlisFiyati;
            //data = model.YiAyarA + ", ";
            //model.YiAyarS = bs.SatisFiyati;
            //data = data + model.YiAyarS + ", ";
            //model.YiAyarM = bs.HsNet;
            //data = data + model.YiAyarM + ", ";
            //model.YiAyarH = bs.HsNetSatis;
            //data = data + model.YiAyarH + ", ";
            //bs = db.TabelaLoglari.Where(x => x.StokCinsi == "BİLEZİK" && x.tarih == k).FirstOrDefault();
            //model.BilezikA = bs.AlisFiyati;
            //data = model.BilezikA + ", ";
            //model.BilezikS = bs.SatisFiyati;
            //data = data + model.BilezikS + ", ";
            //model.BilezikM = bs.HsNet;
            //data = data + model.BilezikM + ", ";
            //model.BilezikH = bs.HsNetSatis;
            //data = data + model.BilezikH + ", ";


            model.Saatler = new List<string>();
            foreach (DateTime i in db.TabelaLoglari.Select(x => x.tarih).Distinct().ToList())
            {
                var saat = i.ToString("HH:mm:ss");
                model.Saatler.Add(saat);
            }


            return Json(data);
        }
      
        public ActionResult UrunEkle(StokKart stok, string k, double? hesap)
        {
            KuyumcuContext db = new KuyumcuContext();
            if (hesap == null)
                hesap = 0;

           

            List<UrunCins> cinsler = new List<UrunCins>();
            TempModelUrunEkle temp = new TempModelUrunEkle();
            if (stok.StokGrubu == null || stok.StokGrubu == "")
            {
                stok.Tarih = DateTime.Now;
            }
            temp.StokKart = stok;
            temp.Toptanci = db.Toptancilar.Where(x => x.Durum == true).ToList();
            temp.SelectedItem = k;
            temp.Bakiye = hesap;
            temp.Cinsler = db.Cins.Select(x => x.Cins).Distinct().ToList();
            temp.Gruplar = db.Cins.Select(x => x.Grup).Distinct().ToList();
            temp.AltGruplar = db.Cins.Select(x => x.AltGrup).Distinct().ToList();
            temp.Milyemler = db.Cins.Select(x => x.Milyem).Distinct().ToList();
            temp.Ozellik1 = db.Ozellikler.Where(y => y.OzellikNumarasi == 1).Select(x => x.Ozellik).ToList();
            temp.Ozellik2 = db.Ozellikler.Where(y => y.OzellikNumarasi == 2).Select(x => x.Ozellik).ToList();
            temp.Ozellik3 = db.Ozellikler.Where(y => y.OzellikNumarasi == 3).Select(x => x.Ozellik).ToList();
            Session["CapturedImage"] = "";
            return View(temp);
        }

        [HttpPost]
        public ActionResult UrunEkle(TempModelUrunEkle Urun, string submit)
        {

            StokKart yeni = new StokKart();
            KuyumcuContext db = new KuyumcuContext();
            StokHareket hareket = new StokHareket();
            UrunCins cins = new UrunCins();

         

            if (submit == "ARA")
            {
                yeni = db.StokKartlari.Where(x => x.StokId == Urun.id).FirstOrDefault();
                return RedirectToAction("UrunEkle", "Kuyumcu", yeni);
            }
            else if (submit == "BARKOD BAS")
            {
                int id = db.StokKartlari.Where(x => x.StokId == Urun.id).Select(y => y.id).FirstOrDefault();
                if (Urun.StokKart.StokCinsi == "ALTIN")
                {
                    if (Urun.StokKart.StokGrubu == "22 AYAR" && Urun.StokKart.Ozellik4 != "FANTAZİ")
                    {
                        Barcode report1 = new Barcode();
                        report1.RequestParameters = false;
                        report1.Parameters["id"].Value = id;
                        report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                        report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                        report1.Parameters["ozellik3"].Value = Urun.StokKart.Ozellik3;
                        report1.Parameters["iscilik"].Value = Urun.StokKart.IscilikCm;
                        report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                        report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                        report1.Parameters["birimfiyat"].Value = Urun.StokKart.Ozellik1;
                        report1.Parameters["satisfiyati"].Value = "6" + Urun.StokKart.Milyem + "6";
                        report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";

                        report1.CreateDocument();
                    
                        using (MemoryStream ms = new MemoryStream())
                        {
                            report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                            return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                        }
                    }
                    else
                    {
                        Barcode report1 = new Barcode();

                        report1.RequestParameters = false;
                        report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                        report1.Parameters["id"].Value = id;
                        report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                        report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                        report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                        report1.Parameters["birimfiyat"].Value = "6" + Urun.StokKart.BirimFiyat + "6";
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari;
                        report1.Parameters["iscilik"].Value = Urun.StokKart.IscilikCm;
                        report1.Parameters["ozellik3"].Value = Urun.StokKart.Ozellik3;
                        report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";

                        report1.CreateDocument();

                        using (MemoryStream ms = new MemoryStream())
                        {
                            report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                            return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                        }
                    }
                }
                else if (Urun.StokKart.StokCinsi == "SAAT")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                    report1.Parameters["id"].Value = id;
                    report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                    report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                    //Saat için birim fiyat kısmına etiket fiyatı atıldı. Barkoda yeni eklenmiyor.
                    report1.Parameters["birimfiyat"].Value = "6" + Urun.StokKart.EtiketFiyat + "6";
                    report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                    report1.Parameters["ozellik3"].Value = Urun.StokKart.Ozellik3;
                    if (Urun.StokKart.Turu == "TL")
                    {
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + "TL";
                    }
                    //else
                    //    report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + " " + "$";
                    report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                    }
                }
                else if (Urun.StokKart.StokCinsi == "INCI")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                    report1.Parameters["id"].Value = id;
                    report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                    report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                    report1.Parameters["maliyet"].Value = "6" + Urun.StokKart.Maliyet + "6";
                    report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                    if (Urun.StokKart.Turu == "TL")
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + "TL";
                    else
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + "" + "$";
                    report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                    }
                }
                else if (Urun.StokKart.StokCinsi == "GUMUS" || Urun.StokKart.StokCinsi == "DIGER")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                    report1.Parameters["id"].Value = id;
                    report1.Parameters["ozellik3"].Value = Urun.StokKart.Ozellik3;
                    report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                    report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                    report1.Parameters["maliyet"].Value = "6" + Urun.StokKart.Maliyet + "6";
                    report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                    if (Urun.StokKart.Turu == "TL")
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + "TL";
                    else
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + " " + "$";
                    report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                    }
                }
                else if (Urun.StokKart.StokCinsi == "PIRLANTA")
                {
                    Pirlantabarkod report1 = new Pirlantabarkod();
                    Urun.Pirlanta = db.PirlantaOz.Where(x => x.Stokid == Urun.StokKart.StokId).FirstOrDefault();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                    report1.Parameters["id"].Value = id;
                    report1.Parameters["sertifika"].Value = Urun.StokKart.Sertifika;
                    report1.Parameters["subeno"].Value = Urun.StokKart.MagazaNo;
                    report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                    //report1.Parameters["birimfiyati"].Value = Urun.StokKart.BirimFiyat;
                    report1.Parameters["maliyet"].Value = "6" + Urun.StokKart.EtiketFiyat + "6";
                    report1.Parameters["miktar"].Value = Urun.Pirlanta.MetalGr + "gr";
                    report1.Parameters["etiketfiyati"].Value = "9" + Urun.StokKart.SatisTutari;
                    report1.Parameters["tarih"].Value = "9" + Urun.StokKart.Tarih.ToShortDateString() + "9";
                    report1.Parameters["ayrinti1"].Value = Urun.Pirlanta.Ayrinti1;
                    report1.Parameters["ayrinti2"].Value = Urun.Pirlanta.Ayrinti2;
                    report1.Parameters["carat1"].Value = Urun.Pirlanta.Carat1;
                    report1.Parameters["carat2"].Value = Urun.Pirlanta.Carat2;


                    report1.CreateDocument();
                    //report1.PrintingSystem.ShowMarginsWarning = false;
                    //report1.Print();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                    }
                }
            }
            else if (submit == "DÜZENLE")
            {
                yeni = db.StokKartlari.Where(x => x.StokId == Urun.StokKart.StokId).FirstOrDefault();
                yeni.Hesaplama = Urun.StokKart.Hesaplama;
                yeni.Sertifika = Urun.StokKart.Sertifika;
                yeni.Miktar = Urun.StokKart.Miktar;
                yeni.Milyem = Urun.StokKart.Milyem;
                yeni.IscilikCm = Urun.StokKart.IscilikCm;
                yeni.IscilikGr = Urun.StokKart.IscilikGr;
                yeni.IscilikCmG = Urun.StokKart.IscilikCmG;
                yeni.HasNet = Urun.StokKart.HasNet;
                yeni.BirimFiyat = Urun.StokKart.BirimFiyat;
                yeni.Maliyet = Urun.StokKart.Maliyet;
                yeni.Turu = Urun.StokKart.Turu;
                yeni.Kar = Urun.StokKart.Kar;
                yeni.SatisTutari = Urun.StokKart.SatisTutari;
                yeni.ToptanciAdi = Urun.StokKart.ToptanciAdi;
                yeni.Tarih = Urun.StokKart.Tarih;
                yeni.RafOmru = yeni.Tarih.AddDays(Urun.RafOmru);
                yeni.Ozellik1 = Urun.StokKart.Ozellik1;
                yeni.Ozellik2 = Urun.StokKart.Ozellik2;
                yeni.Ozellik3 = Urun.StokKart.Ozellik3;
                yeni.Ozellik4 = Urun.StokKart.Ozellik4;
                yeni.Ozellik5 = Urun.StokKart.Ozellik5;
                yeni.Ozellik6 = Urun.StokKart.Ozellik6;
                yeni.Ozellik7 = Urun.StokKart.Ozellik7;
                yeni.Ozellik8 = Urun.StokKart.Ozellik8;
                yeni.Ozellik9 = Urun.StokKart.Ozellik9;
                yeni.Ozellik10 = Urun.StokKart.Ozellik10;
                yeni.MagazaNo = Urun.StokKart.MagazaNo;
                yeni.Image = Urun.StokKart.Image;
                yeni.EtiketFiyat = Convert.ToDouble(Urun.StokKart.EtiketFiyat);

                db.Entry(yeni).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UrunEkle", "Kuyumcu");
            }

            else
            {
                

                cins = db.Cins.Where(x => x.AltGrup == Urun.StokKart.StokAltGrubu).FirstOrDefault();

                hareket.Tarih = DateTime.Now;
                hareket.StokId = Urun.StokKart.StokId;
                hareket.StokAdi = cins.Adi;
                hareket.Hesaplama = Urun.StokKart.Hesaplama;
                hareket.Miktar = Urun.StokKart.Miktar;
                hareket.IscilikCM = Urun.StokKart.IscilikCm;
                hareket.IscilikGram = Urun.StokKart.IscilikGr;
                hareket.IscilikCmG = Urun.StokKart.IscilikCmG;
                hareket.HasNet = Urun.StokKart.HasNet;
                hareket.BirimFiyati = Urun.StokKart.BirimFiyat;
                hareket.Maliyet = Urun.StokKart.Maliyet;
                hareket.SatisTutari = Urun.StokKart.SatisTutari;
                hareket.Turu = Urun.StokKart.Turu;
                hareket.HareketTuru = "GİRİŞ";
                hareket.HareketTipi = "ÜRÜN GİRİŞİ";
                hareket.Kar = Urun.StokKart.Kar;
                hareket.SubeNo = Urun.StokKart.MagazaNo;
                hareket.Onay = false;
                hareket.Ozellik4 = Urun.StokKart.Ozellik4;

                db.StokHareketleri.Add(hareket);
                db.SaveChanges();

                yeni.StokId = Urun.StokKart.StokAltGrubu + genNextId().ToString();
                yeni.StokCinsi = Urun.StokKart.StokCinsi;
                yeni.StokGrubu = Urun.StokKart.StokGrubu;
                yeni.StokAltGrubu = Urun.StokKart.StokAltGrubu;
                yeni.Hesaplama = Urun.StokKart.Hesaplama;
                yeni.Sertifika = Urun.StokKart.Sertifika;
                yeni.Miktar = Urun.StokKart.Miktar;
                yeni.Milyem = Urun.StokKart.Milyem;
                yeni.IscilikCm = Urun.StokKart.IscilikCm;
                yeni.IscilikGr = Urun.StokKart.IscilikGr;
                yeni.IscilikCmG = Urun.StokKart.IscilikCmG;
                yeni.HasNet = Urun.StokKart.HasNet;
                yeni.BirimFiyat = Urun.StokKart.BirimFiyat;
                yeni.Maliyet = Urun.StokKart.Maliyet;
                yeni.Turu = Urun.StokKart.Turu;
                yeni.Kar = Urun.StokKart.Kar;
                yeni.SatisTutari = Urun.StokKart.SatisTutari;
                yeni.ToptanciAdi = Urun.StokKart.ToptanciAdi;
                yeni.Tarih = Urun.StokKart.Tarih;
                yeni.RafOmru = yeni.Tarih.AddDays(Urun.RafOmru);
                yeni.Ozellik1 = Urun.StokKart.Ozellik1;
                yeni.Ozellik2 = Urun.StokKart.Ozellik2;
                yeni.Ozellik3 = Urun.StokKart.Ozellik3;
                yeni.Ozellik4 = Urun.StokKart.Ozellik4;
                yeni.Ozellik5 = Urun.StokKart.Ozellik5;
                yeni.Ozellik6 = Urun.StokKart.Ozellik6;
                yeni.Ozellik7 = Urun.StokKart.Ozellik7;
                yeni.Ozellik8 = Urun.StokKart.Ozellik8;
                yeni.Ozellik9 = Urun.StokKart.Ozellik9;
                yeni.Ozellik10 = Urun.StokKart.Ozellik10;
                yeni.MagazaNo = Urun.StokKart.MagazaNo;
                yeni.Image = Urun.StokKart.Image;
                yeni.EtiketFiyat = Convert.ToDouble(Urun.StokKart.EtiketFiyat);

                if (yeni.StokCinsi == "PIRLANTA")
                {
                    Urun.Pirlanta.Stokid = yeni.StokId;
                    db.PirlantaOz.Add(Urun.Pirlanta);
                }
                db.StokKartlari.Add(yeni);

                db.SaveChanges();

                DateTime dateAndTime = DateTime.Now;
                int id = db.StokKartlari.Where(x => x.StokId == Urun.id).Select(y => y.id).FirstOrDefault();

                if (Urun.StokKart.StokCinsi == "ALTIN")
                {
                    if (Urun.StokKart.StokGrubu == "22 AYAR" && Urun.StokKart.Ozellik4 != "FANTAZİ")
                    {
                        Barcode report1 = new Barcode();
                        report1.RequestParameters = false;
                        report1.Parameters["id"].Value = id;
                        report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                        report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                        report1.Parameters["ozellik3"].Value = Urun.StokKart.Ozellik3;
                        report1.Parameters["iscilik"].Value = Urun.StokKart.IscilikCm;
                        report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                        report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                        report1.Parameters["birimfiyat"].Value = Urun.StokKart.Ozellik1;
                        report1.Parameters["satisfiyati"].Value = "6" + Urun.StokKart.Milyem + "6";
                        report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";

                        report1.CreateDocument();

                       MemoryStream ms = new MemoryStream();
                        
                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });              
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);

                      
                    }

                    else
                    {

                        Barcode report1 = new Barcode();

                        report1.RequestParameters = false;
                        report1.Parameters["id"].Value = id;
                        report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                        report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                        report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                        report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                        report1.Parameters["birimfiyat"].Value = "6" + Urun.StokKart.BirimFiyat + "6";
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari;
                        report1.Parameters["iscilik"].Value = Urun.StokKart.IscilikCm;
                        report1.Parameters["ozellik3"].Value = Urun.StokKart.Ozellik3;
                        report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";
                        report1.CreateDocument();

                        MemoryStream ms = new MemoryStream();

                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);

                    }
                }
                else if (Urun.StokKart.StokCinsi == "SAAT")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["id"].Value = id;
                    report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                    report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                    report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                    //Saat için birim fiyat kısmına etiket fiyatı atıldı. Barkoda yeni eklenmiyor.
                    report1.Parameters["birimfiyat"].Value = "6" + Urun.StokKart.EtiketFiyat + "6";
                    report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                    report1.Parameters["ozellik3"].Value = Urun.StokKart.Ozellik3;
                    if (Urun.StokKart.Turu == "TL")
                    {
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + "TL";
                    }
                    //else
                    //    report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + " " + "$";
                    report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";
                    report1.CreateDocument();

                    MemoryStream ms = new MemoryStream();

                    report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                    return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);

                }
                else if (Urun.StokKart.StokCinsi == "INCI")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["id"].Value = id;
                    report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                    report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                    report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                    report1.Parameters["maliyet"].Value = "6" + Urun.StokKart.Maliyet + "6";
                    report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                    if (Urun.StokKart.Turu == "TL")
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + "TL";
                    else
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + "" + "$";
                    report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();

                    MemoryStream ms = new MemoryStream();

                    report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                    return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);

                }
                else if (Urun.StokKart.StokCinsi == "GUMUS" || Urun.StokKart.StokCinsi == "DIGER")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["id"].Value = id;
                    report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                    report1.Parameters["ozellik3"].Value = Urun.StokKart.Ozellik3;
                    report1.Parameters["SubeNo"].Value = Urun.StokKart.MagazaNo;
                    report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                    report1.Parameters["maliyet"].Value = "6" + Urun.StokKart.Maliyet + "6";
                    report1.Parameters["gram"].Value = Urun.StokKart.Miktar;
                    if (Urun.StokKart.Turu == "TL")
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + "TL";
                    else
                        report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + " " + "$";
                    report1.Parameters["tarih"].Value = "6" + Urun.StokKart.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();
                    MemoryStream ms = new MemoryStream();

                    report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                    return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);

                   
                }
                else if (Urun.StokKart.StokCinsi == "PIRLANTA")
                {
                    Pirlantabarkod report1 = new Pirlantabarkod();
                    Urun.Pirlanta = db.PirlantaOz.Where(x => x.Stokid == Urun.StokKart.StokId).FirstOrDefault();
                    report1.RequestParameters = false;
                    report1.Parameters["id"].Value = id;
                    report1.Parameters["stokid"].Value = Urun.StokKart.StokId;
                    report1.Parameters["sertifika"].Value = Urun.StokKart.Sertifika;
                    report1.Parameters["subeno"].Value = Urun.StokKart.MagazaNo;
                    report1.Parameters["toptanci"].Value = Urun.StokKart.ToptanciAdi;
                    //report1.Parameters["birimfiyati"].Value = Urun.StokKart.BirimFiyat;
                    report1.Parameters["maliyet"].Value = "6" + Urun.StokKart.EtiketFiyat + "6";
                    report1.Parameters["miktar"].Value = Urun.Pirlanta.MetalGr + "gr";
                    report1.Parameters["etiketfiyati"].Value = "9" + Urun.StokKart.SatisTutari;
                    report1.Parameters["tarih"].Value = "9" + Urun.StokKart.Tarih.ToShortDateString() + "9";
                    report1.Parameters["ayrinti1"].Value = Urun.Pirlanta.Ayrinti1;
                    report1.Parameters["ayrinti2"].Value = Urun.Pirlanta.Ayrinti2;
                    report1.Parameters["carat1"].Value = Urun.Pirlanta.Carat1;
                    report1.Parameters["carat2"].Value = Urun.Pirlanta.Carat2;

                    report1.CreateDocument();

                    MemoryStream ms = new MemoryStream();

                    report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                    return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);

                }
                return RedirectToAction("UrunEkle", "Kuyumcu");
            }
            return RedirectToAction("UrunEkle", "Kuyumcu");
        }

        private int genNextId()
        {
            KuyumcuContext db = new KuyumcuContext();


            var id = (from a in db.StokKartlari
                      select (int?)a.id).Max() ?? 0;  //a.id 

            return id + 1;

        }

        [HttpPost]
        public ActionResult UrunEkle1(string k)
        {
            TempModelUrunEkle temp = new TempModelUrunEkle();
            KuyumcuContext db = new KuyumcuContext();
            temp.Gruplar = db.Cins.Where(y => y.Cins == k).Select(x => x.Grup).Distinct().ToList();
            return Json(temp.Gruplar);
        }

        [HttpPost]
        public ActionResult UrunEkle3(string k)
        {
            TempModelUrunEkle temp = new TempModelUrunEkle();
            KuyumcuContext db = new KuyumcuContext();
            temp.AltGruplar = db.Cins.Where(y => y.Grup == k).Select(x => x.AltGrup).Distinct().ToList();
            return Json(temp.AltGruplar);
        }

        [HttpPost]
        public ActionResult UrunEkle5(string k)
        {
            TempModelUrunEkle temp = new TempModelUrunEkle();
            KuyumcuContext db = new KuyumcuContext();

            temp.Ozellik1 = db.Ozellikler.Where(y =>/* y.StokGrubu == k &&*/ y.OzellikNumarasi == 1).Select(x => x.Ozellik).Distinct().ToList();

            return Json(temp.Ozellik1);
        }
        [HttpPost]
        public ActionResult UrunEkle6(string k)
        {
            TempModelUrunEkle temp = new TempModelUrunEkle();
            KuyumcuContext db = new KuyumcuContext();

            temp.Ozellik2 = db.Ozellikler.Where(y =>/* y.StokGrubu == k && */y.OzellikNumarasi == 2).Select(x => x.Ozellik).Distinct().ToList();

            return Json(temp.Ozellik2);
        }
        [HttpPost]
        public ActionResult UrunEkle7(string k)
        {
            TempModelUrunEkle temp = new TempModelUrunEkle();
            KuyumcuContext db = new KuyumcuContext();

            temp.Ozellik3 = db.Ozellikler.Where(y => y.StokGrubu == k && y.OzellikNumarasi == 3).Select(x => x.Ozellik).Distinct().ToList();

            return Json(temp.Ozellik3);
        }

        [HttpPost]
        public ActionResult UrunEkle2(string temp)
        {
            KuyumcuContext db = new KuyumcuContext();
            Toptanci toptanci = new Toptanci();
            toptanci = db.Toptancilar.Where(x => x.ToptanciAdi == temp && x.Durum == true).FirstOrDefault();
            try
            {
                string y = toptanci.Bakiye + " " + toptanci.Turu;
                return Json(y);
            }
            catch
            {
                string y = "Seçiniz";
                return Json(y);
            }

        }

        [HttpPost]
        public ActionResult UrunEkle4(string a, string b, string c)
        {
            string isim;
            KuyumcuContext db = new KuyumcuContext();
            UrunCins yeniUrun = db.Cins.Where(x => x.Cins == a && x.Grup == b && x.AltGrup == c).FirstOrDefault();
            if (yeniUrun == null)
            {
                isim = "Yeni Ürün";
            }
            else
                isim = yeniUrun.Adi;
            isim = isim + ", " + genNextId() + ", " + yeniUrun.Milyem;
            return Json(isim);
        }


        [HttpPost]
        public ActionResult Capture()
        {
            if (Request.InputStream.Length > 0)
            {
                using (System.IO.StreamReader reader = new StreamReader(Request.InputStream))
                {
                    string hexString = Server.UrlEncode(reader.ReadToEnd());
                    string imageName = genNextId().ToString();
                    string imagePath = string.Format("~/Captures/{0}.png", imageName);
                    System.IO.File.WriteAllBytes(Server.MapPath(imagePath), ConvertHexToBytes(hexString));
                    Session["CapturedImage"] = VirtualPathUtility.ToAbsolute(imagePath);
                }
            }

            return View();
        }

        [HttpPost]
        public ContentResult GetCapture()
        {
            string url = Session["CapturedImage"].ToString();
            Session["CapturedImage"] = null;
            return Content(url);
        }

        private static byte[] ConvertHexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        public ActionResult OzellikEkle(Ozellik OzellikEkle)
        {
            KuyumcuContext db = new KuyumcuContext();


            OzellikEkle.Toptanci = db.Toptancilar.Where(x => x.ToptanciAdi == OzellikEkle.ToptanciAdi).FirstOrDefault();
            OzellikEkle.Gruplar = db.Cins.Select(x => x.Grup).Distinct().ToList();

            try
            {
                var id = (from a in db.Toptancilar
                          select a.id).Max();

                id++;

                if (OzellikEkle.Toptanci == null)
                {
                    OzellikEkle.id = id;
                }
                else
                {
                    OzellikEkle.id = OzellikEkle.Toptanci.id;
                }
                return View(OzellikEkle);
            }
            catch (Exception ex)
            {
                return View(OzellikEkle);
            }

        }
        [HttpPost]
        public ActionResult OzellikEkle(Ozellik OzellikEkle, string submit)
        {

            KuyumcuContext db = new KuyumcuContext();
            Toptanci toptanci = new Toptanci();
            UrunCins cinsler = new UrunCins();

            if (submit == "ARA")
            {
                //ModelState.Clear();
                OzellikEkle.Toptanci = db.Toptancilar.Where(x => x.ToptanciAdi == OzellikEkle.ToptanciAdi).FirstOrDefault();

                return RedirectToAction("OzellikEkle", "Kuyumcu", OzellikEkle);

            }

            if (submit == "SİL")
            {
                OzellikEkle.Toptanci = db.Toptancilar.Where(x => x.ToptanciAdi == OzellikEkle.ToptanciAdi).FirstOrDefault();
                if (OzellikEkle.Toptanci != null)
                {
                    db.Toptancilar.Remove(OzellikEkle.Toptanci);
                    db.SaveChanges();
                }
                return RedirectToAction("OzellikEkle", "Kuyumcu");
            }
            else if (submit == "GÜNCELLE")
            {

                toptanci = db.Toptancilar.Where(x => x.ToptanciAdi == OzellikEkle.ToptanciAdi).FirstOrDefault();
                toptanci.Bakiye = OzellikEkle.Toptanci.Bakiye;
                toptanci.Durum = OzellikEkle.Toptanci.Durum;
                toptanci.KayitTuru = OzellikEkle.Toptanci.KayitTuru;
                toptanci.MagazaNo = OzellikEkle.Toptanci.MagazaNo;
                toptanci.ToptanciAdi = OzellikEkle.Toptanci.ToptanciAdi;
                toptanci.ToptanciAdres = OzellikEkle.Toptanci.ToptanciAdres;
                toptanci.ToptanciTel = OzellikEkle.Toptanci.ToptanciTel;
                toptanci.ToptanciTipi = OzellikEkle.Toptanci.ToptanciTipi;
                toptanci.ToptanciYetkili = OzellikEkle.Toptanci.ToptanciYetkili;
                toptanci.Turu = OzellikEkle.Toptanci.Turu;
                toptanci.ToptanciId = OzellikEkle.Toptanci.ToptanciId;
                db.Entry(toptanci).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("OzellikEkle", "Kuyumcu");
            }
            else if (submit == "İPTAL")
            {
                return RedirectToAction("OzellikEkle", "Kuyumcu");
            }
            else
            {
                if (OzellikEkle.Toptanci != null && OzellikEkle.Toptanci.ToptanciAdi != null && OzellikEkle.Toptanci.ToptanciAdi != "")
                {
                    //Toptanci toptanci = new Toptanci();
                    toptanci.Bakiye = OzellikEkle.Toptanci.Bakiye;
                    toptanci.Durum = OzellikEkle.Toptanci.Durum;
                    toptanci.KayitTuru = OzellikEkle.Toptanci.KayitTuru;
                    toptanci.MagazaNo = OzellikEkle.Toptanci.MagazaNo;
                    toptanci.ToptanciAdi = OzellikEkle.Toptanci.ToptanciAdi;
                    toptanci.ToptanciAdres = OzellikEkle.Toptanci.ToptanciAdres;
                    toptanci.ToptanciTel = OzellikEkle.Toptanci.ToptanciTel;
                    toptanci.ToptanciTipi = OzellikEkle.Toptanci.ToptanciTipi;
                    toptanci.ToptanciYetkili = OzellikEkle.Toptanci.ToptanciYetkili;
                    toptanci.Turu = OzellikEkle.Toptanci.Turu;
                    toptanci.ToptanciId = OzellikEkle.Toptanci.ToptanciId;
                    db.Entry(toptanci).State = EntityState.Added;
                    db.SaveChanges();
                }

                if (OzellikEkle.Cins != null && OzellikEkle.Cins.Adi != null && OzellikEkle.Cins.Adi != "")
                {

                    cinsler.Adi = OzellikEkle.Cins.Adi;
                    cinsler.AltGrup = OzellikEkle.Cins.AltGrup;
                    cinsler.Cins = OzellikEkle.Cins.Cins;
                    cinsler.Grup = OzellikEkle.Cins.Grup;
                    cinsler.Milyem = OzellikEkle.Cins.Milyem;
                    cinsler.Tur = OzellikEkle.Cins.Tur;
                    db.Entry(cinsler).State = EntityState.Added;
                    db.SaveChanges();
                }

                if (OzellikEkle.UrunOzellik != null && OzellikEkle.UrunOzellik.Ozellik != null && OzellikEkle.UrunOzellik.Ozellik != "")
                {
                    db.Ozellikler.Add(OzellikEkle.UrunOzellik);
                    db.SaveChanges();
                }

                return RedirectToAction("OzellikEkle", "Kuyumcu");
            }

        }
        public ActionResult UrunDonusum()
        {
            KuyumcuContext db = new KuyumcuContext();
            UrunDonusum Donusum = new UrunDonusum();
            Session["CapturedImage"] = "";
            var query = from o in db.BarkodsuzStokKartlari
                        where o.StokCinsi.Contains("HURDA")
                        select o.StokCinsi;

            StokKart hareket = new StokKart();
            hareket.Tarih = DateTime.Now;
            Donusum.Barkodlu2 = hareket;
            Donusum.HurdaCinsler = query.ToList();
            Donusum.Cinsler = db.Cins.Select(x => x.Cins).Distinct().ToList();
            Donusum.Toptanci = db.Toptancilar.Where(x => x.Durum == true).ToList();
            Donusum.Gruplar = db.Cins.Select(x => x.Grup).Distinct().ToList();
            Donusum.Sarrafiye = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi.Contains("HURDA") == false && x.Turu.Contains("HAS") == true).Select(x => x.StokCinsi).ToList();
            Donusum.AltGruplar = db.Cins.Select(x => x.AltGrup).Distinct().ToList();
            Donusum.Ozellik1 = db.Ozellikler.Where(y => y.OzellikNumarasi == 1).Select(x => x.Ozellik).ToList();
            Donusum.Ozellik2 = db.Ozellikler.Where(y => y.OzellikNumarasi == 2).Select(x => x.Ozellik).ToList();
            Donusum.Ozellik3 = db.Ozellikler.Where(y => y.OzellikNumarasi == 3).Select(x => x.Ozellik).ToList();
            Donusum.Milyemler = db.Cins.Select(x => x.Milyem).Distinct().ToList();
            return View(Donusum);
        }
        [HttpPost]
        public ActionResult UrunDonusum(UrunDonusum Donusum, string submit)
        {
            KuyumcuContext db = new KuyumcuContext();
            StokHareket hareket = new StokHareket();
            StokHareket hareket2 = new StokHareket();
            BarkodsuzStokKart hurda = new BarkodsuzStokKart();
            StokKart yeni = new StokKart();
            int? id = (from a in db.StokHareketleri
                       select a.FisNo).Max();
            if (id == null)
                id = 1;

            DateTime dateTime = DateTime.Now;
            dateTime = new DateTime(
            dateTime.Ticks - (dateTime.Ticks % TimeSpan.TicksPerSecond),
            dateTime.Kind
           );

            if (submit == "HURDA > ÜRÜN")
            {

                hareket.Tarih = dateTime;
                hareket.StokId = Donusum.Barkodsuz.StokCinsi;
                hareket.StokAdi = Donusum.Barkodsuz.StokCinsi;
                hareket.Hesaplama = "GRAM";
                hareket.Miktar = Donusum.HUmiktar;
                hareket.HareketTuru = "ÇIKIŞ";
                hareket.HareketTipi = "HURDA-ÜRÜN ÇIKIŞ";
                hareket.Onay = false;
                hurda = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == Donusum.Barkodsuz.StokCinsi).FirstOrDefault();
                hareket.FisNo = id + 1;

                hareket2.BirimFiyati = Donusum.Barkodlu2.BirimFiyat;
                hareket2.FisNo = id + 1;
                hareket2.HareketTipi = "HURDA-ÜRÜN GİRİŞ";
                hareket2.HareketTuru = "GİRİŞ";
                hareket2.HasNet = Donusum.Barkodlu2.HasNet;
                hareket2.Hesaplama = Donusum.Barkodlu2.Hesaplama;
                hareket2.IscilikCM = Donusum.Barkodlu2.IscilikCm;
                hareket2.IscilikGram = Donusum.Barkodlu2.IscilikGr;
                hareket2.IscilikCmG = Donusum.Barkodlu2.IscilikCmG;
                hareket2.Kar = Donusum.Barkodlu2.Kar;
                hareket2.Maliyet = Donusum.Barkodlu2.Maliyet;
                hareket2.Miktar = Donusum.Barkodlu2.Miktar;
                hareket2.Onay = false;
                hareket2.SatisTutari = Donusum.Barkodlu2.SatisTutari;
                hareket2.StokId = Donusum.Barkodlu2.StokId;
                hareket2.StokAdi = Donusum.Barkodlu2.StokId;
                hareket2.SubeNo = Donusum.Barkodlu2.MagazaNo;
                hareket2.Tarih = dateTime.AddSeconds(1);

                yeni.StokId = Donusum.Barkodlu2.StokId;
                yeni.StokCinsi = Donusum.Barkodlu2.StokCinsi;
                yeni.StokGrubu = Donusum.Barkodlu2.StokGrubu;
                yeni.StokAltGrubu = Donusum.Barkodlu2.StokAltGrubu;
                yeni.Hesaplama = Donusum.Barkodlu2.Hesaplama;
                yeni.Sertifika = Donusum.Barkodlu2.Sertifika;
                yeni.Miktar = Donusum.Barkodlu2.Miktar;
                yeni.Milyem = Donusum.Barkodlu2.Milyem;
                yeni.IscilikCm = Donusum.Barkodlu2.IscilikCm;
                yeni.IscilikGr = Donusum.Barkodlu2.IscilikGr;
                yeni.IscilikCmG = Donusum.Barkodlu2.IscilikCmG;
                yeni.HasNet = Donusum.Barkodlu2.HasNet;
                yeni.BirimFiyat = Donusum.Barkodlu2.BirimFiyat;
                yeni.Maliyet = Donusum.Barkodlu2.Maliyet;
                yeni.Turu = Donusum.Barkodlu2.Turu;
                yeni.Kar = Donusum.Barkodlu2.Kar;
                yeni.SatisTutari = Donusum.Barkodlu2.SatisTutari;
                yeni.ToptanciAdi = Donusum.Barkodlu2.ToptanciAdi;
                yeni.Tarih = Donusum.Barkodlu2.Tarih;
                yeni.Ozellik1 = Donusum.Barkodlu2.Ozellik1;
                yeni.Ozellik2 = Donusum.Barkodlu2.Ozellik2;
                yeni.Ozellik3 = Donusum.Barkodlu2.Ozellik3;
                yeni.Ozellik4 = Donusum.Barkodlu2.Ozellik4;
                yeni.Ozellik5 = Donusum.Barkodlu2.Ozellik5;
                yeni.Ozellik6 = Donusum.Barkodlu2.Ozellik6;
                yeni.Ozellik7 = Donusum.Barkodlu2.Ozellik7;
                yeni.Ozellik8 = Donusum.Barkodlu2.Ozellik8;
                yeni.Ozellik9 = Donusum.Barkodlu2.Ozellik9;
                yeni.Ozellik10 = Donusum.Barkodlu2.Ozellik10;
                yeni.MagazaNo = Donusum.Barkodlu2.MagazaNo;
                yeni.Emanet = Donusum.Barkodlu2.Emanet;
                yeni.Fire = Donusum.Barkodlu2.Fire;
                yeni.Sayim = Donusum.Barkodlu2.Sayim;
                yeni.Image = Donusum.Barkodlu2.Image;

                Donusum.Barkodlu2.RafOmru = Donusum.Barkodlu2.Tarih.AddDays(Donusum.RafOmru);
                yeni.RafOmru = Donusum.Barkodlu2.RafOmru;

                //db.StokKartlari.Add(yeni);
                //db.Entry(yeni).State = EntityState.Added;
                db.Entry(hareket).State = EntityState.Added;
                db.Entry(hareket2).State = EntityState.Added;
                db.Entry(Donusum.Barkodlu2).State = EntityState.Added;
                db.Entry(hurda).State = EntityState.Modified;
                db.SaveChanges();


                if (Donusum.Barkodlu2.StokCinsi == "ALTIN")
                {
                    if (Donusum.Barkodlu2.StokGrubu == "22 AYAR" && Donusum.Barkodlu2.Ozellik4 != "FANTAZİ")
                    {

                        Barcode report1 = new Barcode();
                        report1.RequestParameters = false;
                        report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                        report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                        report1.Parameters["ozellik3"].Value = Donusum.Barkodlu2.Ozellik3;
                        report1.Parameters["iscilik"].Value = Donusum.Barkodlu2.IscilikCm;
                        report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                        report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                        report1.Parameters["birimfiyat"].Value = Donusum.Barkodlu2.Ozellik1;
                        report1.Parameters["satisfiyati"].Value = "6" + Donusum.Barkodlu2.Milyem + "6";
                        report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";

                        report1.CreateDocument();

                        MemoryStream ms = new MemoryStream();

                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                    }
                    else
                    {
                        Barcode report1 = new Barcode();

                        report1.RequestParameters = false;
                        report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                        report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                        report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                        report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                        report1.Parameters["birimfiyat"].Value = "6" + Donusum.Barkodlu2.BirimFiyat + "6";
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari;
                        report1.Parameters["iscilik"].Value = Donusum.Barkodlu2.IscilikCm;
                        report1.Parameters["ozellik3"].Value = Donusum.Barkodlu2.Ozellik3;
                        report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";
                
                        report1.CreateDocument();
                        MemoryStream ms = new MemoryStream();

                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);


                    }
                }
                else if (Donusum.Barkodlu2.StokCinsi == "SAAT")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                    report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                    report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                    //Saat için birim fiyat kısmına etiket fiyatı atıldı. Barkoda yeni eklenmiyor.
                    report1.Parameters["birimfiyat"].Value = "6" + Donusum.Barkodlu2.EtiketFiyat + "6";
                    report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                    report1.Parameters["ozellik3"].Value = Donusum.Barkodlu2.Ozellik3;
                    if (Donusum.Barkodlu2.Turu == "TL")
                    {
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari + "TL";
                    }
                    //else
                    //    report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + " " + "$";
                    report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();
                    MemoryStream ms = new MemoryStream();

                    report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                    return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);

                }
                else if (Donusum.Barkodlu2.StokCinsi == "INCI")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                    report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                    report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                    report1.Parameters["maliyet"].Value = "6" + Donusum.Barkodlu2.Maliyet + "6";
                    report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                    if (Donusum.Barkodlu2.Turu == "TL")
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari + "TL";
                    else
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari + "" + "$";
                    report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();
                    MemoryStream ms = new MemoryStream();

                    report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                    return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);

                }
                else if (Donusum.Barkodlu2.StokCinsi == "GUMUS" || Donusum.Barkodlu2.StokCinsi == "DIGER")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                    report1.Parameters["ozellik3"].Value = Donusum.Barkodlu2.Ozellik3;
                    report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                    report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                    report1.Parameters["maliyet"].Value = "6" + Donusum.Barkodlu2.Maliyet + "6";
                    report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                    if (Donusum.Barkodlu2.Turu == "TL")
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari + "TL";
                    else
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari;
                    report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();

                    MemoryStream ms = new MemoryStream();

                    report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                    return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);


                }



            }
            else if (submit == "ÜRÜN > HURDA")
            {
                StokKart Urun = db.StokKartlari.Where(x => x.id == Donusum.Barkodlu2.id).FirstOrDefault();

                hareket2.BirimFiyati = Donusum.Barkodlu2.BirimFiyat;
                hareket2.FisNo = id + 1;
                hareket2.HareketTipi = "ÜRÜN-HURDA ÇIKIŞ";
                hareket2.HareketTuru = "ÇIKIŞ";
                hareket2.HasNet = Donusum.Barkodlu2.HasNet;
                hareket2.Hesaplama = Donusum.Barkodlu2.Hesaplama;
                hareket2.IscilikCM = Donusum.Barkodlu2.IscilikCm;
                hareket2.IscilikGram = Donusum.Barkodlu2.IscilikGr;
                hareket2.Kar = Donusum.Barkodlu2.Kar;
                hareket2.Maliyet = Donusum.Barkodlu2.Maliyet;
                hareket2.Miktar = Donusum.Barkodlu2.Miktar;
                hareket2.Onay = false;
                hareket2.SatisTutari = Donusum.Barkodlu2.SatisTutari;
                hareket2.StokId = Donusum.Barkodlu2.StokId;
                hareket2.StokAdi = Donusum.Barkodlu2.StokId;
                hareket2.SubeNo = Donusum.Barkodlu2.MagazaNo;
                hareket2.Tarih = dateTime;

                hareket.Tarih = dateTime.AddSeconds(1);
                hareket.FisNo = id + 1;
                hareket.StokId = Donusum.Barkodsuz1.StokCinsi;
                hareket.StokAdi = Donusum.Barkodsuz1.StokCinsi;
                hareket.Hesaplama = "GRAM";
                hareket.Miktar = Donusum.Barkodlu1.Miktar;
                hareket.HareketTuru = "GİRİŞ";
                hareket.HareketTipi = "ÜRÜN-HURDA GİRİŞ";
                hareket.Onay = false;
                hurda = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == Donusum.Barkodsuz1.StokCinsi).FirstOrDefault();



                db.Entry(hareket2).State = EntityState.Added;
                db.Entry(hareket).State = EntityState.Added;
                db.Entry(hurda).State = EntityState.Modified;
                db.Entry(Urun).State = EntityState.Deleted;
                db.SaveChanges();

            }

            else if (submit == "SARRAFİYE > HURDA")
            {
                BarkodsuzStokKart urun = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == Donusum.Barkodsuz2.StokCinsi).FirstOrDefault();
                BarkodsuzStokKart urun1 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == Donusum.Barkodsuz3.StokCinsi).FirstOrDefault();

                hareket.StokId = urun.StokCinsi;
                hareket.StokAdi = urun.StokCinsi;
                hareket.Hesaplama = "ADET";
                hareket.Miktar = Donusum.SHcikisMiktar;
                hareket.Tarih = dateTime;
                hareket.FisNo = id + 1;
                hareket.HareketTuru = "ÇIKIŞ";
                hareket.HareketTipi = "SARRAFİYE-HURDA ÇIKIŞ";
                hareket.Onay = false;
                db.Entry(hareket).State = EntityState.Added;

                hareket2.StokId = urun1.StokCinsi;
                hareket2.StokAdi = urun1.StokCinsi;
                hareket2.Hesaplama = "GRAM";
                hareket2.Miktar = Donusum.SHgirisMiktar;
                hareket2.Tarih = dateTime.AddSeconds(1);
                hareket2.FisNo = id + 1;
                hareket2.HareketTuru = "GİRİŞ";
                hareket2.HareketTipi = "SARRAFİYE-HURDA GİRİŞ";
                hareket2.Onay = false;
                db.Entry(hareket2).State = EntityState.Added;
                db.SaveChanges();

            }
            else if (submit == "BARKOD BAS")
            {
                if (Donusum.Barkodlu2.StokCinsi == "ALTIN")
                {
                    if (Donusum.Barkodlu2.StokGrubu == "22 AYAR" && Donusum.Barkodlu2.Ozellik4 != "FANTAZİ")
                    {
                        Barcode report1 = new Barcode();
                        report1.RequestParameters = false;
                        report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                        report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                        report1.Parameters["ozellik3"].Value = Donusum.Barkodlu2.Ozellik3;
                        report1.Parameters["iscilik"].Value = Donusum.Barkodlu2.IscilikCm;
                        report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                        report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                        report1.Parameters["birimfiyat"].Value = Donusum.Barkodlu2.Ozellik1;
                        report1.Parameters["satisfiyati"].Value = "6" + Donusum.Barkodlu2.Milyem + "6";
                        report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";
                        report1.CreateDocument();

                        using (MemoryStream ms = new MemoryStream())
                        {
                            report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                            return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                        }
                    }
                    else
                    {
                        Barcode report1 = new Barcode();

                        report1.RequestParameters = false;
                        report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                        report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                        report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                        report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                        report1.Parameters["birimfiyat"].Value = "6" + Donusum.Barkodlu2.BirimFiyat + "6";
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari;
                        report1.Parameters["iscilik"].Value = Donusum.Barkodlu2.IscilikCm;
                        report1.Parameters["ozellik3"].Value = Donusum.Barkodlu2.Ozellik3;
                        report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";
                        report1.CreateDocument();

                        using (MemoryStream ms = new MemoryStream())
                        {
                            report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                            return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                        }
                    }
                }
                //else if (Donusum.Barkodlu2.StokCinsi == "PIRLANTA")
                //{
                //    Pirlantabarkod report1 = new Pirlantabarkod();
                //    report1.RequestParameters = false;
                //    report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                //    report1.Parameters["sertifika"].Value = Donusum.Barkodlu2.Sertifika;
                //    report1.Parameters["subeno"].Value = Donusum.Barkodlu2.MagazaNo;
                //    report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                //    //report1.Parameters["birimfiyati"].Value = Urun.StokKart.BirimFiyat;
                //    report1.Parameters["maliyet"].Value = "6" + Donusum.Barkodlu2.Maliyet + "6";
                //    report1.Parameters["miktar"].Value = Donusum.Barkodlu2.Miktar;
                //    report1.Parameters["EtiketFiyat"].Value = "9" + Donusum.Barkodlu2.EtiketFiyat + " " + "$";
                //    report1.Parameters["tarih"].Value = Urun.StokKart.Tarih.ToShortDateString();
                //    report1.Parameters["ayrinti1"].Value = Urun.Pirlanta.Ayrinti1;
                //    report1.Parameters["ayrinti2"].Value = Urun.Pirlanta.Ayrinti2;
                //    report1.Parameters["carat1"].Value = Urun.Pirlanta.Carat1;
                //    report1.Parameters["carat2"].Value = Urun.Pirlanta.Carat2;


                //    report1.CreateDocument();
                //    //report1.PrintingSystem.ShowMarginsWarning = false;
                //    //report1.Print();
                //    using (MemoryStream ms = new MemoryStream())
                //    {
                //        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                //        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                //    }
                //}
                else if (Donusum.Barkodlu2.StokCinsi == "SAAT")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                    report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                    report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                    //Saat için birim fiyat kısmına etiket fiyatı atıldı. Barkoda yeni eklenmiyor.
                    report1.Parameters["birimfiyat"].Value = "6" + Donusum.Barkodlu2.EtiketFiyat + "6";
                    report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                    report1.Parameters["ozellik3"].Value = Donusum.Barkodlu2.Ozellik3;
                    if (Donusum.Barkodlu2.Turu == "TL")
                    {
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari + "TL";
                    }
                    //else
                    //    report1.Parameters["satisfiyati"].Value = Urun.StokKart.SatisTutari + " " + "$";
                    report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                    }
                }
                else if (Donusum.Barkodlu2.StokCinsi == "INCI")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                    report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                    report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                    report1.Parameters["maliyet"].Value = "6" + Donusum.Barkodlu2.Maliyet + "6";
                    report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                    if (Donusum.Barkodlu2.Turu == "TL")
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari + "TL";
                    else
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari + "" + "$";
                    report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";
                    report1.CreateDocument();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                    }
                }
                else if (Donusum.Barkodlu2.StokCinsi == "GUMUS" || Donusum.Barkodlu2.StokCinsi == "DIGER")
                {
                    Barcode report1 = new Barcode();
                    report1.RequestParameters = false;
                    report1.Parameters["stokid"].Value = Donusum.Barkodlu2.StokId;
                    report1.Parameters["ozellik3"].Value = Donusum.Barkodlu2.Ozellik3;
                    report1.Parameters["SubeNo"].Value = Donusum.Barkodlu2.MagazaNo;
                    report1.Parameters["toptanci"].Value = Donusum.Barkodlu2.ToptanciAdi;
                    report1.Parameters["maliyet"].Value = "6" + Donusum.Barkodlu2.Maliyet + "6";
                    report1.Parameters["gram"].Value = Donusum.Barkodlu2.Miktar;
                    if (Donusum.Barkodlu2.Turu == "TL")
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari + "TL";
                    else
                        report1.Parameters["satisfiyati"].Value = Donusum.Barkodlu2.SatisTutari;
                    report1.Parameters["tarih"].Value = "6" + Donusum.Barkodlu2.Tarih.ToShortDateString() + "6";

                    report1.CreateDocument();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        report1.ExportToPdf(ms, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
                        return ExportDocument(ms.ToArray(), "pdf", "Report.pdf", true);
                    }
                }
            }

            return RedirectToAction("UrunDonusum", "Kuyumcu");
        }
        [HttpPost]
        public ActionResult UrunDonusum1(string Cins)
        {
            KuyumcuContext db = new KuyumcuContext();
            var hurda = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == Cins).FirstOrDefault();

            return Json(hurda.Miktar);
        }
        [HttpPost]
        public ActionResult UrunDonusum2(int id)
        {
            KuyumcuContext db = new KuyumcuContext();
            var Urun = db.StokKartlari.Where(x => x.id == id).FirstOrDefault();
            string data = Urun.StokId + ", " + Urun.StokCinsi + ", " + Urun.StokGrubu + ", " + Urun.StokAltGrubu + ", " +
                Urun.Hesaplama + ", " + Urun.Sertifika + ", " + Urun.Miktar + ", " + Urun.Milyem + ", " + Urun.IscilikCm + ", " +
                Urun.IscilikGr + ", " + Urun.HasNet + ", " + Urun.BirimFiyat + ", " + Urun.Maliyet + ", " + Urun.Turu + ", " +
                Urun.Kar + ", " + Urun.SatisTutari + ", " + Urun.ToptanciAdi + ", " + Urun.Ozellik1 + ", " + Urun.Ozellik2 + ", " +
                Urun.Ozellik3 + ", " + Urun.Ozellik4 + ", " + Urun.MagazaNo + ", " + Urun.RafOmru + ", " + Urun.Image;
            return Json(data);
        }

        public ActionResult UrunDonusum3(string Cins)
        {
            KuyumcuContext db = new KuyumcuContext();
            var sarrafiye = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == Cins).FirstOrDefault();

            return Json(sarrafiye.Miktar);
        }

        public ActionResult FaturaGiris()
        {
            KuyumcuContext db = new KuyumcuContext();
            OzelFaturaGiris faturagiris = new OzelFaturaGiris();
            StokHareket hareket = new StokHareket();

            hareket.Tarih = DateTime.Now;
            faturagiris.Hareket = hareket;
            faturagiris.Personel = db.Personel.OrderBy(y => y.AdiSoyadi).Select(x => x.AdiSoyadi).ToList();
            faturagiris.Musteri = db.Musteriler.OrderBy(y => y.AdSoyad).Select(x => x.AdSoyad).ToList();
            faturagiris.Urunler = db.BarkodsuzStokKartlari.OrderBy(y => y.StokCinsi).Select(x => x.StokCinsi).ToList();

            faturagiris.Bankalar = db.Bankalar.Where(y => y.HesapDovizTuru == "TL").Select(x => x.BankaAdi).Distinct().ToList();
            faturagiris.Taksitler = db.Komisyonlar.Select(x => x.Taksit).Distinct().ToList();


            return View(faturagiris);
        }
        [HttpPost]
        public ActionResult FaturaGiris1(string MusteriAdi)
        {
            KuyumcuContext db = new KuyumcuContext();
            Musteri musteri = new Musteri();
            musteri = db.Musteriler.Where(x => x.AdSoyad == MusteriAdi).FirstOrDefault();
            if (musteri != null)
            {
                var data = musteri.HAS + ", " + musteri.TL + ", " + musteri.EURO + ", " + musteri.USD
                + ", " + musteri.STRL + ", " + musteri.ÇEYREK + ", " + musteri.ATATEK + ", "
                + musteri.YiAyarGRAM;
                return Json(data);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult FaturaGiris2(string barkod)
        {
            KuyumcuContext db = new KuyumcuContext();
            StokKart yeni = new StokKart();
            yeni = db.StokKartlari.Where(x => x.StokId == barkod).FirstOrDefault();
            if (yeni == null)
            {
                var x = "failed";
                return Json(x);
            }
            BarkodsuzStokKart kulce = new BarkodsuzStokKart();
            kulce = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KÜLÇE ALTIN").FirstOrDefault();
            var sekayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 AYAR").FirstOrDefault();
            var odayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 AYAR").FirstOrDefault();
            var osayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 AYAR").FirstOrDefault();
            var yiayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR").FirstOrDefault();
            var bilezik = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "BİLEZİK").FirstOrDefault();
            var usd = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "AMERİKAN DOLARI").FirstOrDefault();
            if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "8 AYAR" && yeni.StokId.Contains("BLZ") == false)
            {
                if (sekayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * sekayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;

                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "14 AYAR")
            {
                if (odayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * odayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "18 AYAR" && yeni.StokId.Contains("BLZ") == false)
            {
                if (osayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * osayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "22 AYAR" && yeni.StokId.Contains("BLZ") == false)
            {
                if (yiayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * yiayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokId.Contains("BLZ") == true)
            {
                if (bilezik.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * bilezik.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                }
            }
            if (yeni.Turu == "USD")
            {
                yeni.Miktar = yeni.SatisTutari;
                yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * Convert.ToDouble(usd.SatisFiyati));

            }

            string k = yeni.StokId + ", " + yeni.StokAltGrubu + ", " + yeni.Miktar + ", " +
                yeni.BirimFiyat + ", " + yeni.SatisTutari;
            return Json(k);
        }
        [HttpPost]
        public ActionResult FaturaGiris3(string barkod)
        {
            KuyumcuContext db = new KuyumcuContext();
            BarkodsuzStokKart yeni = new BarkodsuzStokKart();
            yeni = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == barkod).FirstOrDefault();
            if (yeni == null)
            {
                var x = "failed";
                return Json(x);
            }

            string k = yeni.StokCinsi + ", " + yeni.StokCinsi + ", " + "1" + ", " +
                yeni.SatisFiyati + ", " + yeni.SatisFiyati;
            return Json(k);
        }

        [HttpPost]
        public ActionResult FaturaGiris4(string barkod)
        {
            KuyumcuContext db = new KuyumcuContext();
            BarkodsuzStokKart yeni = new BarkodsuzStokKart();
            yeni = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == barkod).FirstOrDefault();
            if (yeni == null)
            {
                var x = "failed";
                return Json(x);
            }

            string k = yeni.StokCinsi + ", " + yeni.StokCinsi + ", " + "1" + ", " +
                yeni.AlisFiyati + ", " + yeni.AlisFiyati;
            return Json(k);
        }
        [HttpPost]
        public ActionResult FaturaGiris5(string bankaadi)
        {
            KuyumcuContext db = new KuyumcuContext();
            OzelFaturaGiris Model = new OzelFaturaGiris();
            Model.Taksitler = db.Komisyonlar.Where(x => x.BankaAdi == bankaadi).Select(y => y.Taksit).ToList();
            return Json(Model.Taksitler);
        }
        [HttpPost]
        public ActionResult FaturaGiris6(string bankaadi, int taksit)
        {
            KuyumcuContext db = new KuyumcuContext();
            OzelFaturaGiris Model = new OzelFaturaGiris();
            double? komisyon = 1;
            komisyon = db.Komisyonlar.Where(x => x.BankaAdi == bankaadi && x.Taksit == taksit).Select(y => y.Komisyon).FirstOrDefault();

            return Json(komisyon);
        }
        [HttpPost]
        public ActionResult FaturaGiris7(List<OzelFaturaGiris> fatura1, List<OzelFaturaGiris> fatura2, double toplam, string Subeno, string Bankaadi, double nakit, int Taksit)
        {
            KuyumcuContext db = new KuyumcuContext();
            Fatura fatura = new Fatura();
            fatura.AlimTutari = 0;
            fatura.Fark = 0;
            fatura.KrediKarti = 0;
            fatura.Nakit = 0;
            fatura.SatisTutari = 0;

            List<StokHareket> Stokhareket = new List<StokHareket>();
            var kulce = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KÜLÇE ALTIN").FirstOrDefault();


            int? id = getid();
            StokKart yeni = new StokKart();
            personelEkle calisan = new personelEkle();
            StokKartSatilan sks = new StokKartSatilan();
            BarkodsuzStokKart brkart = new BarkodsuzStokKart();
            Kasa kasa = new Kasa();
            int m;
            if (fatura1 == null)
            {
                m = 0;
            }
            else
            {
                m = fatura1.Count;
            }

            for (int i = 0; i < m; i++)
            {

                var islemci = fatura1[i].Islemci;
                if (islemci != null)
                {
                    calisan = db.Personel.Where(x => x.AdiSoyadi == islemci).FirstOrDefault();
                }
                else
                {
                    islemci = "";
                }

                string y = fatura1[i].StokId;
                yeni = db.StokKartlari.Where(x => x.StokId == y).FirstOrDefault();
                brkart = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == y).FirstOrDefault();
                StokHareket Hareket = new StokHareket();



                if (yeni != null)
                {


                    if (fatura1[i].MusteriAdSoyad != "")
                    {
                        Hareket.MusteriAdi = fatura1[i].MusteriAdSoyad;
                        fatura.Musteri = Hareket.MusteriAdi;
                    }

                    Hareket.StokId = fatura1[i].StokId;
                    Hareket.StokAdi = fatura1[i].StokId;
                    Hareket.Tarih = fatura1[i].Tarih;
                    Hareket.Hesaplama = "Adet";
                    Hareket.Turu = "HAS";
                    Hareket.Miktar = Math.Round(Convert.ToDouble(fatura1[i].Miktar), 3);

                    Hareket.IscilikCM = yeni.IscilikCm;
                    Hareket.IscilikGram = yeni.IscilikGr;
                    Hareket.IscilikCmG = yeni.IscilikCmG;
                    Hareket.HasNet = yeni.HasNet; Hareket.BirimFiyati = yeni.BirimFiyat;
                    Hareket.Maliyet = yeni.Maliyet;


                    Hareket.SatisTutari = Math.Round(Convert.ToDouble(fatura1[i].SatisTutari), 3);
                    Hareket.FisNo = id;
                    Hareket.Islemci = fatura1[i].Islemci;
                    Hareket.Aciklama = fatura1[i].Aciklama;
                    Hareket.HareketTuru = fatura1[i].HareketTuru;
                    Hareket.HareketTipi = "FATURA GİRİŞ EKRANI";
                    Hareket.Kar = yeni.Kar;
                    Hareket.SubeNo = Subeno;
                    Hareket.Onay = false;

                    if (calisan != null)
                    {
                        Hareket.Islemci = islemci;
                        fatura.Islemci = islemci;
                    }

                    if (yeni.Ozellik4 == "FANTAZİ")
                    {
                        Hareket.Ozellik4 = yeni.Ozellik4;
                    }
                    else if (yeni.Ozellik4 == "KONSİNYE")
                    {
                        Hareket.Ozellik4 = yeni.Ozellik4;
                    }
                    else if (yeni.Ozellik4 == "BAY")
                    {
                        Hareket.Ozellik4 = yeni.Ozellik4;
                    }
                    else if (yeni.Ozellik4 == "BAYAN")
                    {
                        Hareket.Ozellik4 = yeni.Ozellik4;
                    }
                    if (fatura1[i].HareketTuru == "GİRİŞ")
                    {
                        fatura.AlimTutari = Math.Round(Convert.ToDouble(fatura.AlimTutari + fatura1[i].SatisTutari), 3);
                    }
                    else
                    {
                        fatura.SatisTutari = Math.Round(Convert.ToDouble(fatura.SatisTutari + fatura1[i].SatisTutari), 3);
                    }

                    Stokhareket.Add(Hareket);

                    Musteri musteri = new Musteri();
                    string MusteriAdi = fatura1[i].MusteriAdSoyad;
                    if (MusteriAdi != null)
                    {
                        musteri = db.Musteriler.Where(x => x.AdSoyad == MusteriAdi).FirstOrDefault();
                        var Urun = fatura1[i].StokId;
                        var Miktar = Convert.ToDouble(fatura1[i].Miktar);
                        var satisF = Convert.ToDouble(fatura1[i].SatisTutari);
                        fatura1[i].Tarih.AddSeconds(1);

                        if (fatura1[i].HareketTuru == "BORÇ" || fatura1[i].HareketTuru == "A BORÇ")
                        {
                            if (Urun == "ÇEYREK")
                            {
                                musteri.ÇEYREK = musteri.ÇEYREK - Miktar;
                            }
                            else if (Urun == "YARIM")
                            {
                                musteri.YARIM = musteri.YARIM - Miktar;
                            }
                            else if (Urun == "2.5'LU")
                            {
                                musteri.IkıBucuklU = musteri.IkıBucuklU - Miktar;
                            }
                            else if (Urun == "C.LİRA")
                            {
                                musteri.CLİRA = musteri.IkıBucuklU - Miktar;
                            }
                            else if (Urun == "22 AYAR GRAM")
                            {
                                musteri.YiAyarGRAM = musteri.YiAyarGRAM - Miktar;
                            }
                            else if (Urun == "24 AYAR GRAM")
                            {
                                musteri.YdAyarGRAM = musteri.YdAyarGRAM - Miktar;
                            }
                            else if (Urun == "HAMİT LİRA")
                            {
                                musteri.HLira = musteri.HLira - Miktar;
                            }
                            else if (Urun == "8 HURDA")
                            {
                                musteri.SHurda = musteri.SHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "14 HURDA")
                            {
                                musteri.ODHurda = musteri.ODHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "18 HURDA")
                            {
                                musteri.OSHurda = musteri.OSHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "21 HURDA")
                            {
                                musteri.YBHurda = musteri.YBHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "22 HURDA")
                            {
                                musteri.YIhurda = musteri.YIhurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "AMERİKAN DOLARI")
                            {
                                musteri.USD = musteri.USD - Miktar;
                            }
                            else if (Urun == "EURO")
                            {
                                musteri.EURO = musteri.EURO - Miktar;
                            }
                            else if (Urun == "İSVİÇRE FRANGI")
                            {
                                musteri.CHF = musteri.CHF - Miktar;
                            }
                            else if (Urun == "DANİMARKA KRONU")
                            {
                                musteri.DKK = musteri.DKK - Miktar;
                            }
                            else if (Urun == "İNGİLİZ STERLİNİ")
                            {
                                musteri.STRL = musteri.STRL - Miktar;
                            }
                            else if (Urun == "KÜLÇE ALTIN")
                            {
                                musteri.HAS = musteri.HAS - Miktar;
                            }
                            else if (Urun == "REŞAT BEŞLİ")
                            {
                                musteri.RBesli = musteri.RBesli - Miktar;
                            }
                            else if (Urun == "İSVEÇ KRONU")
                            {
                                musteri.SEK = musteri.SEK - Miktar;
                            }
                            else if (Urun == "NORVEÇ KRONU")
                            {
                                musteri.NOK = musteri.NOK - Miktar;
                            }
                            else if (Urun == "JAPON YENİ")
                            {
                                musteri.JPY = musteri.JPY - Miktar;
                            }
                            else if (Urun == "KANADA DOLARI")
                            {
                                musteri.KD = musteri.KD - Miktar;
                            }
                            else if (Urun == "AVUSTRALYA DOLARI")
                            {
                                musteri.AD = musteri.AD - Miktar;
                            }
                            else if (Urun == "RUS RUBLESİ")
                            {
                                musteri.RB = musteri.RB - Miktar;
                            }
                            else if (Urun == "RİYAL")
                            {
                                musteri.RY = musteri.RY - Miktar;
                            }
                            else if (Urun == "ATATEK")
                            {
                                musteri.ATATEK = musteri.ATATEK - Miktar;
                            }
                            else
                            {
                                musteri.TL = musteri.TL - Miktar;
                            }
                        }
                        db.Entry(musteri).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    sks.StokId = yeni.StokId;
                    sks.StokCinsi = yeni.StokCinsi;
                    sks.StokGrubu = yeni.StokGrubu;
                    sks.StokAltGrubu = yeni.StokAltGrubu;
                    sks.Hesaplama = yeni.Hesaplama;
                    sks.Sertifika = yeni.Sertifika;
                    sks.Miktar = yeni.Miktar;
                    sks.Milyem = yeni.Milyem;
                    sks.IscilikCm = yeni.IscilikCm;
                    sks.IscilikCmG = yeni.IscilikCmG;
                    sks.IscilikGr = yeni.IscilikGr;
                    sks.HasNet = yeni.HasNet;
                    sks.BirimFiyat = yeni.BirimFiyat;
                    sks.Maliyet = yeni.Maliyet;
                    sks.Fire = yeni.Fire;
                    sks.Turu = yeni.Turu;
                    sks.Kar = yeni.Kar;
                    sks.SatisTutari = yeni.SatisTutari;
                    sks.ToptanciAdi = yeni.ToptanciAdi;
                    sks.Tarih = yeni.Tarih;
                    sks.Ozellik1 = yeni.Ozellik1;
                    sks.Ozellik2 = yeni.Ozellik2;
                    sks.Ozellik3 = yeni.Ozellik3;
                    sks.RafOmru = yeni.RafOmru;
                    sks.EtiketFiyat = yeni.EtiketFiyat;

                    db.Entry(sks).State = EntityState.Added;
                    db.SaveChanges();
                    db.Entry(yeni).State = EntityState.Deleted;
                    db.SaveChanges();


                }

                else if (brkart != null)
                {
                    Musteri musteri = new Musteri();
                    string MusteriAdi = fatura1[i].MusteriAdSoyad;
                    var Urun = fatura1[i].StokId;
                    var Miktar = Convert.ToDouble(fatura1[i].Miktar);
                    var satisF = Convert.ToDouble(fatura1[i].SatisTutari);
                    //StokHareket Hareket = new StokHareket();

                    if (MusteriAdi != null)
                    {
                        musteri = db.Musteriler.Where(x => x.AdSoyad == MusteriAdi).FirstOrDefault();


                        if (fatura1[i].HareketTuru == "BORÇ" || fatura1[i].HareketTuru == "A BORÇ")
                        {
                            if (Urun == "ÇEYREK")
                            {
                                musteri.ÇEYREK = musteri.ÇEYREK - Miktar;
                            }
                            else if (Urun == "YARIM")
                            {
                                musteri.YARIM = musteri.YARIM - Miktar;
                            }
                            else if (Urun == "2.5'LU")
                            {
                                musteri.IkıBucuklU = musteri.IkıBucuklU - Miktar;
                            }
                            else if (Urun == "C.LİRA")
                            {
                                musteri.CLİRA = musteri.CLİRA - Miktar;
                            }
                            else if (Urun == "22 AYAR GRAM")
                            {
                                musteri.YiAyarGRAM = musteri.YiAyarGRAM - Miktar;
                            }
                            else if (Urun == "24 AYAR GRAM")
                            {
                                musteri.YdAyarGRAM = musteri.YdAyarGRAM - Miktar;
                            }
                            else if (Urun == "HAMİT LİRA")
                            {
                                musteri.HLira = musteri.HLira - Miktar;
                            }
                            else if (Urun == "8 HURDA")
                            {
                                musteri.SHurda = musteri.SHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "14 HURDA")
                            {
                                musteri.ODHurda = musteri.ODHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "18 HURDA")
                            {
                                musteri.OSHurda = musteri.OSHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "21 HURDA")
                            {
                                musteri.YBHurda = musteri.YBHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "22 HURDA")
                            {
                                musteri.YIhurda = musteri.YIhurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "AMERİKAN DOLARI")
                            {
                                musteri.USD = musteri.USD - Miktar;
                            }
                            else if (Urun == "EURO")
                            {
                                musteri.EURO = musteri.EURO - Miktar;
                            }
                            else if (Urun == "İSVİÇRE FRANGI")
                            {
                                musteri.CHF = musteri.CHF - Miktar;
                            }
                            else if (Urun == "DANİMARKA KRONU")
                            {
                                musteri.DKK = musteri.DKK - Miktar;
                            }
                            else if (Urun == "İNGİLİZ STERLİNİ")
                            {
                                musteri.STRL = musteri.STRL - Miktar;
                            }
                            else if (Urun == "KÜLÇE ALTIN")
                            {
                                musteri.HAS = musteri.HAS - Miktar;
                            }
                            else if (Urun == "REŞAT BEŞLİ")
                            {
                                musteri.RBesli = musteri.RBesli - Miktar;
                            }
                            else if (Urun == "İSVEÇ KRONU")
                            {
                                musteri.SEK = musteri.SEK - Miktar;
                            }
                            else if (Urun == "NORVEÇ KRONU")
                            {
                                musteri.NOK = musteri.NOK - Miktar;
                            }
                            else if (Urun == "JAPON YENİ")
                            {
                                musteri.JPY = musteri.JPY - Miktar;
                            }
                            else if (Urun == "KANADA DOLARI")
                            {
                                musteri.KD = musteri.KD - Miktar;
                            }
                            else if (Urun == "AVUSTRALYA DOLARI")
                            {
                                musteri.AD = musteri.AD - Miktar;
                            }
                            else if (Urun == "RUS RUBLESİ")
                            {
                                musteri.RB = musteri.RB - Miktar;
                            }
                            else if (Urun == "RİYAL")
                            {
                                musteri.RY = musteri.RY - Miktar;
                            }
                            else if (Urun == "ATATEK")
                            {
                                musteri.ATATEK = musteri.ATATEK - Miktar;
                            }
                            else if (Urun == "REŞAT LİRA")
                            {
                                musteri.RLira = musteri.RLira - Miktar;
                            }
                            else if (Urun == "HAMİT BEŞLİ")
                            {
                                musteri.HBesli = musteri.HBesli - Miktar;
                            }
                            else if (Urun == "CUMHURİYET BEŞLİ")
                            {
                                musteri.CBesli = musteri.CBesli - Miktar;
                            }
                            else if (Urun == "22 AYAR")
                            {
                                musteri.YiAyar = musteri.YiAyar - Miktar;
                            }
                            else
                            {
                                musteri.TL = musteri.TL - Miktar;
                            }
                        }
                        else if (fatura1[i].HareketTuru == "EMANET" || fatura1[i].HareketTuru == "A EMANET")
                        {
                            if (Urun == "ÇEYREK")
                            {
                                musteri.ÇEYREK = musteri.ÇEYREK + Miktar;
                            }
                            else if (Urun == "YARIM")
                            {
                                musteri.YARIM = musteri.YARIM + Miktar;
                            }
                            else if (Urun == "2.5'LU")
                            {
                                musteri.IkıBucuklU = musteri.IkıBucuklU + Miktar;
                            }
                            else if (Urun == "C.LİRA")
                            {
                                musteri.CLİRA = musteri.CLİRA + Miktar;
                            }
                            else if (Urun == "22 AYAR GRAM")
                            {
                                musteri.YiAyarGRAM = musteri.YiAyarGRAM + Miktar;
                            }
                            else if (Urun == "24 AYAR GRAM")
                            {
                                musteri.YdAyarGRAM = musteri.YdAyarGRAM + Miktar;
                            }
                            else if (Urun == "HAMİT LİRA")
                            {
                                musteri.HLira = musteri.HLira + Miktar;
                            }
                            else if (Urun == "8 HURDA")
                            {
                                musteri.SHurda = musteri.SHurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "14 HURDA")
                            {
                                musteri.ODHurda = musteri.ODHurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "18 HURDA")
                            {
                                musteri.OSHurda = musteri.OSHurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "21 HURDA")
                            {
                                musteri.YBHurda = musteri.YBHurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "22 HURDA")
                            {
                                musteri.YIhurda = musteri.YIhurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "AMERİKAN DOLARI")
                            {
                                musteri.USD = musteri.USD + Miktar;
                            }
                            else if (Urun == "EURO")
                            {
                                musteri.EURO = musteri.EURO + Miktar;
                            }
                            else if (Urun == "İSVİÇRE FRANGI")
                            {
                                musteri.CHF = musteri.CHF + Miktar;
                            }
                            else if (Urun == "DANİMARKA KRONU")
                            {
                                musteri.DKK = musteri.DKK + Miktar;
                            }
                            else if (Urun == "İNGİLİZ STERLİNİ")
                            {
                                musteri.STRL = musteri.STRL + Miktar;
                            }
                            else if (Urun == "KÜLÇE ALTIN")
                            {
                                musteri.HAS = musteri.HAS + Miktar;
                            }
                            else if (Urun == "TÜRK LİRASI")
                            {
                                musteri.TL = musteri.TL + Miktar;
                            }
                            else if (Urun == "REŞAT BEŞLİ")
                            {
                                musteri.RBesli = musteri.RBesli + Miktar;
                            }
                            else if (Urun == "İSVEÇ KRONU")
                            {
                                musteri.SEK = musteri.SEK + Miktar;
                            }
                            else if (Urun == "NORVEÇ KRONU")
                            {
                                musteri.NOK = musteri.NOK + Miktar;
                            }
                            else if (Urun == "JAPON YENİ")
                            {
                                musteri.JPY = musteri.JPY + Miktar;
                            }
                            else if (Urun == "KANADA DOLARI")
                            {
                                musteri.KD = musteri.KD + Miktar;
                            }
                            else if (Urun == "AVUSTRALYA DOLARI")
                            {
                                musteri.AD = musteri.AD + Miktar;
                            }
                            else if (Urun == "RUS RUBLESİ")
                            {
                                musteri.RB = musteri.RB + Miktar;
                            }
                            else if (Urun == "RİYAL")
                            {
                                musteri.RY = musteri.RY + Miktar;
                            }
                            else if (Urun == "ATATEK")
                            {
                                musteri.ATATEK = musteri.ATATEK + Miktar;
                            }
                            else if (Urun == "REŞAT LİRA")
                            {
                                musteri.RLira = musteri.RLira + Miktar;
                            }
                            else if (Urun == "HAMİT BEŞLİ")
                            {
                                musteri.HBesli = musteri.HBesli + Miktar;
                            }
                            else if (Urun == "CUMHURİYET BEŞLİ")
                            {
                                musteri.CBesli = musteri.CBesli + Miktar;
                            }
                            else if (Urun == "22 AYAR")
                            {
                                musteri.YiAyar = musteri.YiAyar + Miktar;
                            }
                        }
                        db.Entry(musteri).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    brkart = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == Urun).FirstOrDefault();

                    Hareket.MusteriAdi = fatura1[i].MusteriAdSoyad;
                    fatura.Musteri = Hareket.MusteriAdi;
                    Hareket.StokId = fatura1[i].StokId;
                    Hareket.StokAdi = fatura1[i].StokId;
                    Hareket.Tarih = fatura1[i].Tarih;
                    Hareket.Hesaplama = "Adet";
                    Hareket.Miktar = Math.Round(Convert.ToDouble(fatura1[i].Miktar), 3);
                    Hareket.IscilikCM = null;
                    Hareket.IscilikGram = null;
                    Hareket.Aciklama = fatura1[i].Aciklama;

                    Hareket.BirimFiyati = fatura1[i].BirimFiyati;
                    Hareket.Maliyet = null;
                    Hareket.SatisTutari = Math.Round(Convert.ToDouble(fatura1[i].SatisTutari), 3);
                    Hareket.FisNo = id;

                    Hareket.HareketTuru = fatura1[i].HareketTuru;
                    Hareket.HareketTipi = "FATURA GİRİŞ EKRANI";
                    Hareket.Kar = null;
                    Hareket.SubeNo = Subeno;
                    if (calisan != null)
                    {
                        Hareket.Islemci = islemci;
                        fatura.Islemci = islemci;
                    }
                    else
                    {
                        Hareket.Islemci = null;
                    }

                    fatura1[i].Tarih.AddSeconds(1);

                    if (fatura1[i].HareketTuru == "GİRİŞ")
                    {
                        fatura.AlimTutari = Math.Round(Convert.ToDouble(fatura.AlimTutari + fatura1[i].SatisTutari), 3);
                    }
                    else
                    {
                        fatura.SatisTutari = Math.Round(Convert.ToDouble(fatura.SatisTutari + fatura1[i].SatisTutari), 3);
                    }
                    Stokhareket.Add(Hareket);

                    var temp = fatura1[i].Miktar;
                    brkart.Miktar = brkart.Miktar - temp;

                    db.Entry(brkart).State = EntityState.Modified;
                    db.SaveChanges();
                }

                if (fatura1[i].StokId == "AMERİKAN DOLARI" || fatura1[i].StokId == "EURO" || fatura1[i].StokId == "İSVİÇRE FRANGI" || fatura1[i].StokId == "DANİMARKA KRONU" || fatura1[i].StokId == "İNGİLİZ STERLİNİ" || fatura1[i].StokId == "TÜRK LİRASI" || fatura1[i].StokId == "İSVEÇ KRONU" || fatura1[i].StokId == "NORVEÇ KRONU" || fatura1[i].StokId == "JAPON YENİ" || fatura1[i].StokId == "KANADA DOLARI" || fatura1[i].StokId == "AVUSTRALYA DOLARI" || fatura1[i].StokId == "RUS RUBLESİ" || fatura1[i].StokId == "RİYAL")
                {
                    Hareket.Turu = "DÖVİZ";
                    Hareket.HasNet = 0;

                    if (Hareket.StokId == "AMERİKAN DOLARI")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "USD" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "EURO")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "EURO" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "İSVİÇRE FRANGI")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "CHF" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "İNGİLİZ STERLİNİ")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "STRL" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "DANİMARKA KRONU")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "DKK" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "İSVEÇ KRONU")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "SEK" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "NORVEÇ KRONU")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "NOK" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "JAPON YENİ")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "JPY" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "KANADA DOLARI")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "KD" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "AVUSTRALYA DOLARI")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "AD" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "RİYAL")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "RİYAL" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket.StokId == "RUS RUBLESİ")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "RB" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye - Hareket.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }


                }
                if (fatura1[i].StokId == "KREDİ KARTI")
                {
                    KomisyonTanim kt = new KomisyonTanim();
                    kt.Komisyon = db.Komisyonlar.Where(x => x.Taksit == Hareket.Taksit && x.BankaAdi == Hareket.StokAdi).Select(x => x.Komisyon).FirstOrDefault();

                    Hareket.Turu = "BANKA";
                    Hareket.StokId = "KREDİ KARTI";
                    Hareket.StokAdi = Bankaadi;
                    Hareket.Taksit = Taksit;
                    Hareket.KomisyonOrani = Convert.ToDouble(kt.Komisyon);
                    fatura.KrediKarti = Math.Round(Convert.ToDouble(fatura.KrediKarti + fatura1[i].SatisTutari), 3);
                    fatura.AlimTutari = Math.Round(Convert.ToDouble(fatura.AlimTutari - fatura.KrediKarti), 3);
                    Hareket.Onay = false;
                    Hareket.SubeNo = Subeno;
                    Hareket.Tarih = DateTime.Today;
                    Hareket.SatisTutari = fatura.KrediKarti;
                    Hareket.MusteriAdi = fatura.Musteri;
                    //Hareket.FisNo = id;

                    Stokhareket.Add(Hareket);
                }
                else
                {
                    Hareket.Turu = "HAS";
                    Hareket.HasNet = Math.Round(Convert.ToDouble((fatura1[i].SatisTutari / fatura1[i].Miktar)), 3) / kulce.SatisFiyati;
                }
            }

            // Fatura1 'in bitişi ve Fatura2'nin başlangıcı
            if (fatura2 == null)
            {
                m = 0;
            }
            else
            {
                m = fatura2.Count;
            }

            for (int i = 0; i < m; i++)
            {
                StokHareket Hareket = new StokHareket();
                var islemci = fatura2[i].Islemci2;

                if (islemci != null)
                {
                    calisan = db.Personel.Where(x => x.AdiSoyadi == islemci).FirstOrDefault();
                }
                else
                {
                    islemci = "";
                }
                Musteri musteri = new Musteri();
                string y = fatura2[i].StokId2;
                yeni = db.StokKartlari.Where(x => x.StokId == y).FirstOrDefault();
                brkart = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == y).FirstOrDefault();

                string MusteriAdi = fatura2[i].MusteriAdSoyad2;

                if (MusteriAdi != null)
                {
                    musteri = db.Musteriler.Where(x => x.AdSoyad == MusteriAdi).FirstOrDefault();

                }


                if (yeni != null)
                {


                    Hareket.StokId = fatura2[i].StokId2;
                    Hareket.StokAdi = fatura2[i].StokId2;
                    Hareket.Tarih = fatura2[i].Tarih2;
                    Hareket.Hesaplama = "Adet";
                    Hareket.Turu = "HAS";
                    Hareket.Miktar = Math.Round(Convert.ToDouble(fatura2[i].Miktar2), 3);
                    Hareket.IscilikCM = yeni.IscilikCm;
                    Hareket.IscilikGram = yeni.IscilikGr;
                    Hareket.IscilikCmG = yeni.IscilikCmG;
                    Hareket.HasNet = yeni.HasNet;
                    Hareket.BirimFiyati = yeni.BirimFiyat;
                    Hareket.Maliyet = yeni.Maliyet;


                    Hareket.SatisTutari = Math.Round(Convert.ToDouble(fatura2[i].SatisTutari2), 3);
                    Hareket.FisNo = id;
                    Hareket.Islemci = fatura2[i].Islemci;
                    Hareket.Aciklama = fatura2[i].Aciklama2;

                    Hareket.HareketTuru = fatura2[i].HareketTuru2;
                    Hareket.HareketTipi = "FATURA GİRİŞ EKRANI";
                    Hareket.Kar = yeni.Kar;
                    Hareket.SubeNo = Subeno;

                    if (fatura2[i].HareketTuru2 == "GİRİŞ")
                    {
                        fatura.AlimTutari = Math.Round(Convert.ToDouble(fatura.AlimTutari + fatura2[i].SatisTutari2), 3);
                    }
                    else
                    {
                        fatura.SatisTutari = Math.Round(Convert.ToDouble(fatura.SatisTutari + fatura2[i].SatisTutari2), 3);
                    }


                    if (MusteriAdi != null)
                    {
                        Hareket.MusteriAdi = fatura2[i].MusteriAdSoyad;
                        fatura.Musteri = Hareket.MusteriAdi;
                        //string MusteriAdi = fatura2[i].MusteriAdSoyad2;
                        musteri = db.Musteriler.Where(x => x.AdSoyad == MusteriAdi).FirstOrDefault();
                    }

                    Hareket.Onay = false;
                    fatura2[i].Tarih.AddSeconds(1);
                    Stokhareket.Add(Hareket);
                    var Urun = fatura2[i].StokId2;
                    var Miktar = Convert.ToDouble(fatura2[i].Miktar2);
                    var satisF = Convert.ToDouble(fatura2[i].SatisTutari2);



                    db.Entry(musteri).State = EntityState.Modified;
                    db.SaveChanges();
                }
                StokHareket Hareket1 = new StokHareket();
                if (brkart != null)
                {
                    var Urun = fatura2[i].StokId2;
                    var Miktar = Convert.ToDouble(fatura2[i].Miktar2);
                    var satisF = Convert.ToDouble(fatura2[i].SatisTutari2);
                    brkart = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == Urun).FirstOrDefault();

                    //string MusteriAdi = fatura2[i].MusteriAdSoyad;



                    Hareket1.StokId = fatura2[i].StokId2;
                    Hareket1.StokAdi = fatura2[i].StokId2;
                    Hareket1.Tarih = fatura2[i].Tarih2;
                    Hareket1.Hesaplama = "Adet";
                    Hareket1.Miktar = Math.Round(Convert.ToDouble(fatura2[i].Miktar2), 3);
                    Hareket1.IscilikCM = null;
                    Hareket1.IscilikGram = null;
                    Hareket1.Aciklama = fatura2[i].Aciklama2;

                    if (MusteriAdi != null)
                    {
                        Hareket1.MusteriAdi = musteri.AdSoyad;
                        fatura.Musteri = Hareket1.MusteriAdi;
                        musteri = db.Musteriler.Where(x => x.AdSoyad == MusteriAdi).FirstOrDefault();


                        if (fatura2[i].HareketTuru2 == "BORÇ" || fatura2[i].HareketTuru2 == "A BORÇ")
                        {
                            if (Urun == "ÇEYREK")
                            {
                                musteri.ÇEYREK = musteri.ÇEYREK - Miktar;
                            }
                            else if (Urun == "YARIM")
                            {
                                musteri.YARIM = musteri.YARIM - Miktar;
                            }
                            else if (Urun == "2.5'LU")
                            {
                                musteri.IkıBucuklU = musteri.IkıBucuklU - Miktar;
                            }
                            else if (Urun == "C.LİRA")
                            {
                                musteri.CLİRA = musteri.CLİRA - Miktar;
                            }
                            else if (Urun == "22 AYAR GRAM")
                            {
                                musteri.YiAyarGRAM = musteri.YiAyarGRAM - Miktar;
                            }
                            else if (Urun == "24 AYAR GRAM")
                            {
                                musteri.YdAyarGRAM = musteri.YdAyarGRAM - Miktar;
                            }
                            else if (Urun == "HAMİT LİRA")
                            {
                                musteri.HLira = musteri.HLira - Miktar;
                            }
                            else if (Urun == "8 HURDA")
                            {
                                musteri.SHurda = musteri.SHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "14 HURDA")
                            {
                                musteri.ODHurda = musteri.ODHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "18 HURDA")
                            {
                                musteri.OSHurda = musteri.OSHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "21 HURDA")
                            {
                                musteri.YBHurda = musteri.YBHurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "22 HURDA")
                            {
                                musteri.YIhurda = musteri.YIhurda - Miktar;
                                musteri.TL = musteri.TL - satisF;
                            }
                            else if (Urun == "AMERİKAN DOLARI")
                            {
                                musteri.USD = musteri.USD - Miktar;
                            }
                            else if (Urun == "EURO")
                            {
                                musteri.EURO = musteri.EURO - Miktar;
                            }
                            else if (Urun == "İSVİÇRE FRANGI")
                            {
                                musteri.CHF = musteri.CHF - Miktar;
                            }
                            else if (Urun == "DANİMARKA KRONU")
                            {
                                musteri.DKK = musteri.DKK - Miktar;
                            }
                            else if (Urun == "İNGİLİZ STERLİNİ")
                            {
                                musteri.STRL = musteri.STRL - Miktar;
                            }
                            else if (Urun == "KÜLÇE ALTIN")
                            {
                                musteri.HAS = musteri.HAS - Miktar;
                            }
                            else if (Urun == "TÜRK LİRASI")
                            {
                                musteri.TL = musteri.TL - Miktar;
                            }
                            else if (Urun == "REŞAT BEŞLİ")
                            {
                                musteri.RBesli = musteri.RBesli - Miktar;
                            }
                            else if (Urun == "İSVEÇ KRONU")
                            {
                                musteri.SEK = musteri.SEK - Miktar;
                            }
                            else if (Urun == "NORVEÇ KRONU")
                            {
                                musteri.NOK = musteri.NOK - Miktar;
                            }
                            else if (Urun == "JAPON YENİ")
                            {
                                musteri.JPY = musteri.JPY - Miktar;
                            }
                            else if (Urun == "KANADA DOLARI")
                            {
                                musteri.KD = musteri.KD - Miktar;
                            }
                            else if (Urun == "AVUSTRALYA DOLARI")
                            {
                                musteri.AD = musteri.AD - Miktar;
                            }
                            else if (Urun == "RUS RUBLESİ")
                            {
                                musteri.RB = musteri.RB - Miktar;
                            }
                            else if (Urun == "RİYAL")
                            {
                                musteri.RY = musteri.RY - Miktar;
                            }
                            else if (Urun == "ATATEK")
                            {
                                musteri.ATATEK = musteri.ATATEK - Miktar;
                            }
                            else if (Urun == "REŞAT LİRA")
                            {
                                musteri.RLira = musteri.RLira - Miktar;
                            }
                            else if (Urun == "HAMİT BEŞLİ")
                            {
                                musteri.HBesli = musteri.HBesli - Miktar;
                            }
                            else if (Urun == "CUMHURİYET BEŞLİ")
                            {
                                musteri.CBesli = musteri.CBesli - Miktar;
                            }
                            else if (Urun == "22 AYAR")
                            {
                                musteri.YiAyar = musteri.YiAyar - Miktar;
                            }
                        }
                        else if (fatura2[i].HareketTuru2 == "EMANET" || fatura2[i].HareketTuru2 == "A EMANET")
                        {
                            if (Urun == "ÇEYREK")
                            {
                                musteri.ÇEYREK = musteri.ÇEYREK + Miktar;
                            }
                            else if (Urun == "YARIM")
                            {
                                musteri.YARIM = musteri.YARIM + Miktar;
                            }
                            else if (Urun == "2.5'LU")
                            {
                                musteri.IkıBucuklU = musteri.IkıBucuklU + Miktar;
                            }
                            else if (Urun == "C.LİRA")
                            {
                                musteri.CLİRA = musteri.CLİRA + Miktar;
                            }
                            else if (Urun == "22 AYAR GRAM")
                            {
                                musteri.YiAyarGRAM = musteri.YiAyarGRAM + Miktar;
                            }
                            else if (Urun == "24 AYAR GRAM")
                            {
                                musteri.YdAyarGRAM = musteri.YdAyarGRAM + Miktar;
                            }
                            else if (Urun == "HAMİT LİRA")
                            {
                                musteri.HLira = musteri.HLira + Miktar;
                            }
                            else if (Urun == "8 HURDA")
                            {
                                musteri.SHurda = musteri.SHurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "14 HURDA")
                            {
                                musteri.ODHurda = musteri.ODHurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "18 HURDA")
                            {
                                musteri.OSHurda = musteri.OSHurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "21 HURDA")
                            {
                                musteri.YBHurda = musteri.YBHurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "22 HURDA")
                            {
                                musteri.YIhurda = musteri.YIhurda + Miktar;
                                musteri.TL = musteri.TL + satisF;
                            }
                            else if (Urun == "AMERİKAN DOLARI")
                            {
                                musteri.USD = musteri.USD + Miktar;
                            }
                            else if (Urun == "EURO")
                            {
                                musteri.EURO = musteri.EURO + Miktar;
                            }
                            else if (Urun == "İSVİÇRE FRANGI")
                            {
                                musteri.CHF = musteri.CHF + Miktar;
                            }
                            else if (Urun == "DANİMARKA KRONU")
                            {
                                musteri.DKK = musteri.DKK + Miktar;
                            }
                            else if (Urun == "İNGİLİZ STERLİNİ")
                            {
                                musteri.STRL = musteri.STRL + Miktar;
                            }
                            else if (Urun == "KÜLÇE ALTIN")
                            {
                                musteri.HAS = musteri.HAS + Miktar;
                            }
                            else if (Urun == "TÜRK LİRASI")
                            {
                                musteri.TL = musteri.TL + Miktar;
                            }
                            else if (Urun == "REŞAT BEŞLİ")
                            {
                                musteri.RBesli = musteri.RBesli + Miktar;
                            }
                            else if (Urun == "İSVEÇ KRONU")
                            {
                                musteri.SEK = musteri.SEK + Miktar;
                            }
                            else if (Urun == "NORVEÇ KRONU")
                            {
                                musteri.NOK = musteri.NOK + Miktar;
                            }
                            else if (Urun == "JAPON YENİ")
                            {
                                musteri.JPY = musteri.JPY + Miktar;
                            }
                            else if (Urun == "KANADA DOLARI")
                            {
                                musteri.KD = musteri.KD + Miktar;
                            }
                            else if (Urun == "AVUSTRALYA DOLARI")
                            {
                                musteri.AD = musteri.AD + Miktar;
                            }
                            else if (Urun == "RUS RUBLESİ")
                            {
                                musteri.RB = musteri.RB + Miktar;
                            }
                            else if (Urun == "RİYAL")
                            {
                                musteri.RY = musteri.RY + Miktar;
                            }
                            else if (Urun == "ATATEK")
                            {
                                musteri.ATATEK = musteri.ATATEK + Miktar;
                            }
                            else if (Urun == "REŞAT LİRA")
                            {
                                musteri.RLira = musteri.RLira + Miktar;
                            }
                            else if (Urun == "HAMİT BEŞLİ")
                            {
                                musteri.HBesli = musteri.HBesli + Miktar;
                            }
                            else if (Urun == "CUMHURİYET BEŞLİ")
                            {
                                musteri.CBesli = musteri.CBesli + Miktar;
                            }
                            else if (Urun == "22 AYAR")
                            {
                                musteri.YiAyar = musteri.YiAyar + Miktar;
                            }
                        }
                        db.Entry(musteri).State = EntityState.Modified;
                        db.SaveChanges();
                    }


                    Hareket1.BirimFiyati = fatura2[i].BirimFiyati2;
                    Hareket1.Maliyet = null;
                    Hareket1.SatisTutari = Math.Round(Convert.ToDouble(fatura2[i].SatisTutari2), 3);
                    Hareket1.FisNo = id;

                    Hareket1.HareketTuru = fatura2[i].HareketTuru2;
                    Hareket1.HareketTipi = "FATURA GİRİŞ EKRANI";
                    Hareket1.Kar = null;
                    Hareket1.SubeNo = Subeno;


                    if (calisan != null)
                    {
                        Hareket1.Islemci = islemci;
                        fatura.Islemci = islemci;
                    }

                    Stokhareket.Add(Hareket1);
                    fatura2[i].Tarih2.AddSeconds(1);

                    if (fatura2[i].HareketTuru2 == "GİRİŞ")
                    {
                        fatura.AlimTutari = Math.Round(Convert.ToDouble(fatura.AlimTutari + fatura2[i].SatisTutari2), 3);
                    }
                    else
                    {
                        fatura.SatisTutari = Math.Round(Convert.ToDouble(fatura.SatisTutari + fatura2[i].SatisTutari2), 3);
                    }
                    var temp = fatura2[i].Miktar2;
                    brkart.Miktar += temp;
                    db.Entry(brkart).State = EntityState.Modified;
                    db.SaveChanges();
                }

                if (fatura2[i].StokId2 == "AMERİKAN DOLARI" || fatura2[i].StokId2 == "EURO" || fatura2[i].StokId2 == "İSVİÇRE FRANGI" || fatura2[i].StokId2 == "DANİMARKA KRONU" || fatura2[i].StokId2 == "İNGİLİZ STERLİNİ" || fatura2[i].StokId2 == "TÜRK LİRASI" || fatura2[i].StokId2 == "İSVEÇ KRONU" || fatura2[i].StokId2 == "NORVEÇ KRONU" || fatura2[i].StokId2 == "JAPON YENİ" || fatura2[i].StokId2 == "KANADA DOLARI" || fatura2[i].StokId2 == "AVUSTRALYA DOLARI" || fatura2[i].StokId2 == "RUS RUBLESİ" || fatura2[i].StokId2 == "RİYAL")
                {
                    Hareket1.Turu = "DÖVİZ";
                    Hareket1.HasNet = 0;

                    if (Hareket1.StokId == "AMERİKAN DOLARI")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "USD" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "EURO")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "EURO" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "İSVİÇRE FRANGI")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "CHF" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "İNGİLİZ STERLİNİ")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "STRL" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "DANİMARKA KRONU")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "DKK" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "İSVEÇ KRONU")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "SEK" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "NORVEÇ KRONU")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "NOK" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "JAPON YENİ")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "JPY" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "KANADA DOLARI")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "KD" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "AVUSTRALYA DOLARI")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "AD" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "RİYAL")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "RİYAL" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else if (Hareket1.StokId == "RUS RUBLESİ")
                    {
                        kasa = db.Kasalar.Where(x => x.DovizTuru == "RB" && x.SubeNo == "NO1").FirstOrDefault();
                        kasa.BaslangicBakiye = kasa.BaslangicBakiye + Hareket1.Miktar;
                        db.Entry(kasa).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    ////////////

                }
                else if (fatura2[i].StokId2 == "KREDİ KARTI")
                {
                    KomisyonTanim kt = new KomisyonTanim();
                    kt.Komisyon = db.Komisyonlar.Where(x => x.Taksit == Hareket1.Taksit && x.BankaAdi.Equals(Hareket1.StokAdi)).Select(x => x.Komisyon).FirstOrDefault();

                    Hareket1.Turu = "BANKA";
                    Hareket1.StokId = "KREDİ KARTI";
                    Hareket1.StokAdi = Bankaadi;
                    Hareket1.Taksit = Taksit;
                    Hareket1.KomisyonOrani = Convert.ToDouble(kt.Komisyon);
                    fatura.KrediKarti = Math.Round(Convert.ToDouble(fatura.KrediKarti + fatura2[i].SatisTutari2), 3);
                    fatura.AlimTutari = Math.Round(Convert.ToDouble(fatura.AlimTutari - fatura.KrediKarti), 3);
                    Hareket1.Onay = false;
                    Hareket1.Tarih = DateTime.Today;
                    Hareket1.SubeNo = Subeno;
                    Hareket1.SatisTutari = fatura.KrediKarti;
                    Hareket1.MusteriAdi = fatura.Musteri;

                    Stokhareket.Add(Hareket1);


                }
                else
                {
                    Hareket1.Turu = "HAS";
                    Hareket1.HasNet = Math.Round(Convert.ToDouble((fatura2[i].SatisTutari2 / fatura2[i].Miktar2)), 3) / kulce.SatisFiyati;

                }

            }

            StokHareket Hareket2 = new StokHareket();
            fatura.Nakit = Math.Round(Convert.ToDouble(nakit), 3);


            fatura.FisNo = Convert.ToInt32(id);
            fatura.Tarih = DateTime.Now;
            if (fatura.Nakit < 0)
            {
                Hareket2.MusteriAdi = fatura.Musteri;
                Hareket2.StokId = "TÜRK LİRASI";
                Hareket2.StokAdi = "TÜRK LİRASI";
                Hareket2.Tarih = DateTime.Today;
                Hareket2.Hesaplama = "Adet";
                Hareket2.HareketTuru = "ÇIKIŞ";
                Hareket2.SubeNo = "NO1";
                Hareket2.Miktar = fatura.Nakit;
                Hareket2.SatisTutari = fatura.Nakit;
                Hareket2.BirimFiyati = 1;
                Hareket2.Maliyet = null;
                //Hareket2.FisNo = id;

                db.Entry(Hareket2).State = EntityState.Added;
                db.SaveChanges();

            }
            else
            {

                Hareket2.MusteriAdi = fatura.Musteri;
                Hareket2.StokId = "TÜRK LİRASI";
                Hareket2.StokAdi = "TÜRK LİRASI";
                Hareket2.Tarih = DateTime.Now.AddSeconds(1);
                Hareket2.Hesaplama = "Adet";
                Hareket2.HareketTuru = "GİRİŞ";
                Hareket2.SubeNo = "NO1";
                Hareket2.Miktar = fatura.Nakit;
                Hareket2.SatisTutari = fatura.Nakit;
                Hareket2.BirimFiyati = 1;
                Hareket2.Maliyet = null;
                //Hareket2.FisNo = id;
                db.Entry(Hareket2).State = EntityState.Added;
                db.SaveChanges();

            }

            //fatura.Nakit = Math.Round(Convert.ToDouble(fatura.Nakit + Hareket2.SatisTutari), 3);
            fatura.Fark = Math.Round(Convert.ToDouble(Hareket2.SatisTutari - fatura.Nakit), 3);

            kasa = db.Kasalar.Where(x => x.DovizTuru == "TL" && x.SubeNo == "NO1").FirstOrDefault();
            kasa.BaslangicBakiye = kasa.BaslangicBakiye + fatura.Nakit;
            db.Entry(kasa).State = EntityState.Modified;
            db.SaveChanges();

            foreach (StokHareket i in Stokhareket)
            {
                db.StokHareketleri.Add(i);
                db.SaveChanges();
            }

            db.Faturalar.Add(fatura);
            db.SaveChanges();



            string k = "";
            return Json(k);
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            //if (prefix.Length < 5) return Json(null);

            KuyumcuContext db = new KuyumcuContext();
            var customers = (from customer in db.Musteriler
                             where customer.AdSoyad.StartsWith(prefix)
                             select new
                             {
                                 label = customer.AdSoyad,
                                 val = customer.id,
                                 telefon = customer.CepTel,
                                 email = customer.Email,
                                 adress1 = customer.Adres1,
                                 adress2 = customer.Adres2
                             }).Take(20).ToList();

            return Json(customers);
        }

        [HttpPost]
        public JsonResult AutoComplete1(string prefix)
        {
            KuyumcuContext db = new KuyumcuContext();
            var customers = (from customer in db.Toptancilar
                             where customer.ToptanciAdi.StartsWith(prefix)
                             select new
                             {
                                 label = customer.ToptanciAdi,
                                 val = customer.id
                             }).ToList();

            return Json(customers);
        }


        public JsonResult TamirList()
        {
            KuyumcuContext db = new KuyumcuContext();
            var tamirazozels = db.Tamir.ToList();
            return Json(tamirazozels, JsonRequestBehavior.AllowGet);

        }
        public ActionResult StokListesi()
        {

            return View();
        }

        [ValidateInput(false)]
        public ActionResult StokListesiPartial()
        {
            KuyumcuContext db = new KuyumcuContext();

            var model = db.StokKartlari;

            return PartialView("_StokListesiPartial", model.ToList());

        }
    }

}