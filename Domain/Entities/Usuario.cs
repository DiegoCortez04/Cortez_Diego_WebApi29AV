using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Esta clase representa a un usuario del sistema
    public class Usuario
    {
        // Clave primaria del usuario (ID único)
        [Key]
        public int PkUsuario { get; set; }

        // Nombre completo del usuario
        public string Nombre { get; set; }

        // Nombre de usuario (para iniciar sesión)
        public string Username { get; set; }

        // Contraseña del usuario
        public string Password { get; set; }

        // Clave foránea que indica el rol asignado al usuario (puede ser nula)
        [ForeignKey("Roles")]
        public int? FkRol { get; set; }

        // Propiedad de navegación que representa el rol del usuario
        public Rol Roles { get; set; }
    }
}
