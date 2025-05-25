using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi29AV.Context
{
    // Esta clase se encarga de la conexión y configuración de la base de datos
    public class ApplicationDbContext : DbContext
    {
        // Constructor que recibe las opciones de configuración del contexto
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        // Estas propiedades representan las tablas que se van a crear en la base de datos
        public DbSet<Usuario> Usuarios { get; set; }  // Tabla de usuarios
        public DbSet<Rol> Roles { get; set; }         // Tabla de roles

        // Este método se ejecuta cuando se está creando el modelo de base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Agrega un registro inicial en la tabla Usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Majo",
                    Username = "Usuario",
                    Password = "123",
                    FkRol = 1
                });

            // Agrega un registro inicial en la tabla Rol
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "sa"
                });
        }
    }
}
