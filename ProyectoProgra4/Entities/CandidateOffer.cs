using System;

namespace Proyecto_Final_PrograIV.Entities
{
    public class CandidateOffer
    {
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }

    }

}
