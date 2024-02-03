using CashFlowAPI.Application.Dtos.Jwt;
using CashFlowAPI.Application.Interfaces.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlowAPI.Application.Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(JwtDto jwtDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(GetTokenDescriptor(jwtDto));

            return tokenHandler.WriteToken(token);


        }

        public async Task<JwtTokenViewDto> ReadTokenAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            return await Task.FromResult(
                new JwtTokenViewDto
                {
                    Id = Guid.Parse(jwtSecurityToken.Claims.FirstOrDefault(u => u.Type == "nameidentifier")?.Value),
                    Email = jwtSecurityToken.Claims.FirstOrDefault(u => u.Type == "email")?.Value,
                    Role = jwtSecurityToken.Claims.FirstOrDefault(u=>u.Type =="role")?.Value
                }
            );
        }

        private SecurityTokenDescriptor GetTokenDescriptor(JwtDto jwtDto)
        {

            var key = Encoding.ASCII.GetBytes(_configuration["JwtSecurity:SecurityKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, jwtDto.Email.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, jwtDto.Id.ToString()),
                    new Claim(ClaimTypes.Role, jwtDto.Role.ToString()),

                }),
                Expires = DateTime.UtcNow.AddHours(double.Parse(_configuration["JwtSecurity:Expiration"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;

        }
    }
}
