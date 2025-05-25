using Domain.Entities;

namespace WebApi29AV.Services.IServices
{
    // Interfaz que define las operaciones que se pueden realizar con los roles
    public interface IRolServices
    {
        // Obtiene la lista completa de roles
        public Task<List<Rol>> GetRols();

        // Obtiene un rol específico por su ID
        public Task<Rol> GetByIdRol(int id);

        // Crea un nuevo rol
        public Task<Rol> CreateRol(Rol i);

        // Edita un rol existente
        public Task<Rol> EditRol(Rol i);

        // Elimina un rol por ID y devuelve true si tuvo éxito
        public Task<bool> DeleteRol(int id);
    }
}
