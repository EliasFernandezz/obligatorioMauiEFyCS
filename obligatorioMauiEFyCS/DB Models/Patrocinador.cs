using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioMauiEFyCS.DB_Models
{
    public class Patrocinador
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        public string Direccion { get; set; }
    }
}
