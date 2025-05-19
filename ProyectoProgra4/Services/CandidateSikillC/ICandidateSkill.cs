using ProyectoProgra4.Entities;
using System.Collections.Generic;

namespace ProyectoProgra4.Services.CandidateSkillC
{
    public interface ICandidateSkill
    {
        List<CandidateSkill> GetByCandidateId(int candidateId);
        void AddSkillToCandidate(int candidateId, int skillId);
        void RemoveSkillFromCandidate(int candidateId, int skillId);
    }
}
