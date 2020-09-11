using datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace webapp.Controllers
{
    public class usuarioController : Controller
    {
        // GET: usuario
        public ActionResult login()
        {
            return View();
        }

        public ActionResult procesarlogin(eUsuario parUsuario )
        {
            dUsuario obj = new dUsuario();            
            int retorno = obj.verificarUsuario(parUsuario);
            if (retorno >= 1)
            {
                Session["usuario"] = parUsuario.username;
               return RedirectToAction("entorno");
                
            }
            else
            {
                return RedirectToAction("login");
            }
            
         
        }

        public ActionResult entorno()
        {
            return View();
        }

        public ActionResult getAgencias()
        {
            List<eAgencia> listAgencias = new List<eAgencia>();
            dAgencia obj = new dAgencia();
            DataTable dtAgencias= obj.getAgencias();
            foreach (DataRow row in dtAgencias.Rows)
            {
                eAgencia agencia = new eAgencia();
                agencia.codigo = Convert.ToInt32( row["cod_agencia"].ToString());
                agencia.descripcion = row["desc_agencia"].ToString();
                listAgencias.Add(agencia);
            }
            return Json(listAgencias, JsonRequestBehavior.AllowGet);
        }
        public ActionResult nuevoUsuairo()
        {
            return View();
        }

        public ActionResult procesarNuevoUsuario(eNuevoUsuario us)
        {

            dUsuario obj = new dUsuario();
            int retorno = obj.guardarUsuarios(us);
            if (retorno >= 1)
            {
                return RedirectToAction("index", "home");
            }
            else
            {
                return RedirectToAction("nuevoUsuario");
            }
        }



        public ActionResult cerrarSesion()
        {
            Session.Clear();
            return RedirectToAction("login");
           
        }

    }

}