using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mon1.Models;

namespace Mon1.Controllers
{

    public class CoverageController : Controller
    {
        public ActionResult Index()
        {

            var db = new asaDataContext();

            return View(db.asas.ToList<asa>());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

