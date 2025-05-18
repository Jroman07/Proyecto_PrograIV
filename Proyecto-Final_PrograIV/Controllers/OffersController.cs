using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services;

namespace Proyecto_Final_PrograIV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        // GET: api/offers
        [HttpGet]
        public ActionResult<IEnumerable<Offer>> GetAll()
        {
            var offers = _offerService.GetallOffers();
            return Ok(offers);
        }

        // GET: api/offers/5
        [HttpGet("{id:int}")]
        public ActionResult<Offer> GetById(int id)
        {
            try
            {
                var offer = _offerService.GetOfferById(id);
                return Ok(offer);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/offers/search?name=frontend
        [HttpGet("search")]
        public ActionResult<IEnumerable<Offer>> SearchByName([FromQuery] string? name)
        {
            var results = _offerService.GetOffersByName(name);
            return Ok(results);
        }

        // POST: api/offers
        [HttpPost]
        public ActionResult<Offer> Create([FromBody] Offer offer)
        {
            if (offer == null || string.IsNullOrWhiteSpace(offer.Job))
                return BadRequest(new { message = "Datos de oferta inválidos." });

            var created = _offerService.AddOffer(offer);
            return CreatedAtAction(nameof(GetById), new { id = created.OfferId }, created);
        }
    }
}
