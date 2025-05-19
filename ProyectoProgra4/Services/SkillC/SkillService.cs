using ProyectoProgra4.Entities;
using ProyectoProgra4.ProjectDataBase;

namespace ProyectoProgra4.Services.SkillC
{
    public class SkillService : ISkill
    {
        private readonly ProjectDataBaseContext _dbContext;

        public SkillService(ProjectDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Skill> GetAllSkills()
        {
            return _dbContext.Skills.ToList();
        }

        public Skill GetSkillById(int id)
        {
            var skill = _dbContext.Skills.Find(id);
            if (skill == null) throw new Exception("Skill not found");
            return skill;
        }

        public Skill AddSkill(Skill skill)
        {
            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();
            return skill;
        }

        public Skill UpdateSkill(int id, Skill skill)
        {
            var existingSkill = _dbContext.Skills.Find(id);
            if (existingSkill == null) throw new Exception("Skill not found");

            existingSkill.Name = skill.Name;
            _dbContext.SaveChanges();
            return existingSkill;
        }

        public void DeleteSkill(int id)
        {
            var skill = _dbContext.Skills.Find(id);
            if (skill == null) throw new Exception("Skill not found");

            _dbContext.Skills.Remove(skill);
            _dbContext.SaveChanges();
        }
    }
}
