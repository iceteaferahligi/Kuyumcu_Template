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
using DevExpress.XtraReports.UI;
using Kuyumcu.Models.Kuyumcu_Sorgu;

namespace Kuyumcu.Controllers
{

    public class KuyumcuSorguController : Controller
    {
        KuyumcuContext db = new KuyumcuContext();

        // GET: KuyumcuSorgu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Raporlar()
        {
            return View();
        }
        public ActionResult MusteriListesi()
        {
            return View();
        }
        public ActionResult StokListesi()
        {
            return View();
        }
        public ActionResult PirlantaListesi()
        {
            return View();
        }
        public ActionResult PirlantaSatis()
        {
            return View();
        }
        public ActionResult RafOmru()
        {
            return View();
        }
        public ActionResult SatisAyrinti()
        {
            return View();
        }
        public ActionResult MusteriEkstre()
        {
            return View();
        }
        public ActionResult BankaEkstre()
        {
            return View();
        }
        public ActionResult StokEkstre()
        {
            return View();
        }
        public ActionResult BankaRapor()
        {
            return View();
        }
        public ActionResult AlyanSiparis()
        {
            return View();
        }
        public ActionResult AlyansSatis()
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

            model.Bankalar = db.Bankalar.Select(x => x.BankaAdi).ToList();
            model.Hesaplar = db.Bankalar.Select(x => x.HesapNumarasi).ToList();
            model.Taksitler = db.Komisyonlar.Where(x => x.BankaAdi == model.StokAdi).Select(x => x.Taksit).ToList();
            model.Musteriler = db.Musteriler.Select(x => x.AdSoyad).ToList();
            model.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            return View(model);
        }
        public ActionResult GrisKontrol()
        {
            return View();
        }
        public ActionResult FaturaGirisRapor()
        {
            return View();
        }
        public ActionResult ToptanciEkstre()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AlyansGetir(string barkod)
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
                    yeni.StokCinsi = yeni.StokId;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                    yeni.StokCinsi = yeni.StokId;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "14 AYAR")
            {
                if (odayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * odayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                    yeni.StokCinsi = yeni.StokId;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                    yeni.StokCinsi = yeni.StokId;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "18 AYAR" && yeni.StokId.Contains("BLZ") == false)
            {
                if (osayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * osayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                    yeni.StokCinsi = yeni.StokId;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                    yeni.StokCinsi = yeni.StokId;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokGrubu == "22 AYAR" && yeni.StokId.Contains("BLZ") == false)
            {
                if (yiayar.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * yiayar.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                    yeni.StokCinsi = yeni.StokId;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                    yeni.StokCinsi = yeni.StokId;
                }
            }
            else if (yeni.StokCinsi == "ALTIN" && yeni.StokId.Contains("BLZ") == true)
            {
                if (bilezik.SatisFiyati != 0)
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * bilezik.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                    yeni.StokCinsi = yeni.StokId;
                }
                else
                {
                    yeni.SatisTutari = Convert.ToDouble(yeni.SatisTutari * kulce.SatisFiyati);
                    yeni.BirimFiyat = yeni.SatisTutari / yeni.Miktar;
                    yeni.StokCinsi = yeni.StokId;
                }
            }
            else if(yeni.StokCinsi == "PIRLANTA")
            {
                yeni.SatisTutari = yeni.SatisTutari * Convert.ToDouble(usd.SatisFiyati);
                yeni.StokCinsi = "PIRLANTA";
            }

            String alyansOzellikleri = "";
            alyansOzellikleri += yeni.StokId + ", ";
            alyansOzellikleri += yeni.StokCinsi + ", ";
            alyansOzellikleri += yeni.Ozellik1 + ", ";
            alyansOzellikleri += yeni.Ozellik2 + ", ";
            alyansOzellikleri += yeni.Ozellik3 + ", ";
            alyansOzellikleri += yeni.Ozellik4 + ", ";
            alyansOzellikleri += yeni.Miktar + ", ";
            if(yeni.StokCinsi=="PIRLANTA")
                alyansOzellikleri += yeni.Sertifika + ", ";
            else
                alyansOzellikleri += yeni.Milyem + ", ";
            alyansOzellikleri += yeni.IscilikCm + ", ";
            alyansOzellikleri += yeni.BirimFiyat + ", ";
            alyansOzellikleri += yeni.SatisTutari;
            return Json(alyansOzellikleri);

        }

        [HttpPost]
        public ActionResult AlyansSatis1(string bankaadi, int taksit)
        {
            KuyumcuContext db = new KuyumcuContext();
            string hesapNo = db.Bankalar.Where(x => x.BankaAdi == bankaadi && x.HesapDovizTuru == "TL" && x.SubeAdi == "NO1").Select(y => y.HesapNumarasi).FirstOrDefault();
            var komisyon = db.Komisyonlar.Where(x => x.BankaAdi == bankaadi && x.Taksit == taksit).Select(y => y.Komisyon).FirstOrDefault();
            return Json(komisyon);
        }
        [HttpPost]
        public ActionResult AlyansSatis2(string barkod)
        {
            KuyumcuContext db = new KuyumcuContext();
            StokKart yeni = new StokKart();

            yeni = db.StokKartlari.Where(x => x.StokId == barkod).FirstOrDefault();
            if (yeni.StokId != null)
            {
                db.StokKartlari.Remove(yeni);
                db.SaveChanges();
            }
            
            return RedirectToAction("AlyansSatis", "KuyumcuSorgu");
        }

        public ActionResult AlyansSiparis()
        {
            SiparisOzel model = new SiparisOzel();
            model.personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            
            return View(model);
        }
        public int? getid()
        {
            KuyumcuContext db = new KuyumcuContext();
            int? id = (from a in db.Tamir
                       select a.id).Max();
            if (id == null)
                id = 1;
            return id + 1;
        }
        [HttpPost]
        public ActionResult AlyansSiparis1(SiparisOzel model)
        {
            StokHareket hareket = new StokHareket();
            StokHareket hareket2 = new StokHareket();
            StokKart satilan = new StokKart();

            model.siparis.SatisTutari = model.siparis.Kapora + model.siparis.Kalan;

            satilan = db.StokKartlari.Where(x => x.StokId == model.siparis.UrunId).FirstOrDefault();

            hareket.StokId = satilan.StokId;
            hareket.StokAdi = satilan.StokId;
            hareket.Tarih = model.siparis.SiparisTarihi;
            hareket.Hesaplama = satilan.Hesaplama;
            hareket.Miktar = satilan.Miktar;
            hareket.IscilikCM = satilan.IscilikCm;
            hareket.IscilikCmG = satilan.IscilikCmG;
            hareket.IscilikGram = satilan.IscilikGr;
            hareket.HasNet = satilan.HasNet;
            hareket.BirimFiyati = satilan.BirimFiyat;
            hareket.SatisTutari = model.siparis.Kapora + model.siparis.Kalan;
            hareket.Maliyet = satilan.SatisTutari;
            hareket.MusteriAdi = model.siparis.MusteriAdi;
            hareket.HareketTuru = "ÇIKIŞ";
            hareket.HareketTipi = "ÜRÜN SİPARİŞ";
            hareket.SubeNo = model.siparis.SubeNo;
            hareket.Islemci = model.siparis.islemci;
            hareket.FisNo = getid();
            hareket.Turu = satilan.Turu;
            hareket.Aciklama = model.siparis.Aciklama;

            hareket2.Tarih = model.siparis.SiparisTarihi;
            hareket2.StokId = "TÜRK LİRASI";
            hareket2.StokAdi = "TÜRK LİRASI";
            hareket2.Hesaplama = "Adet";
            hareket2.Miktar = model.siparis.Kapora;
            hareket2.BirimFiyati = 1;
            hareket2.SatisTutari = model.siparis.Kapora;
            hareket2.MusteriAdi = model.siparis.MusteriAdi;
            hareket2.HareketTuru = "GİRİŞ";
            hareket2.HareketTipi = "ÜRÜN SİPARİŞ";
            hareket2.SubeNo = model.siparis.SubeNo;
            hareket2.Islemci = model.siparis.islemci;
            hareket2.FisNo = hareket.FisNo;
            hareket2.Turu = "TL";
            hareket2.Aciklama = "Sipariş Ödemesi";

            Musteri musteri = new Musteri();
            musteri = db.Musteriler.Where(x => x.AdSoyad == model.siparis.MusteriAdi).FirstOrDefault();
            musteri.TL = musteri.TL - Convert.ToDouble(model.siparis.Kalan);


            db.Entry(hareket).State = EntityState.Added;
            db.Entry(hareket2).State = EntityState.Added;
            db.SaveChanges();

            db.Entry(musteri).State = EntityState.Modified;
            db.SaveChanges();
            db.Entry(model.siparis).State = EntityState.Added;
            db.SaveChanges();
            db.Entry(satilan).State = EntityState.Deleted;
            try
            {
                db.SaveChanges();
            }
            catch { }

            return RedirectToAction("AlyansSiparis", "KuyumcuSorgu");
        }
        public ActionResult AlyansTamir()
        {
            tamirazozel tamirat = new tamirazozel();
            tamirat.personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            //tamirat.tamir = db.Tamir.ToList();
            return View(tamirat);
        }
        [HttpPost]
        public ActionResult AlyansTamir(Tamirat model,string things)
        {

            StokHareket hareket = new StokHareket();
            KuyumcuContext kuyumcuContext = new KuyumcuContext();

            hareket.Tarih = model.tarih;
            hareket.Islemci = model.islemci;
            hareket.MusteriAdi = model.MusteriAdi;
            hareket.StokId = "TÜRK LİRASI";
            hareket.StokAdi = "TÜRK LİRASI";
            hareket.Hesaplama = "ADET";
            hareket.Miktar = model.ucret;
            hareket.SatisTutari = model.ucret;
            hareket.BirimFiyati = 1;
            hareket.HareketTuru = "GİRİŞ";
            hareket.HareketTipi = "TAMİRAT";
            hareket.SubeNo = model.subeno;
            hareket.FisNo = getid();
            hareket.Turu = "TL";
            hareket.Aciklama = model.aciklama;


            if (hareket.MusteriAdi == null)
            {
                hareket.Islemci="Admin";
                ViewBag.message = "1";
                return View();

            }
            if (hareket.Islemci == null)
            {
                hareket.Islemci = "Admin";
                ViewBag.message = "2";
                return View();
            }
            try
            {
                Tamirat tamirat = new Tamirat();
                tamirat.MusteriAdi = model.MusteriAdi;
                tamirat.islemci = model.islemci;
                tamirat.mail = model.mail;
                tamirat.subeno = model.subeno;
                tamirat.tarih = model.tarih;
                tamirat.aciklama = model.aciklama;
                tamirat.adres1 = model.adres1;
                tamirat.adres2 = model.adres2;
                tamirat.agirlik = model.agirlik;
                tamirat.ayar = model.ayar;
                tamirat.TelNo = model.TelNo;
                tamirat.ucret = model.ucret;

                kuyumcuContext.Entry(hareket).State = EntityState.Added;
                kuyumcuContext.Entry(tamirat).State = EntityState.Added;
                kuyumcuContext.SaveChanges();
                
                return Json(Url.Action("PrintTamir", "KuyumcuSorgu", model));
            }
            catch(Exception exception)
            {
                int a = 5;
                Console.WriteLine(exception);
                ViewBag.message = "Kayıt Alınamadı!";
                return View();
            }

            //return Json(Url.Action("PrintTamir", "KuyumcuSorgu", new { FisNo = fisnoo, Musteri = müsteriAdi, islemci = islemci }),JsonRequestBehavior.AllowGet);
            // return RedirectToAction("AlyansTamir", "KuyumcuSorgu");

            //return RedirectToAction("PrintTamir", "KuyumcuSorgu", model.tamir); 

            
        }

        [ValidateInput(false)]
        public ActionResult AlyansTamirPartial()
        {
            KuyumcuContext db = new KuyumcuContext();

            var model = db.Tamir;

            return PartialView("_AlyansTamirPartial", model.ToList());
        }

        public ActionResult AlyansTamirPartialAddNew(Kuyumcu.Models.Kuyumcu_Sorgu.Tamirat item)
        {
            KuyumcuContext db = new KuyumcuContext();

            var model = db.Tamir;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridBankaIslemPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AlyansTamirPartialUpdate(Kuyumcu.Models.Kuyumcu_Sorgu.Tamirat item)
        {
            KuyumcuContext db = new KuyumcuContext();
            var model = db.Tamir;
            
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                       
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_AlyansTamirPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AlyansTamirPartialDelete(System.Int32 id)
        {
            KuyumcuContext db = new KuyumcuContext();
            var model = db.Tamir;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_AlyansTamirPartial", model.ToList());
        }



        [HttpGet]
        public ActionResult PrintTamir(Tamirat tamirat)
        {
            AlyansTamirRapor report = new AlyansTamirRapor();
            report.Parameters["id"].Value = getid()-1;
            report.Parameters["MusteriAdi"].Value = tamirat.MusteriAdi;
            report.Parameters["islemci"].Value = tamirat.islemci;
            report.Parameters["aciklama"].Value =tamirat.aciklama;
            report.Parameters["ucret"].Value = tamirat.ucret;
            report.Parameters["agirlik"].Value = tamirat.agirlik;
            report.Parameters["ayar"].Value = tamirat.ayar;
            report.Parameters["TelNo"].Value = tamirat.TelNo;
            //report.Parameters["Tamir.tarih"].Value = "tarih";
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
            return File(document, contentType);
        }

        public ActionResult Bugun()
        {
            var model = TempData["bugunModel"] as Bugun;

            return View(model);

        }

        
        [HttpPost]
        public ActionResult Bugun2(Bugun bugun1)
        {
            double toplama = 0;
            double toplams = 0;
            Bugun bugun = new Bugun();
            DateTime k = bugun1.Datetime;
            barkodsuzstok bzk = new barkodsuzstok();
            DateTime now = DateTime.Now;

                bugun.YiBilezikS = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (bugun.YiBilezikS == null) bugun.YiBilezikS = 0;

                bugun.YiBilezikA = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (bugun.YiBilezikA == null) bugun.YiBilezikA = 0;

                bugun.YiFantaziS = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.Ozellik4 == "FANTAZİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (bugun.YiFantaziS == null) bugun.YiFantaziS = 0;

                bugun.YiFantaziA = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.Ozellik4 == "FANTAZİ" && x.HareketTipi.Equals("ÜRÜN GİRİŞİ") == false && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (bugun.YiFantaziA == null) bugun.YiFantaziA = 0;

                bugun.OnSekAyarA = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.OnSekAyarA == null) bugun.OnSekAyarA = 0;

                bugun.OnSekAyarS = db.StokHareketleri.Where(x => x.StokId.Contains("18") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.OnSekAyarS == null) bugun.OnSekAyarS = 0;

                bugun.OnDortAyarA = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.OnDortAyarA == null) bugun.OnDortAyarA = 0;

                bugun.OnDortAyarS = db.StokHareketleri.Where(x => x.StokId.Contains("14") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.OnDortAyarS == null) bugun.OnDortAyarS = 0;

                bugun.SekAyarA = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.SekAyarA == null) bugun.SekAyarA = 0;

                bugun.SekAyarS = db.StokHareketleri.Where(x => x.StokId.Contains("8") == true && x.StokId.Contains("18") == false && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.SekAyarS == null) bugun.SekAyarS = 0;

                bugun.PirlantaA = db.StokHareketleri.Where(x => x.StokId.Contains("PRL") == true && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.PirlantaA == null) bugun.PirlantaA = 0;

                bugun.PirlantaS = db.StokHareketleri.Where(x => x.StokId.Contains("PRL") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.PirlantaS == null) bugun.PirlantaS = 0;

                bugun.InciA = db.StokHareketleri.Where(x => x.StokId.Contains("INCI") == true && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.InciA == null) bugun.InciA = 0;

                bugun.InciS = db.StokHareketleri.Where(x => x.StokId.Contains("INCI") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.InciS == null) bugun.InciS = 0;

                bugun.SaatA = db.StokHareketleri.Where(x => x.StokAdi == "SAAT" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.SaatA == null) bugun.SaatA = 0;

                bugun.SaatS = db.StokHareketleri.Where(x => x.StokAdi == "SAAT" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.SaatS == null) bugun.SaatS = 0;

                bugun.CeyrekA = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.CeyrekA == null) bugun.CeyrekA = 0;

                bugun.CeyrekS = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.CeyrekS == null) bugun.CeyrekS = 0;

                bugun.YarimA = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.YarimA == null) bugun.YarimA = 0;

                bugun.YarimS = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.YarimS == null) bugun.YarimS = 0;

                bugun.ZiynetA = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.ZiynetA == null) bugun.ZiynetA = 0;

                bugun.ZiynetS = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.ZiynetS == null) bugun.ZiynetS = 0;

                bugun.AtaA = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.AtaA == null) bugun.AtaA = 0;

                bugun.AtaS = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.AtaS == null) bugun.AtaS = 0;


                bugun.YiBilezikSF = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.YiBilezikSF == null) bugun.YiBilezikSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.YiBilezikSF);

                bugun.YiBilezikAF = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.YiBilezikAF == null) bugun.YiBilezikAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.YiBilezikAF);

                bugun.YiFantaziSF = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.Ozellik4 == "FANTAZİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.YiFantaziSF == null) bugun.YiFantaziSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.YiFantaziSF);

                bugun.YiFantaziAF = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.Ozellik4 == "FANTAZİ" && x.HareketTipi.Equals("ÜRÜN GİRİŞİ") == false && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.YiFantaziAF == null) bugun.YiFantaziAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.YiFantaziAF);

                bugun.OnSekAyarAF = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.OnSekAyarAF == null) bugun.OnSekAyarAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.OnSekAyarAF);

                bugun.OnSekAyarSF = db.StokHareketleri.Where(x => x.StokId.Contains("18") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.OnSekAyarSF == null) bugun.OnSekAyarSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.OnSekAyarSF);

                bugun.OnDortAyarAF = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.OnDortAyarAF == null) bugun.OnDortAyarAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.OnDortAyarAF);

                bugun.OnDortAyarSF = db.StokHareketleri.Where(x => x.StokId.Contains("14") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.OnDortAyarSF == null) bugun.OnDortAyarSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.OnDortAyarSF);

                bugun.SekAyarAF = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.SekAyarAF == null) bugun.SekAyarAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.SekAyarAF);

                bugun.SekAyarSF = db.StokHareketleri.Where(x => x.StokId.Contains("8") == true && x.StokId.Contains("18") == false && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.SekAyarSF == null) bugun.SekAyarSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.SekAyarSF);

                bugun.PirlantaAF = db.StokHareketleri.Where(x => x.StokId.Contains("PRL") == true && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.PirlantaAF == null) bugun.PirlantaAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.PirlantaAF);

                bugun.PirlantaSF = db.StokHareketleri.Where(x => x.StokId.Contains("PRL") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.PirlantaSF == null) bugun.PirlantaSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.PirlantaSF);

                bugun.InciAF = db.StokHareketleri.Where(x => x.StokId.Contains("INCI") == true && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.InciAF == null) bugun.InciAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.InciAF);

                bugun.InciSF = db.StokHareketleri.Where(x => x.StokId.Contains("INCI") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.InciSF == null) bugun.InciSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.InciSF);

                bugun.SaatAF = db.StokHareketleri.Where(x => x.StokAdi == "SAAT" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.SaatAF == null) bugun.SaatAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.SaatAF);

                bugun.SaatSF = db.StokHareketleri.Where(x => x.StokAdi == "SAAT" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.SaatSF == null) bugun.SaatSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.SaatSF);

                bugun.CeyrekAF = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.CeyrekAF == null) bugun.CeyrekAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.CeyrekAF);

                bugun.CeyrekSF = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.CeyrekSF == null) bugun.CeyrekSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.CeyrekSF);

                bugun.YarimAF = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.YarimAF == null) bugun.YarimAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.YarimAF);

                bugun.YarimSF = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.YarimSF == null) bugun.YarimSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.YarimSF);

                bugun.ZiynetAF = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.ZiynetAF == null) bugun.ZiynetAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.ZiynetAF);

                bugun.ZiynetSF = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.ZiynetSF == null) bugun.ZiynetSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.ZiynetSF);

                bugun.AtaAF = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.AtaAF == null) bugun.AtaAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.AtaAF);

                bugun.AtaSF = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.SatisTutari);
                if (bugun.AtaSF == null) bugun.AtaSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.AtaSF);


                bugun.HasnetTA = db.StokHareketleri.Where(x => x.HasNet != null && x.HasNet != 0 && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.HasNet);
                if (bugun.HasnetTA == null) bugun.HasnetTA = 0;
                bugun.HasnetTS = db.StokHareketleri.Where(x => x.HasNet != null && x.HasNet != 0 && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == DateTime.Now.Day && x.Tarih.Month == DateTime.Now.Month && x.Tarih.Year == DateTime.Now.Year).Sum(y => y.Miktar);
                if (bugun.HasnetTS == null) bugun.HasnetTS = 0;

                bugun.HasnetTAF = toplama;
                bugun.HasnetTSF = toplams;

                bugun.HasnetTA = Math.Round(Convert.ToDouble(bugun.HasnetTA), 2);
                bugun.HasnetTS = Math.Round(Convert.ToDouble(bugun.HasnetTS), 2);
                bugun.HasnetTAF = Math.Round(Convert.ToDouble(bugun.HasnetTAF), 2);
                bugun.HasnetTSF = Math.Round(Convert.ToDouble(bugun.HasnetTSF), 2);

                double? temp8 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 AYAR").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "8 AYAR").Sum(y => y.Miktar);
               
                bugun.SekToplam = temp + temp8;
                }
                catch { bugun.SekToplam = temp8; }


                double? temp14 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 AYAR").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "14 AYAR").Sum(y => y.Miktar);
                
                bugun.OnDortToplam = temp + temp14;
                }
                catch
                { bugun.OnDortToplam = temp14; }


                double? temp18 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 AYAR").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "18 AYAR").Sum(y => y.Miktar);
                
                bugun.OnSekToplam = temp + temp18;
                }
                catch
                { bugun.OnSekToplam = temp18; }


                double? temp22 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "22 AYAR").Sum(y => y.Miktar);
               
                bugun.YiToplam = temp + temp22;
                }
                catch
                { bugun.YiToplam = temp22; }

                double? temp21 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "21 AYAR").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "21 AYAR").Sum(y => y.Miktar);
                
                bugun.YiBToplam = temp + temp21;
                }
                catch
                { bugun.YiBToplam = temp21; }

                double? tempinci = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İNCİ").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "INCI").Sum(y => y.Miktar);
                
                bugun.InciToplam = temp + tempinci;
                }

                catch
                { bugun.InciToplam = tempinci; }

                double? temppir = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "PIRLANTA").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "PIRLANTA").Sum(y => y.Miktar);
                
                bugun.PirToplam = temp + temppir;
                }
                catch
                { bugun.PirToplam = temppir; }


                double? tempsaat = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "SAAT").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "SAAT").Sum(y => y.Miktar);
               
                bugun.SaatToplam = temp + tempsaat;
                }
                catch
                { bugun.SaatToplam = tempsaat; }


                bugun.SekToplam = Math.Round(Convert.ToDouble(bugun.SekToplam), 2);
                bugun.OnDortToplam = Math.Round(Convert.ToDouble(bugun.OnDortToplam), 2);
                bugun.OnSekToplam = Math.Round(Convert.ToDouble(bugun.OnSekToplam), 2);
                bugun.YiToplam = Math.Round(Convert.ToDouble(bugun.YiToplam), 2);
                bugun.InciToplam = Math.Round(Convert.ToDouble(bugun.InciToplam), 2);
                bugun.PirToplam = Math.Round(Convert.ToDouble(bugun.PirToplam), 2);
                bugun.SaatToplam = Math.Round(Convert.ToDouble(bugun.SaatToplam), 2);
                bugun.YiBToplam = Math.Round(Convert.ToDouble(bugun.YiBToplam), 2);

            /////////////////////////Tarih //////////////////////////////////////
            ///

                bzk.Tarih = DateTime.Now;

                bugun.SekHMevcut = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 HURDA").Sum(y => y.Miktar);
                bugun.ODHMevcut = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 HURDA").Sum(y => y.Miktar);
                bugun.ONSekHMevcut = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 HURDA").Sum(y => y.Miktar);
                bugun.YBkHMevcut = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "21 HURDA").Sum(y => y.Miktar);
                bugun.YikHMevcut = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 HURDA").Sum(y => y.Miktar);

                bzk.SekHMevcut = bugun.SekHMevcut;
                bzk.ODHMevcut = bugun.ODHMevcut;
                bzk.ONSekHMevcut = bugun.ONSekHMevcut;
                bzk.YBkHMevcut = bugun.YBkHMevcut;
                bzk.YikHMevcut = bugun.YikHMevcut;

                double? temp1 = 0, temp2 = 0;
                temp1 = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.SekHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.SekHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.SekHGirisB = temp1 + temp2; }
                else { bugun.SekHGirisB = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.SekHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.SekHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.SekHCikisB = temp1 + temp2; }
                else { bugun.SekHCikisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.ODHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.ODHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.ODHGirisB = temp1 + temp2; }
                else { bugun.ODHGirisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.ODHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.ODHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.ODHCikisB = temp1 + temp2; }
                else { bugun.ODHCikisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.ONSekHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.ONSekHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.ONSekHGirisB = temp1 + temp2; }
                else { bugun.ONSekHGirisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.ONSekHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.ONSekHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.ONSekHCikisB = temp1 + temp2; }
                else { bugun.ONSekHCikisB = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "21 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "21 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.YBkHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.YBkHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.YBkHGirisB = temp1 + temp2; }
                else { bugun.YBkHGirisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "21 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "21 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.YBkHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.YBkHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.YBkHCikisB = temp1 + temp2; }
                else { bugun.YBkHCikisB = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.YikHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.YikHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.YikHGirisB = temp1 + temp2; }
                else { bugun.YikHGirisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.YikHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.YikHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.YikHCikisB = temp1 + temp2; }
                else { bugun.YikHCikisB = temp1 + temp2; }



                bugun.SekHDevir = bugun.SekHMevcut - bugun.SekHGirisB + bugun.SekHCikisB;
                bugun.ODHDevir = bugun.ODHMevcut - bugun.ODHGirisB + bugun.ODHCikisB;
                bugun.ONSekHDevir = bugun.ONSekHMevcut - bugun.ONSekHGirisB + bugun.ONSekHCikisB;
                bugun.YBkHDevir = bugun.YBkHMevcut - bugun.YBkHGirisB + bugun.YBkHCikisB;
                bugun.YikHDevir = bugun.YikHMevcut - bugun.YikHGirisB + bugun.YikHCikisB;

                bzk.SekHDevir = bugun.SekHDevir;
                bzk.ODHDevir = bugun.ODHDevir;
                bzk.ONSekHDevir = bugun.ONSekHDevir;
                bzk.YBkHDevir = bugun.YBkHDevir;
                bzk.YikHDevir = bugun.YikHDevir;


                bugun.MCeyrek = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "ÇEYREK").Sum(y => y.Miktar);
                bugun.MYarim = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "YARIM").Sum(y => y.Miktar);
                bugun.MAtatek = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "ATATEK").Sum(y => y.Miktar);
                bugun.MIkibuc = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "2.5'LU").Sum(y => y.Miktar);
                bugun.MClira = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "C.LİRA").Sum(y => y.Miktar);
                bugun.MYigram = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR GRAM").Sum(y => y.Miktar);
                bugun.MYdgram = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "24 AYAR GRAM").Sum(y => y.Miktar);
                bugun.MHlira = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "HAMİT LİRA").Sum(y => y.Miktar);
                bugun.MKulce = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KÜLÇE ALTIN").Sum(y => y.Miktar);
                bugun.MRbesli = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "REŞAT BEŞLİ").Sum(y => y.Miktar);
                bugun.MHbesli = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "HAMİT BEŞLİ").Sum(y => y.Miktar);
                bugun.MCbesli = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "CUMHURİYET BEŞLİ").Sum(y => y.Miktar);
                bugun.MRlira = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "REŞAT LİRA").Sum(y => y.Miktar);

                bzk.MCeyrek = bugun.MCeyrek;
                bzk.MYarim = bugun.MYarim;
                bzk.MAtatek = bugun.MAtatek;
                bzk.MIkibuc = bugun.MIkibuc;
                bzk.MClira = bugun.MClira;
                bzk.MYigram = bugun.MYigram;
                bzk.MYdgram = bugun.MYdgram;
                bzk.MHlira = bugun.MHlira;
                bzk.MKulce = bugun.MKulce;
                bzk.MRbesli = bugun.MRbesli;
                bzk.MHbesli = bugun.MHbesli;
                bzk.MCbesli = bugun.MCbesli;
                bzk.MRlira = bugun.MRlira;


                temp1 = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.HareketTuru == "A EMANET" && x.StokId == "ÇEYREK" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GCeyrek = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GCeyrek = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GCeyrek = temp1 + temp2; }
                else { bugun.GCeyrek = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.HareketTuru == "BORÇ" && x.StokId == "ÇEYREK" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CCeyrek = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CCeyrek = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CCeyrek = temp1 + temp2; }
                else { bugun.CCeyrek = temp1 + temp2; }


                temp1 = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GYarim = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GYarim = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GYarim = temp1 + temp2; }
                else { bugun.GYarim = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CYarim = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CYarim = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CYarim = temp1 + temp2; }
                else { bugun.CYarim = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GAtatek = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GAtatek = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GAtatek = temp1 + temp2; }
                else { bugun.GAtatek = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CAtatek = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CAtatek = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CAtatek = temp1 + temp2; }
                else { bugun.CAtatek = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "2.5'LU" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "2.5'LU" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GIkibuc = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GIkibuc = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GIkibuc = temp1 + temp2; }
                else { bugun.GIkibuc = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "2.5'LU" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "2.5'LU" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CIkibuc = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CIkibuc = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CIkibuc = temp1 + temp2; }
                else { bugun.CIkibuc = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GClira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GClira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GClira = temp1 + temp2; }
                else { bugun.GClira = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CClira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CClira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CClira = temp1 + temp2; }
                else { bugun.CClira = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "22 AYAR GRAM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "22 AYAR GRAM" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GYigram = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GYigram = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GYigram = temp1 + temp2; }
                else { bugun.GYigram = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "22 AYAR GRAM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "22 AYAR GRAM" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CYigram = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CYigram = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CYigram = temp1 + temp2; }
                else { bugun.CYigram = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "24 AYAR GRAM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "24 AYAR GRAM" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GYdgram = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GYdgram = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GYdgram = temp1 + temp2; }
                else { bugun.GYdgram = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "24 AYAR GRAM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "24 AYAR GRAM" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CYdgram = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CYdgram = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CYdgram = temp1 + temp2; }
                else { bugun.CYdgram = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "HAMİT LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "HAMİT LİRA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GHlira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GHlira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GHlira = temp1 + temp2; }
                else { bugun.GHlira = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "HAMİT LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "HAMİT LİRA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CHlira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CHlira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CHlira = temp1 + temp2; }
                else { bugun.CHlira = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "KÜLÇE ALTIN" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "KÜLÇE ALTIN" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GKulce = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GKulce = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GKulce = temp1 + temp2; }
                else { bugun.GKulce = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "KÜLÇE ALTIN" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "KÜLÇE ALTIN" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CKulce = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CKulce = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CKulce = temp1 + temp2; }
                else { bugun.CKulce = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "REŞAT BEŞLİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "REŞAT BEŞLİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GRbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GRbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GRbesli = temp1 + temp2; }
                else { bugun.GRbesli = temp1 + temp2; }





                temp1 = db.StokHareketleri.Where(x => x.StokId == "REŞAT BEŞLİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "REŞAT BEŞLİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CRbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CRbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CRbesli = temp1 + temp2; }
                else { bugun.CRbesli = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "HAMİT BEŞLİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "HAMİT BEŞLİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GHbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GHbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GHbesli = temp1 + temp2; }
                else { bugun.GHbesli = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "HAMİT BEŞLİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "HAMİT BEŞLİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CHbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CHbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CHbesli = temp1 + temp2; }
                else { bugun.CHbesli = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "CUMHURİYET BEŞLİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "CUMHURİYET BEŞLİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GCbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GCbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GCbesli = temp1 + temp2; }
                else { bugun.GCbesli = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "CUMHURİYET BEŞLİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "CUMHURİYET BEŞLİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CCbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CCbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CCbesli = temp1 + temp2; }
                else { bugun.CCbesli = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "REŞAT LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "REŞAT LİRA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GRlira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GRlira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GRlira = temp1 + temp2; }
                else { bugun.GRlira = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "REŞAT LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "REŞAT LİRA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CRlira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CRlira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CRlira = temp1 + temp2; }
                else { bugun.CRlira = temp1 + temp2; }



                bugun.DCeyrek = bugun.MCeyrek - bugun.GCeyrek + bugun.CCeyrek;
                bugun.DYarim = bugun.MYarim - bugun.GYarim + bugun.CYarim;
                bugun.DAtatek = bugun.MAtatek - bugun.GAtatek + bugun.CAtatek;
                bugun.DIkibuc = bugun.MIkibuc - bugun.GIkibuc + bugun.CIkibuc;
                bugun.DClira = bugun.MClira - bugun.GClira + bugun.CClira;
                bugun.DYigram = bugun.MYigram - bugun.GYigram + bugun.CYigram;
                bugun.DYdgram = bugun.MYdgram - bugun.GYdgram + bugun.CYdgram;
                bugun.DHlira = bugun.MHlira - bugun.GHlira + bugun.CHlira;
                bugun.DKulce = bugun.MKulce - bugun.GKulce + bugun.CKulce;
                bugun.DRbesli = bugun.MRbesli - bugun.GRbesli + bugun.CRbesli;
                bugun.DHbesli = bugun.MHbesli - bugun.GHbesli + bugun.CHbesli;
                bugun.DCbesli = bugun.MCbesli - bugun.GCbesli + bugun.CCbesli;
                bugun.DRlira = bugun.MRlira - bugun.GRlira + bugun.CClira;

                bzk.DCeyrek = bugun.DCeyrek;
                bzk.DYarim = bugun.DYarim;
                bzk.DAtatek = bugun.DAtatek;
                bzk.DIkibuc = bugun.DIkibuc;
                bzk.DClira = bugun.DClira;
                bzk.DYigram = bugun.DYigram;
                bzk.DYdgram = bugun.DYdgram;
                bzk.DHlira = bugun.DHlira;
                bzk.DKulce = bugun.DKulce;
                bzk.DRbesli = bugun.DRbesli;
                bzk.DHbesli = bugun.DHbesli;
                bzk.DCbesli = bugun.DCbesli;
                bzk.DRlira = bugun.DRlira;



                bugun.MTL = db.Kasalar.Where(x => x.DovizTuru == "TL").Sum(y => y.BaslangicBakiye);
                if (bugun.MTL == null) { bugun.MTL = 0; }
                bugun.MUSD = db.Kasalar.Where(x => x.DovizTuru == "USD").Sum(y => y.BaslangicBakiye);
                if (bugun.MUSD == null) { bugun.MUSD = 0; }
                bugun.MEURO = db.Kasalar.Where(x => x.DovizTuru == "EURO").Sum(y => y.BaslangicBakiye);
                if (bugun.MEURO == null) { bugun.MEURO = 0; }
                bugun.MSTRL = db.Kasalar.Where(x => x.DovizTuru == "STRL").Sum(y => y.BaslangicBakiye);
                if (bugun.MSTRL == null) { bugun.MSTRL = 0; }
                bugun.MCHF = db.Kasalar.Where(x => x.DovizTuru == "CHF").Sum(y => y.BaslangicBakiye);
                if (bugun.MCHF == null) { bugun.MCHF = 0; }
                bugun.MDKK = db.Kasalar.Where(x => x.DovizTuru == "DKK").Sum(y => y.BaslangicBakiye);
                if (bugun.MDKK == null) bugun.MDKK = 0;
                bugun.MRY = db.Kasalar.Where(x => x.DovizTuru == "RY").Sum(y => y.BaslangicBakiye);
                if (bugun.MRY == null) bugun.MRY = 0;
                bugun.MSEK = db.Kasalar.Where(x => x.DovizTuru == "SEK").Sum(y => y.BaslangicBakiye);
                if (bugun.MSEK == null) { bugun.MSEK = 0; }
                bugun.MNOK = db.Kasalar.Where(x => x.DovizTuru == "NOK").Sum(y => y.BaslangicBakiye);
                if (bugun.MNOK == null) { bugun.MNOK = 0; }
                bugun.MRB = db.Kasalar.Where(x => x.DovizTuru == "RB").Sum(y => y.BaslangicBakiye);
                if (bugun.MRB == null) { bugun.MRB = 0; }
                bugun.MAD = db.Kasalar.Where(x => x.DovizTuru == "AD").Sum(y => y.BaslangicBakiye);
                if (bugun.MAD == null) { bugun.MAD = 0; }
                bugun.MKD = db.Kasalar.Where(x => x.DovizTuru == "KD").Sum(y => y.BaslangicBakiye);
                if (bugun.MKD == null) { bugun.MKD = 0; }
                bugun.MJPY = db.Kasalar.Where(x => x.DovizTuru == "JPY").Sum(y => y.BaslangicBakiye);
                if (bugun.MJPY == null) { bugun.MJPY = 0; }

                bzk.MTL = bugun.MTL;
                bzk.MUSD = bugun.MUSD;
                bzk.MEURO = bugun.MEURO;
                bzk.MSTRL = bugun.MSTRL;
                bzk.MCHF = bugun.MCHF;
                bzk.MDKK = bugun.MDKK;
                bzk.MRY = bugun.MRY;
                bzk.MSEK = bugun.MSEK;
                bzk.MNOK = bugun.MNOK;
                bzk.MRB = bugun.MRB;
                bzk.MAD = bugun.MAD;
                bzk.MKD = bugun.MKD;
                bzk.MJPY = bugun.MJPY;



                temp1 = db.StokHareketleri.Where(x => x.StokId == "TÜRK LİRASI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "TÜRK LİRASI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GTL = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GTL = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GTL = temp1 + temp2; }
                else { bugun.GTL = temp1 + temp2; }



                temp1 = (-1) * (db.StokHareketleri.Where(x => x.StokId == "TÜRK LİRASI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar));
                temp2 = (-1) * (db.StokHareketleri.Where(x => x.StokId == "TÜRK LİRASI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar));
                if (temp1 == null && temp2 == null)
                {
                    bugun.CTL = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CTL = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CTL = temp1 + temp2; }
                else { bugun.CTL = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "AMERİKAN DOLARI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "AMERİKAN DOLARI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GUSD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GUSD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GUSD = temp1 + temp2; }
                else { bugun.GUSD = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "AMERİKAN DOLARI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "AMERİKAN DOLARI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CUSD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CUSD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CUSD = temp1 + temp2; }
                else { bugun.CUSD = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "EURO" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "EURO" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GEURO = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GEURO = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GEURO = temp1 + temp2; }
                else { bugun.GEURO = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "EURO" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "EURO" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CEURO = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CEURO = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CEURO = temp1 + temp2; }
                else { bugun.CEURO = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "İNGİLİZ STERLİNİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İNGİLİZ STERLİNİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GSTRL = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GSTRL = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GSTRL = temp1 + temp2; }
                else { bugun.GSTRL = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "İNGİLİZ STERLİNİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İNGİLİZ STERLİNİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CSTRL = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CSTRL = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CSTRL = temp1 + temp2; }
                else { bugun.CSTRL = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "İSVİÇRE FRANGI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İSVİÇRE FRANGI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GCHF = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GCHF = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GCHF = temp1 + temp2; }
                else { bugun.GCHF = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "İSVİÇRE FRANGI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İSVİÇRE FRANGI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CCHF = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CCHF = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CCHF = temp1 + temp2; }
                else { bugun.CCHF = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "DANİMARKA KRONU" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "DANİMARKA KRONU" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GDKK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GDKK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GDKK = temp1 + temp2; }
                else { bugun.GDKK = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "DANİMARKA KRONU" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "DANİMARKA KRONU" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CDKK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CDKK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CDKK = temp1 + temp2; }
                else { bugun.CDKK = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "RİYAL" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "RİYAL" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GRY = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GRY = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GRY = temp1 + temp2; }
                else { bugun.GRY = temp1 + temp2; }


                temp1 = db.StokHareketleri.Where(x => x.StokId == "RİYAL" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "RİYAL" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CRY = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CRY = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CRY = temp1 + temp2; }
                else { bugun.CRY = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "İSVEÇ KRONU" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İSVEÇ KRONU" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GSEK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GSEK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GSEK = temp1 + temp2; }
                else { bugun.GSEK = temp1 + temp2; }


                temp1 = db.StokHareketleri.Where(x => x.StokId == "İSVEÇ KRONU" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İSVEÇ KRONU" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CSEK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CSEK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CSEK = temp1 + temp2; }
                else { bugun.CSEK = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "NORVEÇ KRONU" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "NORVEÇ KRONU" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GNOK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GNOK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GNOK = temp1 + temp2; }
                else { bugun.GNOK = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "NORVEÇ KRONU" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "NORVEÇ KRONU" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CNOK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CNOK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CNOK = temp1 + temp2; }
                else { bugun.CNOK = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "RUS RUBLESİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "RUS RUBLESİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GRB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GRB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GRB = temp1 + temp2; }
                else { bugun.GRB = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "RUS RUBLESİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "RUS RUBLESİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CRB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CRB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CRB = temp1 + temp2; }
                else { bugun.CRB = temp1 + temp2; }


                temp1 = db.StokHareketleri.Where(x => x.StokId == "AVUSTRALYA DOLARI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "AVUSTRALYA DOLARI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GAD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GAD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GAD = temp1 + temp2; }
                else { bugun.GAD = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "AVUSTRALYA DOLARI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "AVUSTRALYA DOLARI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CAD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CAD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CAD = temp1 + temp2; }
                else { bugun.CAD = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "KANADA DOLARI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "KANADA DOLARI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GKD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GKD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GKD = temp1 + temp2; }
                else { bugun.GKD = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "KANADA DOLARI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "KANADA DOLARI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CKD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CKD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CKD = temp1 + temp2; }
                else { bugun.CKD = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "JAPON YENİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "JAPON YENİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GJPY = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GJPY = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GJPY = temp1 + temp2; }
                else { bugun.GJPY = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "JAPON YENİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "JAPON YENİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == now.Day && x.Tarih.Month == now.Month && x.Tarih.Year == now.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CJPY = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CJPY = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CJPY = temp1 + temp2; }
                else { bugun.CJPY = temp1 + temp2; }



                bugun.DTL = bugun.MTL - bugun.GTL + bugun.CTL;
                bugun.DUSD = bugun.MUSD - bugun.GUSD + bugun.CUSD;
                bugun.DEURO = bugun.MEURO - bugun.GEURO + bugun.CEURO;
                bugun.DDKK = bugun.MDKK - bugun.GDKK + bugun.CDKK;
                bugun.DCHF = bugun.MCHF - bugun.GCHF + bugun.CCHF;
                bugun.DRY = bugun.MRY - bugun.GRY + bugun.CRY;
                bugun.DSTRL = bugun.MSTRL - bugun.GSTRL + bugun.CSTRL;
                bugun.DRB = bugun.MRB - bugun.GRB + bugun.CRB;
                bugun.DSEK = bugun.MSEK - bugun.GSEK + bugun.CSEK;
                bugun.DNOK = bugun.MNOK - bugun.GNOK + bugun.CNOK;
                bugun.DAD = bugun.MAD - bugun.GAD + bugun.CAD;
                bugun.DKD = bugun.MKD - bugun.GKD + bugun.CKD;
                bugun.DJPY = bugun.MJPY - bugun.GJPY + bugun.CJPY;

                bzk.DTL = bugun.DTL;
                bzk.DUSD = bugun.DUSD;
                bzk.DEURO = bugun.DEURO;
                bzk.DDKK = bugun.DDKK;
                bzk.DCHF = bugun.DCHF;
                bzk.DRY = bugun.DRY;
                bzk.DSTRL = bugun.DSTRL;
                bzk.DRB = bugun.DRB;
                bzk.DSEK = bugun.DSEK;
                bzk.DNOK = bugun.DNOK;
                bzk.DAD = bugun.DAD;
                bzk.DKD = bugun.DKD;
                bzk.DJPY = bugun.DJPY;

                db.Entry(bzk).State = EntityState.Added;
                db.SaveChanges();

             TempData["bugunModel"] = bugun;          

            return RedirectToAction("Bugun");
            }
        
        [HttpPost]   
        public ActionResult Bugun(Bugun bugun1)
        {
            double toplama = 0;
            double toplams = 0;
            Bugun bugun = new Bugun();                      
            barkodsuzstok bzk = new barkodsuzstok();
            DateTime date = bugun1.Datetime;



                bugun.YiBilezikS = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.YiBilezikS == null) bugun.YiBilezikS = 0;

                bugun.YiBilezikA = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.YiBilezikA == null) bugun.YiBilezikA = 0;

                bugun.YiFantaziS = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.Ozellik4 == "FANTAZİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.YiFantaziS == null) bugun.YiFantaziS = 0;

                bugun.YiFantaziA = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.Ozellik4 == "FANTAZİ" && x.HareketTipi.Equals("ÜRÜN GİRİŞİ") == false && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.YiFantaziA == null) bugun.YiFantaziA = 0;

                bugun.OnSekAyarA = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.OnSekAyarA == null) bugun.OnSekAyarA = 0;

                bugun.OnSekAyarS = db.StokHareketleri.Where(x => x.StokId.Contains("18") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.OnSekAyarS == null) bugun.OnSekAyarS = 0;

                bugun.OnDortAyarA = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.OnDortAyarA == null) bugun.OnDortAyarA = 0;
                bugun.OnDortAyarS = db.StokHareketleri.Where(x => x.StokId.Contains("14") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.OnDortAyarS == null) bugun.OnDortAyarS = 0;
                bugun.SekAyarA = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.SekAyarA == null) bugun.SekAyarA = 0;
                bugun.SekAyarS = db.StokHareketleri.Where(x => x.StokId.Contains("8") == true && x.StokId.Contains("18") == false && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.SekAyarS == null) bugun.SekAyarS = 0;
                bugun.PirlantaA = db.StokHareketleri.Where(x => x.StokId.Contains("PRL") == true && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.PirlantaA == null) bugun.PirlantaA = 0;
                bugun.PirlantaS = db.StokHareketleri.Where(x => x.StokId.Contains("PRL") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.PirlantaS == null) bugun.PirlantaS = 0;
                bugun.InciA = db.StokHareketleri.Where(x => x.StokId.Contains("INCI") == true && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.InciA == null) bugun.InciA = 0;
                bugun.InciS = db.StokHareketleri.Where(x => x.StokId.Contains("INCI") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.InciS == null) bugun.InciS = 0;
                bugun.SaatA = db.StokHareketleri.Where(x => x.StokAdi == "SAAT" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.SaatA == null) bugun.SaatA = 0;
                bugun.SaatS = db.StokHareketleri.Where(x => x.StokAdi == "SAAT" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.SaatS == null) bugun.SaatS = 0;
                bugun.CeyrekA = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.CeyrekA == null) bugun.CeyrekA = 0;
                bugun.CeyrekS = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.CeyrekS == null) bugun.CeyrekS = 0;
                bugun.YarimA = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.YarimA == null) bugun.YarimA = 0;
                bugun.YarimS = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.YarimS == null) bugun.YarimS = 0;
                bugun.ZiynetA = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.ZiynetA == null) bugun.ZiynetA = 0;
                bugun.ZiynetS = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.ZiynetS == null) bugun.ZiynetS = 0;
                bugun.AtaA = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.AtaA == null) bugun.AtaA = 0;
                bugun.AtaS = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.AtaS == null) bugun.AtaS = 0;


                bugun.YiBilezikSF = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.YiBilezikSF == null) bugun.YiBilezikSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.YiBilezikSF);

                bugun.YiBilezikAF = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.YiBilezikAF == null) bugun.YiBilezikAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.YiBilezikAF);

                bugun.YiFantaziSF = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.Ozellik4 == "FANTAZİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.YiFantaziSF == null) bugun.YiFantaziSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.YiFantaziSF);

                bugun.YiFantaziAF = db.StokHareketleri.Where(x => x.StokId.Contains("22BLZ") == true && x.Ozellik4 == "FANTAZİ" && x.HareketTipi.Equals("ÜRÜN GİRİŞİ") == false && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.YiFantaziAF == null) bugun.YiFantaziAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.YiFantaziAF);

                bugun.OnSekAyarAF = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.OnSekAyarAF == null) bugun.OnSekAyarAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.OnSekAyarAF);

                bugun.OnSekAyarSF = db.StokHareketleri.Where(x => x.StokId.Contains("18") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.OnSekAyarSF == null)
                    bugun.OnSekAyarSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.OnSekAyarSF);

                bugun.OnDortAyarAF = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.OnDortAyarAF == null) bugun.OnDortAyarAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.OnDortAyarAF);

                bugun.OnDortAyarSF = db.StokHareketleri.Where(x => x.StokId.Contains("14") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.OnDortAyarSF == null) bugun.OnDortAyarSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.OnDortAyarSF);

                bugun.SekAyarAF = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.SekAyarAF == null) bugun.SekAyarAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.SekAyarAF);

                bugun.SekAyarSF = db.StokHareketleri.Where(x => x.StokId.Contains("8") == true && x.StokId.Contains("18") == false && x.StokId.Contains("18") == false && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.SekAyarSF == null) bugun.SekAyarSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.SekAyarSF);

                bugun.PirlantaAF = db.StokHareketleri.Where(x => x.StokId.Contains("PRL") == true && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.PirlantaAF == null) bugun.PirlantaAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.PirlantaAF);

                bugun.PirlantaSF = db.StokHareketleri.Where(x => x.StokId.Contains("PRL") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.PirlantaSF == null) bugun.PirlantaSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.PirlantaSF);

                bugun.InciAF = db.StokHareketleri.Where(x => x.StokId.Contains("INCI") == true && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.InciAF == null) bugun.InciAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.InciAF);

                bugun.InciSF = db.StokHareketleri.Where(x => x.StokId.Contains("INCI") == true && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.InciSF == null) bugun.InciSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.InciSF);

                bugun.SaatAF = db.StokHareketleri.Where(x => x.StokAdi == "SAAT" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.SaatAF == null) bugun.SaatAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.SaatAF);

                bugun.SaatSF = db.StokHareketleri.Where(x => x.StokAdi == "SAAT" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.SaatSF == null) bugun.SaatSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.SaatSF);

                bugun.CeyrekAF = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.CeyrekAF == null) bugun.CeyrekAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.CeyrekAF);

                bugun.CeyrekSF = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.CeyrekSF == null) bugun.CeyrekSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.CeyrekSF);

                bugun.YarimAF = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.YarimAF == null) bugun.YarimAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.YarimAF);

                bugun.YarimSF = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.YarimSF == null) bugun.YarimSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.YarimSF);

                bugun.ZiynetAF = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.ZiynetAF == null) bugun.ZiynetAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.ZiynetAF);

                bugun.ZiynetSF = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.ZiynetSF == null) bugun.ZiynetSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.ZiynetSF);

                bugun.AtaAF = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.AtaAF == null) bugun.AtaAF = 0;
                toplama = Convert.ToDouble(toplama + bugun.AtaAF);

                bugun.AtaSF = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.SatisTutari);
                if (bugun.AtaSF == null) bugun.AtaSF = 0;
                toplams = Convert.ToDouble(toplams + bugun.AtaSF);


                bugun.HasnetTA = db.StokHareketleri.Where(x => x.HasNet != null && x.HasNet != 0 && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.HasNet);
                if (bugun.HasnetTA == null) bugun.HasnetTA = 0;
                bugun.HasnetTS = db.StokHareketleri.Where(x => x.HasNet != null && x.HasNet != 0 && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (bugun.HasnetTS == null) bugun.HasnetTS = 0;

                bugun.HasnetTAF = toplama;
                bugun.HasnetTSF = toplams;

                bugun.HasnetTA = Math.Round(Convert.ToDouble(bugun.HasnetTA), 2);
                bugun.HasnetTS = Math.Round(Convert.ToDouble(bugun.HasnetTS), 2);
                bugun.HasnetTAF = Math.Round(Convert.ToDouble(bugun.HasnetTAF), 2);
                bugun.HasnetTSF = Math.Round(Convert.ToDouble(bugun.HasnetTSF), 2);

                double? temp8 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 AYAR").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "8 AYAR").Sum(y => y.Miktar);
                
                bugun.SekToplam = temp + temp8;
                }
                catch { bugun.SekToplam = temp8; }

                double? temp14 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 AYAR").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "14 AYAR").Sum(y => y.Miktar);
                
                bugun.OnDortToplam = temp + temp14;

                }
                catch
                { bugun.OnDortToplam = temp14; }

                double? temp18 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 AYAR").Sum(y => y.Miktar);
                try
                {                
                double temp = db.StokKartlari.Where(x => x.StokGrubu == "18 AYAR").Sum(y => y.Miktar);
                
                bugun.OnSekToplam = temp + temp18;
                }
                catch
                { bugun.OnSekToplam = temp18; }

                double? temp22 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "22 AYAR").Sum(y => y.Miktar);
                
                bugun.YiToplam = temp + temp22;
                }
                catch
                { bugun.YiToplam = temp22; }


                double? tempinci = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "İNCİ").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "INCI").Sum(y => y.Miktar);
                
                bugun.InciToplam = temp + tempinci;
                    
                }

                catch
                { bugun.InciToplam = tempinci; }


                double? temppir = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "PIRLANTA").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "PIRLANTA").Sum(y => y.Miktar);
                
                bugun.PirToplam = temp + temppir;
                }
                catch
                { bugun.PirToplam = temppir; }


                double? tempsaat = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "SAAT").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "SAAT").Sum(y => y.Miktar);
                
                bugun.SaatToplam = temp + tempsaat;
                }
                catch
                { bugun.SaatToplam = tempsaat; }


                double? temp21 = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "21 AYAR").Sum(y => y.Miktar);
                try
                {
                double? temp = db.StokKartlari.Where(x => x.StokGrubu == "21 AYAR").Sum(y => y.Miktar);
                
                bugun.YiBToplam = temp + temp21;
                }
                catch
                { bugun.YiBToplam = temp21; }

                bugun.SekToplam = Math.Round(Convert.ToDouble(bugun.SekToplam), 2);
                bugun.OnDortToplam = Math.Round(Convert.ToDouble(bugun.OnDortToplam), 2);
                bugun.OnSekToplam = Math.Round(Convert.ToDouble(bugun.OnSekToplam), 2);
                bugun.YiToplam = Math.Round(Convert.ToDouble(bugun.YiToplam), 2);
                bugun.InciToplam = Math.Round(Convert.ToDouble(bugun.InciToplam), 2);
                bugun.PirToplam = Math.Round(Convert.ToDouble(bugun.PirToplam), 2);
                bugun.SaatToplam = Math.Round(Convert.ToDouble(bugun.SaatToplam), 2);
                bugun.YiBToplam = Math.Round(Convert.ToDouble(bugun.YiBToplam), 2);

                bugun.SekHMevcut = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.SekHMevcut).FirstOrDefault();
                bugun.ODHMevcut = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.ODHMevcut).FirstOrDefault();
                bugun.ONSekHMevcut = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.ONSekHMevcut).FirstOrDefault();
                bugun.YBkHMevcut = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.YBkHMevcut).FirstOrDefault();
                bugun.YikHMevcut = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.YikHMevcut).FirstOrDefault();

                double? temp1 = 0, temp2 = 0;
                temp1 = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.SekHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.SekHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.SekHGirisB = temp1 + temp2; }
                else { bugun.SekHGirisB = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "8 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.SekHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.SekHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.SekHCikisB = temp1 + temp2; }
                else { bugun.SekHCikisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.ODHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.ODHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.ODHGirisB = temp1 + temp2; }
                else { bugun.ODHGirisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "14 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.ODHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.ODHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.ODHCikisB = temp1 + temp2; }
                else { bugun.ODHCikisB = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.ONSekHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.ONSekHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.ONSekHGirisB = temp1 + temp2; }
                else { bugun.ONSekHGirisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "18 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.ONSekHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.ONSekHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.ONSekHCikisB = temp1 + temp2; }
                else { bugun.ONSekHCikisB = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "21 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "21 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.YBkHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.YBkHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.YBkHGirisB = temp1 + temp2; }
                else { bugun.YBkHGirisB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "21 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "21 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.YBkHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.YBkHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.YBkHCikisB = temp1 + temp2; }
                else { bugun.YBkHCikisB = temp1 + temp2; }


                temp1 = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.YikHGirisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.YikHGirisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.YikHGirisB = temp1 + temp2; }
                else { bugun.YikHGirisB = temp1 + temp2; }


                temp1 = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "22 HURDA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.YikHCikisB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.YikHCikisB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.YikHCikisB = temp1 + temp2; }
                else { bugun.YBkHCikisB = temp1 + temp2; }



                bugun.SekHDevir = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.SekHDevir).FirstOrDefault();
                bugun.ODHDevir = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.ODHDevir).FirstOrDefault();
                bugun.ONSekHDevir = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.ONSekHDevir).FirstOrDefault();
                bugun.YBkHDevir = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.YBkHDevir).FirstOrDefault();
                bugun.YikHDevir = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.YikHDevir).FirstOrDefault();


                bugun.MCeyrek = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MCeyrek).FirstOrDefault();
                bugun.MYarim = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MYarim).FirstOrDefault();
                bugun.MAtatek = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MAtatek).FirstOrDefault();
                bugun.MIkibuc = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MIkibuc).FirstOrDefault();
                bugun.MClira = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MClira).FirstOrDefault();
                bugun.MYigram = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MYigram).FirstOrDefault();
                bugun.MYdgram = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MYdgram).FirstOrDefault();
                bugun.MHlira = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MHlira).FirstOrDefault();
                bugun.MKulce = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MKulce).FirstOrDefault();
                bugun.MRbesli = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MRbesli).FirstOrDefault();
                bugun.MHbesli = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MHbesli).FirstOrDefault();
                bugun.MCbesli = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MCbesli).FirstOrDefault();
                bugun.MRlira = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MRlira).FirstOrDefault();



                temp1 = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GCeyrek = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GCeyrek = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GCeyrek = temp1 + temp2; }
                else { bugun.GCeyrek = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "ÇEYREK" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CCeyrek = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CCeyrek = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CCeyrek = temp1 + temp2; }
                else { bugun.CCeyrek = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GYarim = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GYarim = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GYarim = temp1 + temp2; }
                else { bugun.GCeyrek = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "YARIM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CYarim = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CYarim = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CYarim = temp1 + temp2; }
                else { bugun.CYarim = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GAtatek = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GAtatek = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GAtatek = temp1 + temp2; }
                else { bugun.GAtatek = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "ATATEK" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CAtatek = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CAtatek = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CAtatek = temp1 + temp2; }
                else { bugun.CAtatek = temp1 + temp2; }


                ////////////////****************************************************************
                ///

                temp1 = db.StokHareketleri.Where(x => x.StokId == "2.5'LU" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "2.5'LU" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GIkibuc = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GIkibuc = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GIkibuc = temp1 + temp2; }
                else { bugun.GIkibuc = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "2.5'LU" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "2.5'LU" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CIkibuc = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CIkibuc = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CIkibuc = temp1 + temp2; }
                else { bugun.CIkibuc = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GClira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GClira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GClira = temp1 + temp2; }
                else { bugun.GClira = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "C.LİRA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CClira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CClira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CClira = temp1 + temp2; }
                else { bugun.CClira = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "22 AYAR GRAM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "22 AYAR GRAM" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GYigram = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GYigram = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GYigram = temp1 + temp2; }
                else { bugun.GYigram = temp1 + temp2; }


                temp1 = db.StokHareketleri.Where(x => x.StokId == "22 AYAR GRAM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "22 AYAR GRAM" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CYigram = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CYigram = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CYigram = temp1 + temp2; }
                else { bugun.CYigram = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "24 AYAR GRAM" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "24 AYAR GRAM" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GYdgram = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GYdgram = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GYdgram = temp1 + temp2; }
                else { bugun.GYdgram = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "24 AYAR GRAM" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "24 AYAR GRAM" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CYdgram = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CYdgram = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CYdgram = temp1 + temp2; }
                else { bugun.CYdgram = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "HAMİT LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "HAMİT LİRA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GHlira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GHlira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GHlira = temp1 + temp2; }
                else { bugun.GHlira = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "HAMİT LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "HAMİT LİRA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CHlira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CHlira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CHlira = temp1 + temp2; }
                else { bugun.CHlira = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "KÜLÇE ALTIN" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "KÜLÇE ALTIN" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GKulce = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GKulce = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GKulce = temp1 + temp2; }
                else { bugun.GKulce = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "KÜLÇE ALTIN" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "KÜLÇE ALTIN" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CKulce = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CKulce = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CKulce = temp1 + temp2; }
                else { bugun.CKulce = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "REŞAT BEŞLİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "REŞAT BEŞLİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GRbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GRbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GRbesli = temp1 + temp2; }
                else { bugun.GRbesli = temp1 + temp2; }
                




                temp1 = db.StokHareketleri.Where(x => x.StokId == "REŞAT BEŞLİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "REŞAT BEŞLİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CRbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CRbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CRbesli = temp1 + temp2; }
                else { bugun.CRbesli = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "HAMİT BEŞLİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "HAMİT BEŞLİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GHbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GHbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GHbesli = temp1 + temp2; }
                else { bugun.GHbesli = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "HAMİT BEŞLİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "HAMİT BEŞLİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CHbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CHbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CHbesli = temp1 + temp2; }
                else { bugun.CHbesli = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "CUMHURİYET BEŞLİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "CUMHURİYET BEŞLİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GCbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GCbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GCbesli = temp1 + temp2; }
                else { bugun.GCbesli = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "CUMHURİYET BEŞLİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "CUMHURİYET BEŞLİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CCbesli = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CCbesli = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CCbesli = temp1 + temp2; }
                else { bugun.CCbesli = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "REŞAT LİRA" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "REŞAT LİRA" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GRlira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GRlira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GRlira = temp1 + temp2; }
                else { bugun.GRlira = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "REŞAT LİRA" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "REŞAT LİRA" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CRlira = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CRlira = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CRlira = temp1 + temp2; }
                else { bugun.CRlira = temp1 + temp2; }



                bugun.DCeyrek = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DCeyrek).FirstOrDefault();
                bugun.DYarim = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DYarim).FirstOrDefault();
                bugun.DAtatek = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DAtatek).FirstOrDefault();
                bugun.DIkibuc = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DIkibuc).FirstOrDefault();
                bugun.DClira = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DClira).FirstOrDefault();
                bugun.DYigram = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DYigram).FirstOrDefault();
                bugun.DYdgram = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DYdgram).FirstOrDefault();
                bugun.DHlira = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DHlira).FirstOrDefault();
                bugun.DKulce = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DKulce).FirstOrDefault();
                bugun.DRbesli = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DRbesli).FirstOrDefault();
                bugun.DHbesli = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DHbesli).FirstOrDefault();
                bugun.DCbesli = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DCbesli).FirstOrDefault();
                bugun.DRlira = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DRlira).FirstOrDefault();




                bugun.MTL = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MTL).FirstOrDefault();
                bugun.MUSD = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MUSD).FirstOrDefault();
                bugun.MEURO = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MEURO).FirstOrDefault();
                bugun.MSTRL = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MSTRL).FirstOrDefault();
                bugun.MCHF = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MCHF).FirstOrDefault();
                bugun.MDKK = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MDKK).FirstOrDefault();
                bugun.MRY = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MRY).FirstOrDefault();
                bugun.MSEK = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MSEK).FirstOrDefault();
                bugun.MNOK = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MNOK).FirstOrDefault();
                bugun.MRB = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MRB).FirstOrDefault();
                bugun.MAD = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MAD).FirstOrDefault();
                bugun.MKD = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MKD).FirstOrDefault();
                bugun.MJPY = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(y => y.MJPY).FirstOrDefault();





                temp1 = db.StokHareketleri.Where(x => x.StokId == "TÜRK LİRASI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "TÜRK LİRASI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GTL = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GTL = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GTL = temp1 + temp2; }
                else { bugun.GTL = temp1 + temp2; }




                temp1 = (-1) * (db.StokHareketleri.Where(x => x.StokId == "TÜRK LİRASI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar));
                temp2 = (-1) * (db.StokHareketleri.Where(x => x.StokId == "TÜRK LİRASI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar));
                if (temp1 == null && temp2 == null)
                {
                    bugun.CTL = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CTL = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CTL = temp1 + temp2; }
                else { bugun.CTL = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "AMERİKAN DOLARI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "AMERİKAN DOLARI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GUSD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GUSD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GUSD = temp1 + temp2; }
                else { bugun.GUSD = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "AMERİKAN DOLARI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "AMERİKAN DOLARI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CUSD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CUSD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CUSD = temp1 + temp2; }
                else { bugun.CUSD = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "EURO" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "EURO" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GEURO = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GEURO = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GEURO = temp1 + temp2; }
                else { bugun.GEURO = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "EURO" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "EURO" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CEURO = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CEURO = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CEURO = temp1 + temp2; }
                else { bugun.CEURO = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "İNGİLİZ STERLİNİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İNGİLİZ STERLİNİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GSTRL = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GSTRL = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GSTRL = temp1 + temp2; }
                else { bugun.GSTRL = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "İNGİLİZ STERLİNİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İNGİLİZ STERLİNİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CSTRL = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CSTRL = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CSTRL = temp1 + temp2; }
                else { bugun.CSTRL = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "İSVİÇRE FRANGI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İSVİÇRE FRANGI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GCHF = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GCHF = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GCHF = temp1 + temp2; }
                else { bugun.GCHF = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "İSVİÇRE FRANGI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İSVİÇRE FRANGI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CCHF = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CCHF = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CCHF = temp1 + temp2; }
                else { bugun.CCHF = temp1 + temp2; }


                temp1 = db.StokHareketleri.Where(x => x.StokId == "DANİMARKA KRONU" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "DANİMARKA KRONU" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GDKK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GDKK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GDKK = temp1 + temp2; }
                else { bugun.GDKK = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "DANİMARKA KRONU" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "DANİMARKA KRONU" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CDKK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CDKK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CDKK = temp1 + temp2; }
                else { bugun.CDKK = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "RİYAL" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "RİYAL" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GRY = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GRY = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GRY = temp1 + temp2; }
                else { bugun.GRY = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "RİYAL" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "RİYAL" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CRY = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CRY = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CRY = temp1 + temp2; }
                else { bugun.CRY = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "İSVEÇ KRONU" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İSVEÇ KRONU" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GSEK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GSEK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GSEK = temp1 + temp2; }
                else { bugun.GSEK = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "İSVEÇ KRONU" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "İSVEÇ KRONU" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CSEK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CSEK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CSEK = temp1 + temp2; }
                else { bugun.CSEK = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "NORVEÇ KRONU" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "NORVEÇ KRONU" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GNOK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GNOK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GNOK = temp1 + temp2; }
                else { bugun.GNOK = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "NORVEÇ KRONU" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "NORVEÇ KRONU" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CNOK = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CNOK = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CNOK = temp1 + temp2; }
                else { bugun.CNOK = temp1 + temp2; }


                temp1 = db.StokHareketleri.Where(x => x.StokId == "RUS RUBLESİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "RUS RUBLESİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GRB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GRB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GRB = temp1 + temp2; }
                else { bugun.GRB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "RUS RUBLESİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "RUS RUBLESİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CRB = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CRB = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CRB = temp1 + temp2; }
                else { bugun.CRB = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "AVUSTRALYA DOLARI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "AVUSTRALYA DOLARI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GAD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GAD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GAD = temp1 + temp2; }
                else { bugun.GAD = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "AVUSTRALYA DOLARI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "AVUSTRALYA DOLARI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CAD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CAD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CAD = temp1 + temp2; }
                else { bugun.CAD = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "KANADA DOLARI" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "KANADA DOLARI" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GKD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GKD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GKD = temp1 + temp2; }
                else { bugun.GKD = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "KANADA DOLARI" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "KANADA DOLARI" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CKD = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CKD = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CKD = temp1 + temp2; }
                else { bugun.CKD = temp1 + temp2; }



                temp1 = db.StokHareketleri.Where(x => x.StokId == "JAPON YENİ" && x.HareketTuru == "GİRİŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "JAPON YENİ" && x.HareketTuru == "A EMANET" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.GJPY = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.GJPY = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.GJPY = temp1 + temp2; }
                else { bugun.GJPY = temp1 + temp2; }




                temp1 = db.StokHareketleri.Where(x => x.StokId == "JAPON YENİ" && x.HareketTuru == "ÇIKIŞ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                temp2 = db.StokHareketleri.Where(x => x.StokId == "JAPON YENİ" && x.HareketTuru == "BORÇ" && x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).Sum(y => y.Miktar);
                if (temp1 == null && temp2 == null)
                {
                    bugun.CJPY = 0;
                }
                else if (temp1 == null) { temp1 = 0; bugun.CJPY = temp1 + temp2; }
                else if (temp2 == null) { temp2 = 0; bugun.CJPY = temp1 + temp2; }
                else { bugun.CJPY = temp1 + temp2; }



                bugun.DTL = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DTL).FirstOrDefault();
                bugun.DUSD = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DUSD).FirstOrDefault();
                bugun.DEURO = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DEURO).FirstOrDefault();
                bugun.DDKK = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DDKK).FirstOrDefault();
                bugun.DCHF = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DCHF).FirstOrDefault();
                bugun.DRY = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DRY).FirstOrDefault();
                bugun.DSTRL = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DSTRL).FirstOrDefault();
                bugun.DRB = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DRB).FirstOrDefault();
                bugun.DSEK = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DSEK).FirstOrDefault();
                bugun.DNOK = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DNOK).FirstOrDefault();
                bugun.DAD = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DAD).FirstOrDefault();
                bugun.DKD = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DKD).FirstOrDefault();
                bugun.DJPY = db.BarkodsuzStok.Where(x => x.Tarih.Day == date.Day && x.Tarih.Month == date.Month && x.Tarih.Year == date.Year).OrderByDescending(x => x.Id).Select(x => x.DJPY).FirstOrDefault();


            //TempData["bugunModel"] = bugun;
            //return RedirectToAction("Bugun");

            return View(bugun);


        }
        public ActionResult Pozisyonlar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Pozisyonlar(Pozisyonlar poz, string submit)
        {
            Pozisyonlar pozisyonlar = new Pozisyonlar();
            
            pozisyonlar.MHas = 0;
            pozisyonlar.MTL = 0;
            pozisyonlar.MEURO = 0;
            pozisyonlar.MUSD = 0;
            pozisyonlar.MCHF = 0;
            pozisyonlar.MSTRL = 0;
            pozisyonlar.MCeyrek = 0;
            pozisyonlar.MYi = 0;

            pozisyonlar.THas = 0;
            pozisyonlar.TTL = 0;
            pozisyonlar.TEURO = 0;
            pozisyonlar.TUSD = 0;
            pozisyonlar.TCHF = 0;
            pozisyonlar.TSTRL = 0;
            pozisyonlar.TCeyrek = 0;
            pozisyonlar.TYi = 0;

            pozisyonlar.MHas2 = 0;
            pozisyonlar.MTL2 = 0;
            pozisyonlar.MEURO2 = 0;
            pozisyonlar.MUSD2 = 0;
            pozisyonlar.MCHF2 = 0;
            pozisyonlar.MSTRL2 = 0;
            pozisyonlar.MCeyrek2 = 0;
            pozisyonlar.MYi2 = 0;

            pozisyonlar.THas2 = 0;
            pozisyonlar.TTL2 = 0;
            pozisyonlar.TEURO2 = 0;
            pozisyonlar.TUSD2 = 0;
            pozisyonlar.TCHF2 = 0;
            pozisyonlar.TSTRL2 = 0;
            pozisyonlar.TCeyrek2 = 0;
            pozisyonlar.TYi2 = 0;

            pozisyonlar.TL = 0;
            pozisyonlar.USD = 0;
            pozisyonlar.EURO = 0;
            pozisyonlar.STRL = 0;
            pozisyonlar.CHF = 0;

            if (submit == "BUGUN")
            {
                List<Musteri> musteriler = db.Musteriler.ToList();
                List<Toptanci> toptancilar = db.Toptancilar.Where(x => x.MagazaNo == poz.SubeNo).ToList();
                PozisyonlarDB pozdb = new PozisyonlarDB();
                
                pozdb.Tarih = DateTime.Now;

                for (int i = 0; i < musteriler.Count; i++)
                {
                    if (musteriler[i].HAS < 0)
                    {
                        pozisyonlar.MHas = pozisyonlar.MHas - musteriler[i].HAS;
                        pozdb.MHas = pozisyonlar.MHas;
                    }
                    if (musteriler[i].TL < 0)
                    {
                        pozisyonlar.MTL = pozisyonlar.MTL - musteriler[i].TL;
                        pozdb.MTL = pozisyonlar.MTL;
                    }
                    if (musteriler[i].EURO < 0)
                    {
                        pozisyonlar.MEURO = pozisyonlar.MEURO - musteriler[i].EURO;
                        pozdb.MEURO = pozisyonlar.MEURO;
                    }
                    if (musteriler[i].USD < 0)
                    {
                        pozisyonlar.MUSD = pozisyonlar.MUSD - musteriler[i].USD;
                        pozdb.MUSD = pozisyonlar.MUSD;
                    }
                    if (musteriler[i].CHF < 0)
                    {
                        pozisyonlar.MCHF = pozisyonlar.MCHF - musteriler[i].CHF;
                        pozdb.MCHF = pozisyonlar.MCHF;
                    }
                    if (musteriler[i].STRL < 0)
                    {
                        pozisyonlar.MSTRL = pozisyonlar.MSTRL - musteriler[i].STRL;
                        pozdb.MSTRL = pozisyonlar.MSTRL;
                    }
                    if (musteriler[i].ÇEYREK < 0)
                    {
                        pozisyonlar.MCeyrek = pozisyonlar.MCeyrek - musteriler[i].ÇEYREK;
                        pozdb.MCeyrek = pozisyonlar.MCeyrek;
                    }
                    if (musteriler[i].YiAyarGRAM < 0)
                    {
                        pozisyonlar.MYi = pozisyonlar.MYi - musteriler[i].YiAyarGRAM;
                        pozdb.MYi = pozisyonlar.MYi;
                    }


                    if (musteriler[i].HAS > 0)
                    {
                        pozisyonlar.MHas2 = pozisyonlar.MHas2 + musteriler[i].HAS;
                        pozdb.MHas2 = pozisyonlar.MHas2;
                    }
                    if (musteriler[i].TL > 0)
                    {
                        pozisyonlar.MTL2 = pozisyonlar.MTL2 + musteriler[i].TL;
                        pozisyonlar.MTL2 = pozisyonlar.MTL2;
                    }
                    if (musteriler[i].EURO > 0)
                    {
                        pozisyonlar.MEURO2 = pozisyonlar.MEURO2 + musteriler[i].EURO;
                        pozdb.MEURO2 = pozisyonlar.MEURO2;
                    }
                    if (musteriler[i].USD > 0)
                    {
                        pozisyonlar.MUSD2 = pozisyonlar.MUSD2 + musteriler[i].USD;
                        pozdb.MUSD2 = pozisyonlar.MUSD2;
                    }
                    if (musteriler[i].CHF > 0)
                    {
                        pozisyonlar.MCHF2 = pozisyonlar.MCHF2 + musteriler[i].CHF;
                        pozdb.MCHF2 = pozisyonlar.MCHF2;
                    }
                    if (musteriler[i].STRL > 0)
                    {
                        pozisyonlar.MSTRL2 = pozisyonlar.MSTRL2 + musteriler[i].STRL;
                        pozdb.MSTRL2 = pozisyonlar.MSTRL2;
                    }
                    if (musteriler[i].ÇEYREK > 0)
                    {
                        pozisyonlar.MCeyrek2 = pozisyonlar.MCeyrek2 + musteriler[i].ÇEYREK;
                        pozdb.MCeyrek2 = pozisyonlar.MCeyrek2;
                    }
                    if (musteriler[i].YiAyarGRAM > 0)
                    {
                        pozisyonlar.MYi2 = pozisyonlar.MYi2 + musteriler[i].YiAyarGRAM;
                        pozdb.MYi2 = pozisyonlar.MYi2;
                    }
                }

                for (int i = 0; i < toptancilar.Count; i++)
                {
                    if (toptancilar[i].Bakiye > 0)
                    {
                        pozisyonlar.THas = pozisyonlar.THas + toptancilar[i].Bakiye;
                        pozdb.THas = pozisyonlar.THas;
                    }
                    if (toptancilar[i].TlBakiye > 0)
                    {
                        pozisyonlar.TTL = pozisyonlar.TTL + toptancilar[i].TlBakiye;
                        pozdb.TTL = pozisyonlar.TTL;
                    }
                    if (toptancilar[i].EuroBakiye > 0)
                    {
                        pozisyonlar.TEURO = pozisyonlar.TEURO + toptancilar[i].EuroBakiye;
                        pozdb.TEURO = pozisyonlar.TEURO;
                    }
                    if (toptancilar[i].UsdBakiye > 0)
                    {
                        pozisyonlar.TUSD = pozisyonlar.TUSD + toptancilar[i].UsdBakiye;
                        pozdb.TUSD = pozisyonlar.TUSD;
                    }
                    if (toptancilar[i].ChfBakiye > 0)
                    {
                        pozisyonlar.TCHF = pozisyonlar.TCHF + toptancilar[i].ChfBakiye;
                        pozdb.TCHF = pozisyonlar.TCHF;
                    }
                    if (toptancilar[i].StrlBakiye > 0)
                    {
                        pozisyonlar.TSTRL = pozisyonlar.TSTRL + toptancilar[i].StrlBakiye;
                        pozdb.TSTRL = pozisyonlar.TSTRL;
                    }
                    if (toptancilar[i].CeyrekBakiye > 0)
                    {
                        pozisyonlar.TCeyrek = pozisyonlar.TCeyrek + toptancilar[i].CeyrekBakiye;
                        pozdb.TCeyrek = pozisyonlar.TCeyrek;
                    }
                    if (toptancilar[i].YiAyarBakiye > 0)
                    {
                        pozisyonlar.TYi = pozisyonlar.TYi + toptancilar[i].YiAyarBakiye;
                        pozdb.TYi = pozisyonlar.TYi;
                    }


                    if (toptancilar[i].Bakiye < 0)
                    {
                        pozisyonlar.THas2 = pozisyonlar.THas2 - toptancilar[i].Bakiye;
                        pozdb.THas2 = pozisyonlar.THas2;
                    }
                    if (toptancilar[i].TlBakiye < 0)
                    {
                        pozisyonlar.TTL2 = pozisyonlar.TTL2 - toptancilar[i].TlBakiye;
                        pozdb.TTL2 = pozisyonlar.TTL2;
                    }
                    if (toptancilar[i].EuroBakiye < 0)
                    {
                        pozisyonlar.TEURO2 = pozisyonlar.TEURO2 - toptancilar[i].EuroBakiye;
                        pozdb.TEURO2 = pozisyonlar.TEURO2;
                    }
                    if (toptancilar[i].UsdBakiye < 0)
                    {
                        pozisyonlar.TUSD2 = pozisyonlar.TUSD2 - toptancilar[i].UsdBakiye;
                        pozdb.TUSD2 = pozisyonlar.TUSD2;
                    }
                    if (toptancilar[i].ChfBakiye < 0)
                    {
                        pozisyonlar.TCHF2 = pozisyonlar.TCHF2 - toptancilar[i].ChfBakiye;
                        pozdb.TCHF2 = pozisyonlar.TCHF2;
                    }
                    if (toptancilar[i].StrlBakiye < 0)
                    {
                        pozisyonlar.TSTRL2 = pozisyonlar.TSTRL2 - toptancilar[i].StrlBakiye;
                        pozdb.TSTRL2 = pozisyonlar.TSTRL2;
                    }
                    if (toptancilar[i].CeyrekBakiye < 0)
                    {
                        pozisyonlar.TCeyrek2 = pozisyonlar.TCeyrek2 - toptancilar[i].CeyrekBakiye;
                        pozdb.TCeyrek2 = pozisyonlar.TCeyrek2;
                    }
                    if (toptancilar[i].YiAyarBakiye < 0)
                    {
                        pozisyonlar.TYi2 = pozisyonlar.TYi2 - toptancilar[i].YiAyarBakiye;
                        pozdb.TYi2 = pozisyonlar.TYi2;
                    }

                }


                pozisyonlar.ToplamCeyrekB = pozisyonlar.MCeyrek2 + pozisyonlar.TCeyrek2;
                pozisyonlar.ToplamCHFB = db.Kasalar.Where(x => x.DovizTuru == "CHF" && x.SubeNo == "NO1").Sum(x => x.BaslangicBakiye);
                pozisyonlar.ToplamEUROB = db.Kasalar.Where(x => x.DovizTuru == "EURO" && x.SubeNo == "NO1").Sum(x => x.BaslangicBakiye);
                pozisyonlar.ToplamHasB = pozisyonlar.MHas2 + pozisyonlar.THas2;
                pozisyonlar.ToplamSTRLB = db.Kasalar.Where(x => x.DovizTuru == "STRL" && x.SubeNo == "NO1").Sum(x => x.BaslangicBakiye);
                pozisyonlar.ToplamTLB = db.Kasalar.Where(x => x.DovizTuru == "TL" && x.SubeNo == "NO1").Sum(x => x.BaslangicBakiye);
                pozisyonlar.ToplamUSDB = db.Kasalar.Where(x => x.DovizTuru == "USD" && x.SubeNo == "NO1").Sum(x => x.BaslangicBakiye);
                pozisyonlar.ToplamYiB = pozisyonlar.MYi2 + pozisyonlar.TYi2;

                pozisyonlar.ToplamCeyrekA = pozisyonlar.MCeyrek + pozisyonlar.TCeyrek;
                pozisyonlar.ToplamCHFA = pozisyonlar.MCHF + pozisyonlar.TCHF;
                pozisyonlar.ToplamEUROA = pozisyonlar.MEURO + pozisyonlar.TEURO;
                pozisyonlar.ToplamHasA = pozisyonlar.MHas + pozisyonlar.THas;
                pozisyonlar.ToplamSTRLA = pozisyonlar.MSTRL + pozisyonlar.TSTRL;
                pozisyonlar.ToplamTLA = pozisyonlar.MTL + pozisyonlar.TTL;
                pozisyonlar.ToplamUSDA = pozisyonlar.MUSD + pozisyonlar.TUSD;
                pozisyonlar.ToplamYiA = pozisyonlar.MYi + pozisyonlar.TYi;

                pozdb.ToplamCeyrekB = pozisyonlar.ToplamCeyrekB;
                pozdb.ToplamCHFB = pozisyonlar.ToplamCHFB;
                pozdb.ToplamEUROB = pozisyonlar.ToplamEUROB;
                pozdb.ToplamHasB = pozisyonlar.ToplamHasB;
                pozdb.ToplamSTRLB = pozisyonlar.ToplamSTRLB;
                pozdb.ToplamTLB = pozisyonlar.ToplamTLB;
                pozdb.ToplamUSDB = pozisyonlar.ToplamUSDB;
                pozdb.ToplamYiB = pozisyonlar.ToplamYiB;

                pozdb.ToplamCeyrekA = pozisyonlar.ToplamCeyrekA;
                pozdb.ToplamCHFA = pozisyonlar.ToplamCHFA;
                pozdb.ToplamEUROA = pozisyonlar.ToplamEUROA;
                pozdb.ToplamHasA = pozisyonlar.ToplamHasA;
                pozdb.ToplamSTRLA = pozisyonlar.ToplamSTRLA;
                pozdb.ToplamTLA = pozisyonlar.ToplamTLA;
                pozdb.ToplamUSDA = pozisyonlar.ToplamUSDA;
                pozdb.ToplamYiA = pozisyonlar.ToplamYiA;

                double temp = 0;
                double temp2 = 0;
                
                if(pozisyonlar.TTL2 > pozisyonlar.TTL)
                {
                    temp = Convert.ToDouble(pozisyonlar.TTL2 - pozisyonlar.TTL);
                    if((pozisyonlar.ToplamTLB - temp) > 0)
                    {
                        pozisyonlar.FazlaTL = pozisyonlar.ToplamTLB - temp;
                        pozisyonlar.AcikTL = 0;
                        
                        
                    }
                    else
                    {
                        pozisyonlar.AcikTL = (pozisyonlar.ToplamTLB - temp) * (-1);
                        pozisyonlar.FazlaTL = 0;
                    }

                }
                else if(pozisyonlar.TTL > pozisyonlar.TTL2)
                {
                    temp2 = Convert.ToDouble(pozisyonlar.TTL - pozisyonlar.TTL2);
                    pozisyonlar.FazlaTL = pozisyonlar.ToplamTLB + temp2;
                    pozisyonlar.AcikTL = 0;
                }
                else
                {
                    pozisyonlar.FazlaTL = 0;
                    pozisyonlar.AcikTL = 0;
                }

                if(pozisyonlar.TUSD2 > pozisyonlar.TUSD)
                {
                    temp = Convert.ToDouble(pozisyonlar.TUSD2 - pozisyonlar.TUSD);
                    if((pozisyonlar.ToplamUSDB - temp) > 0)
                    {
                        pozisyonlar.FazlaUSD = pozisyonlar.ToplamUSDB - temp;
                        pozisyonlar.AcikUSD = 0;
                    }
                    else
                    {
                        pozisyonlar.AcikUSD = (pozisyonlar.ToplamUSDB - temp) * (-1);
                        pozisyonlar.FazlaUSD = 0;
                    }
                }
                else if(pozisyonlar.TUSD > pozisyonlar.TUSD2)
                {
                    temp2 = Convert.ToDouble(pozisyonlar.TUSD - pozisyonlar.TUSD2);
                    pozisyonlar.FazlaUSD = pozisyonlar.ToplamUSDB + temp2;
                    pozisyonlar.AcikUSD = 0;
                }
                else
                {
                    pozisyonlar.FazlaUSD = 0;
                    pozisyonlar.AcikUSD = 0;
                }
                if (pozisyonlar.TEURO2 > pozisyonlar.TEURO)
                {
                    temp = Convert.ToDouble(pozisyonlar.TEURO2 - pozisyonlar.TEURO);
                    if ((pozisyonlar.ToplamEUROB - temp) > 0)
                    {
                        pozisyonlar.FazlaEURO = pozisyonlar.ToplamEUROB - temp;
                        pozisyonlar.AcikEURO = 0;
                    }
                    else
                    {
                        pozisyonlar.AcikEURO = (pozisyonlar.ToplamEUROB - temp) * (-1);
                        pozisyonlar.FazlaEURO = 0;
                    }
                }
                else if (pozisyonlar.TEURO > pozisyonlar.TEURO2)
                {
                    temp2 = Convert.ToDouble(pozisyonlar.TUSD - pozisyonlar.TUSD2);
                    pozisyonlar.FazlaEURO = pozisyonlar.ToplamEUROB + temp2;
                    pozisyonlar.AcikEURO = 0;
                }
                else
                {
                    pozisyonlar.FazlaEURO = 0;
                    pozisyonlar.AcikEURO = 0;
                }
                if (pozisyonlar.TSTRL2 > pozisyonlar.TSTRL)
                {
                    temp = Convert.ToDouble(pozisyonlar.TSTRL2 - pozisyonlar.TSTRL);
                    if ((pozisyonlar.ToplamSTRLB - temp) > 0)
                    {
                        pozisyonlar.FazlaSTRL = pozisyonlar.ToplamSTRLB - temp;
                        pozisyonlar.AcikSTRL = 0;
                    }
                    else
                    {
                        pozisyonlar.AcikSTRL = (pozisyonlar.ToplamSTRLB - temp) * (-1);
                        pozisyonlar.FazlaSTRL = 0;
                    }
                }
                else if (pozisyonlar.TSTRL > pozisyonlar.TSTRL2)
                {
                    temp2 = Convert.ToDouble(pozisyonlar.TSTRL - pozisyonlar.TSTRL2);
                    pozisyonlar.FazlaSTRL = pozisyonlar.ToplamSTRLB + temp2;
                    pozisyonlar.AcikSTRL = 0;
                }
                else
                {
                    pozisyonlar.FazlaSTRL = 0;
                    pozisyonlar.AcikSTRL = 0;
                }
                if (pozisyonlar.TCHF2 > pozisyonlar.TCHF)
                {
                    temp = Convert.ToDouble(pozisyonlar.TCHF2 - pozisyonlar.TCHF);
                    if ((pozisyonlar.ToplamCHFB - temp) > 0)
                    {
                        pozisyonlar.FazlaCHF = pozisyonlar.ToplamCHFB - temp;
                        pozisyonlar.AcikCHF = 0;
                    }
                    else
                    {
                        pozisyonlar.AcikCHF = (pozisyonlar.ToplamCHFB - temp) * (-1);
                        pozisyonlar.FazlaCHF = 0;
                    }
                }
                else if (pozisyonlar.TCHF > pozisyonlar.TCHF2)
                {
                    temp2 = Convert.ToDouble(pozisyonlar.TCHF - pozisyonlar.TCHF2);
                    pozisyonlar.FazlaCHF = pozisyonlar.ToplamCHFB + temp2;
                    pozisyonlar.AcikCHF = 0;
                }
                else
                {
                    pozisyonlar.FazlaCHF = 0;
                    pozisyonlar.AcikCHF = 0;
                }
                pozdb.AcikCHF = pozisyonlar.AcikCHF;
                pozdb.AcikEURO = pozisyonlar.AcikEURO;
                pozdb.AcikSTRL = pozisyonlar.AcikSTRL;
                pozdb.AcikTL = pozisyonlar.AcikTL;
                pozdb.AcikUSD = pozisyonlar.AcikUSD;

                pozdb.FazlaCHF = pozisyonlar.FazlaCHF;
                pozdb.FazlaEURO = pozisyonlar.FazlaEURO;
                pozdb.FazlaSTRL = pozisyonlar.FazlaSTRL;
                pozdb.FazlaTL = pozisyonlar.FazlaTL;
                pozdb.FazlaUSD = pozisyonlar.FazlaUSD;

                List<Banka> bankalar = new List<Banka>();
                bankalar = db.Bankalar.Where(x => x.SubeAdi == poz.SubeNo).ToList();
                for (int i = 0; i < bankalar.Count; i++)
                {

                    if (bankalar[i].HesapDovizTuru == "TL")
                    {
                        pozisyonlar.TL = pozisyonlar.TL + bankalar[i].Bakiye;
                        pozdb.TL = pozisyonlar.TL;
                    }
                    else if (bankalar[i].HesapDovizTuru == "USD")
                    {
                        pozisyonlar.USD = pozisyonlar.USD + bankalar[i].Bakiye;
                        pozdb.USD = pozisyonlar.USD;
                    }
                    else if (bankalar[i].HesapDovizTuru == "EURO")
                    {
                        pozisyonlar.EURO = pozisyonlar.EURO + bankalar[i].Bakiye;
                        pozdb.EURO = pozisyonlar.EURO;
                    }
                    else if (bankalar[i].HesapDovizTuru == "CHF")
                    {
                        pozisyonlar.CHF = pozisyonlar.CHF + bankalar[i].Bakiye;
                        pozdb.CHF = pozisyonlar.CHF;
                    }
                    else if (bankalar[i].HesapDovizTuru == "STRL")
                    {
                        pozisyonlar.STRL = pozisyonlar.STRL + bankalar[i].Bakiye;
                        pozdb.STRL = pozisyonlar.STRL;
                    }
                   
                }
                db.Entry(pozdb).State = EntityState.Added;
                db.SaveChanges();

                return View(pozisyonlar);
            }
            else if (submit == "ISTENILEN TARIH")
            {
                List<Musteri> musteriler = db.Musteriler.ToList();
                List<Toptanci> toptancilar = db.Toptancilar.Where(x => x.MagazaNo == poz.SubeNo).ToList();
                DateTime m = Convert.ToDateTime(poz.Tarih);

                for (int i = 0; i < musteriler.Count; i++)
                {
                    if (musteriler[i].HAS < 0)
                    {
                        pozisyonlar.MHas = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MHas).FirstOrDefault();
                    }
                    if (musteriler[i].TL < 0)
                    {
                        pozisyonlar.MTL= db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MTL).FirstOrDefault();
                    }
                    if (musteriler[i].EURO < 0)
                    {
                        pozisyonlar.MEURO = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MEURO).FirstOrDefault();
                    }
                    if (musteriler[i].USD < 0)
                    {
                        pozisyonlar.MUSD = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MUSD).FirstOrDefault();
                    }
                    if (musteriler[i].CHF < 0)
                    {
                        pozisyonlar.MCHF = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MCHF).FirstOrDefault();
                    }
                    if (musteriler[i].STRL < 0)
                    {
                        pozisyonlar.MSTRL = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MSTRL).FirstOrDefault();
                    }
                    if (musteriler[i].ÇEYREK < 0)
                    {
                        pozisyonlar.MCeyrek = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MCeyrek).FirstOrDefault();
                    }
                    if (musteriler[i].YiAyarGRAM < 0)
                    {
                        pozisyonlar.MYi = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MYi).FirstOrDefault();
                    }


                    if (musteriler[i].HAS > 0)
                    {
                        pozisyonlar.MHas2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MHas2).FirstOrDefault();
                    }
                    if (musteriler[i].TL > 0)
                    {
                        pozisyonlar.MTL2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MTL2).FirstOrDefault();
                    }
                    if (musteriler[i].EURO > 0)
                    {
                        pozisyonlar.MEURO2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MEURO2).FirstOrDefault();
                    }
                    if (musteriler[i].USD > 0)
                    {
                        pozisyonlar.MUSD2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MUSD2).FirstOrDefault();
                    }
                    if (musteriler[i].CHF > 0)
                    {
                        pozisyonlar.MCHF2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MCHF2).FirstOrDefault();
                    }
                    if (musteriler[i].STRL > 0)
                    {
                        pozisyonlar.MSTRL2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MSTRL2).FirstOrDefault();
                    }
                    if (musteriler[i].ÇEYREK > 0)
                    {
                        pozisyonlar.MCeyrek2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MCeyrek2).FirstOrDefault();
                    }
                    if (musteriler[i].YiAyarGRAM > 0)
                    {
                        pozisyonlar.MYi2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.MYi2).FirstOrDefault();
                    }
                }

                for (int i = 0; i < toptancilar.Count; i++)
                {
                    if (toptancilar[i].Bakiye > 0)
                    {
                        pozisyonlar.THas = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.THas).FirstOrDefault();
                    }
                    if (toptancilar[i].TlBakiye > 0)
                    {
                        pozisyonlar.TTL = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TTL).FirstOrDefault();
                    }
                    if (toptancilar[i].EuroBakiye > 0)
                    {
                        pozisyonlar.TEURO = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TEURO).FirstOrDefault();
                    }
                    if (toptancilar[i].UsdBakiye > 0)
                    {
                        pozisyonlar.TUSD = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TUSD).FirstOrDefault();
                    }
                    if (toptancilar[i].ChfBakiye > 0)
                    {
                        pozisyonlar.TCHF = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TCHF).FirstOrDefault();
                    }
                    if (toptancilar[i].StrlBakiye > 0)
                    {
                        pozisyonlar.TSTRL = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TSTRL).FirstOrDefault();
                    }
                    if (toptancilar[i].CeyrekBakiye > 0)
                    {
                        pozisyonlar.TCeyrek = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TCeyrek).FirstOrDefault();
                    }
                    if (toptancilar[i].YiAyarBakiye > 0)
                    {
                        pozisyonlar.TYi = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TYi).FirstOrDefault();
                    }


                    if (toptancilar[i].Bakiye < 0)
                    {
                        pozisyonlar.THas2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.THas2).FirstOrDefault();
                    }
                    if (toptancilar[i].TlBakiye < 0)
                    {
                        pozisyonlar.TTL2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TTL2).FirstOrDefault();
                    }
                    if (toptancilar[i].EuroBakiye < 0)
                    {
                        pozisyonlar.TEURO2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TEURO2).FirstOrDefault();
                    }
                    if (toptancilar[i].UsdBakiye < 0)
                    {
                        pozisyonlar.TUSD2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TUSD2).FirstOrDefault();
                    }
                    if (toptancilar[i].ChfBakiye < 0)
                    {
                        pozisyonlar.TCHF2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TCHF2).FirstOrDefault();
                    }
                    if (toptancilar[i].StrlBakiye < 0)
                    {
                        pozisyonlar.TSTRL2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TSTRL2).FirstOrDefault();
                    }
                    if (toptancilar[i].CeyrekBakiye < 0)
                    {
                        pozisyonlar.TCeyrek2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TCeyrek2).FirstOrDefault();
                    }
                    if (toptancilar[i].YiAyarBakiye < 0)
                    {
                        pozisyonlar.TYi2 = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TYi2).FirstOrDefault();
                    }

                }
                pozisyonlar.ToplamCeyrekB = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamCeyrekB).FirstOrDefault();
                pozisyonlar.ToplamCHFB = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamCHFB).FirstOrDefault();
                pozisyonlar.ToplamEUROB = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamEUROB).FirstOrDefault();
                pozisyonlar.ToplamHasB = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamHasB).FirstOrDefault();
                pozisyonlar.ToplamSTRLB = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamSTRLB).FirstOrDefault();
                pozisyonlar.ToplamTLB = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamTLB).FirstOrDefault();
                pozisyonlar.ToplamUSDB = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamUSDB).FirstOrDefault();
                pozisyonlar.ToplamYiB = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamYiB).FirstOrDefault();

                pozisyonlar.ToplamCeyrekA = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamCeyrekA).FirstOrDefault();
                pozisyonlar.ToplamCHFA = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamCHFA).FirstOrDefault();
                pozisyonlar.ToplamEUROA = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamEUROA).FirstOrDefault();
                pozisyonlar.ToplamHasA = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamHasA).FirstOrDefault();
                pozisyonlar.ToplamSTRLA = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamSTRLA).FirstOrDefault();
                pozisyonlar.ToplamTLA = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamTLA).FirstOrDefault();
                pozisyonlar.ToplamUSDA = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamUSDA).FirstOrDefault();
                pozisyonlar.ToplamYiA = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.ToplamYiA).FirstOrDefault();


                pozisyonlar.AcikCHF = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.AcikCHF).FirstOrDefault();
                pozisyonlar.AcikEURO = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.AcikEURO).FirstOrDefault();
                pozisyonlar.AcikSTRL = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.AcikSTRL).FirstOrDefault();
                pozisyonlar.AcikTL = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.AcikTL).FirstOrDefault();
                pozisyonlar.AcikUSD = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.AcikUSD).FirstOrDefault();

                pozisyonlar.FazlaCHF = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.FazlaCHF).FirstOrDefault();
                pozisyonlar.FazlaEURO = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.FazlaEURO).FirstOrDefault();
                pozisyonlar.FazlaSTRL = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.FazlaSTRL).FirstOrDefault();
                pozisyonlar.FazlaTL = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.FazlaTL).FirstOrDefault();
                pozisyonlar.FazlaUSD = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.FazlaUSD).FirstOrDefault();

                List<Banka> bankalar = new List<Banka>();
                bankalar = db.Bankalar.Where(x => x.SubeAdi == poz.SubeNo).ToList();
                for (int i = 0; i < bankalar.Count; i++)
                {
                    if (bankalar[i].HesapDovizTuru == "TL")
                    {
                        pozisyonlar.TL = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.TL).FirstOrDefault();
                    }
                    else if (bankalar[i].HesapDovizTuru == "USD")
                    {
                        pozisyonlar.USD = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.USD).FirstOrDefault();
                    }
                    else if (bankalar[i].HesapDovizTuru == "EURO")
                    {
                        pozisyonlar.EURO = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.EURO).FirstOrDefault();
                    }
                    else if (bankalar[i].HesapDovizTuru == "CHF")
                    {
                        pozisyonlar.CHF = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.CHF).FirstOrDefault();
                    }
                    else if (bankalar[i].HesapDovizTuru == "STRL")
                    {
                        pozisyonlar.STRL = db.PozisyonlarDB.Where(x => x.Tarih.Day == m.Day && x.Tarih.Month == m.Month && x.Tarih.Year == m.Year).OrderByDescending(p => p.Id).Select(x => x.STRL).FirstOrDefault();
                    }
                }
                return View(pozisyonlar);
            }
            return RedirectToAction("Pozisyonlar","KuyumcuSorgu");
        }
        public ActionResult Sayim()
        {

            return View();
        }
        public ActionResult Sayim1(string barkod){
            string k = "";
            var element = db.StokKartlari.Where(x => x.StokId == barkod).FirstOrDefault();
            element.Sayim = true;
            k = element.Image;
            db.Entry(element).State = EntityState.Modified;
            db.SaveChanges();
            return Json(k);
        }
        public ActionResult Sayim2()
        {
            string k = "";
            var element = db.StokKartlari.Where(x => x.Sayim == true).ToList();
            foreach(var i in element)
            {
                i.Sayim = false;
                db.Entry(i).State = EntityState.Modified;
            }
            db.SaveChanges();
            return Json(k);
        }
    }
}

