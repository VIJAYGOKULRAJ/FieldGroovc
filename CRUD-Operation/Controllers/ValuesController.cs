using CRUD.Data.MySQL.Data;
using CRUD.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProductContext _context;

        public ValuesController(ProductContext context)
        {
            _context = context;
        }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate(Login model)
            {
            var details = _context.Users.FirstOrDefault(value => value.Email == model.Username);
            var hasedPassword = BCrypt.Net.BCrypt.Verify(model.Password, details.Password);
            var user = _context.Users.FirstOrDefault(value => value.Email == model.Username && hasedPassword);

            if (user == null)
            {
                return Unauthorized();
            }

            var tokenKey = Encoding.UTF8.GetBytes("thisismysecretkeycreatedbyvijay-45234-5435-234-5345-3245-23452345-345-23453245");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.IsAdmin ? "admin" : "user"),
                   
            }),
                
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var finalToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializedToken = tokenHandler.WriteToken(finalToken);

            return Ok(new { Token = serializedToken });

        }
    }
}
