using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Esta clase representa un rol dentro del sistema (como "Administrador", "Usuario", etc.)
    public class Rol
    {
        // Clave primaria del rol (identificador único)
        [Key]
        public int PkRol { get; set; }

        // Nombre del rol
        public string Nombre { get; set; }
    }
}
