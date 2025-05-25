using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi29AV.Context;
using WebApi29AV.Services.IServices;

namespace WebApi29AV.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;

        // Recibe el contexto para acceder a la base de datos
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtiene la lista completa de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios()
        {
            try
            {
                // Trae todos los usuarios de la base de datos
                List<Usuario> response = await _context.Usuarios.ToListAsync();

                // Devuelve la lista con un mensaje de confirmación
                return new Response<List<Usuario>>(response, "Lista de usuarios");
            }
            catch (Exception ex)
            {
                // En caso de error, lanza excepción con el mensaje
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        // Obtiene un usuario específico por su ID
        public async Task<Response<Usuario>> ById(int id)
        {
            try
            {
                // Busca el usuario y también carga el rol relacionado
                Usuario usuario = await _context.Usuarios
                    .Include(u => u.Roles)
                    .FirstOrDefaultAsync(x => x.PkUsuario == id);

                // Devuelve el usuario encontrado
                return new Response<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        // Crea un nuevo usuario con los datos que llegan en el request
        public async Task<Response<Usuario>> Crear(UsuarioRequest request)
        {
            try
            {
                // Crea un nuevo objeto Usuario con los datos recibidos
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    Username = request.Username,
                    Password = request.Password,
                    FkRol = request.FkRol
                };

                // Agrega el usuario al contexto para que se guarde en la BD
                _context.Usuarios.Add(usuario);

                // Guarda los cambios en la base de datos (persistir creación)
                await _context.SaveChangesAsync();

                // Devuelve el usuario creado
                return new Response<Usuario>(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

        // Actualiza un usuario existente con nueva información
        public async Task<Usuario> EditUser(UsuarioRequest i)
        {
            try
            {
                // Busca el usuario por su ID en la base de datos
                var user = await _context.Usuarios.FindAsync(i.PkUsuario);

                // Si no existe, lanza excepción con mensaje
                if (user == null)
                    throw new Exception("Usuario no encontrado.");

                // Actualiza las propiedades con la nueva información
                user.Nombre = i.Nombre;
                user.Username = i.Username;
                user.Password = i.Password;
                user.FkRol = i.FkRol;

                // Indica que el objeto fue modificado para actualizarlo
                _context.Entry(user).State = EntityState.Modified;

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                // Devuelve el usuario actualizado
                return user;
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lanza excepción con mensaje detallado
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        // Elimina un usuario por su ID
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                // Busca el usuario en la base de datos por su ID
                var user = await _context.Usuarios.FindAsync(id);

                // Si no existe el usuario, devuelve false
                if (user == null)
                    return false;

                // Elimina el usuario del contexto
                _context.Usuarios.Remove(user);

                // Guarda los cambios para que se elimine en la base de datos
                await _context.SaveChangesAsync();

                // Devuelve true indicando que la eliminación fue exitosa
                return true;
            }
            catch (Exception ex)
            {
                // Si hay error, lanza excepción con el mensaje
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }
    }
}
