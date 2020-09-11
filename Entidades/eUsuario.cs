using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class eUsuario
    {
        [Required]
        public string username { get; set; }
        public string nombre { get; set; }
        [Required]
        public string password { get; set; }


    }
}
