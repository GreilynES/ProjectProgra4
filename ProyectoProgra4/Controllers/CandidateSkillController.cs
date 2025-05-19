using Microsoft.AspNetCore.Mvc;
using ProyectoProgra4.Entities;
using ProyectoProgra4.Services.CandidateSkillC;

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

        // GET: api/CandidateSkill/candidate/5
        [HttpGet("candidate/{candidateId}")]
        public IEnumerable<CandidateSkill> GetByCandidate(int candidateId)
        {
            return _candidateSkillService.GetByCandidateId(candidateId);
        }

        // POST: api/CandidateSkill
        [HttpPost]
        public IActionResult Post([FromBody] CandidateSkill model)
        {
            _candidateSkillService.AddSkillToCandidate(model.CandidateId, model.IdSkill);
            return Ok(new { message = "Skill agregada correctamente." });
        }

        // DELETE: api/CandidateSkill
        [HttpDelete]
        public IActionResult Delete([FromBody] CandidateSkill model)
        {
            _candidateSkillService.RemoveSkillFromCandidate(model.CandidateId, model.IdSkill);
            return Ok(new { message = "Skill eliminada correctamente." });
        }
    }
}
