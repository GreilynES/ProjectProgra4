using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.Entities;
using ProyectoProgra4.ProjectDataBase;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Test.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ProjectDataBaseContext _dbContext;

        public AuthController(ProjectDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Candidate loginData)
        {
            // Buscar el usuario por correo
            var user = _dbContext.Candidates.FirstOrDefault(c => c.Email == loginData.Email);

            // Verificar si existe y si la contraseña coincide (plaintext por ahora)
            if (user == null || user.Password != loginData.Password)
            {
                return Unauthorized("Email o contraseña incorrectos");
            }

            // Generar token con el rol (o GUEST si está nulo)

            else
            {
                var token = GenerateJwtToken(user.Email, user.Role = user.Role ?? "CANDIDATE");
                _dbContext.SaveChanges();
                return Ok(new { token });
            }
        }

        private string GenerateJwtToken(string email, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
