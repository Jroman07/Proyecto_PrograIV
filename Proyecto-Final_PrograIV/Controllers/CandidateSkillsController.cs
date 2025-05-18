using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services;
using Proyecto_Final_PrograIV.Services.CandiadateSkillService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateSkillsController : ControllerBase
    {
        private readonly ICandidateSkillService _CandidateSkillService;
        public CandidateSkillsController(ICandidateSkillService candidateSkillService)
        {
            _CandidateSkillService = candidateSkillService;
        }
        // GET: api/<CandidateSkillByIdController>
        [HttpGet]
        public IEnumerable<CandidateSkill> Get()
        {
            return _CandidateSkillService.GetAllCandidateSkills();
        }

        // GET api/<CandidateSkillByIdController>/5
        [HttpGet("{id}")]
        public CandidateSkill Get(int id)
        {
            return _CandidateSkillService.GetCandidateSkillById(id);
        }


        // POST api/<CandidateSkillByIdController>
        [HttpPost]
        public CandidateSkill Post([FromBody] CandidateSkill candidateSkill)
        {
            return _CandidateSkillService.AddCandidateSkill(candidateSkill);
        }

        // PUT api/<CandidateSkillByIdController>/5
        [HttpPut("{id}")]
        public   CandidateSkill Put(int id, [FromBody]   CandidateSkill candidateSkill)
        {
            return _CandidateSkillService.UpdateCandidateSkill(id, candidateSkill);
        }

        // DELETE api/<CandidateSkillByIdController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _CandidateSkillService.DeleteCandidateSkillById(id);
        }
    }
}
