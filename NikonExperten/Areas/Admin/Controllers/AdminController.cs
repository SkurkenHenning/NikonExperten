using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoNE;
using RepoNE.Factories;

namespace NikonExperten.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        KategoriFac kf = new KategoriFac();
        ProduktFac pf = new ProduktFac();
            // GET: Admin/Admin
        public ActionResult Index()
        {

            return View();

        }

        public ActionResult OpretKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OpretKategori(Kategori k, HttpPostedFileBase Billede)
        {
            if (Billede != null)
            {
                Uploader u = new Uploader();
                string path = Path.GetFullPath(Request.PhysicalApplicationPath + "Content/images/kategorier/");
                string file = u.UploadImage(Billede, path, 250, true);

                k.Billede = Path.GetFileName(file);
                kf.Insert(k);
                @ViewBag.MSG = "Produktet er oprettet med billede";
            }
            else
            {
                k.Billede = "ImageComing.jpg";
                kf.Insert(k);
                @ViewBag.MSG = "Produktet er oprettet med standard billede";
            }
            return View("OpretKategori");
        }

        public ActionResult OpretProdukt()
        {
            return View(kf.GetAll());
        }
        [HttpPost]
        public ActionResult OpretProdukt(Produkt p, HttpPostedFileBase Billede)
        {
            if (Billede != null)
            {
                Uploader u = new Uploader();
                string path = Path.GetFullPath(Request.PhysicalApplicationPath + "Content/images/produkter/");
                string file = u.UploadImage(Billede, path, 200, true);

                p.Billede = Path.GetFileName(file);
                pf.Insert(p);
                @ViewBag.MSG = "Produktet er oprettet med det valgte billede";
            }
            else
            {
                p.Billede = "ImageComing.jpg";
                pf.Insert(p);
                @ViewBag.MSG = "Produktet er oprettet med standard billede";
            }
            return View("Index");
        }


        public ActionResult SletRedigerKategori()
        {
            return View(kf.GetAll());
        }

        public ActionResult SletRedigerKategoriResult(int id)
        {
            kf.Delete(id);
            return View("SletRedigerKategori", kf.GetAll());
        }

        public ActionResult RedigerKategori(int id)
        {
            return View(kf.Get(id));
        }
        [HttpPost]
        public ActionResult RedigerKategori(Kategori k, HttpPostedFileBase Fil)
        {
            if (Fil != null)
            {
                Uploader u = new Uploader();
                string path = Path.GetFullPath(Request.PhysicalApplicationPath + "Content/images/kategorier/");
                string file = u.UploadImage(Fil, path, 200, true);

                k.Billede = Path.GetFileName(file);
                kf.Update(k);
                @ViewBag.MSG = "Produktet er oprettet med det valgte billede";
            }
            else
            {
                kf.Update(k);
                @ViewBag.MSG = "Produktet er oprettet med standard billede";
            }
            return View("SletRedigerKategori", kf.GetAll());
        }

        public ActionResult RedigerProdukt(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult RedigerProdukt()
        {
            return View(pf.Get(id));
        }


    }
}