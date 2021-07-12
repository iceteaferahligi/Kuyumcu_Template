using Kuyumcu.Data;
using Kuyumcu.Models.Kuyumcu;
using Kuyumcu.Models.Musteri_Islemleri;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Kuyumcu.Models;
using System.Data.Entity.Validation;

namespace Kuyumcu.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        public ActionResult MusteriIslemleri()
        {
            return View();
        }
        public ActionResult MusteriEkle(Musteri user)
        {
            if (user.id == 0)
            {
                user = null;
                return View(user);
            }
            else{
                return View(user);
            }
            
        }
        [HttpPost]
        public ActionResult MusteriEkle(Musteri user, string submit)
        {
            KuyumcuContext db = new KuyumcuContext();

            if (submit == "KAYDET")
            {
                if (user.DogumTarihi == Convert.ToDateTime("1.01.0001 00:00:00"))
                {
                    user.DogumTarihi = Convert.ToDateTime("1.01.1900 00:00:00");
                }
                if (user.EsDogumTarihi == Convert.ToDateTime("1.01.0001 00:00:00"))
                {
                    user.EsDogumTarihi = Convert.ToDateTime("1.01.1900 00:00:00");
                }
                if (user.EvlilikTarihi == Convert.ToDateTime("1.01.0001 00:00:00"))
                {
                    user.EvlilikTarihi = Convert.ToDateTime("1.01.1900 00:00:00");
                }
                try
                {
                    db.Musteriler.Add(user);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.message = "1";
                    return View();
                }
                catch(DbEntityValidationException dbValidationException)
                {
                    return View();
                }
            }
            
            else if(submit== "GÜNCELLE")
            {
                if (user.DogumTarihi == Convert.ToDateTime("1.01.0001 00:00:00"))
                {
                    user.DogumTarihi = Convert.ToDateTime("1.01.1900 00:00:00");
                }
                if (user.EsDogumTarihi == Convert.ToDateTime("1.01.0001 00:00:00"))
                {
                    user.EsDogumTarihi = Convert.ToDateTime("1.01.1900 00:00:00");
                }
                if (user.EvlilikTarihi == Convert.ToDateTime("1.01.0001 00:00:00"))
                {
                    user.EvlilikTarihi = Convert.ToDateTime("1.01.1900 00:00:00");
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.message = "2";
                return View();
            }
            return View();

        }
        public ActionResult MusteriBilgileri(List<StokHareket> alisveris)
        {
            KuyumcuContext db = new KuyumcuContext();

            alisveris = db.StokHareketleri.Where(x => x.MusteriAdi.Equals(null) == false).ToList();

            return View(alisveris);
        }

        [HttpPost]
        public ActionResult MusteriBilgileri(string SearchString)
        {
            KuyumcuContext db = new KuyumcuContext();

            var musteri = new List<StokHareket>();
            musteri = db.StokHareketleri.Where(x => x.MusteriAdi == SearchString).ToList();

            return View(musteri);
        }
        public ActionResult UrunIade()
        {

            IadeModel Iade = new IadeModel();
            Iade.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            return View(Iade);
        }
        [HttpPost]
        public ActionResult UrunIade2(IadeModel Iade)
        {
            var tutar = Iade.Hareket.SatisTutari;
            var Satilan = db.StokKartSatilanlar.Where(x => x.StokId == Iade.Hareket.StokId).FirstOrDefault();
            var usd = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "AMERİKAN DOLARI").FirstOrDefault();

            StokKart yeni = new StokKart();
            yeni.BirimFiyat = Satilan.BirimFiyat;
            yeni.Emanet = Satilan.Emanet;
            yeni.Fire = Satilan.Fire;
            yeni.HasNet = Satilan.HasNet;
            yeni.Hesaplama = Satilan.Hesaplama;
            yeni.Image = Satilan.Image;
            yeni.IscilikCm = Satilan.IscilikCm;
            yeni.IscilikCmG = Satilan.IscilikCmG;
            yeni.IscilikGr = Satilan.IscilikGr;
            yeni.Kar = Satilan.Kar;
            yeni.MagazaNo = Satilan.MagazaNo;
            yeni.Maliyet = Satilan.Maliyet;
            yeni.Miktar = Satilan.Miktar;
            yeni.Milyem = Satilan.Milyem;
            yeni.Ozellik1 = Satilan.Ozellik1;
            yeni.Ozellik2 = Satilan.Ozellik2;
            yeni.Ozellik3 = Satilan.Ozellik3;
            yeni.Ozellik4 = Satilan.Ozellik4;
            yeni.Ozellik5 = Satilan.Ozellik5;
            yeni.Ozellik6 = Satilan.Ozellik6;
            yeni.Ozellik7 = Satilan.Ozellik7;
            yeni.Ozellik8 = Satilan.Ozellik8;
            yeni.Ozellik9 = Satilan.Ozellik9;
            yeni.Ozellik10 = Satilan.Ozellik10;
            yeni.RafOmru = Satilan.RafOmru;
            //yeni.EtiketFiyat = Satilan.EtiketFiyati;

            if (Satilan.StokCinsi == "ALTIN")
            {
                yeni.SatisTutari = ((Satilan.BirimFiyat * Satilan.Kar) / 100) + Satilan.BirimFiyat;
            }
            else if(Satilan.Turu == "USD")
            {
                yeni.SatisTutari = Convert.ToDouble(Satilan.SatisTutari / Convert.ToDouble(usd.SatisFiyati));
            }
            yeni.Sertifika = Satilan.Sertifika;
            yeni.StokAltGrubu = Satilan.StokAltGrubu;
            yeni.StokCinsi = Satilan.StokCinsi;
            yeni.StokGrubu = Satilan.StokGrubu;
            yeni.StokId = Satilan.StokId;
            yeni.Tarih = DateTime.Now;
            yeni.ToptanciAdi = Satilan.ToptanciAdi;
            yeni.Turu = Satilan.Turu;

            Iade.Hareket.BirimFiyati = yeni.BirimFiyat;
            Iade.Hareket.FisNo = getid();
            Iade.Hareket.HareketTuru = "GİRİŞ";
            Iade.Hareket.HasNet = yeni.HasNet;
            Iade.Hareket.Hesaplama = yeni.Hesaplama;
            Iade.Hareket.IscilikCM = yeni.IscilikCm;
            Iade.Hareket.IscilikCmG = yeni.IscilikCmG;
            Iade.Hareket.IscilikGram = yeni.IscilikGr;
            Iade.Hareket.Miktar = yeni.Miktar;
            Iade.Hareket.SatisTutari = yeni.SatisTutari;
            Iade.Hareket.StokAdi = yeni.StokId;
            Iade.Hareket.StokId = yeni.StokId;
            Iade.Hareket.SubeNo = yeni.MagazaNo;
            Iade.Hareket.Tarih = DateTime.Now;
            Iade.Hareket.Turu = yeni.Turu;
            if (Iade.Hareket.HareketTipi == "Peşin Ödeme Yap")
            {
                Iade.Hareket.HareketTipi = "İADE PEŞİN ÖDEME";


                StokHareket Hareket = new StokHareket();

                Hareket.BirimFiyati = 1;
                Hareket.FisNo = Iade.Hareket.FisNo;
                Hareket.HareketTuru = "ÇIKIŞ";
                Hareket.HareketTipi = "IADE PEŞİN ÖDEME";
                Hareket.HasNet = yeni.HasNet;
                Hareket.Hesaplama = yeni.Hesaplama;
                Hareket.IscilikCM = yeni.IscilikCm;
                Hareket.IscilikCmG = yeni.IscilikCmG;
                Hareket.IscilikGram = yeni.IscilikGr;
                Hareket.Islemci = Iade.Hareket.Islemci;
                Hareket.MusteriAdi = Iade.Hareket.MusteriAdi;
                Hareket.SatisTutari = tutar;
                Hareket.Miktar = tutar;
                Hareket.Turu = "DÖVİZ";
                Hareket.StokAdi = "TÜRK LİRASI";
                Hareket.StokId = "TÜRK LİRASI";
                if (Satilan.Turu == "USD")
                {
                    Hareket.StokAdi = "AMERİKAN DOLARI";
                    Hareket.StokId = "AMERİKAN DOLARI";
                }
                Hareket.SubeNo = yeni.MagazaNo;
                Hareket.Tarih = DateTime.Now;
                Hareket.Turu = yeni.Turu;
                db.Entry(Hareket).State = EntityState.Added;
            }
            else
            {
                Iade.Hareket.HareketTipi = "İADE ALACAKLI KAYDET";
                Musteri musteri = new Musteri();
                musteri = db.Musteriler.Where(x => x.AdSoyad == Iade.Hareket.MusteriAdi).FirstOrDefault();
                if (Satilan.Turu == "USD")
                {
                    musteri.USD = musteri.USD + Satilan.SatisTutari;
                }
                else
                {
                    musteri.TL = musteri.TL + Satilan.SatisTutari;
                }
                db.Entry(musteri).State = EntityState.Modified;
            }

            db.Entry(Iade.Hareket).State = EntityState.Added;

            db.Entry(yeni).State = EntityState.Added;
            db.Entry(Satilan).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("UrunIade", "Musteri");
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
        public ActionResult UrunIade1(string barkod)
        {
            StokKartSatilan satilan = new StokKartSatilan();
            satilan = db.StokKartSatilanlar.Where(x => x.StokId == barkod).FirstOrDefault();
            string data;
            if (satilan.MusteriAdi == "" || satilan.MusteriAdi == null)
            {
                satilan.MusteriAdi = "-";
            }




            BarkodsuzStokKart kulce = new BarkodsuzStokKart();
            kulce = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "KÜLÇE ALTIN").FirstOrDefault();
            var sekayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "8 AYAR").FirstOrDefault();
            var odayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "14 AYAR").FirstOrDefault();
            var osayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "18 AYAR").FirstOrDefault();
            var yiayar = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "22 AYAR").FirstOrDefault();
            var bilezik = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == "BİLEZİK").FirstOrDefault();
            if (satilan.StokCinsi == "ALTIN" && satilan.StokGrubu == "8 AYAR" && satilan.StokId.Contains("BLZ") == false)
            {
                if (sekayar.SatisFiyati != 0)
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * sekayar.SatisFiyati);
                }
                else
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * kulce.SatisFiyati);
                }
            }
            else if (satilan.StokCinsi == "ALTIN" && satilan.StokGrubu == "14 AYAR")
            {
                if (odayar.SatisFiyati != 0)
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * odayar.SatisFiyati);
                }
                else
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * kulce.SatisFiyati);
                }
            }
            else if (satilan.StokCinsi == "ALTIN" && satilan.StokGrubu == "18 AYAR" && satilan.StokId.Contains("BLZ") == false)
            {
                if (osayar.SatisFiyati != 0)
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * osayar.SatisFiyati);
                }
                else
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * kulce.SatisFiyati);
                }
            }
            else if (satilan.StokCinsi == "ALTIN" && satilan.StokGrubu == "22 AYAR" && satilan.StokId.Contains("BLZ") == false)
            {
                if (yiayar.SatisFiyati != 0)
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * yiayar.SatisFiyati);
                }
                else
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * kulce.SatisFiyati);
                }
            }
            else if (satilan.StokCinsi == "ALTIN" && satilan.StokId.Contains("BLZ") == true)
            {
                if (bilezik.SatisFiyati != 0)
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * bilezik.SatisFiyati);
                }
                else
                {
                    satilan.Maliyet = Convert.ToDouble((((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat) * kulce.SatisFiyati);
                }
            }
            if(satilan.Turu == "USD")
            {
                satilan.SatisTutari = ((satilan.BirimFiyat * satilan.Kar) / 100) + satilan.BirimFiyat;
            }

            data = satilan.SatisTutari + ", " + satilan.Maliyet + ", " + satilan.MusteriAdi;
            return Json(data);
        }
        Kuyumcu.Data.KuyumcuContext db = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult IadeGridViewPartial()
        {
            var model = db.StokKartSatilanlar;
            return PartialView("_IadeGridViewPartial", model.ToList());
        }

        public ActionResult MusteriDuzenle()
        {

            KuyumcuContext kuyumcuContext = new KuyumcuContext();
            List<Musteri> musteris;
            musteris = kuyumcuContext.Musteriler.ToList();
            return View(musteris);
        }
       
        [HttpPost]
        public ActionResult MusteriDuzenle(string submit,string searchString)
        {
            //KuyumcuContext kuyumcuContext = new KuyumcuContext();
            KuyumcuContext db = new KuyumcuContext();
            

            if (submit.Equals("ara"))
            {
                List<Musteri> musteris = new List<Musteri>();
                musteris = db.Musteriler.Where(m => m.AdSoyad.StartsWith(searchString)).ToList();
                return View(musteris);
                
            }
            else
            {
                int id = Int32.Parse(submit);
               
                var musteri = db.Musteriler.Where(m => m.id == id).ToList();
                Musteri a = musteri[0];
                return RedirectToAction("MusteriEkle","Musteri",a);
            }
            
            
        }
    }
}