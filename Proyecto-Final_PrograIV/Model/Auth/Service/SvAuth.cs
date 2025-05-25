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
        private string GenerateJwtToken(int Id, string email, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimTypes.Role, role),
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

        public AuthResponse Authenticate(Auth auth)
        {
            if(auth != null)
            {
                Candidate Data = _dbContext.Candidates.Where(x => x.Email == auth.Email).FirstOrDefault();
                if (Data == null)
                {
                    return null; 
                }
                else
                {
                    if (Data.Password != auth.Password)
                    {
                        return null;
                    }
                    else
                    {
                        var token = GenerateJwtToken(Data.CandidateId, Data.Email, "CANDIDATE");

                        return new AuthResponse
                        {
                            Token = token,
                            Candidate = Data
                        };
                    }
                }
            }
            return null;
          
        }
    }
}
