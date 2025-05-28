using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.Services.CandidateOfferC;

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateOfferController : ControllerBase
    {
        private readonly ICandidateOffer _candidateOfferService;

        public CandidateOfferController(ICandidateOffer candidateOfferService)
        {
            _candidateOfferService = candidateOfferService;
        }

        // GET: api/<CandidateOfferController>
        [HttpGet]
        public IEnumerable<CandidateOffer> Get()
        {
            return _candidateOfferService.GetAllCandidateOffers();
        }

        // GET api/<CandidateOfferController>/5
        [HttpGet("{id}")]
        public IEnumerable<Offer> Get(int id)
        {
            return _candidateOfferService.GetCandidateOfferById(id);
        }

        // POST api/<CandidateOfferController>
        [HttpPost]
        public CandidateOffer Post([FromBody] CandidateOffer candidateOffer)
        {
            return _candidateOfferService.AddCandidateOffer(candidateOffer);
        }

        // PUT api/<CandidateOfferController>/5
        [HttpPut("{id}")]
        public CandidateOffer Put(int id, [FromBody] CandidateOffer candidateOffer)
        {
            return _candidateOfferService.UpdateCandidateOffer(id, candidateOffer);
        }

        // DELETE api/<CandidateOfferController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _candidateOfferService.DeleteCandidateOffer(id);
        }
    }
}