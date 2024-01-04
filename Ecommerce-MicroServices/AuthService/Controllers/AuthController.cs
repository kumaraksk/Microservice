using AuthService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            if (ModelState.IsValid && !(user is null))
            {
                if (user.UserName == "kumar" && user.Password == "kumar@123")
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var claims = new List<Claim>
                    {
                        new Claim("UserName",user.UserName),
                        new Claim("Role","Admin")
                    };
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "https://localhost:44391",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(15),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(tokenString);
                }
                return Unauthorized();
            }
            return BadRequest("User name and Password required");
        }
    }
}
