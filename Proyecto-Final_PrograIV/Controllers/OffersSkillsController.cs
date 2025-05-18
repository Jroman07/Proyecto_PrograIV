using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services;

namespace Proyecto_Final_PrograIV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferSkillsController : ControllerBase
    {
        private readonly IOfferSkillService _offerSkillService;

        public OfferSkillsController(IOfferSkillService offerSkillService)
        {
            _offerSkillService = offerSkillService;
        }

        [HttpGet]
        public IEnumerable<OfferSkill> Get()
        {
            return _offerSkillService.GetAllOfferSkills();
        }

        // GET api/<CandidatesController>/5
        [HttpGet("{id}")]
        public OfferSkill Get(int id)
        {
            return _offerSkillService.GetOfferSkillsById(id);
        }

        // POST api/<CandidatesController>
        [HttpPost]
        public OfferSkill Post([FromBody] OfferSkill offerSkill)
        {
            return _offerSkillService.AddOfferSkill(offerSkill);
        }

        // PUT api/<CandidatesController>/5
        [HttpPut("{id}")]
        public OfferSkill Put(int id, [FromBody] OfferSkill offerSkill)
        {
            return _offerSkillService.UpdateOfferSkill(id, offerSkill);
        }

        // DELETE api/<CandidatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _offerSkillService.DeleteOfferSkill(id);
        }

    }
}
