using Kuyumcu.Data;
using Kuyumcu.Models;
using Kuyumcu.Models.Personel_Takip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Kuyumcu.Controllers
{
    public class PersonelTakipController : Controller
    {
        // GET: PersonelTakip
        KuyumcuContext db = new KuyumcuContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PersonelEkle(personelEkle pr)
        {

            if (pr.Id == 0)
            {
                pr = null;
                return View(pr);
            }
            else
            {
                return View(pr);
            }
        }
        [HttpPost]
        public ActionResult PersonelEkle(personelEkle pr, string submit, string SearchString)
        {
            KuyumcuContext db = new KuyumcuContext();
            personelEkle personel = new personelEkle();

            if (submit == "ARA")
            {
                if(SearchString == "")
                {
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    personel = db.Personel.Where(m => m.AdiSoyadi.Equals(SearchString)).FirstOrDefault();

                    return RedirectToAction("PersonelEkle", "PersonelTakip", personel);
                }                
            }
            else if (submit.Equals("GÜNCELLE"))
            {
                //if (pr.DogumTarihi == null)
                //    personel.DogumTarihi = Convert.ToDateTime("01/01/1900");

                //else if (pr.EsDogumTarihi == null)
                //    personel.EsDogumTarihi = Convert.ToDateTime("01/01/1900");

                //else if (pr.GirisTarihi == null)
                //    personel.GirisTarihi = Convert.ToDateTime("01/01/1900");

                db.Entry(pr).State = EntityState.Modified;
                db.SaveChanges();
                ModelState.Clear();


                return RedirectToAction("PersonelEkle", "PersonelTakip");

            }
            else if (submit.Equals("KAYDET"))  // "KAYDET"
            {

                //if (pr.DogumTarihi == null)
                //    personel.DogumTarihi = Convert.ToDateTime("01/01/1900");

                //else if (pr.EsDogumTarihi == null)
                //    personel.EsDogumTarihi = Convert.ToDateTime("01/01/1900");

                //else if (pr.GirisTarihi == null)
                //    personel.GirisTarihi = Convert.ToDateTime("01/01/1900");

                db.Personel.Add(pr);
                db.SaveChanges();
                ModelState.Clear();
                // return RedirectToAction("PersonelEkle", "PersonelTakip");
                return View();
            }
            else if(submit.Equals("SİL"))
            {
                
                personel = db.Personel.Where(x => x.AdiSoyadi == pr.AdiSoyadi).FirstOrDefault();
                if(personel.AdiSoyadi != null)
                {
                    db.Personel.Remove(personel);
                    db.SaveChanges();
                }
                

                return RedirectToAction("PersonelEkle","PersonelTakip");
            }
            return View();

        }

        public ActionResult PersonelIslem()
        {
            KuyumcuContext kuyumcuContext = new KuyumcuContext();
            List<personelEkle> pr;
            pr = kuyumcuContext.Personel.ToList();
            return View(pr);
        }

        [HttpPost]
        public ActionResult PersonelIslem(string submit, string SearchString)
        {
            KuyumcuContext db = new KuyumcuContext();
            List<personelEkle> pr = new List<personelEkle>();

            if (submit == "ARA")
            {
               
                pr = db.Personel.Where(m => m.AdiSoyadi.Equals(SearchString)).ToList();
                return View(pr);

            }
            return View(pr);
        }
    }
}
