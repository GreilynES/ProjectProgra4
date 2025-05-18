using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.Services.CandidateC;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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


        // GET: api/<CandidatesController>
        [HttpGet]
        //[Authorize]
        public IEnumerable<Candidate> Get()
        {
            return _candidateService.GetAllCandidates();
        }

        // GET api/<CandidatesController>/5
        [HttpGet("{id}")]
        public Candidate Get(int id)
        {
            return _candidateService.GetCandidateById(id);
        }


        // POST api/<CandidatesController>
        [HttpPost]
        public Candidate Post([FromBody] Candidate candidate)
        {
            return _candidateService.AddCandidate(candidate);
        }

        // PUT api/<CandidatesController>/5
        [HttpPut("{id}")]
        public Candidate Put(int id, [FromBody] Candidate candidate)
        {
            return _candidateService.UpdateCandidate(id, candidate);
        }

        // DELETE api/<CandidatesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _candidateService.DeleteCandidate(id);
        }
    }
}
