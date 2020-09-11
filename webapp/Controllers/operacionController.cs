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
    public class operacionController : Controller
    {
        // GET: operacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult nuevaOrdenCompra()
        {
            return View();
        }

        public ActionResult procesarNuevo(ordencompra orden )
        {

            dOrdenCompra obj = new dOrdenCompra();
            int retorno = obj.guardarOrdenCompra(orden);
            if (retorno >= 1)
            {
                return RedirectToAction("index", "home");
            }
            else {
                return RedirectToAction("nuevaOrdenCompra");
            }
        }

        public ActionResult verFirmados()
        {
            DataTable dtResultado = new DataTable();
            dOrdenCompra obj = new dOrdenCompra();
            dtResultado = obj.getMostrarFirmados();
            List<ordencompra> listordencompra = new List<ordencompra>();
            foreach(DataRow fila in dtResultado.Rows)
            {
                ordencompra orden = new ordencompra();
                orden.codigo = Convert.ToInt32( fila["codigo"].ToString());
                orden.proveedor =fila["proveedor"].ToString();
                orden.fecha = Convert.ToDateTime (fila["fecha"].ToString());
                orden.producto = fila["producto"].ToString();
                orden.total = Convert.ToInt32(fila["total"].ToString());
                orden.firma = fila["firma"].ToString();
                orden.autorizador = fila["autorizador"].ToString();
                listordencompra.Add(orden);
            }

            return View(listordencompra);
        }

        public ActionResult verNoFirmados()
        {
            DataTable dtResultado = new DataTable();
            dOrdenCompra obj = new dOrdenCompra();
            dtResultado = obj.getMostrarNoFirmados();
            List<ordencompra> listordencompra = new List<ordencompra>();
            foreach (DataRow fila in dtResultado.Rows)
            {
                ordencompra orden = new ordencompra();
                orden.codigo = Convert.ToInt32(fila["codigo"].ToString());
                orden.proveedor = fila["proveedor"].ToString();
                orden.fecha = Convert.ToDateTime(fila["fecha"].ToString());
                orden.producto = fila["producto"].ToString();
                orden.total = Convert.ToInt32(fila["total"].ToString());
                orden.firma = fila["firma"].ToString();
                orden.autorizador = fila["autorizador"].ToString();
                listordencompra.Add(orden);
            }

            return View(listordencompra);
        }

        public ActionResult firmar(string codigo)
        {
            ordencompra orden = new ordencompra();
            orden.codigo = Convert.ToInt32(codigo);
            orden.autorizador = Session["usuario"].ToString();
            dOrdenCompra obj = new dOrdenCompra();
            int retorno = obj.firmarOrdenCompra(orden);

            return RedirectToAction("verFirmados");

        }

    }
}