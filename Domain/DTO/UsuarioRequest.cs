using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    // Esta clase representa los datos que se reciben cuando se crea o actualiza un usuario.
    public class UsuarioRequest
    {
        // ID único del usuario
        public int PkUsuario { get; set; }

        // Nombre del usuario
        public string Nombre { get; set; }

        // Nombre de usuario (usado para iniciar sesión)
        public string Username { get; set; }

        // Contraseña del usuario
        public string Password { get; set; }

        // ID del rol asignado al usuario (puede ser nulo)
        public int? FkRol { get; set; }
    }
}
