﻿using System;
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
        OmOsFac OO = new OmOsFac();
        // GET: Default
        public ActionResult Index(Kategori k)
        {

            return View(kf.GetAll());
        }

        public ActionResult OmOs()
        {

            return View(OO.Get(2));
        }

        public ActionResult ProduktListe()
        {

            return View(OO.GetAll());
        }
    }
}