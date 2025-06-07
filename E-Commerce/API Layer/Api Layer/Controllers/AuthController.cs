using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend_ECommerce_App.Models;
using Infrastructure;

namespace Backend_ECommerce_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly WebContext _context;

        public AuthController(IConfiguration config, WebContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var existingUser = _context.Users.SingleOrDefault(u => u.Email == dto.Email);
            if (existingUser != null)
                return BadRequest("User already exists");

            var user = new User
            {
                Email = dto.Email,
                Password = dto.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == dto.Email && u.Password == dto.Password);
            if (user == null)
                return Unauthorized("Invalid credentials");

            var token = GenerateJwtToken(user.Id.ToString());

            return Ok(new { token });
        }

        private string GenerateJwtToken(string userId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

 
    public class RegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
