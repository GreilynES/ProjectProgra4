using ProyectoProgra4.DTO;
using ProyectoProgra4.Entities;

namespace ProyectoProgra4.Services.OfferSkillC
{
    public interface IOfferSkill
    {
        List<OfferSkillDTO> GetAllOfferSkills();
        public OfferSkill GetOfferSkillsById(int Id);
        public OfferSkill AddOfferSkill(OfferSkill offerSkill);
        public OfferSkill UpdateOfferSkill(int Id, OfferSkill offerSkill);
        public void DeleteOfferSkill(int Id);
    }
}