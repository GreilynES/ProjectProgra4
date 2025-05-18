using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.Services.OfferC;

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOffer _offerService;

        public OfferController(IOffer offerService)
        {
            _offerService = offerService;
        }

        // GET: api/<OfferController>
        [HttpGet]
        public IEnumerable<Offer> Get()
        {
            return _offerService.GetAllOffers();
        }

        // GET api/<OfferController>/5
        [HttpGet("{id}")]
        public Offer Get(int id)
        {
            return _offerService.GetOfferById(id);
        }

        // POST api/<OfferController>
        [HttpPost]
        public Offer Post([FromBody] Offer offer)
        {
            return _offerService.AddOffer(offer);
        }

        // PUT api/<OfferController>/5
        [HttpPut("{id}")]
        public Offer Put(int id, [FromBody] Offer offer)
        {
            return _offerService.UpdateOffer(id, offer);
        }

        // DELETE api/<OfferController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _offerService.DeleteOffer(id);
        }
    }
}
