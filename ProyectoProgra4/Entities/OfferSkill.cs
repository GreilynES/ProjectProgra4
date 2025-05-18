using Proyecto_Final_PrograIV.Entities;
using System.Text.Json.Serialization;

namespace ProyectoProgra4.Entities
{
    public class OfferSkill
    {
        [JsonIgnore]
        public int IdOfferSkill { get; set; }

        public int IdOffer { get; set; }
        public int SkillId { get; set; }

        public Offer? Offer { get; set; } //una oferta tiene una lista de skills
        public Skill? Skill { get; set; } //una skill tiene una lista de ofertas
    }
}
