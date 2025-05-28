using Proyecto_Final_PrograIV.Entities;

namespace ProyectoProgra4.Services.CandidateC
{
    public interface ICandidate
    {
        List<Candidate> GetAllCandidates();
        Candidate GetCandidateById(int Id);
        Candidate AddCandidate(Candidate candidate);
        Candidate UpdateCandidate(int Id, Candidate candidate);
        void DeleteCandidate(int Id);
        Candidate? GetCandidateByEmail(string email);
    }
}