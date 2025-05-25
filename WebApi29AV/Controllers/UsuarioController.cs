using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi29AV.Services.IServices;

namespace WebApi29AV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        // Constructor que recibe el servicio de usuarios
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        // GET /Usuario
        // Obtiene la lista de todos los usuarios
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _usuarioServices.ObtenerUsuarios();
            return Ok(response); // Retorna 200 OK con los datos
        }

        // GET /Usuario/{id}
        // Obtiene un usuario específico por su ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _usuarioServices.ById(id));
        }

        // POST /Usuario
        // Crea un nuevo usuario a partir de los datos enviados en el cuerpo
        [HttpPost]
        public async Task<IActionResult> PostUser(UsuarioRequest request)
        {
            return Ok(await _usuarioServices.Crear(request));
        }

        // PUT /Usuario/editar/{id}
        // Actualiza la información de un usuario existente
        [HttpPut("editar/{id:int}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UsuarioRequest request)
        {
            if (id != request.PkUsuario)
                return BadRequest("El ID en la URL no coincide con el ID del cuerpo.");

            var updatedUser = await _usuarioServices.EditUser(request);

            if (updatedUser == null)
                return NotFound($"No se pudo actualizar el usuario con ID {id}.");

            return Ok(updatedUser);
        }

        // DELETE /Usuario/eliminar/{id}
        // Elimina un usuario por su ID
        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _usuarioServices.DeleteUser(id);

            if (!deleted)
                return NotFound($"No se encontró el usuario con ID {id} para eliminar.");

            return Ok(new { message = $"Usuario con ID {id} eliminado correctamente." });
        }
    }
}
