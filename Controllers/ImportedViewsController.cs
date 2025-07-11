using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniverseObjects.Controllers
{
    public class ImportedViewsController : Controller
    {
        // GET: ImportedViews
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeviceAVObjects()
        {
            return View();
        }

        public ActionResult EmptyPage()
        {
            return View();
        }

        public ActionResult StandAlone2D()
        {
            return View();
        }

    }
}