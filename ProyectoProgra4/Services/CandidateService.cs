using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.ProjectDataBase;
using System.Xml.Linq;

namespace Proyecto_Final_PrograIV.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ProjectDataBaseContext _dbContext;
        public CandidateService(ProjectDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Candidate AddCandidate(Candidate candidate)
        {
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
            return _dbContext.Candidates.ToList();
        }

        public Candidate GetCandidateById(int Id)
        {
            return _dbContext.Candidates.Find(Id);
        }


        public Candidate UpdateCandidate(int Id, Candidate candidate)
        {
            Candidate updateCandidate = _dbContext.Candidates.Find(Id);
            if (updateCandidate != null)
            {
                updateCandidate.Name = candidate.Name;
                updateCandidate.Surname1 = candidate.Surname1;
                updateCandidate.Surname2 = candidate.Surname2;
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
