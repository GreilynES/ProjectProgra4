using Proyecto_Final_PrograIV.Entities;

namespace ProyectoProgra4.Services.CandidateOfferC
{
    public interface ICandidateOffer
    {
        List<CandidateOffer> GetAllCandidateOffers();
        CandidateOffer GetCandidateOfferById(int id);
        CandidateOffer AddCandidateOffer(CandidateOffer candidateOffer);
        CandidateOffer UpdateCandidateOffer(int id, CandidateOffer candidateOffer);
        void DeleteCandidateOffer(int id);
    }
}