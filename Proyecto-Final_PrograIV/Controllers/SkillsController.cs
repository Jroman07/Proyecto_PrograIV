using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services.SkillsServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        // GET: api/<SkillController>
        [HttpGet]
        public IEnumerable<Skill> Get()
        {
            return _skillService.GetSkills();
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public Skill Get(int id)
        {
            return _skillService.GetSkillById(id);
        }

        // POST api/<SkillController>
        [HttpPost]
        public Skill Post([FromBody] Skill skill)
        {
            return _skillService.AddSkill(skill);
        }
    

        // PUT api/<SkillController>/5
        [HttpPut("{id}")]
        public Skill Put(int id, [FromBody] Skill skill)
        {
            return _skillService.UpdateSkill(id, skill);
        }

        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _skillService.DeleteSkill(id);
        }
    }
}
