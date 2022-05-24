using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProje.Models.Siniflar
{
    public class BlogYorum
    {
        public IEnumerable<Blog> deger1 { get; set; }
        public IEnumerable<Yorumlar> deger2 { get; set; }
    }
}