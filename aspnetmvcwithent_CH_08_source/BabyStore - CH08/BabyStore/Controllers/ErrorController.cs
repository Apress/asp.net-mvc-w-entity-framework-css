using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BabyStore.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult FileUploadLimitExceeded()
        {
            return View();
        }
    }
}