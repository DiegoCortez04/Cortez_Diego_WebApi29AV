using Microsoft.EntityFrameworkCore;
using WebApi29AV.Context;
using WebApi29AV.Services.IServices;
using WebApi29AV.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra el servicio UsuarioServices para que se inyecte cada vez que se necesite IUsuarioServices.
// Usa AddTransient para crear una nueva instancia cada vez que se solicite el servicio.
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();

// Registra el servicio RolServices para que se inyecte cada vez que se necesite IRolServices.
// Usa AddTransient para crear una nueva instancia cada vez que se solicite el servicio.
builder.Services.AddTransient<IRolServices, RolServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
