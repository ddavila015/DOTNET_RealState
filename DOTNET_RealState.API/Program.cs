using DOTNET_RealState.Aplicacion.InyeccionDependencias;
using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Infraestructura.Repositorios;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AgregarCapaAplicacion();
builder.Services.AddScoped<IPropiedades, Propiedades>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSwagger");
app.UseAuthorization();

app.MapControllers();

app.Run();
