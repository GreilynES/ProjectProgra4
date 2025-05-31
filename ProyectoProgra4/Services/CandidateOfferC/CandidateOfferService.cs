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

        public List<Offer> GetCandidateOfferById(int id)
        {
            var offers = _dbContext.CandidateOffers
            .Where(co => co.CandidateId == id)
            .Include(co => co.Offer)
            .ThenInclude(o => o.Company)
            .Include(co => co.Offer)
            .ThenInclude(o => o.OfferSkills)
            .ThenInclude(os => os.Skill)
            .Select(co => co.Offer)
            .ToList();

            if (offers == null)
            {
                return null;
            }

            return offers;

            //var offer = _dbContext.CandidateOffers.Find(id);
            //if (offer == null) throw new Exception("CandidateOffer not found");
            //return offer;
        }

        public CandidateOffer AddCandidateOffer(CandidateOffer candidateOffer)
        {
            // Verificar si ya existe una postulación para esa oferta y candidato
            var exists = _dbContext.CandidateOffers.Any(co =>
                co.CandidateId == candidateOffer.CandidateId &&
                co.OfferId == candidateOffer.OfferId
            );

            if (exists)
            {
                throw new InvalidOperationException("Ya te has postulado a esta oferta.");
            }

            // Si no existe, se agrega normalmente
            _dbContext.CandidateOffers.Add(candidateOffer);
            _dbContext.SaveChanges();

            return candidateOffer;
        }



        public CandidateOffer UpdateCandidateOffer(int id, CandidateOffer candidateOffer)
        {
            var existing = _dbContext.CandidateOffers.Find(id);
            if (existing == null) throw new Exception("CandidateOffer not found");

            existing.CandidateId = candidateOffer.CandidateId;
            existing.OfferId = candidateOffer.OfferId;

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

        public void RemoveOfferFromCandidate(int candidateId, int offerid)
        {
            var record = _dbContext.CandidateOffers
                .FirstOrDefault(cs => cs.CandidateId == candidateId && cs.OfferId == offerid);

            if (record != null)
            {
                _dbContext.CandidateOffers.Remove(record);
                _dbContext.SaveChanges();
            }
        }
    }
}