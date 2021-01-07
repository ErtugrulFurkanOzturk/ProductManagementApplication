using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Common.Dtos;
using Common.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ProductManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase//login and register operations
    {
        private readonly ILogger<AuthController> _logger; // logg operation 
        private readonly IPasswordHasher<ApplicationUserDto> _hasher; //to keep the user's password in the database by hashing
        private readonly IConfigurationRoot _config; // for inject operation
        private readonly UserManager<ApplicationUserDto> _userManager;//For user operations
        public AuthController(UserManager<ApplicationUserDto> userManager,ILogger<AuthController> logger,IPasswordHasher<ApplicationUserDto> hasher,IConfigurationRoot config)
        {
            _logger = logger;
            _hasher = hasher;
            _config = config;
            _userManager = userManager;
        }

        [HttpPost("Token")]
        public async Task<ActionResult> CreateToken([FromBody] CredentialModelDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    if (_hasher.VerifyHashedPassword(user,user.PasswordHash,model.Password)==PasswordVerificationResult.Success)
                    {
                        return Ok(CreateToken(user));
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"An error occurred while creating jwt:  {ex.Message.ToString()}");
            }
            return null;
        }


        // Ctreating Token Methods
        private async Task<JwtTokenPacket> CreateToken(ApplicationUserDto appUser)
        {
            var userClaims = await _userManager.GetClaimsAsync(appUser);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub,appUser.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            }.Union(userClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Token:Issuer"],
                audience: _config["Token:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: cred);

            return new JwtTokenPacket
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo.ToString(),
                UserName = appUser.UserName
            };
        }
    }
}
