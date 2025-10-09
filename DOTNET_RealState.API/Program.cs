using DOTNET_RealState.Aplicacion.InyeccionDependencias;
using DOTNET_RealState.Aplicacion.Puertos;
using DOTNET_RealState.Infraestructura.Persistencia;
using DOTNET_RealState.Infraestructura.Repositorios;
using DOTNET_RealState.Infraestructura.Servicios;
using MongoDB.Driver;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

Env.Load();


// MongoDB
var mongoClient = new MongoClient(Environment.GetEnvironmentVariable("MongoDB_Conexion"));
var database = mongoClient.GetDatabase(Environment.GetEnvironmentVariable("MongoDB_Nombre_BaseDato"));
builder.Services.AddSingleton(database);

// Servicios
builder.Services.AddScoped<AuthService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AgregarCapaAplicacion();
builder.Services.AddScoped<IPropiedades, Propiedades>();
builder.Services.AddScoped<IPropietarios, Propietarios>();
builder.Services.AddScoped<IUsuarios, Usuarios>();
builder.Services.AddScoped<IMongoDBContext, MongoDBContext>();

// JWT Config
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = Environment.GetEnvironmentVariable("Mongo_WJT_Issuer"),
            ValidateAudience = true,
            ValidAudience = Environment.GetEnvironmentVariable("Mongo_WJT_Audience"),
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Mongo_WJT_KEY")))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSwagger");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
