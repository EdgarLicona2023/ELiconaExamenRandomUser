using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SL.Controllers
{
    public class RandonUserController : Controller
    {
        // GET: RandonUser
        public ActionResult GetAll()
        {
            return View();
        }
    }
}