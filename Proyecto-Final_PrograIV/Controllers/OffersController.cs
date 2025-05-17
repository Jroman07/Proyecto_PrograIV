using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services;

namespace Proyecto_Final_PrograIV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _OfferService;

        public OffersController(IOfferService offerService)
        {
            _OfferService = offerService;
        }

        // get : api/OffersController
        [HttpGet]
        public IEnumerable<Offer> Get()
        {
            return _OfferService.GetallOffers();
        }

        // get by id
        [HttpGet("{id}")]
        public Offer Get(int id)
        {
            return _OfferService.GetOfferById(id);
        }

        [HttpGet("search")]
        public IEnumerable<Offer> Get([FromQuery] string? name)
        {
            return _OfferService.GetOffersByName(name);
        }

        [HttpPost]
        public Offer Post([FromBody] Offer offer)
        {
            return _OfferService.AddOffer(offer);
        }
    }
}