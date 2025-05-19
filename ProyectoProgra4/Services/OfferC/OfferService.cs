using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.ProjectDataBase;

namespace ProyectoProgra4.Services.OfferC
{
    public class OfferService : IOffer
    {
        private readonly ProjectDataBaseContext _dbContext;

        public OfferService(ProjectDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Offer> GetAllOffers()
        {
            return _dbContext.Offers
                .Include(x => x.Company)
                .Include(o => o.OfferSkills)
                    .ThenInclude(os => os.Skill.Name)
                .ToList();
        }

        public Offer GetOfferById(int id)
        {
            var offer = _dbContext.Offers.Find(id);
            if (offer == null) throw new Exception("Offer not found");
            return offer;
        }

        public Offer AddOffer(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
            return offer;
        }

        public Offer UpdateOffer(int id, Offer offer)
        {
            var existingOffer = _dbContext.Offers.Find(id);
            if (existingOffer == null) throw new Exception("Offer not found");

            existingOffer.Name = offer.Name;
            existingOffer.Description = offer.Description;
            // Agrega otros campos necesarios

            _dbContext.SaveChanges();
            return existingOffer;
        }

        public void DeleteOffer(int id)
        {
            var offer = _dbContext.Offers.Find(id);
            if (offer == null) throw new Exception("Offer not found");

            _dbContext.Offers.Remove(offer);
            _dbContext.SaveChanges();
        }
    }
}