using Microsoft.EntityFrameworkCore;
using ProyectoProgra4.DTO;
using ProyectoProgra4.Entities;
using ProyectoProgra4.ProjectDataBase;

namespace ProyectoProgra4.Services.CandidateSkillC
{
    public class CandidateSkillService : ICandidateSkill
    {
        private readonly ProjectDataBaseContext _dbContext;

        public CandidateSkillService(ProjectDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CandidateSkillDTO> GetByCandidateId(int candidateId)
        {
            return _dbContext.CandidateSkills
                .Where(cs => cs.CandidateId == candidateId)
                .Select(cs => new CandidateSkillDTO
                {
                    CandidateId = cs.CandidateId,
                    CandidateName = cs.Candidate.Name,
                    CandidateFirstLastname = cs.Candidate.FirstLastName,
                    CandidateSecondLastname = cs.Candidate.SecondLastName,
                    SkillId = cs.IdSkill,
                    SkillName = cs.Skill.Name
                })
                .ToList();
        }

        public void AddSkillToCandidate(int candidateId, int skillId)
        {
            var exists = _dbContext.CandidateSkills.Any(cs =>
                cs.CandidateId == candidateId && cs.IdSkill == skillId);

            if (!exists)
            {
                _dbContext.CandidateSkills.Add(new CandidateSkill
                {
                    CandidateId = candidateId,
                    IdSkill = skillId
                });

                _dbContext.SaveChanges();
            }
        }

        public void RemoveSkillFromCandidate(int candidateId, int skillId)
        {
            var record = _dbContext.CandidateSkills
                .FirstOrDefault(cs => cs.CandidateId == candidateId && cs.IdSkill == skillId);

            if (record != null)
            {
                _dbContext.CandidateSkills.Remove(record);
                _dbContext.SaveChanges();
            }
        }
        public bool Remove(int candidateId, int skillId)
        {
            var entity = _dbContext.CandidateSkills
                .FirstOrDefault(cs => cs.CandidateId == candidateId && cs.IdSkill == skillId);

            if (entity == null)
                return false;

            _dbContext.CandidateSkills.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

    }
}