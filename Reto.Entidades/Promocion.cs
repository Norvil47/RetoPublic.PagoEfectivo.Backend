using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Entidades
{
    [Table("Promocion")]
   public class Promocion
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string nombreUsuario { get; set; }
        public string estado { get; set; }
        public string codigo { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public DateTime? fechaCanje { get; set; }


    }
}
