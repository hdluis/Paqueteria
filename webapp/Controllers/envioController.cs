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
    public class envioController : Controller
    {
        // GET: envio
        public ActionResult nuevo()
        {
            return View();
        }

        public ActionResult getClientes()
        {
            List<eCliente> listClientes = new List<eCliente>();
            dCliente obj = new dCliente();
            DataTable dtClientes = obj.getClientes();
            foreach (DataRow row in dtClientes.Rows)
            {
                eCliente Cliente = new eCliente();
                Cliente.codigo = Convert.ToInt32(row["codigo"].ToString());
                Cliente.nombre = row["nombre"].ToString();
                listClientes.Add(Cliente);
            }
            return Json(listClientes, JsonRequestBehavior.AllowGet);
        }

        public ActionResult guardar(eEnvio envio)
        {
            envio.agencia = Convert.ToInt32(Session["agencia"].ToString());
            dEnvio obj = new dEnvio();
            int retorno = obj.GuardarEnvio(envio);
            return RedirectToAction("listar");
        }

        public ActionResult listar()
        {
            List<eEnvio> listEnvios = new List<eEnvio>();
            dEnvio obj = new dEnvio();
            DataTable dtEnvios = obj.getEnvios();
            foreach (DataRow row in dtEnvios.Rows)
            {
                eEnvio Envio = new eEnvio();
                Envio.codigo = Convert.ToInt32(row["codigo"].ToString());
                Envio.descAgencia = row["agencia"].ToString();
                Envio.descCliente =row["cliente"].ToString();
                Envio.peso = Convert.ToDouble( row["peso"].ToString());
                Envio.costo  = Convert.ToDecimal( row["peso"].ToString());
                Envio.descripcion = row["descripcion"].ToString();
                Envio.fecha = row["fecha_envio"].ToString();
              //  Envio.direccion = row["direccion"].ToString();
                listEnvios.Add(Envio);
            }
            return View(listEnvios);
        }
    }
}