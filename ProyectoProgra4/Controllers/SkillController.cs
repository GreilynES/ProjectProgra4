using Microsoft.AspNetCore.Mvc;
using ProyectoProgra4.Entities;
using ProyectoProgra4.Services.SkillC;

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkill _skillService;

        public SkillController(ISkill skillService)
        {
            _skillService = skillService;
        }

        // GET: api/Skill
        [HttpGet]
        public IEnumerable<Skill> Get()
        {
            return _skillService.GetAllSkills();
        }

        // GET api/Skill/5
        [HttpGet("{id}")]
        public Skill Get(int id)
        {
            return _skillService.GetSkillById(id);
        }

        // POST api/Skill
        [HttpPost]
        public Skill Post([FromBody] Skill skill)
        {
            return _skillService.AddSkill(skill);
        }

        // PUT api/Skill/5
        [HttpPut("{id}")]
        public Skill Put(int id, [FromBody] Skill skill)
        {
            return _skillService.UpdateSkill(id, skill);
        }

        // DELETE api/Skill/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _skillService.DeleteSkill(id);
        }
    }
}
