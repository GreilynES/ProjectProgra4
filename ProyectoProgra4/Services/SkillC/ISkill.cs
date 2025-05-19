using ProyectoProgra4.Entities;

namespace ProyectoProgra4.Services.SkillC
{
    public interface ISkill
    {
        List<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        Skill AddSkill(Skill skill);
        Skill UpdateSkill(int id, Skill skill);
        void DeleteSkill(int id);
    }
}
