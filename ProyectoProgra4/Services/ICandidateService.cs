using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services
{
    public interface ICandidateService
    {
        public List<Candidate> GetAllCandidates();
        public Candidate GetCandidateById(int Id);
        public Candidate AddCandidate(Candidate candidate);
        public Candidate UpdateCandidate(int Id, Candidate candidate);
        public void DeleteCandidate(int Id);
    }
}
