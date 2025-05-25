using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi29AV.Services.IServices;

namespace WebApi29AV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : Controller
    {
        private readonly IRolServices _rolServices;

        // Constructor: recibe el servicio de roles para poder usarlo en todos los métodos de este controlador
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        // GET /Rol
        // Obtiene la lista de todos los roles registrados
        [HttpGet]
        public async Task<IActionResult> GetRols()
        {
            var rols = await _rolServices.GetRols();
            return Ok(rols); // Devuelve la lista con código 200 OK
        }

        // GET /Rol/{id}
        // Obtiene un rol específico según su ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRol(int id)
        {
            var rol = await _rolServices.GetByIdRol(id);

            if (rol == null)
                return NotFound($"No se encontró un rol con ID {id}.");

            return Ok(rol);
        }

        // POST /Rol/crear
        // Crea un nuevo rol a partir de los datos enviados en el cuerpo del request
        [HttpPost("crear")]
        public async Task<IActionResult> PostRol([FromBody] Rol request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Verifica que los datos enviados sean válidos

            var createdRol = await _rolServices.CreateRol(request);

            // Devuelve el rol creado con código 201 Created y la ruta para consultarlo
            return CreatedAtAction(nameof(GetRol), new { id = createdRol.PkRol }, createdRol);
        }

        // PUT /Rol/editar/{id}
        // Edita los datos de un rol existente
        [HttpPut("editar/{id:int}")]
        public async Task<IActionResult> PutRol(int id, [FromBody] Rol request)
        {
            if (id != request.PkRol)
                return BadRequest("El ID en la URL no coincide con el ID del cuerpo.");

            var updatedRol = await _rolServices.EditRol(request);

            if (updatedRol == null)
                return NotFound($"No se pudo actualizar el rol con ID {id}.");

            return Ok(updatedRol);
        }

        // DELETE /Rol/eliminar/{id}
        // Elimina un rol por su ID
        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var deleted = await _rolServices.DeleteRol(id);

            if (!deleted)
                return NotFound($"No se encontró el rol con ID {id} para eliminar.");

            return Ok(new { message = $"Rol con ID {id} eliminado correctamente." });
        }
    }
}
