using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RepoNE;
using RepoNE.Factories;
using RepoNE.Models.Viewmodels;

namespace NikonExperten.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        KategoriFac kf = new KategoriFac();
        ProduktFac pf = new ProduktFac();
        Uploader uploader = new Uploader();
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
   
        public ActionResult SletRedigerProdukt()
        {   
            EditProdukt ep = new EditProdukt();
            ep.Kategorier = kf.GetAll();
            return View(ep);
        }

        public ActionResult SletRedigerProduktList(int KatID)
        {
            EditProdukt ep = new EditProdukt();
            ProduktListe pl = new ProduktListe();
            ep.Kategorier = kf.GetAll();
            pl.listProdukt = pf.GetBy("KatID", KatID);
            pl.Kategori = kf.Get(KatID);
            ep.Produktliste = pl;
            return View("SletRedigerProdukt",  ep);
        }

        public ActionResult SletRedigerProduktForm(int id)
        {
            EditProduktForm epf = new EditProduktForm();
            epf.Kategorier = kf.GetAll();
            epf.Produkt = pf.Get(id);
            return View(epf);
        }

        public ActionResult SletRedigerProduktResult(Produkt prod, HttpPostedFileBase fil)
        {
            if (fil != null)
            {
                string path = Request.PhysicalApplicationPath + "Content/images/Produkter/";
                prod.Billede = Path.GetFileName(uploader.UploadImage(fil, path, 200, true));
            }
            else
            {
                prod.Billede = "ImageComing.jpg";
            }

            pf.Update(prod);


            EditProduktForm epf = new EditProduktForm();
            epf.Kategorier = kf.GetAll();
            epf.Produkt = pf.Get(prod.ID);
            ViewBag.MSG = "Produktet er opdateret";

            return View("SletRedigerProduktForm", epf);
        }

        public ActionResult Delete(int id)
        {
            pf.Delete(id);
            return RedirectToAction("SletRedigerProdukt");
        }




    }
}