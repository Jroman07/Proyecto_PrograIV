using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services.CandidateServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
        // GET: api/<CandidatesController>
        [HttpGet]
        //[Authorize]
        public IEnumerable<Candidate> Get()
        {
            return _candidateService.GetAllCandidates();
        }

        // GET api/<CandidatesController>/5
        [HttpGet("{id}")]
        public Candidate Get(int id)
        {
            return _candidateService.GetCandidateById(id);
        }

        [HttpGet("search")]
        public IEnumerable<Candidate> Get([FromQuery] string? name)
        {
            return _candidateService.GetCandidatesByName(name);
        }

        // POST api/<CandidatesController>
        [HttpPost]
        public Candidate Post([FromBody] Candidate candidate)
        {
            //if (candidate.Email == "string")
            //{
            //    //user.Role = "GUEST";
            //    //generate token
            //    var token = GenerateJwtToken(candidate.Email);
            //    _candidateService.AddCandidate(candidate);

            //    return token;
            //}

            //return "";
            return _candidateService.AddCandidate(candidate);
        }

        private string GenerateJwtToken(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
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

        // PUT api/<CandidatesController>/5
        [HttpPut("{id}")]
        public Candidate Put(int id, [FromBody] Candidate candidate)
        {
            return _candidateService.UpdateCandidate(id, candidate);
        }

        // DELETE api/<CandidatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _candidateService.DeleteCandidate(id);
        }
    }
}
