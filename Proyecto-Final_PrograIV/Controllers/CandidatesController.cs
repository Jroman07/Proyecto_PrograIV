using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Model.Auth;
using Proyecto_Final_PrograIV.Services.CandidateServices;

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
        [Authorize(Roles = "CANDIDATE")]
        public IEnumerable<Candidate> Get()
        {
            return _candidateService.GetAllCandidates();
        }

        // GET api/<CandidatesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "CANDIDATE")]
        public Candidate Get(int id)
        {
            return _candidateService.GetCandidateById(id);
        }

        [HttpGet("Offers{id}")]
        [Authorize(Roles = "CANDIDATE")]
        public IEnumerable<Offer> GetOffers(int id)
        {
            return _candidateService.GetOffersByCandidate(id);
        }
        [HttpGet("Skills{id}")]
        [Authorize(Roles = "CANDIDATE")]
        public IEnumerable<Skill> GetSkills(int id)
        {
            return _candidateService.GetSkillsByCandidate(id);
        }


        // POST api/<CandidatesController>
        [HttpPost]
        
        public ActionResult<Candidate>  Post([FromBody] Candidate candidate)
        {
            var result = _candidateService.AddCandidate(candidate);
            if (result == null)
            {
                return Conflict("Ya existe un candidato con ese correo electrónico.");
            }
            return Ok(result);
        }

        // DELETE api/<CandidatesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "CANDIDATE")]
        public void Delete(int id)
        {
            _candidateService.DeleteCandidate(id);
        }
    }
}
