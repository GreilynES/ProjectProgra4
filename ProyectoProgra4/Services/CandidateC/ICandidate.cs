

using Proyecto_Final_PrograIV.Entities;

namespace ProyectoProgra4.Services.CandidateC
{
    public interface ICandidate
    {
        public List<Candidate> GetAllCandidates();
        public Candidate GetCandidateById(int Id);
        public Candidate AddCandidate(Candidate candidate);
        public Candidate UpdateCandidate(int Id, Candidate candidate);
        public void DeleteCandidate(int Id);
    }
}
