using System.Text.Json.Serialization;

namespace ProyectoProgra4.Entities
{
    public class Skill
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OfferSkill>? OfferSkills { get; set; } //una skill tiene una lista de ofertas
        public List<CandidateSkill>? CandidateSkills { get; set; } //una skill tiene una lista de candidatos
    }
}
