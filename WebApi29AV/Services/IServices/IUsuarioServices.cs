using Domain.DTO;
using Domain.Entities;

namespace WebApi29AV.Services.IServices
{
    // Interfaz que define los métodos para manejar operaciones relacionadas con usuarios
    public interface IUsuarioServices
    {
        // Obtiene una lista de todos los usuarios dentro de un objeto de respuesta genérica
        public Task<Response<List<Usuario>>> ObtenerUsuarios();

        // Busca un usuario por su ID y lo retorna dentro de un objeto de respuesta
        public Task<Response<Usuario>> ById(int id);

        // Crea un nuevo usuario a partir de los datos recibidos en el DTO (UsuarioRequest)
        public Task<Response<Usuario>> Crear(UsuarioRequest request);

        // Actualiza un usuario existente usando los datos del DTO
        public Task<Usuario> EditUser(UsuarioRequest i);

        // Elimina un usuario por su ID y devuelve true si se eliminó correctamente
        public Task<bool> DeleteUser(int id);
    }
}
