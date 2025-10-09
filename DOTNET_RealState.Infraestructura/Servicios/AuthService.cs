using DOTNET_RealState.Dominio.Entidades;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;

namespace DOTNET_RealState.Infraestructura.Servicios
{
    public class AuthService
    {
        private readonly IMongoCollection<Usuario> _usuarios;
        private readonly IMongoCollection<RefreshToken> _refreshTokens;       

        public AuthService(IConfiguration config, IMongoDatabase database)
        {
            _usuarios = database.GetCollection<Usuario>("usuarios");
            _refreshTokens = database.GetCollection<RefreshToken>("refreshTokens");           
        }

        //Validar usuario y generar tokens
        public async Task<(string accessToken, string refreshToken)> LoginAsync(string username, string password)
        {
            var usuario = await _usuarios.Find(u => u.Username == username).FirstOrDefaultAsync();
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash))
                throw new UnauthorizedAccessException("Usuario o contraseña incorrectos");

            string accessToken = GenerarJwt(usuario);
            string refreshToken = await GenerarRefreshToken(usuario.Id);

            return (accessToken, refreshToken);
        }

        //Generar JWT corto
        private string GenerarJwt(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, usuario.Id),
                new Claim("role", usuario.Rol),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Mongo_WJT_KEY")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("Mongo_WJT_Issuer"),
                audience: Environment.GetEnvironmentVariable("Mongo_WJT_Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(240),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Generar refresh token y guardar en Mongo
        private async Task<string> GenerarRefreshToken(string userId)
        {
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken)));

            var entity = new RefreshToken
            {
                UsuarioId = userId,
                TokenHash = hash,
                Expiracion = DateTime.UtcNow.AddDays(7),
                Revocado = false
            };

            await _refreshTokens.InsertOneAsync(entity);
            // Devuelvo el token en crudo (no el hash)
            return refreshToken; 
        }

        //Renovar Access Token
        public async Task<string> RefreshAsync(string refreshToken)
        {
            var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken)));
            var tokenDb = await _refreshTokens.Find(t => t.TokenHash == hash && !t.Revocado).FirstOrDefaultAsync();

            if (tokenDb == null || tokenDb.Expiracion < DateTime.UtcNow)
                throw new UnauthorizedAccessException("Refresh token inválido o expirado");

            var usuario = await _usuarios.Find(u => u.Id == tokenDb.UsuarioId).FirstOrDefaultAsync();
            if (usuario == null)
                throw new UnauthorizedAccessException("Usuario no encontrado");

            return GenerarJwt(usuario);
        }

        //Logout → revoca el refresh token
        public async Task RevocarRefreshToken(string refreshToken)
        {
            var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(refreshToken)));
            var update = Builders<RefreshToken>.Update.Set(t => t.Revocado, true);
            await _refreshTokens.UpdateOneAsync(t => t.TokenHash == hash, update);
        }
    }
}
