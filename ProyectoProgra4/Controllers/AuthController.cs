using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProyectoProgra4.DTO;
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
        public IActionResult Login([FromBody] LoginDTO loginData)
        {
            if (string.IsNullOrWhiteSpace(loginData.Email) || string.IsNullOrWhiteSpace(loginData.Password))
                return BadRequest("Faltan datos");

            var user = _dbContext.Candidates.FirstOrDefault(c => c.Email == loginData.Email);

            if (user == null || user.Password != loginData.Password)
                return Unauthorized("Credenciales incorrectas");

            var token = GenerateJwtToken(user.Email, user.Role ?? "CANDIDATE");

            return Ok(new
            {
                token,
                candidate = new
                {
                    user.Id,
                    user.Name,
                    user.FirstLastName,
                    user.SecondLastName,
                    user.Email,
                    user.Role
                }
            });
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
