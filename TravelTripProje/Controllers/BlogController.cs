using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum bg = new BlogYorum();
        // GET: Blog
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
      
        public ActionResult BlogDetay(int id)
        {
            //var blogbul = c.Blogs.Where(x => x.Id == id).ToList();
            bg.deger1 = c.Blogs.Where(x => x.Id == id).ToList();
            bg.deger2 = c.Yorumlars.Where(x => x.Id == id).ToList();
            return View(bg);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}