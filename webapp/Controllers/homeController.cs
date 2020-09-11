using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapp.Controllers
{
    public class homeController : Controller
    {
        // GET: home
        public ActionResult Index(eAgencia agencia)
        {
            Session["agencia"] = agencia.codigo;
            return View();
        }
    }
}