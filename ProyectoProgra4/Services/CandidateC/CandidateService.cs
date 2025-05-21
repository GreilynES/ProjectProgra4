using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.ProjectDataBase;

namespace ProyectoProgra4.Services.CandidateC
{
    public class CandidateService : ICandidate
    {
        private readonly ProjectDataBaseContext _dbContext;

        public CandidateService(ProjectDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Candidate AddCandidate(Candidate candidate)
        {
            candidate.Role = "CANDIDATE"; // ✅ se asigna el rol al registrarse
            _dbContext.Candidates.Add(candidate);
            _dbContext.SaveChanges();
            return candidate;
        }

        public void DeleteCandidate(int Id)
        {
            Candidate DeleteCandidate = _dbContext.Candidates.Find(Id);
            if (DeleteCandidate != null)
            {
                _dbContext.Candidates.Remove(DeleteCandidate);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Candidate not found");
            }
        }

        public List<Candidate> GetAllCandidates()
        {
            return _dbContext.Candidates
                .Include(c => c.CandidateSkills)
                    .ThenInclude(cs => cs.Skill)
                .Include(c => c.CandidateOffers)
                .ToList();
        }

        public Candidate GetCandidateById(int Id)
        {
            return _dbContext.Candidates
                .Include(c => c.CandidateSkills)
                    .ThenInclude(cs => cs.Skill)
                .Include(c => c.CandidateOffers)
                    .ThenInclude(co => co.Offer)
                .FirstOrDefault(c => c.Id == Id);
        }

        public Candidate UpdateCandidate(int Id, Candidate candidate)
        {
            Candidate updateCandidate = _dbContext.Candidates.Find(Id);
            if (updateCandidate != null)
            {
                updateCandidate.Name = candidate.Name;
                updateCandidate.FirstLastName = candidate.FirstLastName;
                updateCandidate.SecondLastName = candidate.SecondLastName;
                updateCandidate.Email = candidate.Email;
                updateCandidate.Password = candidate.Password;
                _dbContext.SaveChanges();
                return updateCandidate;
            }
            else
            {
                throw new Exception("Candidate not found");
            }
        }
    }
}
