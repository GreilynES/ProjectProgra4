using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class Offer
    {
        public int OfferId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public List<CandidateOffer>? CandidateOffers { get; set; } //en offer tengo una lista de candidatos 
    }
}
