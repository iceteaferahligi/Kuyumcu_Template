using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Kuyumcu.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Kuyumcu.Data;
using Kuyumcu.Models.Musteri_Islemleri;
using Kuyumcu.Models.Kuyumcu;

namespace Kuyumcu.Controllers
{
    public class OrdersController : ApiController
    {
        KuyumcuContext db = new KuyumcuContext();
        [HttpGet]
        public HttpResponseMessage Get1(DataSourceLoadOptions loadOptions)
        {
            List<Musteri> Musteri = new List<Musteri>();
            Musteri = db.Musteriler.ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Musteri, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
        {
            List<StokKart> StokListesi = new List<StokKart>();
            StokListesi = db.StokKartlari.ToList();
            return Request.CreateResponse(DataSourceLoader.Load(StokListesi, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get15(DataSourceLoadOptions loadOptions)
        {
            List<StokKart> StokListesi = new List<StokKart>();
            StokListesi = db.StokKartlari.Where(x=> x.Sayim == true).ToList();
            return Request.CreateResponse(DataSourceLoader.Load(StokListesi, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get16(DataSourceLoadOptions loadOptions)
        {
            List<StokKart> StokListesi = new List<StokKart>();
            StokListesi = db.StokKartlari.Where(x => x.Sayim == false).ToList();
            return Request.CreateResponse(DataSourceLoader.Load(StokListesi, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage Get2(DataSourceLoadOptions loadOptions)
        {
            List<StokHareket> Satis = new List<StokHareket>();
            Satis = db.StokHareketleri.Where(x => x.HareketTuru == "ÇIKIŞ" && x.FisNo.Equals(null) == false || x.HareketTuru == "BORÇ" && x.FisNo.Equals(null) == false || x.HareketTuru == "EMANET" && x.FisNo.Equals(null) == false).ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get3(DataSourceLoadOptions loadOptions)
        {
            List<StokHareket> Satis = new List<StokHareket>();
            Satis = db.StokHareketleri.Where(x => x.HareketTuru == "GİRİŞ" && x.HareketTipi == "EK GELİR GİRİŞİ").ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get4(DataSourceLoadOptions loadOptions)
        {
            List<StokHareket> Satis = new List<StokHareket>();
            Satis = db.StokHareketleri.Where(x => x.HareketTuru == "ÇIKIŞ" && x.HareketTipi == "EK GİDER ÇIKIŞI").ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage Get5(DataSourceLoadOptions loadOptions)
        {
            List<StokKart> StokListesi = new List<StokKart>();
            StokListesi = db.StokKartlari.Where(x => x.RafOmru < DateTime.Today).ToList();
            return Request.CreateResponse(DataSourceLoader.Load(StokListesi, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage Get6(DataSourceLoadOptions loadOptions)
        {
            List<StokHareket> Satis = new List<StokHareket>();
            Satis = db.StokHareketleri.Where(x => x.MusteriAdi.Equals(null) == false).ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage Get7(DataSourceLoadOptions loadOptions)
        {
            List<StokHareket> Satis = new List<StokHareket>();
            Satis = db.StokHareketleri.Where(x => x.HareketTuru == "GİRİŞ" && x.StokId.Equals("TÜRK LİRASI") == false || x.HareketTuru == "A EMANET" && x.StokId.Equals("TÜRK LİRASI") == false || x.HareketTuru == "A BORÇ" && x.StokId.Equals("TÜRK LİRASI") == false).ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage Get8(DataSourceLoadOptions loadOptions)
        {
            List<StokHareket> Satis = new List<StokHareket>();
            Satis = db.StokHareketleri.Where(x => x.Turu.Contains("BANKA") == true).ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get9(DataSourceLoadOptions loadOptions)
        {
            List<StokHareket> Satis = new List<StokHareket>();
            Satis = db.StokHareketleri.Where(x => x.HareketTipi == "FATURA GİRİŞ EKRANI").ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get10(DataSourceLoadOptions loadOptions)
        {
           
            var model = db.ToptanciHareketler.ToList();
            return Request.CreateResponse(DataSourceLoader.Load(model, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get11(DataSourceLoadOptions loadOptions)
        {
            List<BarkodsuzStokKart> Satis = new List<BarkodsuzStokKart>();
            Satis = db.BarkodsuzStokKartlari.Where(x => x.Turu == "HAS" && x.StokCinsi.Contains("HURDA") == false).ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage Get12(DataSourceLoadOptions loadOptions)
        {
            List<BarkodsuzStokKart> Satis = new List<BarkodsuzStokKart>();
            Satis = db.BarkodsuzStokKartlari.Where(x => x.Turu == "HAS" && x.StokCinsi.Contains("HURDA") == true).ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }

        [HttpGet]
        public HttpResponseMessage Get13(DataSourceLoadOptions loadOptions)
        {
            var Satis = (from a in db.StokKartlari
                         where a.StokCinsi == "PIRLANTA"
                         join b in db.PirlantaOz on a.StokId equals b.Stokid
                         select new { a.StokId,  a.RafOmru, a.SatisTutari,
                              a.Sertifika,a.ToptanciAdi,a.EtiketFiyat, b.MetalGr,b.Carat1, b.Carat2,
                         b.Carat3, b.Carat4, b.Carat5, b.Ayrinti1, b.Ayrinti2, b.Ayrinti3, b.Ayrinti4, b.Ayrinti5,
                             b.TCinsi1, b.TCinsi2, b.TCinsi3, b.TCinsi4, b.TCinsi5});
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get14(DataSourceLoadOptions loadOptions)
        {
            var Satis = db.StokKartSatilanlar.Where(x => x.StokCinsi == "PIRLANTA").ToList();
            return Request.CreateResponse(DataSourceLoader.Load(Satis, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get17(DataSourceLoadOptions loadOptions)
        {
            List<Siparis> SiparisListesi = new List<Siparis>();
            SiparisListesi = db.Siparisler.ToList();
            return Request.CreateResponse(DataSourceLoader.Load(SiparisListesi, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get18(DataSourceLoadOptions loadOptions)
        {
            List<StokKartSatilan> barkodluSatilan = new List<StokKartSatilan>();
            barkodluSatilan = db.StokKartSatilanlar.ToList();
            return Request.CreateResponse(DataSourceLoader.Load(barkodluSatilan, loadOptions));
        }
        [HttpGet]
        public HttpResponseMessage Get19(DataSourceLoadOptions loadOptions)
        {
            List<Models.Finans.Banka> banka = new List<Models.Finans.Banka>();
            banka = db.Bankalar.ToList();
            return Request.CreateResponse(DataSourceLoader.Load(banka,loadOptions));
        }

    }
}