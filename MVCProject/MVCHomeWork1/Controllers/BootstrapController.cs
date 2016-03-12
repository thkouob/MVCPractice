using MVCHomeWork1.ActionFilter;
using MVCHomeWork1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHomeWork1.Controllers
{
    [HandleError]
    public class BootstrapController : Controller
    {
        // GET: Bootstrap
        public ActionResult Index()
        {
            return View();
        }

        [LogActionFilterAttribute]
        public ActionResult GettingStarted()
        {
            return View();
        }

        [HttpPost]
        [OutputCache(Duration = 60, VaryByParam = "url")]
        public ActionResult GettingStarted(GettingStartedViewModel model)
        {
            var url = string.Empty;
            if (model.ViewName == 1) 
            {
                url = "starter-template";
            }
            else if(model.ViewName == 2)
            {
                url = "theme";
            }
            string formatUrl = string.Format("examples/{0}/Index", url);
            return View(Url.Content(formatUrl));
        }
    }
}