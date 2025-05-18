using Proyecto_Final_PrograIV.Entities;

namespace ProyectoProgra4.Entities
{
    public class CandidateSkill
    {
        public int IdCandidateSkill { get; set; }

        public int CandidateId { get; set; }
        public int IdSkill { get; set; }

        public Candidate? Candidate { get; set; } //una skill tiene un candidato
        public Skill? Skill { get; set; } //una skill tiene una lista de skills
    }
}
