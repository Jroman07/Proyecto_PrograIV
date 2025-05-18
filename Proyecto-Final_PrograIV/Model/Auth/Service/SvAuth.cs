using Microsoft.IdentityModel.Tokens;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proyecto_Final_PrograIV.Model.Auth.Service
{
    public class SvAuth : ISvAuth
    {
        private readonly FinalProjectDbContext _dbContext;
        public SvAuth(FinalProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private string GenerateJwtToken(Auth auth)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, auth.Email),
                new Claim(JwtRegisteredClaimNames.Sub, auth.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string Authenticate(Auth auth)
        {
            if(auth.Email != null && auth.Password != null)
            {
                Candidate Data = _dbContext.Candidates.Where(x => x.Email == auth.Email).FirstOrDefault();

                if (Data.Password != auth.Password)
                {
                    return null;
                }
                else
                {
                    return GenerateJwtToken(auth);
                }
            }
            return null;
          
        }
    }
}
