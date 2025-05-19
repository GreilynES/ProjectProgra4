using ProyectoProgra4.DTO;
using ProyectoProgra4.Entities;
using System.Collections.Generic;

namespace ProyectoProgra4.Services.CandidateSkillC
{
    public interface ICandidateSkill
    {
        List<CandidateSkillDTO> GetByCandidateId(int candidateId);
        void AddSkillToCandidate(int candidateId, int skillId);
        void RemoveSkillFromCandidate(int candidateId, int skillId);
    }
}
