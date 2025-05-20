using Microsoft.AspNetCore.Mvc;
using ProyectoProgra4.DTO;
using ProyectoProgra4.Entities;
using ProyectoProgra4.Services.OfferSkillC;

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferSkillController : ControllerBase
    {
        private readonly IOfferSkill _offerSkillService;

        public OfferSkillController(IOfferSkill offerSkillService)
        {
            _offerSkillService = offerSkillService;
        }

        // GET: api/OfferSkill
        [HttpGet]
        public IEnumerable<OfferSkillDTO> Get()
        {
            return _offerSkillService.GetAllOfferSkills();
        }


        // GET: api/OfferSkill/5
        [HttpGet("{id}")]
        public OfferSkill Get(int id)
        {
            return _offerSkillService.GetOfferSkillsById(id);
        }

        // POST: api/OfferSkill
        [HttpPost]
        public OfferSkill Post([FromBody] OfferSkill offerSkill)
        {
            return _offerSkillService.AddOfferSkill(offerSkill);
        }

        // PUT: api/OfferSkill/5
        [HttpPut("{id}")]
        public OfferSkill Put(int id, [FromBody] OfferSkill offerSkill)
        {
            return _offerSkillService.UpdateOfferSkill(id, offerSkill);
        }

        // DELETE: api/OfferSkill/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _offerSkillService.DeleteOfferSkill(id);
        }

        // GET: api/OfferSkill/match/5
        [HttpGet("match/{candidateId}")]
        public ActionResult<List<OfferSkillDTO>> GetMatchedOffers(int candidateId)
        {
            return _offerSkillService.GetMatchedOffersByCandidate(candidateId);
        }
    }
}