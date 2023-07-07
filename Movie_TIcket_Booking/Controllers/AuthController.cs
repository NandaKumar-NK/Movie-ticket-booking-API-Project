using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Movie_TIcket_Booking.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Movie_TIcket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly MovieTicketContext ctx;
        public AuthController(IConfiguration configuration, MovieTicketContext _ctx)
        {
            _configuration = configuration;
            ctx= _ctx;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRegister request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);


                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.UserName= request.Username;
                ctx.users.Add(user);
            ctx.SaveChanges();


            return Ok(user);
            
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserRegister request)
        {
          //  ctx.users.Any(x=>x.UserName==request.Username);
            if(!ctx.users.Any(x => x.UserName == request.Username))
            {
                return BadRequest("User Not Found");
            }
            else
            {
                User user1 = ctx.users.FirstOrDefault(x => x.UserName == request.Username);
            }
            if(!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("wrong password");
            }
            string token = CreateToken(user);
            return  BadRequest("Success");
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            var jwt  = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash= hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
            }
        }

    }
}
