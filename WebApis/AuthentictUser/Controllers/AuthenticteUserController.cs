using Microsoft.AspNetCore.Mvc;
using AuthentictUserBL;
using CommonLib.Model;
using AuthentictUserBL.Service;
using Mysqlx;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;


namespace AuthentictUser.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class AuthenticteUserController : ControllerBase
    {
        AuthenticteUserService _authenticteUserService;
        public AuthenticteUserController(AuthenticteUserService authenticteUserService) {
            _authenticteUserService=authenticteUserService;
        }
      
        [HttpOptions]
        public IActionResult Options()
        {
            return Ok();
        }

        [HttpPost("AuthenticteUser")]
        public ActionResult Authenticte([FromBody]UserModel usermodel) 
        {
            var result = _authenticteUserService.Authenticte(usermodel);
            if(result == null)
            {
              //  return BadRequest("Invalid Username or Password");
                return Unauthorized();
            }
            else
            {
                string tokenvalue = GenerateJwtToken(result.UserName);
                return Ok(new { tokenvalue ,status =true});

            }
             
        }


        private string GenerateJwtToken(string username)
        {
            // var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("b2dlVGhpcyBJcyBBIFN0cm9uZ0tleSEyM3JzMTIz"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, username),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            string validAudience = "*";
            var token = new JwtSecurityToken(
                // issuer: ["Jwt:Issuer"],
                audience: validAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [HttpPost("RegisterUser")]
        public ActionResult RegisterUser([FromBody] Registerusermodel model)

        {
            var result = _authenticteUserService.RegisterUser(model);
            if (result == 0)
            {
                return BadRequest("Some error occured while registering");
            }
            return Ok(new { status = true, message = "User Registertion Sccessful" });
        }

        [Authorize]
        [HttpGet("test")]
        public IActionResult GetProductById()
        {
            // Only authenticated users with a valid JWT can access this method
            return Ok(new {ProductName = "Sample Product" });
        }
    }
}
