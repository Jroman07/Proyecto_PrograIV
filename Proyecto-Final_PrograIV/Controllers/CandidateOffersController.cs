using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services.Candidateoffer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateOffersController : ControllerBase
    {
        private readonly ICandidateOfferService _CandidateOfferService;
        public CandidateOffersController(ICandidateOfferService candidateOfferService)
        {
            _CandidateOfferService = candidateOfferService;
        }
        // GET: api/<CandidateOfferByIdController>
        [HttpGet]
        public IEnumerable<CandidateOffer> Get()
        {
            return _CandidateOfferService.GetAllCandidateOffer();
        }

        // GET api/<CandidateOfferByIdController>/5
        [HttpGet("{id}")]
        public IEnumerable<Offer> Get(int id)
        {
            return _CandidateOfferService.GetCandidateOfferById(id);
        }


        // POST api/<CandidateOfferByIdController>
        [HttpPost]
        public CandidateOffer Post([FromBody] CandidateOffer candidateOffer)
        {
            return _CandidateOfferService.AddCandidateOffer(candidateOffer);
        }

        // PUT api/<CandidateOfferByIdController>/5
        [HttpPut("{id}")]
        public CandidateOffer Put(int id, [FromBody] CandidateOffer candidateOffer)
        {
            return _CandidateOfferService.UpdateCandidateOffer(id, candidateOffer);
        }

        // DELETE api/<CandidateOfferByIdController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _CandidateOfferService.DeleteCandidateOfferById(id);
        }
        [HttpDelete]
        public void DeleteCandidateOffer(int idCandidate,int idOffer)
        {
            _CandidateOfferService.DeleteCandidateOffer(idCandidate, idOffer);
        }
    }
}
