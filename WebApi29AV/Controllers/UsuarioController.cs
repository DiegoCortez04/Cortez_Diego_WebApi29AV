using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi29AV.Services.IServices;

namespace WebApi29AV.Controllers
{
    [Authorize] // Solo usuarios autenticados
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;

        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _usuarioServices.ObtenerUsuarios();
            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _usuarioServices.ById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UsuarioRequest request)
        {
            return Ok(await _usuarioServices.Crear(request));
        }

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