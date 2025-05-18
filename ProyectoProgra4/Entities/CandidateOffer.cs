using System;

namespace Proyecto_Final_PrograIV.Entities
{
    public class CandidateOffer
    {
        public int IdCandidateOffer { get; set; } //clave primaria
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int IdOffer { get; set; }
        public Offer Offer { get; set; }

    }

}
