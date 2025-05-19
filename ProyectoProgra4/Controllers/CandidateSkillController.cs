using Microsoft.AspNetCore.Mvc;
using ProyectoProgra4.Services.CandidateSkillC;
using ProyectoProgra4.Entities;

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateSkillController : ControllerBase
    {
        private readonly ICandidateSkill _candidateSkillService;

        public CandidateSkillController(ICandidateSkill candidateSkillService)
        {
            _candidateSkillService = candidateSkillService;
        }

        // GET: api/CandidateSkill/5
        [HttpGet("{candidateId}")]
        public IEnumerable<Skill> Get(int candidateId)
        {
            return _candidateSkillService.GetSkillsByCandidateId(candidateId);
        }

        // POST: api/CandidateSkill
        [HttpPost]
        public IActionResult Post([FromBody] CandidateSkill model)
        {
            _candidateSkillService.AddSkillToCandidate(model.CandidateId, model.IdSkill);
            return Ok();
        }

        // DELETE: api/CandidateSkill
        [HttpDelete]
        public IActionResult Delete([FromBody] CandidateSkill model)
        {
            _candidateSkillService.RemoveSkillFromCandidate(model.CandidateId, model.IdSkill);
            return Ok();
        }
    }
}
