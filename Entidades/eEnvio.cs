using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eEnvio
    {
        public int codigo { get; set; }
        public double peso { get; set; }
        public decimal costo { get; set; }
        public string descripcion { get; set; }
        public string fecha { get; set; }
        public int agencia { get; set; }
        public string direccion { get; set; }
        public int cliente { get; set; }
        public string descCliente { get; set; }
        public string descAgencia { get; set; }
    }
}
