using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services.Candidateoffer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Final_PrograIV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "CANDIDATE")]
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
        public ActionResult<CandidateOffer> Post([FromBody] CandidateOffer candidateOffer)
        {
            var response = _CandidateOfferService.AddCandidateOffer(candidateOffer);

            if (response == null)
            {
                return Conflict("El candidato ya existe.");
            }
            return response;
        }

        // DELETE api/<CandidateOfferByIdController>/5
   
        [HttpDelete]
        public void DeleteCandidateOffer(CandidateOffer candidateOffer)
        {
            _CandidateOfferService.DeleteCandidateOffer(candidateOffer);
        }
    }
}
