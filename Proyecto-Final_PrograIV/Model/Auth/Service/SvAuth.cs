using Microsoft.IdentityModel.Tokens;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public string Authenticate(Auth auth)
        {
            if(auth != null)
            {
                Candidate? candidate = _dbContext.Candidates.Where(x => x.Email == auth.Email).FirstOrDefault();
                Company? company = _dbContext.Companies.Where(x => x.Email == auth.Email).FirstOrDefault();

                if (candidate != null)
                {
                    if (candidate.Password == auth.Password)
                    {
                        var token = GenerateJwtToken(candidate.CandidateId, candidate.Email, "CANDIDATE");

                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (company != null)
                {
                    if (company.Password == auth.Password)
                    {
                        var token = GenerateJwtToken(company.CompanyId, company.Email, "COMPANY");

                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            return null;
          
        }
    }
}
