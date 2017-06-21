using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wtime.Controllers
{
    public class TurniController : Controller
    {
        // GET: Turni
        public ActionResult Index()
        {
            return RedirectToAction("Programmazione");
        }

        // GET: Turni
        public ActionResult Programmazione()
        {
            return View();
        }

        // GET: Turni
        public ActionResult Storico()
        {
            return View();
        }

    }
}