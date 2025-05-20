using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.ProjectDataBase;

namespace ProyectoProgra4.Services.CandidateOfferC
{
    public class CandidateOfferService : ICandidateOffer
    {
        private readonly ProjectDataBaseContext _dbContext;

        public CandidateOfferService(ProjectDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<CandidateOffer> GetAllCandidateOffers()
        {
            return _dbContext.CandidateOffers.Include(x => x.Offer).Include(x => x.Offer.Company).Include(x => x.Candidate).ToList();
        }

        public CandidateOffer GetCandidateOfferById(int id)
        {
            var offer = _dbContext.CandidateOffers.Find(id);
            if (offer == null) throw new Exception("CandidateOffer not found");
            return offer;
        }

        public CandidateOffer AddCandidateOffer(CandidateOffer candidateOffer)
        {
            _dbContext.CandidateOffers.Add(candidateOffer);
            _dbContext.SaveChanges();

            return candidateOffer;
        }


        public CandidateOffer UpdateCandidateOffer(int id, CandidateOffer candidateOffer)
        {
            var existing = _dbContext.CandidateOffers.Find(id);
            if (existing == null) throw new Exception("CandidateOffer not found");

            existing.CandidateId = candidateOffer.CandidateId;
            existing.IdOffer = candidateOffer.IdOffer;

            _dbContext.SaveChanges();
            return existing;
        }

        public void DeleteCandidateOffer(int id)
        {
            var offer = _dbContext.CandidateOffers.Find(id);
            if (offer == null) throw new Exception("CandidateOffer not found");

            _dbContext.CandidateOffers.Remove(offer);
            _dbContext.SaveChanges();
        }
    }
}