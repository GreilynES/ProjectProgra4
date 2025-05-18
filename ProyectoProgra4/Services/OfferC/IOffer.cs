using Proyecto_Final_PrograIV.Entities;

namespace ProyectoProgra4.Services.OfferC
{
    public interface IOffer
    {
        public List<Offer> GetAllOffers();
        public Offer GetOfferById(int id);
        public Offer AddOffer(Offer offer);
        public Offer UpdateOffer(int id, Offer offer);
        public void DeleteOffer(int id);
    }
}
