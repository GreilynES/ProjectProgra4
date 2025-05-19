using ProyectoProgra4.Entities;

namespace ProyectoProgra4.Services.CandidateSkillC
{
    public interface ICandidateSkill
    {
        List<Skill> GetSkillsByCandidateId(int candidateId);
        void AddSkillToCandidate(int candidateId, int skillId);
        void RemoveSkillFromCandidate(int candidateId, int skillId);
    }
}
