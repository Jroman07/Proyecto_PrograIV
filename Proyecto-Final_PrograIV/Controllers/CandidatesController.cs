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
        public Candidate Get(int id)
        {
            return _candidateService.GetCandidateById(id);
        }

        [HttpGet("Offers{id}")]
        public IEnumerable<Offer> GetOffers(int id)
        {
            return _candidateService.GetOffersByCandidate(id);
        }
        [HttpGet("Skills{id}")]
        public IEnumerable<Skill> GetSkills(int id)
        {
            return _candidateService.GetSkillByCandidate(id);
        }

        [HttpGet("search")]
        public IEnumerable<Candidate> Get([FromQuery] string? name)
        {
            return _candidateService.GetCandidatesByName(name);
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
