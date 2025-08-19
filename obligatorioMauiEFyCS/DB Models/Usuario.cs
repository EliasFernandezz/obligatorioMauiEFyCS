using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioMauiEFyCS.DB_Models
{
    public class Usuario
    {
        [PrimaryKey]
        [Required]
        [System.ComponentModel.DataAnnotations.MaxLength(20)]
        public string Nickname { get; set; }

        [Required]
        [Unique]
        [MinLength(8)]
        [System.ComponentModel.DataAnnotations.MaxLength(16)]
        public string Contrasena { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Phone]
        [Required]
        public int Telefono { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public byte[]  FotoPerfil { get; set; }
    }
}
