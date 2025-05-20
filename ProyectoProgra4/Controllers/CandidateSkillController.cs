using Microsoft.AspNetCore.Mvc;
using ProyectoProgra4.DTO;
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

        //GetById CandidateSkill con DTO
        [HttpGet("candidate/{candidateId}")]
        public IEnumerable<CandidateSkillDTO> GetByCandidate(int candidateId)
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

        [HttpDelete("{candidateId}/{skillId}")]
        public IActionResult Delete(int candidateId, int skillId)
        {
            _candidateSkillService.RemoveSkillFromCandidate(candidateId, skillId);
            return Ok(new { message = "Skill eliminada correctamente." });
        }
    }
}
