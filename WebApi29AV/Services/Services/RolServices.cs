using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi29AV.Context;
using WebApi29AV.Services.IServices;

namespace WebApi29AV.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;

        // Recibe el contexto de la base de datos para poder usarlo en los métodos
        public RolServices(ApplicationDbContext context)
        {
            _context = context;
        }

        // Trae todos los roles almacenados en la base de datos
        public async Task<List<Rol>> GetRols()
        {
            try
            {
                // Usa Entity Framework para obtener todos los roles como una lista
                return await _context.Roles.ToListAsync();
            }
            catch (Exception ex)
            {
                // En caso de error, lanza una excepción con el mensaje
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        // Busca un rol específico usando su ID
        public async Task<Rol> GetByIdRol(int id)
        {
            try
            {
                // Busca el primer rol que tenga el ID indicado (o null si no existe)
                return await _context.Roles.FirstOrDefaultAsync(x => x.PkRol == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        // Crea un nuevo rol en la base de datos
        public async Task<Rol> CreateRol(Rol i)
        {
            try
            {
                // Crea un nuevo objeto Rol con el nombre recibido
                Rol request = new Rol()
                {
                    Nombre = i.Nombre
                };

                // Agrega el nuevo rol al contexto para que se guarde
                await _context.Roles.AddAsync(request);

                // Guarda los cambios en la base de datos (persistir la creación)
                _context.SaveChanges();

                // Devuelve el rol que se creó
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        // Actualiza los datos de un rol existente
        public async Task<Rol> EditRol(Rol i)
        {
            try
            {
                // Busca el rol existente en la base de datos por su ID
                Rol request = await _context.Roles.FindAsync(i.PkRol);

                // Cambia el nombre del rol con el nuevo valor que llegó
                request.Nombre = i.Nombre;

                // Marca el objeto como modificado para que se actualice en la BD
                _context.Entry(request).State = EntityState.Modified;

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                // Devuelve el rol actualizado
                return request;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }

        // Borra un rol usando su ID
        public async Task<bool> DeleteRol(int id)
        {
            try
            {
                // Busca el rol en la base de datos con ese ID
                var rol = await _context.Roles.FindAsync(id);

                // Si no existe el rol, devuelve false para indicar que no se pudo borrar
                if (rol == null)
                    return false;

                // Remueve el rol del contexto para borrarlo
                _context.Roles.Remove(rol);

                // Guarda los cambios en la base de datos para que se elimine realmente
                await _context.SaveChangesAsync();

                // Devuelve true porque la eliminación fue exitosa
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgió un error: " + ex.Message);
            }
        }
    }
}
