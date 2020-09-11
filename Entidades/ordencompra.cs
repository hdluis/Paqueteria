using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ordencompra
    {
        public int codigo { get; set; }
        [Required]
        public string proveedor { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        [Required]
        public string producto { get; set; }
        [Required]
        public int total { get; set; }
        public string firma { get; set; }
        public string autorizador { get; set; }
    }
}
