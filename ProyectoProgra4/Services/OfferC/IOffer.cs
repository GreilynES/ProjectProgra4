using Proyecto_Final_PrograIV.Entities;

namespace ProyectoProgra4.Services.OfferC
{
    public interface IOfferService
    {
        Task<List<Offer>> GetAllOffersAsync();
        Task<Offer?> GetOfferByIdAsync(int id);
        Task<Offer> CreateOfferAsync(Offer offer);
        Task<bool> UpdateOfferAsync(Offer offer);
        Task<bool> DeleteOfferAsync(int id);
    }
}
