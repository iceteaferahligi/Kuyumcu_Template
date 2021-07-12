using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kuyumcu.Data;
using Kuyumcu.Models;

namespace Kuyumcu.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris

        public ActionResult Index()
        {
            return View(new Giris());
        }

        [HttpPost]
        public ActionResult Index(Giris kullanici)
        {
            KuyumcuContext db = new KuyumcuContext();
            Giris userDetails = db.Girisler.FirstOrDefault(x => x.KullaniciAdi == kullanici.KullaniciAdi && x.Sifre == kullanici.Sifre);
            if (userDetails == null)
            {
                ModelState.AddModelError("", "Kullanici Adi ya da Şifre Hatalı!");
                return View(kullanici);
            }
            else
            {
                return RedirectToAction("Index", "Anasayfa");
            }

        }
    }
}