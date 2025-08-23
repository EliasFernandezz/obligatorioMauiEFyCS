using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace obligatorioMauiEFyCS.Models
{
    public class PatrocinadoresModel
    {   
        [PrimaryKey, AutoIncrement] 
        public int id { get; set; }

        [System.ComponentModel.DataAnnotations.MaxLength(20)]
        public string nombre { get; set; }

        public string logo { get; set; } 

        public string direccion { get; set; }

    }
}
