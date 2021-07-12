using Kuyumcu.Data;
using Kuyumcu.Models;
using Kuyumcu.Models.Finans;
using Kuyumcu.Models.Kuyumcu;
using Kuyumcu.Models.Personel_Takip;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Kuyumcu.Models.Musteri_Islemleri;

namespace Kuyumcu.Controllers
{
    public class FinansController : Controller
    {
        // GET: Finans
        KuyumcuContext db = new KuyumcuContext();
        public static string temp;

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Onay()
        {
            return View();
        }
        public ActionResult BankaTanim(Banka arananBanka, string hesapNo)
        {
            List<Banka> banka = new List<Banka>();
            banka = db.Bankalar.ToList();
            OzelBanka model = new OzelBanka();
            model.Banka = banka;
            model.Bank = arananBanka;
            model.HesapNo = model.Bank.HesapNumarasi;
            return View(model);
        }

        [HttpPost]
        public ActionResult BankaTanim(OzelBanka banka, string submit, string hesapNo)
        {
            if (submit == "ARA")
            {
                var arananbanka = db.Bankalar.Where(x => x.HesapNumarasi == hesapNo).FirstOrDefault();
                return RedirectToAction("BankaTanim", "Finans", arananbanka);
            }
            else if (submit == "KAYDET")
            {
                Banka Yenibanka = new Banka();
                Yenibanka = banka.Bank;
                db.Bankalar.Add(Yenibanka);
                db.SaveChanges();
                return RedirectToAction("BankaTanim");
            }
            else if (submit == "DÜZENLE")
            {
                Banka arananbanka = db.Bankalar.Where(x => x.HesapNumarasi == hesapNo).FirstOrDefault();
                arananbanka.BankaAciklama = banka.Bank.BankaAciklama;
                arananbanka.BankaAdi = banka.Bank.BankaAdi;
                arananbanka.BankaSubeAdi = banka.Bank.BankaSubeAdi;
                arananbanka.BankaTelefon = banka.Bank.BankaTelefon;
                arananbanka.EsnekBakiyeLimiti = banka.Bank.EsnekBakiyeLimiti;
                arananbanka.FaxNo = banka.Bank.FaxNo;
                arananbanka.HesapDovizTuru = banka.Bank.HesapDovizTuru;
                arananbanka.HesapNumarasi = banka.Bank.HesapNumarasi;

                arananbanka.SubeAdi = banka.Bank.SubeAdi;

                db.Entry(arananbanka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BankaTanim");
            }
            else if (submit == "SİL")
            {
                Banka arananbanka = new Banka();
                try
                {
                    arananbanka = db.Bankalar.Where(x => x.HesapNumarasi == banka.Bank.HesapNumarasi).FirstOrDefault();
                    db.Bankalar.Remove(arananbanka);
                    db.SaveChanges();
                }
                catch { }

                return RedirectToAction("BankaTanim");
            }
            else
                return RedirectToAction("BankaTanim");
        }
        public ActionResult KomisyonTanim(Banka arananBanka, string hesapNo)
        {
            List<Banka> banka = new List<Banka>();
            banka = db.Bankalar.ToList();
            OzelBanka model = new OzelBanka();
            model.Banka = banka;
            model.Bank = arananBanka;
            model.HesapNo = model.Bank.HesapNumarasi;
            model.Hesaplar = db.Bankalar.Select(x => x.HesapNumarasi).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult KomisyonTanim1(string banka)
        {
            OzelBanka temp = new OzelBanka();
            KuyumcuContext db = new KuyumcuContext();
            temp.Hesaplar = db.Bankalar.Where(y => y.BankaAdi == banka).Select(x => x.HesapNumarasi).Distinct().ToList();
            return Json(temp.Hesaplar);
        }
        [HttpPost]
        public ActionResult KomisyonTanim2(OzelBanka HesapKomisyon)
        {
            KuyumcuContext db = new KuyumcuContext();
            db.Komisyonlar.Add(HesapKomisyon.Komisyon);
            db.SaveChanges();
            return RedirectToAction("KomisyonTanim", "Finans");
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


        public ActionResult Gelir_Gider()
        {
            OzelBanka Model = new OzelBanka();
            Model.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            Model.KasaAdi = db.Kasalar.Select(x => x.KasaAdi).ToList();
            Model.Fisno = getid();
            Model.GelirAc = db.GelirGiderKalemleri.Where(x => x.Tip == "GELİR").Select(y => y.Aciklama).ToList();
            Model.GiderAc = db.GelirGiderKalemleri.Where(x => x.Tip == "GİDER").Select(y => y.Aciklama).ToList();
            Model.TL = Convert.ToDouble(db.Kasalar.Where(x => x.DovizTuru == "TL").Select(y => y.BaslangicBakiye).FirstOrDefault());
            return View(Model);
        }
        [HttpPost]
        public ActionResult Gelir_Gider(OzelBanka Model, string submit,string yeniGelirKalem,OzelBanka ekleme)
        {

            if (submit == "GELİR EKLE")
            {
                Model.Hareket1.FisNo = Model.Fisno;
                Model.Hareket1.Hesaplama = "Adet";
                Model.Hareket1.SatisTutari = Model.Hareket1.Miktar;
                Model.Hareket1.HareketTuru = "GİRİŞ";
                Model.Hareket1.HareketTipi = "EK GELİR GİRİŞİ";
                db.StokHareketleri.Add(Model.Hareket1);
                ekleme.gelirEkle.Tip = "GELİR";                
                db.Entry(ekleme.gelirEkle).State = EntityState.Added;                
                db.SaveChanges();

                return RedirectToAction("Gelir_Gider", "Finans");
            }
            else
            {
                Model.Hareket2.FisNo = Model.Fisno;
                Model.Hareket2.Hesaplama = "Adet";
                Model.Hareket2.SatisTutari = Model.Hareket2.Miktar;
                Model.Hareket2.HareketTuru = "ÇIKIŞ";
                Model.Hareket2.HareketTipi = "EK GİDER ÇIKIŞI";
                db.StokHareketleri.Add(Model.Hareket2);
                ekleme.giderEkle.Tip = "GİDER";
                db.Entry(ekleme.giderEkle).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("Gelir_Gider", "Finans");
            }
        }
        [HttpPost]
        public ActionResult Gelir_Gider1(string KasaAdi)
        {
            var data = db.Kasalar.Where(x => x.KasaAdi == KasaAdi).Select(y => y.DovizTuru);
            return Json(data);
        }

        public ActionResult Kasa()
        {
            KuyumcuContext db = new KuyumcuContext();
            OzelBanka Model = new OzelBanka();
            Model.Kasalar = db.Kasalar.ToList();

            return View(Model);
        }
        [HttpPost]
        public ActionResult Kasa1(OzelBanka kasa)
        {
            KuyumcuContext db = new KuyumcuContext();
            db.Entry(kasa.ekle).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Kasa","Finans");
        }


        Kuyumcu.Data.KuyumcuContext db1 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db1.StokHareketleri.Where(x => x.HareketTipi == "EK GELİR GİRİŞİ");
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(Kuyumcu.Models.Kuyumcu.StokHareket item)
        {
            var model = db1.StokHareketleri;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.Where(x => x.HareketTipi == "EK GELİR GİRİŞİ").ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Kuyumcu.Models.Kuyumcu.StokHareket item)
        {
            var model = db1.StokHareketleri;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.IslemNo == item.IslemNo);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db1.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.Where(x => x.HareketTipi == "EK GELİR GİRİŞİ").ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 IslemNo)
        {
            var model = db1.StokHareketleri;
            if (IslemNo >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.IslemNo == IslemNo);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.Where(x => x.HareketTipi == "EK GELİR GİRİŞİ").ToList());
        }

        Kuyumcu.Data.KuyumcuContext db2 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridGiderPartial()
        {
            var model = db2.StokHareketleri.Where(x => x.HareketTipi == "EK GİDER ÇIKIŞI");
            return PartialView("_GridGiderPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridGiderPartialAddNew(Kuyumcu.Models.Kuyumcu.StokHareket item)
        {
            var model = db2.StokHareketleri;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db2.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridGiderPartial", model.Where(x => x.HareketTipi == "EK GİDER ÇIKIŞI").ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridGiderPartialUpdate(Kuyumcu.Models.Kuyumcu.StokHareket item)
        {
            var model = db2.StokHareketleri;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.IslemNo == item.IslemNo);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db2.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridGiderPartial", model.Where(x => x.HareketTipi == "EK GİDER ÇIKIŞI").ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridGiderPartialDelete(System.Int32 IslemNo)
        {
            var model = db2.StokHareketleri;
            if (IslemNo >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.IslemNo == IslemNo);
                    if (item != null)
                        model.Remove(item);
                    db2.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridGiderPartial", model.Where(x => x.HareketTipi == "EK GİDER ÇIKIŞI").ToList());
        }

        Kuyumcu.Data.KuyumcuContext db3 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridBankaTanimPartial()
        {
            var model = db3.Bankalar;
            return PartialView("_GridBankaTanimPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridBankaTanimPartialAddNew(Kuyumcu.Models.Finans.Banka item)
        {
            var model = db3.Bankalar;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db3.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridBankaTanimPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridBankaTanimPartialUpdate(Kuyumcu.Models.Finans.Banka item)
        {
            var model = db3.Bankalar;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db3.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridBankaTanimPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridBankaTanimPartialDelete(System.Int32 Id)
        {
            var model = db3.Bankalar;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db3.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridBankaTanimPartial", model.ToList());
        }

        Kuyumcu.Data.KuyumcuContext db4 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridKomisyonPartial()
        {
            var model = db4.Komisyonlar;
            return PartialView("_GridKomisyonPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridKomisyonPartialAddNew(Kuyumcu.Models.Finans.KomisyonTanim item)
        {
            var model = db4.Komisyonlar;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db4.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridKomisyonPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridKomisyonPartialUpdate(Kuyumcu.Models.Finans.KomisyonTanim item)
        {
            var model = db4.Komisyonlar;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db4.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridKomisyonPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridKomisyonPartialDelete(System.Int32 Id)
        {
            var model = db4.Komisyonlar;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db4.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridKomisyonPartial", model.ToList());
        }

        Kuyumcu.Data.KuyumcuContext db5 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridKasaPartial()
        {
            var model = db5.Kasalar;
            return PartialView("_GridKasaPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridKasaPartialAddNew(Kuyumcu.Models.Finans.Kasa item)
        {
            var model = db5.Kasalar;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db5.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridKasaPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridKasaPartialUpdate(Kuyumcu.Models.Finans.Kasa item)
        {
            var model = db5.Kasalar;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db5.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridKasaPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridKasaPartialDelete(System.Int32 Id)
        {
            var model = db5.Kasalar;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db5.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridKasaPartial", model.ToList());
        }
        public ActionResult BankaIslemleri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BankaIslemleri1(int islemno)
        {
            StokHareket hareket = new StokHareket();
            KomisyonTanim kt = new KomisyonTanim();
           
            hareket = db.StokHareketleri.Where(x => x.IslemNo == islemno).FirstOrDefault();
            string data;
            if (hareket.MusteriAdi == "" || hareket.MusteriAdi == null)
            {
                hareket.MusteriAdi = "-";
            }
          
            kt.Komisyon = db.Komisyonlar.Where(x => x.Taksit == hareket.Taksit && x.BankaAdi.Equals(hareket.StokAdi)).Select(x => x.Komisyon).FirstOrDefault();

            data = hareket.FisNo + ", " + hareket.Tarih + ", " + hareket.StokAdi + ", " + hareket.MusteriAdi + ", " + kt.Komisyon +
                ", " + /*hareket.KomisyonOrani + ", " +*/ Math.Round(Convert.ToDouble(hareket.SatisTutari * kt.Komisyon / 100), 3) + ", " + hareket.SatisTutari; /*+ ", "*/
                                                                                                                                                         /*+ hareket.SatisTutari;*/


            return Json(data);
        }
        [HttpPost]
        public ActionResult BankaIslemleri2(int islemno, bool radiobtn)
        {
            StokHareket hareket = new StokHareket();
            KomisyonTanim kt = new KomisyonTanim();
            hareket = db.StokHareketleri.Where(x => x.IslemNo == islemno).FirstOrDefault();
            hareket.Onay = true;
            db.Entry(hareket).State = EntityState.Modified;
            db.SaveChanges();

            Banka banka = new Banka();
            banka = db.Bankalar.Where(x => x.BankaAdi == hareket.StokAdi && x.SubeAdi == hareket.SubeNo && x.HesapDovizTuru == "TL").FirstOrDefault();

            kt.Komisyon = db.Komisyonlar.Where(x => x.Taksit == hareket.Taksit && x.BankaAdi.Equals(hareket.StokAdi)).Select(x => x.Komisyon).FirstOrDefault();

            double? komisyonTutari = Math.Round(Convert.ToDouble((hareket.SatisTutari * kt.Komisyon) / 100), 3);

            
            if (radiobtn == true)
            {         
                banka.Bakiye = banka.Bakiye + hareket.SatisTutari - komisyonTutari;
            }
            else
            {
                banka.Bakiye = banka.Bakiye + hareket.SatisTutari;
            }

            
            db.Entry(banka).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("BankaIslemleri", "Finans");
        }

        Kuyumcu.Data.KuyumcuContext db6 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridBankaIslemPartial()
        {

            var model = db6.StokHareketleri.Where(x => x.Turu == "BANKA" && x.Onay == false);
            return PartialView("_GridBankaIslemPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridBankaIslemPartialAddNew(Kuyumcu.Models.Kuyumcu.StokHareket item)
        {
            var model = db6.StokHareketleri;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db6.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridBankaIslemPartial", model.Where(x => x.Turu == "BANKA" && x.Onay == false).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridBankaIslemPartialUpdate(Kuyumcu.Models.Kuyumcu.StokHareket item)
        {
            var model = db6.StokHareketleri;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.IslemNo == item.IslemNo);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db6.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridBankaIslemPartial", model.Where(x => x.Turu == "BANKA" && x.Onay == false).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridBankaIslemPartialDelete(System.Int32 IslemNo)
        {
            var model = db6.StokHareketleri;
            if (IslemNo >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.IslemNo == IslemNo);
                    if (item != null)
                        model.Remove(item);
                    db6.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridBankaIslemPartial", model.Where(x => x.Turu == "BANKA" && x.Onay == false).ToList());
        }

        Kuyumcu.Data.KuyumcuContext db7 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridBankaBakiyePartial()
        {
            var model = db7.Bankalar;
            return PartialView("_GridBankaBakiyePartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridBankaBakiyePartialAddNew(Kuyumcu.Models.Finans.Banka item)
        {
            var model = db7.Bankalar;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db7.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridBankaBakiyePartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridBankaBakiyePartialUpdate(Kuyumcu.Models.Finans.Banka item)
        {
            var model = db7.Bankalar;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db7.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridBankaBakiyePartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridBankaBakiyePartialDelete(System.Int32 Id)
        {
            var model = db7.Bankalar;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db7.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridBankaBakiyePartial", model.ToList());
        }

        Kuyumcu.Data.KuyumcuContext db9 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridFaturaPartial()
        {
            var model = db9.Faturalar;
            return PartialView("_GridFaturaPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridFaturaPartialAddNew(Kuyumcu.Models.Finans.Fatura item)
        {
            var model = db9.Faturalar;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db9.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridFaturaPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridFaturaPartialUpdate(Kuyumcu.Models.Finans.Fatura item)
        {
            var model = db9.Faturalar;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.FisNo == item.FisNo);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db9.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridFaturaPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridFaturaPartialDelete(System.Int32 Id)
        {
            var model = db9.Faturalar;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db9.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridFaturaPartial", model.ToList());
        }

        Kuyumcu.Data.KuyumcuContext db10 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridFaturaDetayPartialPartial(int? FisNo)
        {
            //string FisNo = Request.Params["FisNo"];
            ViewData["FisNo"] = FisNo;

            if (FisNo != null)
            {
                var model = db10.StokHareketleri.Where(z => z.FisNo == FisNo);
                return PartialView("_GridFaturaDetayPartialPartial", model.ToList());
            }
            else
            {
                //Do nothing
                return null;
            }
            //else
            //{
            //    var model = db10.StokHareketleri;
            //    return PartialView("_GridFaturaDetayPartialPartial", model.ToList());
            //}

        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridFaturaDetayPartialPartialAddNew(Kuyumcu.Models.Kuyumcu.StokHareket item, int? FisNo)
        {
            ViewData["FisNo"] = FisNo;

            var model = db10.StokHareketleri;
            if (ModelState.IsValid)
            {
                try
                {
                   
                    model.Add(item);
                    db10.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridFaturaDetayPartialPartial", model.Where(x => x.FisNo == FisNo).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridFaturaDetayPartialPartialUpdate(Kuyumcu.Models.Kuyumcu.StokHareket item, int? FisNo)
        {
            ViewData["FisNo"] = FisNo;
            var model = db10.StokHareketleri;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.IslemNo == item.IslemNo);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db10.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";            
            return PartialView("_GridFaturaDetayPartialPartial", model.Where(x => x.FisNo == FisNo).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridFaturaDetayPartialPartialDelete(System.Int32 IslemNo, int? FisNo)
        {
            ViewData["FisNo"] = FisNo;
            var model = db10.StokHareketleri;
            
            if (IslemNo >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.IslemNo == IslemNo);
                    
                    if (item!= null)
                        model.Remove(item);
                    db10.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridFaturaDetayPartialPartial", model.Where(x=>x.FisNo == FisNo).ToList());
        }

        public ActionResult BankadanOdeme()
        {
            OzelBanka Model = new OzelBanka();
            StokHareket hareket = new StokHareket();

            hareket.Tarih = DateTime.Now;
            Model.Hareket1 = hareket;
            Model.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            Model.KasaAdi = db.Kasalar.Where(x => x.SubeNo == "NO1").Select(x => x.KasaAdi).ToList();
            Model.Fisno = getid();
            Model.GelirAc = db.GelirGiderKalemleri.Where(x => x.Tip == "GELİR").Select(y => y.Aciklama).ToList();
            Model.GiderAc = db.GelirGiderKalemleri.Where(x => x.Tip == "GİDER").Select(y => y.Aciklama).ToList();
            //Model.Musteriler = db.Musteriler.OrderBy(y => y.AdSoyad).Select(x => x.AdSoyad).ToList();
            Model.Bankalar = db.Bankalar.Select(x => x.BankaAdi).Distinct().ToList();
            Model.DovizTuru = db.Bankalar.Select(x => x.HesapDovizTuru).Distinct().ToList();
            return View(Model);
        }
        [HttpPost]
        public ActionResult BankadanOdeme(OzelBanka banka)
        {
            if (banka.Hareket1.HareketTipi == "Kasadan Bankaya Para Aktarımı")
            {
                banka.Hareket1.Hesaplama = "Adet";
                banka.Hareket1.StokAdi = banka.Hareket1.StokId;
                banka.Hareket1.Miktar = banka.Toplam;
                banka.Hareket1.SatisTutari = banka.Toplam;
                banka.Hareket1.HareketTuru = "Banka Giriş";
                banka.Hareket1.FisNo = getid();
                banka.Hareket1.Onay = false;
                banka.Hareket1.Turu = "KASA-BANKA";
                

                Kasa kasa = new Kasa();
                kasa = db.Kasalar.Where(x => x.KasaAdi == banka.Hareket1.StokId && x.SubeNo == banka.Hareket1.SubeNo).FirstOrDefault();
                kasa.BaslangicBakiye = Math.Round(Convert.ToDouble(kasa.BaslangicBakiye - banka.Toplam), 3);
                Banka hesap = new Banka();
                hesap = db.Bankalar.Where(x => x.HesapNumarasi == banka.Bank.HesapNumarasi).FirstOrDefault();
                hesap.Bakiye = Math.Round(Convert.ToDouble(hesap.Bakiye + banka.Toplam), 3);
                db.StokHareketleri.Add(banka.Hareket1);
                db.Entry(kasa).State = EntityState.Modified;
                db.Entry(hesap).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (banka.Hareket1.HareketTipi == "Müşteri Hesabından hesabımıza Havale")
            {
                banka.Hareket1.Hesaplama = "Adet";
                banka.Hareket1.Miktar = banka.Toplam;
                banka.Hareket1.StokAdi = banka.Hareket1.StokId;
                banka.Hareket1.FisNo = getid();
                banka.Hareket1.SatisTutari = banka.Toplam;
                banka.Hareket1.HareketTuru = "Banka Giriş";
                banka.Hareket1.Onay = false;
                banka.Hareket1.Turu = "MÜŞTERİ-BANKA";


                Banka hesap = new Banka();
                hesap = db.Bankalar.Where(x => x.HesapNumarasi == banka.Bank.HesapNumarasi).FirstOrDefault();
                hesap.Bakiye = Math.Round(Convert.ToDouble(hesap.Bakiye + banka.Toplam), 3);
                db.StokHareketleri.Add(banka.Hareket1);
                db.Entry(hesap).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (banka.Hareket1.HareketTipi == "Bankadan Gidere Ödeme")
            {
                banka.Hareket1.Hesaplama = "Adet";
                banka.Hareket1.Miktar = banka.Toplam;
                banka.Hareket1.StokAdi = banka.Hareket1.StokId;
                banka.Hareket1.FisNo = getid();
                banka.Hareket1.SatisTutari = banka.Toplam;
                banka.Hareket1.HareketTuru = "Banka Çıkış";
                banka.Hareket1.Onay = false;
                banka.Hareket1.Turu = "BANKA-GİDER";


                Banka hesap = new Banka();
                hesap = db.Bankalar.Where(x => x.HesapNumarasi == banka.Bank.HesapNumarasi).FirstOrDefault();
                hesap.Bakiye = Math.Round(Convert.ToDouble(hesap.Bakiye - banka.Toplam), 3);
                db.StokHareketleri.Add(banka.Hareket1);
                db.Entry(hesap).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (banka.Hareket1.HareketTipi == "Bankadan Cariye Ödeme")
            {
                banka.Hareket1.Hesaplama = "Adet";
                banka.Hareket1.Miktar = banka.Toplam;
                banka.Hareket1.StokAdi = banka.Hareket1.StokId;
                banka.Hareket1.SatisTutari = banka.Toplam;
                banka.Hareket1.HareketTuru = "Banka Çıkış";
                banka.Hareket1.FisNo = getid();
                banka.Hareket1.Onay = false;
                banka.Hareket1.Turu = "BANKA-CARİ";


                Banka hesap = new Banka();
                hesap = db.Bankalar.Where(x => x.HesapNumarasi == banka.Bank.HesapNumarasi).FirstOrDefault();
                hesap.Bakiye = Math.Round(Convert.ToDouble(hesap.Bakiye - banka.Toplam), 3);
                db.StokHareketleri.Add(banka.Hareket1);
                db.Entry(hesap).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (banka.Hareket1.HareketTipi == "Bankadan Toptancıya Ödeme")
            {
                banka.Hareket1.Hesaplama = "Adet";
                banka.Hareket1.Miktar = banka.Toplam;
                banka.Hareket1.StokAdi = banka.Hareket1.StokId;
                banka.Hareket1.FisNo = getid();
                banka.Hareket1.SatisTutari = banka.Toplam;
                banka.Hareket1.HareketTuru = "Banka Çıkış";
                banka.Hareket1.Onay = false;
                banka.Hareket1.Turu = "BANKA-TOPTANCI";


                Banka hesap = new Banka();
                hesap = db.Bankalar.Where(x => x.HesapNumarasi == banka.Bank.HesapNumarasi).FirstOrDefault();
                hesap.Bakiye = Math.Round(Convert.ToDouble(hesap.Bakiye - banka.Toplam), 3);
                db.StokHareketleri.Add(banka.Hareket1);
                db.Entry(hesap).State = EntityState.Modified;
                db.SaveChanges();
            }
            else if (banka.Hareket1.HareketTipi == "Bankadan Üreticiye Ödeme")
            {
                banka.Hareket1.Hesaplama = "Adet";
                banka.Hareket1.Miktar = banka.Toplam;
                banka.Hareket1.StokAdi = banka.Hareket1.StokId;
                banka.Hareket1.FisNo = getid();
                banka.Hareket1.SatisTutari = banka.Toplam;
                banka.Hareket1.HareketTuru = "Banka Çıkış";
                banka.Hareket1.Onay = false;
                banka.Hareket1.Turu = "BANKA-ÜRETİCİ";


                Banka hesap = new Banka();
                hesap = db.Bankalar.Where(x => x.HesapNumarasi == banka.Bank.HesapNumarasi).FirstOrDefault();
                hesap.Bakiye = Math.Round(Convert.ToDouble(hesap.Bakiye - banka.Toplam), 3);
                db.StokHareketleri.Add(banka.Hareket1);
                db.Entry(hesap).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("BankadanOdeme", "Finans");
        }
        [HttpPost]
        public ActionResult BankadanOdeme1(string BankaAdi)
        {
            OzelBanka Model = new OzelBanka();
            Model.DovizTuru = db.Bankalar.Where(y => y.BankaAdi == BankaAdi).Select(x => x.HesapDovizTuru).Distinct().ToList();
            return Json(Model.DovizTuru);
        }
        [HttpPost]
        public ActionResult BankadanOdeme2(string SubeNo)
        {
            OzelBanka Model = new OzelBanka();
            Model.DovizTuru = db.Kasalar.Where(y => y.SubeNo == SubeNo).Select(x => x.DovizTuru).ToList();
            return Json(Model.DovizTuru);
        }
        [HttpPost]
        public ActionResult BankadanOdeme3(string subeadi, string dovizturu, string bankaAdi)
        {
            OzelBanka Model = new OzelBanka();
            string hesapno;
            hesapno = db.Bankalar.Where(y => y.SubeAdi == subeadi && y.HesapDovizTuru == dovizturu && y.BankaAdi == bankaAdi).Select(x => x.HesapNumarasi).FirstOrDefault();
            return Json(hesapno);
        }

        public ActionResult ToptanciAlim()
        {
            Toptancilar toptancilar = new Toptancilar();
            ToptanciHareket hareket = new ToptanciHareket();

            hareket.Tarih = DateTime.Now;
            toptancilar.Hareket = hareket;
            toptancilar.liste = db.Toptancilar.Where(y => y.MagazaNo == "NO1").Select(x => x.ToptanciAdi).ToList();
            toptancilar.Milyemler = db.Cins.Select(x => x.Milyem).Distinct().ToList();
            toptancilar.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            return View(toptancilar);
        }
        [HttpPost]
        public ActionResult ToptanciAlim1(string ToptanciAdi, string subeno)
        {
            string data = "";
            Toptanci toptanci = new Toptanci();
            toptanci = db.Toptancilar.Where(x => x.ToptanciAdi == ToptanciAdi && x.MagazaNo == subeno).FirstOrDefault();
            data = toptanci.Bakiye + ", " + toptanci.TlBakiye + ", " + toptanci.EuroBakiye + ", " + toptanci.UsdBakiye + ", " + toptanci.ChfBakiye + ", " + toptanci.StrlBakiye + ", " + toptanci.CeyrekBakiye + ", " + toptanci.YiAyarBakiye;

            return Json(data);
        }
        [HttpPost]
        public ActionResult ToptanciAlim2(Toptancilar x, string submit)
        {
            int? id;
            KuyumcuContext db = new KuyumcuContext();
            try
            {
                id = (from a in db.ToptanciHareketler
                      select a.id).Max();
            }
            catch
            {
                id = 1;
                id = id + 1;
            }


            x.Hareket.FisNo = "TA" + id;
            x.Hareket.HareketTuru = "TOPTANCI ALIM";
            x.Hareket.ToptanciiAdi = x.toptanci.ToptanciAdi;
            db.ToptanciHareketler.Add(x.Hareket);

            Toptanci toptanci = new Toptanci();
            BarkodsuzStokKart bsk = new BarkodsuzStokKart();

            //toptanci = db.Toptancilar.Where(y => y.ToptanciAdi == x.toptanci.ToptanciAdi && y.Durum == true).FirstOrDefault();
            toptanci = db.Toptancilar.Where(y => y.ToptanciAdi == x.toptanci.ToptanciAdi).FirstOrDefault();


            bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == x.Hareket.StokId).FirstOrDefault();

            if (x.Hareket.Turu == "HAS")
            {
                toptanci.Bakiye = Convert.ToDouble(toptanci.Bakiye + x.Hareket.ToplamHas);
            }
            else if (x.Hareket.Turu == "USD")
            {
                toptanci.UsdBakiye = Convert.ToDouble(toptanci.UsdBakiye + x.Hareket.ToplamHas);
            }
            else if (x.Hareket.Turu == "TL")
            {
                toptanci.TlBakiye = Convert.ToDouble(toptanci.TlBakiye + x.Hareket.ToplamHas);
            }
            else if (x.Hareket.Turu == "EURO")
            {
                toptanci.EuroBakiye = Convert.ToDouble(toptanci.EuroBakiye + x.Hareket.ToplamHas);
            }
            else if (x.Hareket.Turu == "CHF")
            {
                toptanci.ChfBakiye = Convert.ToDouble(toptanci.ChfBakiye + x.Hareket.ToplamHas);
            }
            else if (x.Hareket.Turu == "STRL")
            {
                toptanci.StrlBakiye = Convert.ToDouble(toptanci.StrlBakiye + x.Hareket.ToplamHas);
            }
            else if (x.Hareket.Turu == "ÇEYREK")
            {
                toptanci.CeyrekBakiye = Convert.ToDouble(toptanci.CeyrekBakiye + x.Hareket.ToplamHas);
            }
            else if (x.Hareket.Turu == "22 AYAR")
            {
                toptanci.YiAyarBakiye = Convert.ToDouble(toptanci.YiAyarBakiye + x.Hareket.ToplamHas);
            
            }
            if (x.Hareket.StokId == "KÜLÇE ALTIN")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar - x.Hareket.Miktar);

            }
            else if (x.Hareket.StokId == "AMERİKAN DOLARI")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);

            }
            else if (x.Hareket.StokId == "TÜRK LİRASI")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);

            }
            else if (x.Hareket.StokId == "EURO")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);

            }
            else if (x.Hareket.StokId == "İSVİÇRE FRANGI")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);

            }
            else if (x.Hareket.StokId == "İNGİLİZ STERLİNİ")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);

            }
            else if (x.Hareket.StokId == "ÇEYREK")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);

            }
            else if (x.Hareket.StokId == "22 AYAR GRAM")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "YARIM")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "ATATEK")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "2.5'LU")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "C.LİRA")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "24 AYAR GRAM")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "HAMİT LİRA")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "REŞAT BEŞLİ")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "HAMİT BEŞLİ")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "CUMHURİYET BEŞLİ")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "REŞAT İKİBUÇUKLU")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "BİLEZİK")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "8 AYAR")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "14 AYAR")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "18 AYAR")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "22 AYAR")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "8 HURDA")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "14 HURDA")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "18 HURDA")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "21 HURDA")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "22 HURDA")
            {
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if(x.Hareket.StokId == "14 Muhtelif")
            {
                bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == "14 AYAR").FirstOrDefault();
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "18 Muhtelif")
            {
                bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == "18 AYAR").FirstOrDefault();
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "21 Muhtelif")
            {
                bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == "21 AYAR").FirstOrDefault();
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "22 Muhtelif")
            {
                bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == "22 AYAR").FirstOrDefault();
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "İnci Muhtelif")
            {
                bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == "İNCİ").FirstOrDefault();
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "Saat Muhtelif")
            {
                bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == "SAAT").FirstOrDefault();
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "Çelik Muhtelif")
            {
                bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == "ÇELİK").FirstOrDefault();
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "Pırlanta Muhtelif")
            {
                bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == "PIRLANTA").FirstOrDefault();
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }
            else if (x.Hareket.StokId == "Gümüş Muhtelif")
            {
                bsk = db.BarkodsuzStokKartlari.Where(k => k.StokCinsi == "GÜMÜŞ").FirstOrDefault();
                bsk.Miktar = Convert.ToDouble(bsk.Miktar + x.Hareket.Miktar);
            }



            db.Entry(toptanci).State = EntityState.Modified;
            db.Entry(bsk).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ToptanciAlim", "Finans");
        }

        [HttpPost]
        public ActionResult ToptanciAlim3(string magaza)
        {
            Toptancilar toptancilar = new Toptancilar();
            toptancilar.liste = db.Toptancilar.Where(z => z.MagazaNo == magaza).OrderBy(y => y.ToptanciAdi).Select(x => x.ToptanciAdi).ToList();
            return Json(toptancilar.liste);
        }
        [HttpPost] 
        public ActionResult ToptanciAlim4(string stokid)
        {
            BarkodsuzStokKart bsk = new BarkodsuzStokKart();
            bsk.SatisFiyati = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == stokid).Select(y => y.SatisFiyati).FirstOrDefault();
            return Json(bsk.SatisFiyati);
        }


        public ActionResult ToptanciyaOdeme()
        {
            Toptancilar toptanci = new Toptancilar();
            ToptanciHareket hareket = new ToptanciHareket();

            hareket.Tarih = DateTime.Now;
            toptanci.Hareket = hareket;
            toptanci.UrunKodu = db.BarkodsuzStokKartlari.Select(x => x.StokCinsi).ToList();
            toptanci.liste = db.Toptancilar.Where(y => y.MagazaNo == "NO1").Select(x => x.ToptanciAdi).ToList();
            toptanci.Milyemler = db.Cins.Select(x => x.Milyem).Distinct().ToList();
            toptanci.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            return View(toptanci);
        }
        [HttpPost]
        public ActionResult ToptanciyaOdeme1(Toptancilar x)
        {
            int? id;
            KuyumcuContext db = new KuyumcuContext();
            try
            {
                id = (from a in db.ToptanciHareketler
                      select a.id).Max();
            }
            catch
            {
                id = 1;
                id = id + 1;
            }


            x.Hareket.FisNo = "TO" + id;
            x.Hareket.HareketTuru = "TOPTANCIYA ÖDEME";
            x.Hareket.ToptanciiAdi = x.toptanci.ToptanciAdi;
            db.ToptanciHareketler.Add(x.Hareket);
            BarkodsuzStokKart Barkodsuz = new BarkodsuzStokKart();
            //barkodsuzstok stok = new barkodsuzstok();
            Kasa kasa = new Kasa();
            Toptanci toptanci = new Toptanci();
            
            toptanci = db.Toptancilar.Where(y => y.ToptanciAdi == x.toptanci.ToptanciAdi && y.Durum == true && y.MagazaNo == x.Hareket.SubeNo).FirstOrDefault();
            //Barkodsuz.Miktar = db.BarkodsuzStokKartlari.Where(y => y.StokCinsi == x.Hareket.StokId).Select(y => y.Miktar).FirstOrDefault();
            

            if (x.Hareket.Turu == "HAS")
            {
                toptanci.Bakiye = Convert.ToDouble(toptanci.Bakiye - x.Hareket.ToplamHas);
                Barkodsuz = db.BarkodsuzStokKartlari.Where(y => y.StokCinsi == "KÜLÇE ALTIN").FirstOrDefault();
                Barkodsuz.Miktar = Barkodsuz.Miktar - x.Hareket.ToplamHas;
                kasa = db.Kasalar.Where(z => z.DovizTuru == x.Hareket.Turu).FirstOrDefault();

                try
                {
                    kasa.BaslangicBakiye = kasa.BaslangicBakiye - Convert.ToDouble(x.Hareket.ToplamHas);
                    db.Entry(kasa).State = EntityState.Modified;
                }
                catch(NullReferenceException ex)
                {
                    Kasa yeniKasa = new Kasa();
                    yeniKasa.BaslangicBakiye = - Convert.ToDouble(x.Hareket.ToplamHas);
                    yeniKasa.SubeNo = x.Hareket.SubeNo;
                    yeniKasa.DovizTuru = x.Hareket.Turu;
                    yeniKasa.KasaAdi = yeniKasa.DovizTuru + " " + "KASA" + " " + yeniKasa.SubeNo;
                    db.Entry(yeniKasa).State = EntityState.Added;
                }
                    
            }
            else if (x.Hareket.Turu == "USD")
            {
                toptanci.UsdBakiye = Convert.ToDouble(toptanci.UsdBakiye - x.Hareket.ToplamHas);
                Barkodsuz = db.BarkodsuzStokKartlari.Where(y => y.StokCinsi == "AMERİKAN DOLARI").FirstOrDefault();
                //stok = db.BarkodsuzStok.Where(y => y.StokCinsi == "AMERİKAN DOLARI").FirstOrDefault();
                Barkodsuz.Miktar = Barkodsuz.Miktar - x.Hareket.ToplamHas;
                //stok.Miktar = stok.Miktar - x.Hareket.ToplamHas;
                kasa = db.Kasalar.Where(z => z.DovizTuru == x.Hareket.Turu).FirstOrDefault();
                try
                {
                    kasa.BaslangicBakiye = kasa.BaslangicBakiye - Convert.ToDouble(x.Hareket.ToplamHas);
                    db.Entry(kasa).State = EntityState.Modified;
                }
                catch (NullReferenceException ex)
                {
                    Kasa yeniKasa = new Kasa();
                    yeniKasa.BaslangicBakiye = - Convert.ToDouble(x.Hareket.ToplamHas);
                    yeniKasa.SubeNo = x.Hareket.SubeNo;
                    yeniKasa.DovizTuru = x.Hareket.Turu;
                    yeniKasa.KasaAdi = yeniKasa.DovizTuru + " " + "KASA" + " " + yeniKasa.SubeNo;
                    db.Entry(yeniKasa).State = EntityState.Added;
                }


            }
            else if (x.Hareket.Turu == "TL")
            {
                toptanci.TlBakiye = Convert.ToDouble(toptanci.TlBakiye - x.Hareket.ToplamHas);
                Barkodsuz = db.BarkodsuzStokKartlari.Where(y => y.StokCinsi == "TÜRK LİRASI").FirstOrDefault();
                //stok = db.BarkodsuzStok.Where(y => y.StokCinsi == "TÜRK LİRASI").FirstOrDefault();
                Barkodsuz.Miktar = Barkodsuz.Miktar - x.Hareket.ToplamHas;
                //stok.Miktar = stok.Miktar - x.Hareket.ToplamHas;
                kasa = db.Kasalar.Where(z => z.DovizTuru == x.Hareket.Turu).FirstOrDefault();

                try
                {
                    kasa.BaslangicBakiye = kasa.BaslangicBakiye - Convert.ToDouble(x.Hareket.ToplamHas);
                    db.Entry(kasa).State = EntityState.Modified;
                }
                catch (NullReferenceException ex)
                {
                    Kasa yeniKasa = new Kasa();
                    yeniKasa.BaslangicBakiye = - Convert.ToDouble(x.Hareket.ToplamHas);
                    yeniKasa.SubeNo = x.Hareket.SubeNo;
                    yeniKasa.DovizTuru = x.Hareket.Turu;
                    yeniKasa.KasaAdi = yeniKasa.DovizTuru + " " + "KASA" + " " + yeniKasa.SubeNo;
                    db.Entry(yeniKasa).State = EntityState.Added;
                }

            }
            else if (x.Hareket.Turu == "EURO")
            {
                toptanci.EuroBakiye = Convert.ToDouble(toptanci.EuroBakiye - x.Hareket.ToplamHas);
                Barkodsuz = db.BarkodsuzStokKartlari.Where(y => y.StokCinsi == "EURO").FirstOrDefault();
                //stok = db.BarkodsuzStok.Where(y => y.StokCinsi == "EURO").FirstOrDefault();
                Barkodsuz.Miktar = Barkodsuz.Miktar - x.Hareket.ToplamHas;
                //stok.Miktar = stok.Miktar - x.Hareket.ToplamHas;
                kasa = db.Kasalar.Where(z => z.DovizTuru == x.Hareket.Turu).FirstOrDefault();

                try
                {
                    kasa.BaslangicBakiye = kasa.BaslangicBakiye - Convert.ToDouble(x.Hareket.ToplamHas);
                    db.Entry(kasa).State = EntityState.Modified;
                }
                catch (NullReferenceException ex)
                {
                    Kasa yeniKasa = new Kasa();
                    yeniKasa.BaslangicBakiye = - Convert.ToDouble(x.Hareket.ToplamHas);
                    yeniKasa.SubeNo = x.Hareket.SubeNo;
                    yeniKasa.DovizTuru = x.Hareket.Turu;
                    yeniKasa.KasaAdi = yeniKasa.DovizTuru + " " + "KASA" + " " + yeniKasa.SubeNo;
                    db.Entry(yeniKasa).State = EntityState.Added;
                }

            }
            else if (x.Hareket.Turu == "CHF")
            {
                toptanci.ChfBakiye = Convert.ToDouble(toptanci.ChfBakiye - x.Hareket.ToplamHas);
                Barkodsuz = db.BarkodsuzStokKartlari.Where(y => y.StokCinsi == "İSVİÇRE FRANGI").FirstOrDefault();
                //stok = db.BarkodsuzStok.Where(y => y.StokCinsi == "İSVİÇRE FRANGI").FirstOrDefault();
                Barkodsuz.Miktar = Barkodsuz.Miktar - x.Hareket.ToplamHas;
                //stok.Miktar = stok.Miktar - x.Hareket.ToplamHas;
                kasa = db.Kasalar.Where(z => z.DovizTuru == x.Hareket.Turu).FirstOrDefault();

                try
                {
                    kasa.BaslangicBakiye = kasa.BaslangicBakiye - Convert.ToDouble(x.Hareket.ToplamHas);
                    db.Entry(kasa).State = EntityState.Modified;
                }
                catch (NullReferenceException ex)
                {
                    Kasa yeniKasa = new Kasa();
                    yeniKasa.BaslangicBakiye = - Convert.ToDouble(x.Hareket.ToplamHas);
                    yeniKasa.SubeNo = x.Hareket.SubeNo;
                    yeniKasa.DovizTuru = x.Hareket.Turu;
                    yeniKasa.KasaAdi = yeniKasa.DovizTuru + " " + "KASA" + " " + yeniKasa.SubeNo;
                    db.Entry(yeniKasa).State = EntityState.Added;
                }

            }
            else if (x.Hareket.Turu == "STRL")
            {

                toptanci.StrlBakiye = Convert.ToDouble(toptanci.StrlBakiye - x.Hareket.ToplamHas);
                Barkodsuz = db.BarkodsuzStokKartlari.Where(y => y.StokCinsi == "İNGİLİZ STERLİNİ").FirstOrDefault();
                Barkodsuz.Miktar = Barkodsuz.Miktar - x.Hareket.ToplamHas;
                kasa = db.Kasalar.Where(z => z.DovizTuru == x.Hareket.Turu).FirstOrDefault();
                try
                {
                    kasa.BaslangicBakiye = kasa.BaslangicBakiye - Convert.ToDouble(x.Hareket.ToplamHas);
                    db.Entry(kasa).State = EntityState.Modified;
                }
                catch (NullReferenceException ex)
                {
                    Kasa yeniKasa = new Kasa();
                    yeniKasa.BaslangicBakiye = - Convert.ToDouble(x.Hareket.ToplamHas);
                    yeniKasa.SubeNo = x.Hareket.SubeNo;
                    yeniKasa.DovizTuru = x.Hareket.Turu;
                    yeniKasa.KasaAdi = yeniKasa.DovizTuru + " " + "KASA" + " " + yeniKasa.SubeNo;
                    db.Entry(yeniKasa).State = EntityState.Added;
                }

            }
            else if (x.Hareket.Turu == "ÇEYREK")
            {
                toptanci.CeyrekBakiye = Convert.ToDouble(toptanci.CeyrekBakiye - x.Hareket.ToplamHas);
                Barkodsuz = db.BarkodsuzStokKartlari.Where(y => y.StokCinsi == "ÇEYREK").FirstOrDefault();
                //stok = db.BarkodsuzStok.Where(y => y.StokCinsi == "ÇEYREK").FirstOrDefault();
                Barkodsuz.Miktar = Barkodsuz.Miktar - x.Hareket.ToplamHas;
                //stok.Miktar = stok.Miktar - x.Hareket.ToplamHas;
            }
            else if (x.Hareket.Turu == "22 AYAR")
            {
                toptanci.YiAyarBakiye = Convert.ToDouble(toptanci.YiAyarBakiye - x.Hareket.ToplamHas);
                Barkodsuz = db.BarkodsuzStokKartlari.Where(y => y.StokCinsi == "22 AYAR GRAM").FirstOrDefault();
                //stok = db.BarkodsuzStok.Where(y => y.StokCinsi == "22 AYAR GRAM").FirstOrDefault();
                Barkodsuz.Miktar = Barkodsuz.Miktar - x.Hareket.ToplamHas;
                //stok.Miktar = stok.Miktar - x.Hareket.ToplamHas;
            }
            db.Entry(toptanci).State = EntityState.Modified;
            db.SaveChanges();
            db.Entry(Barkodsuz).State = EntityState.Modified;
            db.SaveChanges();
           
           
            return RedirectToAction("ToptanciyaOdeme", "Finans");
        }
        public ActionResult ToptanciBorcAktarimi()
        {
            Toptancilar toptancilar = new Toptancilar();
            ToptanciHareket hareket = new ToptanciHareket();

            hareket.Tarih = DateTime.Now;
            toptancilar.Hareket = hareket;
            toptancilar.liste = db.Toptancilar.Where(y => y.MagazaNo == "NO1").Select(x => x.ToptanciAdi).ToList();
            toptancilar.Milyemler = db.Cins.Select(x => x.Milyem).Distinct().ToList();
            toptancilar.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            return View(toptancilar);
        }
        [HttpPost]
        public ActionResult ToptanciBorcAktarimi(Toptancilar toptancilar)
        {
            int? id;
            KuyumcuContext db = new KuyumcuContext();
            try
            {
                id = (from a in db.ToptanciHareketler
                      select a.id).Max();
            }
            catch
            {
                id = 1;
                id = id + 1;
            }

            toptancilar.Hareket.FisNo = "BA" + id;
            toptancilar.Hareket.StokId = toptancilar.Hareket.Turu;
            toptancilar.Hareket.ToptanciiAdi = toptancilar.toptanci.ToptanciAdi + "-" + toptancilar.toptanci2.ToptanciAdi;
            toptancilar.Hareket.HareketTuru = "TOPTANCI BORÇ AKTARIMI";

            toptancilar.toptanci = db.Toptancilar.Where(x => x.ToptanciAdi == toptancilar.toptanci.ToptanciAdi).FirstOrDefault();
            toptancilar.toptanci2 = db.Toptancilar.Where(x => x.ToptanciAdi == toptancilar.toptanci2.ToptanciAdi).FirstOrDefault();


            if (toptancilar.Hareket.Turu == "HAS")
            {
                toptancilar.toptanci.Bakiye = Convert.ToDouble(toptancilar.toptanci.Bakiye - toptancilar.Hareket.Miktar);
                toptancilar.toptanci2.Bakiye = Convert.ToDouble(toptancilar.toptanci2.Bakiye + toptancilar.Hareket.Miktar);
            }
            else if (toptancilar.Hareket.Turu == "USD")
            {
                toptancilar.toptanci.UsdBakiye = Convert.ToDouble(toptancilar.toptanci.UsdBakiye - toptancilar.Hareket.Miktar);
                toptancilar.toptanci2.UsdBakiye = Convert.ToDouble(toptancilar.toptanci2.UsdBakiye + toptancilar.Hareket.Miktar);
            }
            else if (toptancilar.Hareket.Turu == "TL")
            {
                toptancilar.toptanci.TlBakiye = Convert.ToDouble(toptancilar.toptanci.TlBakiye - toptancilar.Hareket.Miktar);
                toptancilar.toptanci2.TlBakiye = Convert.ToDouble(toptancilar.toptanci2.TlBakiye + toptancilar.Hareket.Miktar);
            }
            else if (toptancilar.Hareket.Turu == "EURO")
            {
                toptancilar.toptanci.EuroBakiye = Convert.ToDouble(toptancilar.toptanci.EuroBakiye - toptancilar.Hareket.Miktar);
                toptancilar.toptanci2.EuroBakiye = Convert.ToDouble(toptancilar.toptanci2.EuroBakiye + toptancilar.Hareket.Miktar);
            }
            else if (toptancilar.Hareket.Turu == "CHF")
            {
                toptancilar.toptanci.ChfBakiye = Convert.ToDouble(toptancilar.toptanci.ChfBakiye - toptancilar.Hareket.Miktar);
                toptancilar.toptanci2.ChfBakiye = Convert.ToDouble(toptancilar.toptanci2.ChfBakiye + toptancilar.Hareket.Miktar);
            }
            else if (toptancilar.Hareket.Turu == "STRL")
            {
                toptancilar.toptanci.StrlBakiye = Convert.ToDouble(toptancilar.toptanci.StrlBakiye - toptancilar.Hareket.Miktar);
                toptancilar.toptanci2.StrlBakiye = Convert.ToDouble(toptancilar.toptanci2.StrlBakiye + toptancilar.Hareket.Miktar);
            }
            else if (toptancilar.Hareket.Turu == "ÇEYREK")
            {
                toptancilar.toptanci.CeyrekBakiye = Convert.ToDouble(toptancilar.toptanci.CeyrekBakiye - toptancilar.Hareket.Miktar);
                toptancilar.toptanci2.CeyrekBakiye = Convert.ToDouble(toptancilar.toptanci2.CeyrekBakiye + toptancilar.Hareket.Miktar);
            }
            else if (toptancilar.Hareket.Turu == "22 AYAR")
            {
                toptancilar.toptanci.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci.YiAyarBakiye - toptancilar.Hareket.Miktar);
                toptancilar.toptanci2.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci2.YiAyarBakiye + toptancilar.Hareket.Miktar);
            }
            //else if (toptancilar.Hareket.Turu == "22 AYAR")
            //{
            //    toptancilar.toptanci.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci.YiAyarBakiye - toptancilar.Hareket.Miktar);
            //    toptancilar.toptanci2.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci2.YiAyarBakiye + toptancilar.Hareket.Miktar);
            //}
            db.Entry(toptancilar.toptanci).State = EntityState.Modified;
            db.Entry(toptancilar.toptanci2).State = EntityState.Modified;
            db.Entry(toptancilar.Hareket).State = EntityState.Added;
            db.SaveChanges();


            return RedirectToAction("ToptanciBorcAktarimi", "Finans");
        }


        Kuyumcu.Data.KuyumcuContext db8 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridViewBAKPartial()
        {

            var model1 = db8.ToptanciHareketler.Where(x => x.HareketTuru == "TOPTANCI BORÇ AKTARIMI");
            return PartialView("_GridViewBAKPartial", model1.ToList());
        }

      

        public ActionResult ToptanciBorcAlacakCevrimi()
        {
            Toptancilar toptancilar = new Toptancilar();
            ToptanciHareket hareket = new ToptanciHareket();

            hareket.Tarih = DateTime.Now;
            toptancilar.Hareket = hareket;
            toptancilar.liste = db.Toptancilar.Where(y => y.MagazaNo == "NO1").Select(x => x.ToptanciAdi).ToList();
            toptancilar.Milyemler = db.Cins.Select(x => x.Milyem).Distinct().ToList();
            toptancilar.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            return View(toptancilar);
        }
        [HttpPost]
        public ActionResult ToptanciBorcAlacakCevrimi(Toptancilar toptancilar)
        {
            int? id;
            KuyumcuContext db = new KuyumcuContext();
            try
            {
                id = (from a in db.ToptanciHareketler
                      select a.id).Max();
            }
            catch
            {
                id = 1;
                id = id + 1;
            }

            toptancilar.Hareket.FisNo = "BAC" + id;
            toptancilar.Hareket.HareketTuru = "TOPTANCI BORÇ ALACAK ÇEVRİMİ";
            toptancilar.Hareket.ToptanciiAdi = toptancilar.toptanci.ToptanciAdi;

            toptancilar.toptanci = db.Toptancilar.Where(y => y.ToptanciAdi == toptancilar.toptanci.ToptanciAdi).FirstOrDefault();



            if (toptancilar.Hareket.StokId == "KÜLÇE ALTIN" && toptancilar.toptanci.Bakiye > 0)
            {
                toptancilar.toptanci.Bakiye = Convert.ToDouble(toptancilar.toptanci.Bakiye - toptancilar.Hareket.Miktar);

            }
            else if (toptancilar.Hareket.StokId == "AMERİKAN DOLARI" && toptancilar.toptanci.UsdBakiye > 0)
            {
                toptancilar.toptanci.UsdBakiye = Convert.ToDouble(toptancilar.toptanci.UsdBakiye - toptancilar.Hareket.Miktar);

            }
            else if (toptancilar.Hareket.StokId == "TÜRK LİRASI" && toptancilar.toptanci.TlBakiye > 0)
            {
                toptancilar.toptanci.TlBakiye = Convert.ToDouble(toptancilar.toptanci.TlBakiye - toptancilar.Hareket.Miktar);

            }
            else if (toptancilar.Hareket.StokId == "EURO" && toptancilar.toptanci.EuroBakiye > 0)
            {
                toptancilar.toptanci.EuroBakiye = Convert.ToDouble(toptancilar.toptanci.EuroBakiye - toptancilar.Hareket.Miktar);

            }
            else if (toptancilar.Hareket.StokId == "İSVİÇRE FRANGI" && toptancilar.toptanci.ChfBakiye > 0)
            {
                toptancilar.toptanci.ChfBakiye = Convert.ToDouble(toptancilar.toptanci.ChfBakiye - toptancilar.Hareket.Miktar);

            }
            else if (toptancilar.Hareket.StokId == "İNGİLİZ STERLİNİ" && toptancilar.toptanci.StrlBakiye > 0)
            {
                toptancilar.toptanci.StrlBakiye = Convert.ToDouble(toptancilar.toptanci.StrlBakiye - toptancilar.Hareket.Miktar);

            }
            else if (toptancilar.Hareket.StokId == "ÇEYREK" && toptancilar.toptanci.CeyrekBakiye > 0)
            {
                toptancilar.toptanci.CeyrekBakiye = Convert.ToDouble(toptancilar.toptanci.CeyrekBakiye - toptancilar.Hareket.Miktar);

            }
            else if (toptancilar.Hareket.StokId == "22 AYAR GRAM" && toptancilar.toptanci.YiAyarBakiye > 0)
            {
                toptancilar.toptanci.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci.YiAyarBakiye - toptancilar.Hareket.Miktar);
            }
            else if (toptancilar.Hareket.StokId == "KÜLÇE ALTIN" && toptancilar.toptanci.Bakiye <= 0)
            {
                toptancilar.toptanci.Bakiye = Convert.ToDouble(toptancilar.toptanci.Bakiye + toptancilar.Hareket.Miktar);
                toptancilar.Hareket.Donusum = 0 - toptancilar.Hareket.Donusum;

            }
            else if (toptancilar.Hareket.StokId == "AMERİKAN DOLARI" && toptancilar.toptanci.UsdBakiye <= 0)
            {
                toptancilar.toptanci.UsdBakiye = Convert.ToDouble(toptancilar.toptanci.UsdBakiye + toptancilar.Hareket.Miktar);
                toptancilar.Hareket.Donusum = 0 - toptancilar.Hareket.Donusum;
            }
            else if (toptancilar.Hareket.StokId == "TÜRK LİRASI" && toptancilar.toptanci.TlBakiye <= 0)
            {
                toptancilar.toptanci.TlBakiye = Convert.ToDouble(toptancilar.toptanci.TlBakiye + toptancilar.Hareket.Miktar);
                toptancilar.Hareket.Donusum = 0 - toptancilar.Hareket.Donusum;
            }
            else if (toptancilar.Hareket.StokId == "EURO" && toptancilar.toptanci.EuroBakiye <= 0)
            {
                toptancilar.toptanci.EuroBakiye = Convert.ToDouble(toptancilar.toptanci.EuroBakiye + toptancilar.Hareket.Miktar);
                toptancilar.Hareket.Donusum = 0 - toptancilar.Hareket.Donusum;
            }
            else if (toptancilar.Hareket.StokId == "İSVİÇRE FRANGI" && toptancilar.toptanci.ChfBakiye <= 0)
            {
                toptancilar.toptanci.ChfBakiye = Convert.ToDouble(toptancilar.toptanci.ChfBakiye + toptancilar.Hareket.Miktar);
                toptancilar.Hareket.Donusum = 0 - toptancilar.Hareket.Donusum;
            }
            else if (toptancilar.Hareket.StokId == "İNGİLİZ STERLİNİ" && toptancilar.toptanci.StrlBakiye <= 0)
            {
                toptancilar.toptanci.StrlBakiye = Convert.ToDouble(toptancilar.toptanci.StrlBakiye + toptancilar.Hareket.Miktar);
                toptancilar.Hareket.Donusum = 0 - toptancilar.Hareket.Donusum;
            }
            else if (toptancilar.Hareket.StokId == "ÇEYREK" && toptancilar.toptanci.CeyrekBakiye <= 0)
            {
                toptancilar.toptanci.CeyrekBakiye = Convert.ToDouble(toptancilar.toptanci.CeyrekBakiye + toptancilar.Hareket.Miktar);
                toptancilar.Hareket.Donusum = 0 - toptancilar.Hareket.Donusum;
            }
            else if (toptancilar.Hareket.StokId == "22 AYAR GRAM" && toptancilar.toptanci.YiAyarBakiye <= 0)
            {
                toptancilar.toptanci.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci.YiAyarBakiye + toptancilar.Hareket.Miktar);
                toptancilar.Hareket.Donusum = 0 - toptancilar.Hareket.Donusum;
            }



            if (toptancilar.Hareket.StokAdi == "KÜLÇE ALTIN")
            {
                toptancilar.toptanci.Bakiye = Convert.ToDouble(toptancilar.toptanci.Bakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "AMERİKAN DOLARI")
            {
                toptancilar.toptanci.UsdBakiye = Convert.ToDouble(toptancilar.toptanci.UsdBakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "TÜRK LİRASI")
            {
                toptancilar.toptanci.TlBakiye = Convert.ToDouble(toptancilar.toptanci.TlBakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "EURO")
            {
                toptancilar.toptanci.EuroBakiye = Convert.ToDouble(toptancilar.toptanci.EuroBakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "İSVİÇRE FRANGI")
            {
                toptancilar.toptanci.ChfBakiye = Convert.ToDouble(toptancilar.toptanci.ChfBakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "İNGİLİZ STERLİNİ")
            {
                toptancilar.toptanci.StrlBakiye = Convert.ToDouble(toptancilar.toptanci.StrlBakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "ÇEYREK")
            {
                toptancilar.toptanci.CeyrekBakiye = Convert.ToDouble(toptancilar.toptanci.CeyrekBakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "22 AYAR GRAM")
            {
                toptancilar.toptanci.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci.YiAyarBakiye + toptancilar.Hareket.Donusum);

            }





            db.Entry(toptancilar.toptanci).State = EntityState.Modified;
            db.Entry(toptancilar.Hareket).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("ToptanciBorcAlacakCevrimi", "Finans");
        }
        [HttpPost]
        public ActionResult ToptanciBorcAlacakCevrimi1(string donusen, double miktar, string donusum)
        {
            double tutar = 0;
            double donusenTL = 0;
            BarkodsuzStokKart urun = new BarkodsuzStokKart();
            urun = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == donusen).FirstOrDefault();
            donusenTL = Convert.ToDouble(urun.SatisFiyati * miktar);
            urun = db.BarkodsuzStokKartlari.Where(x => x.StokCinsi == donusum).FirstOrDefault();
            tutar = Math.Round(Convert.ToDouble(donusenTL / urun.SatisFiyati), 3);
            return Json(tutar);
        }
        public ActionResult BaglamaIslemleri()
        {
            Toptancilar toptancilar = new Toptancilar();
            ToptanciHareket hareket = new ToptanciHareket();

            hareket.Tarih = DateTime.Now;
            toptancilar.Hareket = hareket;
            toptancilar.liste = db.Toptancilar.Where(y => y.MagazaNo == "NO1").Select(x => x.ToptanciAdi).ToList();
            toptancilar.Milyemler = db.Cins.Select(x => x.Milyem).Distinct().ToList();
            toptancilar.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            return View(toptancilar);
        }
        [HttpPost]
        public ActionResult BaglamaIslemleri(Toptancilar toptancilar)
        {
            toptancilar.toptanci = db.Toptancilar.Where(x => x.ToptanciAdi == toptancilar.toptanci.ToptanciAdi).FirstOrDefault();
            bool k = false;
            bool l = false;
            int? id;
            try
            {
                id = (from a in db.ToptanciHareketler
                      select a.id).Max();
            }
            catch
            {
                id = 1;
                id = id + 1;
            }

            Kasa kasa = new Kasa();
            toptancilar.Hareket.FisNo = "BI" + id;
            toptancilar.Hareket.HareketTuru = "BAĞLAMA İŞLEMLERİ";
            toptancilar.Hareket.ToptanciiAdi = toptancilar.toptanci.ToptanciAdi;

            if (toptancilar.Hareket.StokId == "KÜLÇE ALTIN" && toptancilar.toptanci.Bakiye > 0)
            {
                k = true;
                toptancilar.toptanci.Bakiye = Convert.ToDouble(toptancilar.toptanci.Bakiye - toptancilar.Hareket.Miktar);
                


            }
            else if (toptancilar.Hareket.StokId == "AMERİKAN DOLARI" && toptancilar.toptanci.UsdBakiye > 0)
            {
                k = true;
                toptancilar.toptanci.UsdBakiye = Convert.ToDouble(toptancilar.toptanci.UsdBakiye - toptancilar.Hareket.Miktar);
             

            }
            else if (toptancilar.Hareket.StokId == "TÜRK LİRASI" && toptancilar.toptanci.TlBakiye > 0)
            {
                k = true;
                toptancilar.toptanci.TlBakiye = Convert.ToDouble(toptancilar.toptanci.TlBakiye - toptancilar.Hareket.Miktar);
                

            }
            else if (toptancilar.Hareket.StokId == "EURO" && toptancilar.toptanci.EuroBakiye > 0)
            {
                toptancilar.toptanci.EuroBakiye = Convert.ToDouble(toptancilar.toptanci.EuroBakiye - toptancilar.Hareket.Miktar);
                k = true;
            }
            else if (toptancilar.Hareket.StokId == "İSVİÇRE FRANGI" && toptancilar.toptanci.ChfBakiye > 0)
            {
                toptancilar.toptanci.ChfBakiye = Convert.ToDouble(toptancilar.toptanci.ChfBakiye - toptancilar.Hareket.Miktar);
                k = true;
            }
            else if (toptancilar.Hareket.StokId == "İNGİLİZ STERLİNİ" && toptancilar.toptanci.StrlBakiye > 0)
            {
                toptancilar.toptanci.StrlBakiye = Convert.ToDouble(toptancilar.toptanci.StrlBakiye - toptancilar.Hareket.Miktar);
                k = true;
            }
            else if (toptancilar.Hareket.StokId == "ÇEYREK" && toptancilar.toptanci.CeyrekBakiye > 0)
            {
                toptancilar.toptanci.CeyrekBakiye = Convert.ToDouble(toptancilar.toptanci.CeyrekBakiye - toptancilar.Hareket.Miktar);
                k = true;
            }
            else if (toptancilar.Hareket.StokId == "22 AYAR GRAM" && toptancilar.toptanci.YiAyarBakiye > 0)
            {
                k = true;
                toptancilar.toptanci.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci.YiAyarBakiye - toptancilar.Hareket.Miktar);
              
            }

            if (toptancilar.Hareket.StokId == "KÜLÇE ALTIN" && toptancilar.toptanci.Bakiye <= 0)
            {
                toptancilar.toptanci.Bakiye = Convert.ToDouble(toptancilar.toptanci.Bakiye + toptancilar.Hareket.Miktar);
                l = true;
            }
            else if (toptancilar.Hareket.StokId == "AMERİKAN DOLARI" && toptancilar.toptanci.UsdBakiye <= 0)
            {
                toptancilar.toptanci.UsdBakiye = Convert.ToDouble(toptancilar.toptanci.UsdBakiye + toptancilar.Hareket.Miktar);
                l = true;
            }
            else if (toptancilar.Hareket.StokId == "TÜRK LİRASI" && toptancilar.toptanci.TlBakiye <= 0)
            {
                toptancilar.toptanci.TlBakiye = Convert.ToDouble(toptancilar.toptanci.TlBakiye + toptancilar.Hareket.Miktar);
                l = true;
            }
            else if (toptancilar.Hareket.StokId == "EURO" && toptancilar.toptanci.EuroBakiye <= 0)
            {
                toptancilar.toptanci.EuroBakiye = Convert.ToDouble(toptancilar.toptanci.EuroBakiye + toptancilar.Hareket.Miktar);
                l = true;
            }
            else if (toptancilar.Hareket.StokId == "İSVİÇRE FRANGI" && toptancilar.toptanci.ChfBakiye <= 0)
            {
                toptancilar.toptanci.ChfBakiye = Convert.ToDouble(toptancilar.toptanci.ChfBakiye + toptancilar.Hareket.Miktar);
                l = true;

            }
            else if (toptancilar.Hareket.StokId == "İNGİLİZ STERLİNİ" && toptancilar.toptanci.StrlBakiye <= 0)
            {
                toptancilar.toptanci.StrlBakiye = Convert.ToDouble(toptancilar.toptanci.StrlBakiye + toptancilar.Hareket.Miktar);
                l = true;
            }
            else if (toptancilar.Hareket.StokId == "ÇEYREK" && toptancilar.toptanci.CeyrekBakiye <= 0)
            {
                toptancilar.toptanci.CeyrekBakiye = Convert.ToDouble(toptancilar.toptanci.CeyrekBakiye + toptancilar.Hareket.Miktar);
                l = true;
            }
            else if (toptancilar.Hareket.StokId == "22 AYAR GRAM" && toptancilar.toptanci.YiAyarBakiye <= 0)
            {
                toptancilar.toptanci.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci.YiAyarBakiye + toptancilar.Hareket.Miktar);
                l = true;
            }


            if (toptancilar.Hareket.StokAdi == "KÜLÇE ALTIN" && k == true)
            {
                toptancilar.toptanci.Bakiye = Convert.ToDouble(toptancilar.toptanci.Bakiye + toptancilar.Hareket.Donusum);

               

            }
            else if (toptancilar.Hareket.StokAdi == "AMERİKAN DOLARI" && k == true)
            {
                toptancilar.toptanci.UsdBakiye = Convert.ToDouble(toptancilar.toptanci.UsdBakiye + toptancilar.Hareket.Donusum);

               

            }
            else if (toptancilar.Hareket.StokAdi == "TÜRK LİRASI" && k == true)
            {
                toptancilar.toptanci.TlBakiye = Convert.ToDouble(toptancilar.toptanci.TlBakiye + toptancilar.Hareket.Donusum);

                //kasa = db.Kasalar.Where(z => z.DovizTuru == toptancilar.Hareket.StokAdi).FirstOrDefault();
                //kasa.BaslangicBakiye = Convert.ToDouble(kasa.BaslangicBakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "EURO" && k == true)
            {
                toptancilar.toptanci.EuroBakiye = Convert.ToDouble(toptancilar.toptanci.EuroBakiye + toptancilar.Hareket.Donusum);


            }
            else if (toptancilar.Hareket.StokAdi == "İSVİÇRE FRANGI" && k == true)
            {
                toptancilar.toptanci.ChfBakiye = Convert.ToDouble(toptancilar.toptanci.ChfBakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "İNGİLİZ STERLİNİ" && k == true)
            {
                toptancilar.toptanci.StrlBakiye = Convert.ToDouble(toptancilar.toptanci.StrlBakiye + toptancilar.Hareket.Donusum);

           

            }
            else if (toptancilar.Hareket.StokAdi == "ÇEYREK" && k == true)
            {
                toptancilar.toptanci.CeyrekBakiye = Convert.ToDouble(toptancilar.toptanci.CeyrekBakiye + toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "22 AYAR GRAM" && k == true)
            {
                toptancilar.toptanci.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci.YiAyarBakiye + toptancilar.Hareket.Donusum);

            }



            if (toptancilar.Hareket.StokAdi == "KÜLÇE ALTIN" && l == true)
            {
                toptancilar.toptanci.Bakiye = Convert.ToDouble(toptancilar.toptanci.Bakiye - toptancilar.Hareket.Donusum);


            }
            else if (toptancilar.Hareket.StokAdi == "AMERİKAN DOLARI" && l == true)
            {
                toptancilar.toptanci.UsdBakiye = Convert.ToDouble(toptancilar.toptanci.UsdBakiye - toptancilar.Hareket.Donusum);

            }
            else if (toptancilar.Hareket.StokAdi == "TÜRK LİRASI" && l == true)
            {
                toptancilar.toptanci.TlBakiye = Convert.ToDouble(toptancilar.toptanci.TlBakiye - toptancilar.Hareket.Donusum);

              
            }
            else if (toptancilar.Hareket.StokAdi == "EURO" && l == true)
            {
                toptancilar.toptanci.EuroBakiye = Convert.ToDouble(toptancilar.toptanci.EuroBakiye - toptancilar.Hareket.Donusum);

               

            }
            else if (toptancilar.Hareket.StokAdi == "İSVİÇRE FRANGI" && l == true)
            {
                toptancilar.toptanci.ChfBakiye = Convert.ToDouble(toptancilar.toptanci.ChfBakiye - toptancilar.Hareket.Donusum);


            }
            else if (toptancilar.Hareket.StokAdi == "İNGİLİZ STERLİNİ" && l == true)
            {
                toptancilar.toptanci.StrlBakiye = Convert.ToDouble(toptancilar.toptanci.StrlBakiye - toptancilar.Hareket.Donusum);

             
            }
            else if (toptancilar.Hareket.StokAdi == "ÇEYREK" && l == true)
            {
                toptancilar.toptanci.CeyrekBakiye = Convert.ToDouble(toptancilar.toptanci.CeyrekBakiye - toptancilar.Hareket.Donusum);

              
            }
            else if (toptancilar.Hareket.StokAdi == "22 AYAR GRAM" && l == true)
            {
                toptancilar.toptanci.YiAyarBakiye = Convert.ToDouble(toptancilar.toptanci.YiAyarBakiye - toptancilar.Hareket.Donusum);


            }

            db.Entry(toptancilar.toptanci).State = EntityState.Modified;
            db.SaveChanges();
            db.Entry(toptancilar.Hareket).State = EntityState.Added;
            db.SaveChanges();
            if (kasa.KasaAdi != null)
            {
                db.Entry(kasa).State = EntityState.Modified;
                db.SaveChanges();
            }


            return RedirectToAction("BaglamaIslemleri", "Finans");
        }



        public ActionResult ToptanciIade()
        {
            Toptancilar toptancilar = new Toptancilar();
            ToptanciHareket hareket = new ToptanciHareket();

            hareket.Tarih = DateTime.Now;
            toptancilar.Hareket = hareket;
            toptancilar.liste = db.Toptancilar.Where(y => y.MagazaNo == "NO1").Select(x => x.ToptanciAdi).ToList();
            toptancilar.Milyemler = db.Cins.Select(x => x.Milyem).Distinct().ToList();
            toptancilar.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            return View(toptancilar);
        }

        Kuyumcu.Data.KuyumcuContext db11 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridViewBACPartial()
        {
            var model = db11.ToptanciHareketler.Where(x => x.HareketTuru == "TOPTANCI BORÇ ALACAK ÇEVRİMİ");
            return PartialView("_GridViewBACPartial", model.ToList());
        }



        Kuyumcu.Data.KuyumcuContext db12 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult GridViewBIPartial()
        {
            var model = db12.ToptanciHareketler.Where(x => x.HareketTuru == "BAĞLAMA İŞLEMLERİ");
            return PartialView("_GridViewBIPartial", model.ToList());
        }



        public ActionResult BorcEmanetIslemleri()
        {
            BEhareket Model = new BEhareket();
            StokHareket hareket = new StokHareket();

            hareket.Tarih = DateTime.Now;
            Model.hareket = hareket;
            Model.Sarrafiye = db.BarkodsuzStokKartlari.Select(x => x.StokCinsi).ToList();
            Model.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            return View(Model);
        }
        [HttpPost]
        public ActionResult BorcEmanetIslemleri(BEhareket behareket)
        {
            BarkodsuzStokKart sarrafiye = new BarkodsuzStokKart();
            Musteri musteri = new Musteri();
            musteri = db.Musteriler.Where(x => x.AdSoyad == behareket.hareket.MusteriAdi).FirstOrDefault();
            if (behareket.hareket.HareketTipi == "BORÇ-EMANET ÖDEME")
            {
                behareket.hareket.HareketTuru = "ÇIKIŞ";
                if (behareket.hareket.StokId == "ÇEYREK")
                {
                    musteri.ÇEYREK = Convert.ToDouble(musteri.ÇEYREK - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "YARIM")
                {
                    musteri.YARIM = Convert.ToDouble(musteri.YARIM - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "2.5'LU")
                {
                    musteri.IkıBucuklU = Convert.ToDouble(musteri.IkıBucuklU - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "C.LİRA")
                {
                    musteri.CLİRA = Convert.ToDouble(musteri.CLİRA - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "22 AYAR GRAM")
                {
                    musteri.YiAyarGRAM = Convert.ToDouble(musteri.YiAyarGRAM - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "24 AYAR GRAM")
                {
                    musteri.YdAyarGRAM = Convert.ToDouble(musteri.YdAyarGRAM - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "HAMİT LİRA")
                {
                    musteri.HLira = Convert.ToDouble(musteri.HLira - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "AMERİKAN DOLARI")
                {
                    musteri.USD = Convert.ToDouble(musteri.USD - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "EURO")
                {
                    musteri.EURO = Convert.ToDouble(musteri.EURO - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İSVİÇRE FRANGI")
                {
                    musteri.CHF = Convert.ToDouble(musteri.CHF - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "DANİMARKA KRONU")
                {
                    musteri.DKK = Convert.ToDouble(musteri.DKK - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İNGİLİZ STERLİNİ")
                {
                    musteri.STRL = Convert.ToDouble(musteri.STRL - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "KÜLÇE ALTIN")
                {
                    musteri.HAS = Convert.ToDouble(musteri.HAS - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "TÜRK LİRASI")
                {
                    musteri.TL = Convert.ToDouble(musteri.TL - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "REŞAT BEŞLİ")
                {
                    musteri.RBesli = Convert.ToDouble(musteri.RBesli - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "HAMİT BEŞLİ")
                {
                    musteri.HBesli = Convert.ToDouble(musteri.HBesli - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "CUMHURİYET BEŞLİ")
                {
                    musteri.CBesli = Convert.ToDouble(musteri.CBesli - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "REŞAT LİRA")
                {
                    musteri.RLira = Convert.ToDouble(musteri.RLira - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İSVEÇ KRONU")
                {
                    musteri.SEK = Convert.ToDouble(musteri.SEK - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "NORVEÇ KRONU")
                {
                    musteri.NOK = Convert.ToDouble(musteri.NOK - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "JAPON YENİ")
                {
                    musteri.JPY = Convert.ToDouble(musteri.JPY - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "AVUSTRALYA DOLARI")
                {
                    musteri.AD = Convert.ToDouble(musteri.AD - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "KANADA DOLARI")
                {
                    musteri.KD = Convert.ToDouble(musteri.KD - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "RİYAL")
                {
                    musteri.RY = Convert.ToDouble(musteri.RY - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "RUS RUBLESİ")
                {
                    musteri.RB = Convert.ToDouble(musteri.RB - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "ATATEK")
                {
                    musteri.ATATEK = Convert.ToDouble(musteri.ATATEK - behareket.hareket.Miktar);
                }
            }
            else if (behareket.hareket.HareketTipi == "BORÇ-EMANET TAHSİL")
            {
                behareket.hareket.HareketTuru = "GİRİŞ";
                if (behareket.hareket.StokId == "ÇEYREK")
                {
                    musteri.ÇEYREK = Convert.ToDouble(musteri.ÇEYREK + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "YARIM")
                {
                    musteri.YARIM = Convert.ToDouble(musteri.YARIM + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "2.5'LU")
                {
                    musteri.IkıBucuklU = Convert.ToDouble(musteri.IkıBucuklU + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "C.LİRA")
                {
                    musteri.CLİRA = Convert.ToDouble(musteri.CLİRA + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "22 AYAR GRAM")
                {
                    musteri.YiAyarGRAM = Convert.ToDouble(musteri.YiAyarGRAM + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "24 AYAR GRAM")
                {
                    musteri.YdAyarGRAM = Convert.ToDouble(musteri.YdAyarGRAM + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "HAMİT LİRA")
                {
                    musteri.HLira = Convert.ToDouble(musteri.HLira + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "AMERİKAN DOLARI")
                {
                    musteri.USD = Convert.ToDouble(musteri.USD + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "EURO")
                {
                    musteri.EURO = Convert.ToDouble(musteri.EURO + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İSVİÇRE FRANGI")
                {
                    musteri.CHF = Convert.ToDouble(musteri.CHF + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "DANİMARKA KRONU")
                {
                    musteri.DKK = Convert.ToDouble(musteri.DKK + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İNGİLİZ STERLİNİ")
                {
                    musteri.STRL = Convert.ToDouble(musteri.STRL + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "KÜLÇE ALTIN")
                {
                    musteri.HAS = Convert.ToDouble(musteri.HAS + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "TÜRK LİRASI")
                {
                    musteri.TL = Convert.ToDouble(musteri.TL + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "REŞAT BEŞLİ")
                {
                    musteri.RBesli = Convert.ToDouble(musteri.RBesli + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "HAMİT BEŞLİ")
                {
                    musteri.HBesli = Convert.ToDouble(musteri.HBesli + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "CUMHURİYET BEŞLİ")
                {
                    musteri.CBesli = Convert.ToDouble(musteri.CBesli + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "REŞAT LİRA")
                {
                    musteri.RLira = Convert.ToDouble(musteri.RLira + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İSVEÇ KRONU")
                {
                    musteri.SEK = Convert.ToDouble(musteri.SEK + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "NORVEÇ KRONU")
                {
                    musteri.NOK = Convert.ToDouble(musteri.NOK + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "JAPON YENİ")
                {
                    musteri.JPY = Convert.ToDouble(musteri.JPY + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "AVUSTRALYA DOLARI")
                {
                    musteri.AD = Convert.ToDouble(musteri.AD + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "KANADA DOLARI")
                {
                    musteri.KD = Convert.ToDouble(musteri.KD + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "RİYAL")
                {
                    musteri.RY = Convert.ToDouble(musteri.RY + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "RUS RUBLESİ")
                {
                    musteri.RB = Convert.ToDouble(musteri.RB + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "ATATEK")
                {
                    musteri.ATATEK = Convert.ToDouble(musteri.ATATEK + behareket.hareket.Miktar);
                }
            }
            else if (behareket.hareket.HareketTipi == "BORÇ DÖNÜŞÜM")
            {
                behareket.hareket.HareketTuru = "DÖNÜŞÜM";
                
                behareket.hareket.DonusumMiktar = behareket.Temphareket.Miktar;
                if (behareket.hareket.StokId == "ÇEYREK")
                {
                    musteri.ÇEYREK = Convert.ToDouble(musteri.ÇEYREK + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "YARIM")
                {
                    musteri.YARIM = Convert.ToDouble(musteri.YARIM + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "2.5'LU")
                {
                    musteri.IkıBucuklU = Convert.ToDouble(musteri.IkıBucuklU + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "C.LİRA")
                {
                    musteri.CLİRA = Convert.ToDouble(musteri.CLİRA + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "22 AYAR GRAM")
                {
                    musteri.YiAyarGRAM = Convert.ToDouble(musteri.YiAyarGRAM + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "24 AYAR GRAM")
                {
                    musteri.YdAyarGRAM = Convert.ToDouble(musteri.YdAyarGRAM + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "HAMİT LİRA")
                {
                    musteri.HLira = Convert.ToDouble(musteri.HLira + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "AMERİKAN DOLARI")
                {
                    musteri.USD = Convert.ToDouble(musteri.USD + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "EURO")
                {
                    musteri.EURO = Convert.ToDouble(musteri.EURO + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İSVİÇRE FRANGI")
                {
                    musteri.CHF = Convert.ToDouble(musteri.CHF + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "DANİMARKA KRONU")
                {
                    musteri.DKK = Convert.ToDouble(musteri.DKK + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İNGİLİZ STERLİNİ")
                {
                    musteri.STRL = Convert.ToDouble(musteri.STRL + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "KÜLÇE ALTIN")
                {
                    musteri.HAS = Convert.ToDouble(musteri.HAS + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "TÜRK LİRASI")
                {
                    musteri.TL = Convert.ToDouble(musteri.TL + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "REŞAT BEŞLİ")
                {
                    musteri.RBesli = Convert.ToDouble(musteri.RBesli + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "HAMİT BEŞLİ")
                {
                    musteri.HBesli = Convert.ToDouble(musteri.HBesli + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "CUMHURİYET BEŞLİ")
                {
                    musteri.CBesli = Convert.ToDouble(musteri.CBesli + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "REŞAT LİRA")
                {
                    musteri.RLira = Convert.ToDouble(musteri.RLira + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İSVEÇ KRONU")
                {
                    musteri.SEK = Convert.ToDouble(musteri.SEK + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "NORVEÇ KRONU")
                {
                    musteri.NOK = Convert.ToDouble(musteri.NOK + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "JAPON YENİ")
                {
                    musteri.JPY = Convert.ToDouble(musteri.JPY + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "AVUSTRALYA DOLARI")
                {
                    musteri.AD = Convert.ToDouble(musteri.AD + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "KANADA DOLARI")
                {
                    musteri.KD = Convert.ToDouble(musteri.KD + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "RİYAL")
                {
                    musteri.RY = Convert.ToDouble(musteri.RY + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "RUS RUBLESİ")
                {
                    musteri.RB = Convert.ToDouble(musteri.RB + behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "ATATEK")
                {
                    musteri.ATATEK = Convert.ToDouble(musteri.ATATEK + behareket.hareket.Miktar);
                }




                if (behareket.Temphareket.StokId == "ÇEYREK")
                {
                    musteri.ÇEYREK = Convert.ToDouble(musteri.ÇEYREK - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "YARIM")
                {
                    musteri.YARIM = Convert.ToDouble(musteri.YARIM - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "2.5'LU")
                {
                    musteri.IkıBucuklU = Convert.ToDouble(musteri.IkıBucuklU - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "C.LİRA")
                {
                    musteri.CLİRA = Convert.ToDouble(musteri.CLİRA - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "22 AYAR GRAM")
                {
                    musteri.YiAyarGRAM = Convert.ToDouble(musteri.YiAyarGRAM - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "24 AYAR GRAM")
                {
                    musteri.YdAyarGRAM = Convert.ToDouble(musteri.YdAyarGRAM - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "HAMİT LİRA")
                {
                    musteri.HLira = Convert.ToDouble(musteri.HLira - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "AMERİKAN DOLARI")
                {
                    musteri.USD = Convert.ToDouble(musteri.USD - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "EURO")
                {
                    musteri.EURO = Convert.ToDouble(musteri.EURO - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "İSVİÇRE FRANGI")
                {
                    musteri.CHF = Convert.ToDouble(musteri.CHF - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "DANİMARKA KRONU")
                {
                    musteri.DKK = Convert.ToDouble(musteri.DKK - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "İNGİLİZ STERLİNİ")
                {
                    musteri.STRL = Convert.ToDouble(musteri.STRL - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "KÜLÇE ALTIN")
                {
                    musteri.HAS = Convert.ToDouble(musteri.HAS - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "TÜRK LİRASI")
                {
                    musteri.TL = Convert.ToDouble(musteri.TL - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "REŞAT BEŞLİ")
                {
                    musteri.RBesli = Convert.ToDouble(musteri.RBesli - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "HAMİT BEŞLİ")
                {
                    musteri.HBesli = Convert.ToDouble(musteri.HBesli - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "CUMHURİYET BEŞLİ")
                {
                    musteri.CBesli = Convert.ToDouble(musteri.CBesli - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "REŞAT LİRA")
                {
                    musteri.RLira = Convert.ToDouble(musteri.RLira - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "İSVEÇ KRONU")
                {
                    musteri.SEK = Convert.ToDouble(musteri.SEK - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "NORVEÇ KRONU")
                {
                    musteri.NOK = Convert.ToDouble(musteri.NOK - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "JAPON YENİ")
                {
                    musteri.JPY = Convert.ToDouble(musteri.JPY - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "AVUSTRALYA DOLARI")
                {
                    musteri.AD = Convert.ToDouble(musteri.AD - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "KANADA DOLARI")
                {
                    musteri.KD = Convert.ToDouble(musteri.KD - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "RİYAL")
                {
                    musteri.RY = Convert.ToDouble(musteri.RY - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "RUS RUBLESİ")
                {
                    musteri.RB = Convert.ToDouble(musteri.RB - behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "ATATEK")
                {
                    musteri.ATATEK = Convert.ToDouble(musteri.ATATEK - behareket.Temphareket.Miktar);
                }
                behareket.hareket.StokId = behareket.hareket.StokId + "-" + behareket.Temphareket.StokId;
            }
            else if (behareket.hareket.HareketTipi == "EMANET DÖNÜŞÜM")
            {
                behareket.hareket.HareketTuru = "DÖNÜŞÜM";
                
                behareket.hareket.DonusumMiktar = behareket.Temphareket.Miktar;

                if (behareket.hareket.StokId == "ÇEYREK")
                {
                    musteri.ÇEYREK = Convert.ToDouble(musteri.ÇEYREK - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "YARIM")
                {
                    musteri.YARIM = Convert.ToDouble(musteri.YARIM - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "2.5'LU")
                {
                    musteri.IkıBucuklU = Convert.ToDouble(musteri.IkıBucuklU - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "C.LİRA")
                {
                    musteri.CLİRA = Convert.ToDouble(musteri.CLİRA - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "22 AYAR GRAM")
                {
                    musteri.YiAyarGRAM = Convert.ToDouble(musteri.YiAyarGRAM - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "24 AYAR GRAM")
                {
                    musteri.YdAyarGRAM = Convert.ToDouble(musteri.YdAyarGRAM - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "HAMİT LİRA")
                {
                    musteri.HLira = Convert.ToDouble(musteri.HLira - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "AMERİKAN DOLARI")
                {
                    musteri.USD = Convert.ToDouble(musteri.USD - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "EURO")
                {
                    musteri.EURO = Convert.ToDouble(musteri.EURO - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İSVİÇRE FRANGI")
                {
                    musteri.CHF = Convert.ToDouble(musteri.CHF - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "DANİMARKA KRONU")
                {
                    musteri.DKK = Convert.ToDouble(musteri.DKK - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İNGİLİZ STERLİNİ")
                {
                    musteri.STRL = Convert.ToDouble(musteri.STRL - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "KÜLÇE ALTIN")
                {
                    musteri.HAS = Convert.ToDouble(musteri.HAS - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "TÜRK LİRASI")
                {
                    musteri.TL = Convert.ToDouble(musteri.TL - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "REŞAT BEŞLİ")
                {
                    musteri.RBesli = Convert.ToDouble(musteri.RBesli - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "HAMİT BEŞLİ")
                {
                    musteri.HBesli = Convert.ToDouble(musteri.HBesli - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "CUMHURİYET BEŞLİ")
                {
                    musteri.CBesli = Convert.ToDouble(musteri.CBesli - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "REŞAT LİRA")
                {
                    musteri.RLira = Convert.ToDouble(musteri.RLira - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "İSVEÇ KRONU")
                {
                    musteri.SEK = Convert.ToDouble(musteri.SEK - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "NORVEÇ KRONU")
                {
                    musteri.NOK = Convert.ToDouble(musteri.NOK - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "JAPON YENİ")
                {
                    musteri.JPY = Convert.ToDouble(musteri.JPY - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "AVUSTRALYA DOLARI")
                {
                    musteri.AD = Convert.ToDouble(musteri.AD - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "KANADA DOLARI")
                {
                    musteri.KD = Convert.ToDouble(musteri.KD - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "RİYAL")
                {
                    musteri.RY = Convert.ToDouble(musteri.RY - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "RUS RUBLESİ")
                {
                    musteri.RB = Convert.ToDouble(musteri.RB - behareket.hareket.Miktar);
                }
                else if (behareket.hareket.StokId == "ATATEK")
                {
                    musteri.ATATEK = Convert.ToDouble(musteri.ATATEK - behareket.hareket.Miktar);
                }


                if (behareket.Temphareket.StokId == "ÇEYREK")
                {
                    musteri.ÇEYREK = Convert.ToDouble(musteri.ÇEYREK + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "YARIM")
                {
                    musteri.YARIM = Convert.ToDouble(musteri.YARIM + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "2.5'LU")
                {
                    musteri.IkıBucuklU = Convert.ToDouble(musteri.IkıBucuklU + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "C.LİRA")
                {
                    musteri.CLİRA = Convert.ToDouble(musteri.CLİRA + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "22 AYAR GRAM")
                {
                    musteri.YiAyarGRAM = Convert.ToDouble(musteri.YiAyarGRAM + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "24 AYAR GRAM")
                {
                    musteri.YdAyarGRAM = Convert.ToDouble(musteri.YdAyarGRAM + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "HAMİT LİRA")
                {
                    musteri.HLira = Convert.ToDouble(musteri.HLira + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "AMERİKAN DOLARI")
                {
                    musteri.USD = Convert.ToDouble(musteri.USD + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "EURO")
                {
                    musteri.EURO = Convert.ToDouble(musteri.EURO + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "İSVİÇRE FRANGI")
                {
                    musteri.CHF = Convert.ToDouble(musteri.CHF + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "DANİMARKA KRONU")
                {
                    musteri.DKK = Convert.ToDouble(musteri.DKK + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "İNGİLİZ STERLİNİ")
                {
                    musteri.STRL = Convert.ToDouble(musteri.STRL + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "KÜLÇE ALTIN")
                {
                    musteri.HAS = Convert.ToDouble(musteri.HAS + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "TÜRK LİRASI")
                {
                    musteri.TL = Convert.ToDouble(musteri.TL + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "REŞAT BEŞLİ")
                {
                    musteri.RBesli = Convert.ToDouble(musteri.RBesli + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "HAMİT BEŞLİ")
                {
                    musteri.HBesli = Convert.ToDouble(musteri.HBesli + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "CUMHURİYET BEŞLİ")
                {
                    musteri.CBesli = Convert.ToDouble(musteri.CBesli + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "REŞAT LİRA")
                {
                    musteri.RLira = Convert.ToDouble(musteri.RLira + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "İSVEÇ KRONU")
                {
                    musteri.SEK = Convert.ToDouble(musteri.SEK + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "NORVEÇ KRONU")
                {
                    musteri.NOK = Convert.ToDouble(musteri.NOK + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "JAPON YENİ")
                {
                    musteri.JPY = Convert.ToDouble(musteri.JPY + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "AVUSTRALYA DOLARI")
                {
                    musteri.AD = Convert.ToDouble(musteri.AD + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "KANADA DOLARI")
                {
                    musteri.KD = Convert.ToDouble(musteri.KD + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "RİYAL")
                {
                    musteri.RY = Convert.ToDouble(musteri.RY + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "RUS RUBLESİ")
                {
                    musteri.RB = Convert.ToDouble(musteri.RB + behareket.Temphareket.Miktar);
                }
                else if (behareket.Temphareket.StokId == "ATATEK")
                {
                    musteri.ATATEK = Convert.ToDouble(musteri.ATATEK + behareket.Temphareket.Miktar);
                }

                behareket.hareket.StokId = behareket.hareket.StokId + "-" + behareket.Temphareket.StokId;
            }
            behareket.hareket.StokAdi = behareket.hareket.StokId;
            behareket.hareket.FisNo = getid();


            db.Entry(behareket.hareket).State = EntityState.Added;
            db.Entry(musteri).State = EntityState.Modified;
            db.SaveChanges();



            return RedirectToAction("BorcEmanetIslemleri", "Finans");
        }

        [HttpPost]
        public ActionResult BorcEmanetIslemleri2(List<Toptancilar> toptancilar)
        {
            StokKart stok = new StokKart();
            int? id;
            try
            {
                id = (from a in db.ToptanciHareketler
                      select a.id).Max();
            }
            catch
            {
                id = 1;
                id = id + 1;
            }
            ToptanciHareket hareket = new ToptanciHareket();
            hareket.FisNo = "Tİ" + id;
            hareket.Tarih = DateTime.Now;
            hareket.StokId = "";
            for (int y = 0; y < toptancilar.Count; y++)
            {
                hareket.StokId = hareket.StokId + " " + toptancilar[y].barkodNo;
            }
            hareket.ToptanciiAdi = toptancilar[0].ToptanciiAdi;
            hareket.Islemci = toptancilar[0].Islemci;
            hareket.Aciklama = toptancilar[0].Aciklama;
            hareket.BrutHasNet = toptancilar[0].BrutHasNet;
            hareket.TopIscilik = toptancilar[0].TopIscilik;
            hareket.ToplamHas = toptancilar[0].ToplamHas;
            hareket.IscilikZarar = toptancilar[0].IscilikZarar;
            hareket.HareketTuru = "TOPTANCI İADE";



            for (int i = 0; i < toptancilar.Count; i++)
            {
                ToptanciIade iade = new ToptanciIade();
                var value = toptancilar[i].barkodNo;
                stok = db.StokKartlari.Where(x => x.StokId == value).FirstOrDefault();
                iade.BirimFiyat = stok.BirimFiyat;
                iade.Emanet = stok.Emanet;
                iade.Fire = stok.Fire;
                iade.HasNet = stok.HasNet;
                iade.Hesaplama = stok.Hesaplama;
                iade.Image = stok.Image;
                iade.IscilikCm = stok.IscilikCm;
                iade.IscilikCmG = stok.IscilikCm;
                iade.IscilikGr = stok.IscilikGr;
                iade.Kar = stok.Kar;
                iade.MagazaNo = stok.MagazaNo;
                iade.Maliyet = stok.Maliyet;
                iade.Miktar = stok.Miktar;
                iade.Milyem = stok.Milyem;
                iade.Ozellik1 = stok.Ozellik1;
                iade.Ozellik10 = stok.Ozellik10;
                iade.Ozellik2 = stok.Ozellik2;
                iade.Ozellik3 = stok.Ozellik3;
                iade.Ozellik4 = stok.Ozellik4;
                iade.Ozellik5 = stok.Ozellik5;
                iade.Ozellik6 = stok.Ozellik6;
                iade.Ozellik7 = stok.Ozellik7;
                iade.Ozellik8 = stok.Ozellik8;
                iade.Ozellik9 = stok.Ozellik9;
                iade.RafOmru = stok.RafOmru;
                iade.SatisTutari = stok.SatisTutari;
                iade.Sertifika = stok.Sertifika;
                iade.StokAltGrubu = stok.StokAltGrubu;
                iade.StokCinsi = stok.StokCinsi;
                iade.StokGrubu = stok.StokGrubu;
                iade.StokId = stok.StokId;
                iade.Tarih = DateTime.Now;
                iade.ToptanciAdi = toptancilar[i].toptancii;
                iade.Turu = stok.Turu;
                iade.FisNo = "Tİ" + id;
                db.Entry(iade).State = EntityState.Added;
                db.Entry(stok).State = EntityState.Deleted;
                db.SaveChanges();
                if (stok.Turu == "HAS")
                {
                    hareket.Turu = "HAS";
                }
                else if (stok.Turu == "TL")
                {
                    hareket.Turu = "TL";
                }
                else if (stok.Turu == "USD")
                {
                    hareket.Turu = "USD";
                }
            }
            db.Entry(hareket).State = EntityState.Added;
            db.SaveChanges();
            Toptanci toptanci = new Toptanci();

            toptanci = db.Toptancilar.Where(x => x.ToptanciAdi == hareket.ToptanciiAdi).FirstOrDefault();
            if (hareket.Turu == "HAS")
            {
                toptanci.Bakiye = Convert.ToDouble(toptanci.Bakiye + hareket.ToplamHas);
            }
            else if (hareket.Turu == "TL")
            {
                toptanci.TlBakiye = Convert.ToDouble(toptanci.TlBakiye + hareket.ToplamHas);
            }
            else if (hareket.Turu == "USD")
            {
                toptanci.UsdBakiye = Convert.ToDouble(toptanci.UsdBakiye + hareket.ToplamHas);
            }
            db.Entry(toptanci).State = EntityState.Modified;
            db.SaveChanges();

            return Json("k");
        }


        [HttpPost]
        public ActionResult BorcEmanetIslemleri1(string barkod)
        {
            StokKart yeni = new StokKart();
            yeni = db.StokKartlari.Where(x => x.StokId == barkod).FirstOrDefault();
            if (yeni == null)
            {
                var x = "failed";
                return Json(x);
            }
            if (yeni.Turu != "HAS")
            {
                yeni.IscilikCmG = yeni.BirimFiyat;
            }

            string k = yeni.StokId + ", " + yeni.Miktar + ", " + yeni.IscilikCm + ", " + yeni.IscilikCmG + ", " + yeni.IscilikGr + ", " + yeni.HasNet
                 + ", " + yeni.Maliyet + ", " + yeni.Turu + ", " + yeni.SatisTutari + ", " + yeni.ToptanciAdi;
            return Json(k);
        }



        Kuyumcu.Data.KuyumcuContext db13 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult BEMGridViewPartial()
        {
            var model = db13.Musteriler;
            return PartialView("_BEMGridViewPartial", model.ToList());
        }
        [HttpPost]
        public ActionResult BEM1(int k)
        {
            var data = db.Musteriler.Where(x => x.id == k).Select(y => y.AdSoyad).FirstOrDefault();
            return Json(data);
        }


        [HttpPost]
        public ActionResult BEM(int k)
        {
            string data = "";
            Musteri musteri = new Musteri();
            musteri = db.Musteriler.Where(x => x.id == k).FirstOrDefault();
            if (musteri.ÇEYREK < 0)
            {
                data = data + " " + (-1 * musteri.ÇEYREK) + " ÇEYREK " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.YARIM < 0)
            {
                data = data + " " + (-1 * musteri.YARIM) + " YARIM " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.ATATEK < 0)
            {
                data = data + " " + (-1 * musteri.ATATEK) + " ATATEK " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.IkıBucuklU < 0)
            {
                data = data + " " + (-1 * musteri.IkıBucuklU) + " 2.5'LU " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.CLİRA < 0)
            {
                data = data + " " + (-1 * musteri.CLİRA) + " C.LİRA " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.YiAyarGRAM < 0)
            {
                data = data + " " + (-1 * musteri.YiAyarGRAM) + " 22 GRAM ALTIN " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.YdAyarGRAM < 0)
            {
                data = data + " " + (-1 * musteri.YdAyarGRAM) + " 24 GRAM ALTIN " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.HLira < 0)
            {
                data = data + " " + (-1 * musteri.HLira) + " H.LİRA " + "BORÇLU" + System.Environment.NewLine;
            }

            if (musteri.RBesli < 0)
            {
                data = data + " " + (-1 * musteri.RBesli) + " RBESLİ " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.HBesli < 0)
            {
                data = data + " " + (-1 * musteri.HBesli) + " H.BESLİ " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.CBesli < 0)
            {
                data = data + " " + (-1 * musteri.CBesli) + " C.BESLİ " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.RLira < 0)
            {
                data = data + " " + (-1 * musteri.RLira) + " R.LİRA " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.USD < 0)
            {
                data = data + " " + (-1 * musteri.USD) + " USD " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.EURO < 0)
            {
                data = data + " " + (-1 * musteri.EURO) + " EURO " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.CHF < 0)
            {
                data = data + " " + (-1 * musteri.CHF) + " İSVİÇRE FRANGI " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.DKK < 0)
            {
                data = data + " " + (-1 * musteri.DKK) + " DANİMARKA KRONU " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.STRL < 0)
            {
                data = data + " " + (-1 * musteri.STRL) + " STERLİN " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.SEK < 0)
            {
                data = data + " " + (-1 * musteri.SEK) + " İSVEÇ KRONU " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.NOK < 0)
            {
                data = data + " " + (-1 * musteri.NOK) + " NORVEÇ KRONU " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.JPY < 0)
            {
                data = data + " " + (-1 * musteri.JPY) + " JAPON YENİ " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.KD < 0)
            {
                data = data + " " + (-1 * musteri.KD) + " KANADA DOLARI " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.AD < 0)
            {
                data = data + " " + (-1 * musteri.AD) + " AVUSTRALYA DOLARI " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.RB < 0)
            {
                data = data + " " + (-1 * musteri.RB) + " RUS RUBLESİ " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.RY < 0)
            {
                data = data + " " + (-1 * musteri.RY) + " RİYAL " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.HAS < 0)
            {
                data = data + " " + (-1 * musteri.HAS) + " HAS " + "BORÇLU" + System.Environment.NewLine;
            }
            if (musteri.TL < 0)
            {
                data = data + " " + (-1 * musteri.TL) + " TÜRK LİRASI " + "BORÇLU" + System.Environment.NewLine;
            }
            data = data + "-----------------------------------------------" + System.Environment.NewLine;

            if (musteri.ÇEYREK > 0)
            {
                data = data + " " + musteri.ÇEYREK + " ÇEYREK " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.YARIM > 0)
            {
                data = data + " " + musteri.YARIM + " YARIM " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.ATATEK > 0)
            {
                data = data + " " + musteri.ATATEK + " ATATEK " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.IkıBucuklU > 0)
            {
                data = data + " " + musteri.IkıBucuklU + " 2.5'LU " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.CLİRA > 0)
            {
                data = data + " " + musteri.CLİRA + " C.LİRA " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.YiAyarGRAM > 0)
            {
                data = data + " " + musteri.YiAyarGRAM + " 22 GRAM ALTIN " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.YdAyarGRAM > 0)
            {
                data = data + " " + musteri.YdAyarGRAM + " 24 GRAM ALTIN " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.HLira > 0)
            {
                data = data + " " + musteri.HLira + " H.LİRA " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.RBesli > 0)
            {
                data = data + " " + musteri.RBesli + " R.BEŞLİ " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.HBesli > 0)
            {
                data = data + " " + musteri.HBesli + " H.BEŞLİ " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.CBesli > 0)
            {
                data = data + " " + musteri.CBesli + " C.BEŞLİ " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.RLira > 0)
            {
                data = data + " " + musteri.RLira + " REŞAT LİRA " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.USD > 0)
            {
                data = data + " " + musteri.USD + " USD " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.EURO > 0)
            {
                data = data + " " + musteri.EURO + " EURO " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.CHF > 0)
            {
                data = data + " " + musteri.CHF + " İSVİÇRE FRANGI " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.DKK > 0)
            {
                data = data + " " + musteri.DKK + " DANİMARKA KRONU " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.STRL > 0)
            {
                data = data + " " + musteri.STRL + " STERLİN " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.SEK > 0)
            {
                data = data + " " + musteri.SEK + " İSVEÇ KRONU " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.NOK > 0)
            {
                data = data + " " + musteri.NOK + " NORVEÇ KRONU " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.JPY > 0)
            {
                data = data + " " + musteri.JPY + " JAPON YENİ " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.KD > 0)
            {
                data = data + " " + musteri.KD + " KANADA DOLARI " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.AD > 0)
            {
                data = data + " " + musteri.AD + " AVUSTRALYA DOLARI " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.RB > 0)
            {
                data = data + " " + musteri.RB + " RUS RUBLESİ " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.RY > 0)
            {
                data = data + " " + musteri.RY + " RİYAL " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.HAS > 0)
            {
                data = data + " " + musteri.HAS + " HAS " + "ALACAKLI" + System.Environment.NewLine;
            }
            if (musteri.TL > 0)
            {
                data = data + " " + musteri.TL + " TÜRK LİRASI " + "ALACAKLI" + System.Environment.NewLine;
            }

            return Json(data);
        }

        public ActionResult BorcEmanetDetay()
        {
           
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult BorcEmanetDetay1(string AdSoyad)
        {
           if(AdSoyad == null)
            {
                AdSoyad = temp;
            }
           else
            {
                temp = AdSoyad;
            }

            var model = db13.StokHareketleri.Where(x => x.MusteriAdi == AdSoyad && x.HareketTuru == "BORÇ" || x.MusteriAdi == AdSoyad && x.HareketTuru == "A EMANET" || x.MusteriAdi == AdSoyad && x.HareketTuru == "EMANET" || x.MusteriAdi == AdSoyad && x.HareketTuru == "A BORÇ");
            return PartialView("_BorcEmanetPartial", model.ToList());
        }
        

        public ActionResult BorcEmanetDetayPartialDelete(System.Int32 IslemNo)
        {
            var model = db.StokHareketleri;
            var AdSoyad = "";
            
            if (IslemNo >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.IslemNo == IslemNo);
                    AdSoyad = item.MusteriAdi;

                    if (item != null)
                    model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_BorcEmanetPartial", model.Where(x => x.MusteriAdi == AdSoyad && x.HareketTuru == "BORÇ" || x.MusteriAdi == AdSoyad && x.HareketTuru == "A EMANET" || x.MusteriAdi == AdSoyad && x.HareketTuru == "EMANET").ToList());
        }

        public ActionResult Toptanci()
        {
            return View();
        }

        Kuyumcu.Data.KuyumcuContext db14 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult THareketGridViewPartial()
        {
            var model = db14.ToptanciHareketler;
            return PartialView("_THareketGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult THareketGridViewPartialAddNew(Kuyumcu.Models.Finans.ToptanciHareket item)
        {
            var model = db14.ToptanciHareketler;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db14.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_THareketGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult THareketGridViewPartialUpdate(Kuyumcu.Models.Finans.ToptanciHareket item)
        {
            var model = db14.ToptanciHareketler;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db14.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_THareketGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult THareketGridViewPartialDelete(System.Int32 id)
        {
            var model = db14.ToptanciHareketler;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    db14.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_THareketGridViewPartial", model.ToList());
        }

        Kuyumcu.Data.KuyumcuContext db15 = new Kuyumcu.Data.KuyumcuContext();

        [ValidateInput(false)]
        public ActionResult TBakiyeGridView1Partial()
        {
            var model = db15.Toptancilar.Where(x => x.MagazaNo == "NO1");
            return PartialView("_TBakiyeGridView1Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TBakiyeGridView1PartialAddNew(Kuyumcu.Models.Kuyumcu.Toptanci item)
        {
            var model = db15.Toptancilar;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db15.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TBakiyeGridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TBakiyeGridView1PartialUpdate(Kuyumcu.Models.Kuyumcu.Toptanci item)
        {
            var model = db15.Toptancilar;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id == item.id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db15.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TBakiyeGridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TBakiyeGridView1PartialDelete(System.Int32 id)
        {
            var model = db15.Toptancilar;
            if (id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id == id);
                    if (item != null)
                        model.Remove(item);
                    db15.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_TBakiyeGridView1Partial", model.ToList());
        }
        public ActionResult KKTahsilat()
        {
            KKBanka model = new KKBanka();
            StokHareket hareket = new StokHareket();
            hareket.Tarih = DateTime.Now;
            model.hareket = hareket;
            model.Personel = db.Personel.Select(x => x.AdiSoyadi).ToList();
            model.Bankalar = db.Komisyonlar.Select(x => x.BankaAdi).Distinct().ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult KKTahsilat1(KKBanka tahsilat)
        {
            tahsilat.hareket.StokId = "KREDİ KARTI";
            tahsilat.hareket.Hesaplama = "Adet";
            tahsilat.hareket.Miktar = tahsilat.hareket.SatisTutari - tahsilat.hareket1.KomisyonOrani;
            tahsilat.hareket.HareketTuru = "GİRİŞ";
            tahsilat.hareket.HareketTipi = "KREDİ KARTI TAHSİLAT";
            tahsilat.hareket.Onay = false;
            tahsilat.hareket.FisNo = getid();
            tahsilat.hareket.Turu = "BANKA";
            //tahsilat.hareket.Kar = tahsilat.hareket1.Kar; // Bu kodda yok
            //tahsilat.hareket.Kar = tahsilat.hareket1.KomisyonOrani; // Bu değiştirildi
            tahsilat.hareket.KomisyonOrani = tahsilat.hareket1.KomisyonOrani;
            

            tahsilat.hareket1.Tarih = tahsilat.hareket.Tarih;
            tahsilat.hareket1.StokId = "TÜRK LİRASI";
            tahsilat.hareket1.StokAdi = "TÜRK LİRASI";
            tahsilat.hareket1.Islemci = tahsilat.hareket.Islemci;
            tahsilat.hareket1.MusteriAdi = tahsilat.hareket.MusteriAdi;
            tahsilat.hareket1.Hesaplama = "Adet";
            tahsilat.hareket1.SubeNo = tahsilat.hareket.SubeNo;
            tahsilat.hareket1.Miktar = tahsilat.hareket1.SatisTutari;
            tahsilat.hareket1.HareketTipi = "KREDİ KARTI TAHSİLAT";
            tahsilat.hareket1.HareketTuru = "ÇIKIŞ";
            tahsilat.hareket1.FisNo = tahsilat.hareket.FisNo;
            tahsilat.hareket1.Turu = "DÖVİZ";
            tahsilat.hareket1.Kar = tahsilat.hareket.Kar;
            tahsilat.hareket1.KomisyonOrani = tahsilat.hareket.KomisyonOrani;
            tahsilat.hareket1.Taksit = tahsilat.hareket.Taksit;

            db.Entry(tahsilat.hareket).State = EntityState.Added;
            db.Entry(tahsilat.hareket1).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("KKTahsilat", "Finans");
        }
        [HttpPost]
        public ActionResult MusteriBakiyeCek(string MusteriAdi)
        {
            KuyumcuContext db = new KuyumcuContext();
            Musteri musteri = new Musteri();
            musteri = db.Musteriler.Where(x => x.AdSoyad == MusteriAdi).FirstOrDefault();
            if (musteri != null)
            {
                var data = musteri.HAS + ", " + musteri.TL + ", " + musteri.EURO + ", " + musteri.USD + ", " + musteri.STRL + ", " + musteri.CHF + ", " + musteri.DKK + ", " + musteri.SEK + ", " +
                musteri.KD + ", " + musteri.RY + ", " + musteri.YARIM + ", " + musteri.ÇEYREK + ", " + musteri.ATATEK + ", " + musteri.YiAyarGRAM + ", " + musteri.IkıBucuklU + ", " + musteri.YdAyarGRAM + ", " +
                musteri.CLİRA + ", " + musteri.HLira;
                return Json(data);
            }
            else
            {
                return View();
            }
        }
    }

}