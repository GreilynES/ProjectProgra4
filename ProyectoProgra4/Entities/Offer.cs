using ProyectoProgra4.Entities;
using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdCompany { get; set; } //clave foranea

        public Company? Company { get; set; } //una oferta pertenece a una empresa

        [JsonIgnore]
        public List<CandidateOffer>? CandidateOffers { get; set; } //en offer tengo una lista de candidatos 
       
        public List<OfferSkill>? OfferSkills { get; set; } //una oferta tiene una lista de skills
    }
}
