using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.Id);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");

          
        }
        public ActionResult YorumYap()
        {
            var deger = c.Yorumlars.ToList();
            return View(deger);
        }

        public ActionResult YorumSil(int id)
        {
            var dger=c.Yorumlars.Find(id);
            c.Yorumlars.Remove(dger);
            c.SaveChanges();
            return RedirectToAction("YorumYap");
        }
        
        public ActionResult YorumGetir( int id)
        {
            var yorum = c.Yorumlars.Find(id);
            return View("YorumGetir",yorum);
        }
        public ActionResult YorumGuncelle( Yorumlar y)
        {
            var yr = c.Yorumlars.Find(y.Id);
            yr.KullaniciAdi = y.KullaniciAdi;
            yr.Mail = y.Mail;
            yr.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumYap");
        }

    }
}