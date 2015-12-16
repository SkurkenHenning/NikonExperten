using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoNE;
using RepoNE.Factories;

namespace NikonExperten.Controllers
{
    public class DefaultController : Controller
    {
        KategoriFac kf = new KategoriFac();
        MenuNavFac mnFac = new MenuNavFac();
        KontaktFac konf = new KontaktFac();
        // GET: Default
        public ActionResult Index(Kategori k)
        {

            return View(kf.GetAll());
        }

        public ActionResult Kontakt(Kontakt kon)
        {
            return View(konf.Get(1));
        }
    }
}