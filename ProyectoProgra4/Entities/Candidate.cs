using ProyectoProgra4.Entities;
using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class Candidate
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public List<CandidateOffer>? CandidateOffers { get; set; }
        public List<CandidateSkill>? CandidateSkills { get; set; } //una oferta tiene una lista de skills
    }
}
//intento de git

//intento de git 2