using Proyecto_Final_PrograIV.Entities;

namespace ProyectoProgra4.Services.CandidateOfferC
{
    public interface ICandidateOffer
    {
        List<CandidateOffer> GetAllCandidateOffers();
        List<Offer> GetCandidateOfferById(int id);
        CandidateOffer AddCandidateOffer(CandidateOffer candidateOffer);
        CandidateOffer UpdateCandidateOffer(int id, CandidateOffer candidateOffer);
        void DeleteCandidateOffer(int id);
        void RemoveOfferFromCandidate(int candidateId, int offerid);
    }
}