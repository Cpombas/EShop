using e_shop.DbContexts;
using e_shop.Entities;
using e_shop.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace e_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly EShopContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration, EShopContext context)
        {
            this._context = context;
            this._configuration = configuration;
        }

        [HttpPost("register")]

        public async Task<ActionResult<User>> Register([FromBody]RegisterUserDTO request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = new User
            {
                UserName = request.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
                Email = request.Email,
                Address = request.Address,
                Role = "Client"
            };

            await _context.User.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] ListUserAuthDTO request)
        {
            var user = await _context.User.
                FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (user == null || !VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Username or Password");
            }

            string token = CreateToken(user);
            return Ok(JsonConvert.SerializeObject(token));
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("Authentication:SecretForKey").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


        /*
        private readonly IConfiguration _configuration;
        private readonly EShopContext _context;

        //we won't use this outside of this class, so we can scope it to this namespace
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }

            public string? Password { get; set; }
        }
        public AuthenticationController(IConfiguration configuration, EShopContext context)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _context = context;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate()
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            //The claims that
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("noUser", "Not_A_RegUser"));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(15),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);

        }

        [HttpPost("authenticateRegisteredUser")]
        public ActionResult<string> Authenticate(
            AuthenticationRequestBody authenticationRequestBody)
        {
            //Step 1: validate the username/password
            var user = ValidateUserCredentials(
                authenticationRequestBody.UserName,
                authenticationRequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            //Step 2: create a token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            //The claims that
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("role", user.RoleId.ToString()));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(15),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);

        }
        private ListUserDTO ValidateUserCredentials(string? userName, string? password)
        {
            var user = _context.User.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            return new ListUserDTO(user);
        }
        */



    }

}
