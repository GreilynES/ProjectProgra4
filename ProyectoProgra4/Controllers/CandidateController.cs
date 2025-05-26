using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.Services.CandidateC;

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidate _candidateService;

        public CandidateController(ICandidate candidateService)
        {
            _candidateService = candidateService;
        }
        
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Candidate> Get(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            if (candidate == null)
                return NotFound("Candidato no encontrado");

            return Ok(candidate);
        }

        [HttpPost]
        public ActionResult<Candidate> Post([FromBody] Candidate candidate)
        {
            candidate.Role = "CANDIDATE";
            return _candidateService.AddCandidate(candidate);
        }
    }
}
