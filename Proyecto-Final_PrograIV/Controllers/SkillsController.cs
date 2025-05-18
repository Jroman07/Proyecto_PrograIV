using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services.SkillsServices;

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

        // GET: api/skills
        [HttpGet]
        public ActionResult<IEnumerable<Skill>> GetAll()
        {
            var skills = _skillService.GetSkills();
            return Ok(skills);
        }

        // GET: api/skills/5
        [HttpGet("{id}")]
        public ActionResult<Skill> GetById(int id)
        {
            try
            {
                var skill = _skillService.GetSkillById(id);
                return Ok(skill);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/skills
        [HttpPost]
        public ActionResult<Skill> Create([FromBody] Skill skill)
        {
            if (skill == null || string.IsNullOrWhiteSpace(skill.Name))
                return BadRequest(new { message = "Datos inválidos" });

            var createdSkill = _skillService.AddSkill(skill);
            return CreatedAtAction(nameof(GetById), new { id = createdSkill.SkillId }, createdSkill);
        }

        // PUT: api/skills/5
        [HttpPut("{id}")]
        public ActionResult<Skill> Update(int id, [FromBody] Skill skill)
        {
            try
            {
                var updatedSkill = _skillService.UpdateSkill(id, skill);
                return Ok(updatedSkill);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/skills/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _skillService.DeleteSkill(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
