using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class Candidate
    {
        [JsonIgnore]
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public List<CandidateOffer>? CandidateOffers { get; set; }
    }
}
//intento de git

//intento de git 2