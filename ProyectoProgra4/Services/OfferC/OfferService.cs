using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.ProjectDataBase;

namespace ProyectoProgra4.Services.OfferC
{
    public class OfferService : IOfferService
    {
        private readonly ProjectDataBaseContext _context;

        public OfferService(ProjectDataBaseContext context)
        {
            _context = context;
        }

        public async Task<List<Offer>> GetAllOffersAsync()
        {
            return await _context.Offers
                .Include(o => o.Company)
                .Include(o => o.CandidateOffers)
                .Include(o => o.OfferSkills)
                .ToListAsync();
        }

        public async Task<Offer?> GetOfferByIdAsync(int id)
        {
            return await _context.Offers
                .Include(o => o.Company)
                .Include(o => o.CandidateOffers)
                .Include(o => o.OfferSkills)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Offer> CreateOfferAsync(Offer offer)
        {
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();
            return offer;
        }

        public async Task<bool> UpdateOfferAsync(Offer offer)
        {
            _context.Offers.Update(offer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOfferAsync(int id)
        {
            var offer = await _context.Offers.FindAsync(id);
            if (offer == null) return false;
            _context.Offers.Remove(offer);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
