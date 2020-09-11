using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class eNuevoUsuario
    {
            [Required]
            public string username { get; set; }
            [Required]
            public string nombre { get; set; }
            [Required]
            public string password { get; set; }
            [Required]
            public int rol { get; set; }
            [Required]
            public int clave { get; set; }
    }
}
