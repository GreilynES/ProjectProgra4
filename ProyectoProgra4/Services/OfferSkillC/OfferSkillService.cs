using Microsoft.EntityFrameworkCore;
using ProyectoProgra4.Entities;
using ProyectoProgra4.ProjectDataBase;

namespace ProyectoProgra4.Services.OfferSkillC
{
    public class OfferSkillService : IOfferSkill
    {
        private readonly ProjectDataBaseContext _dbContext;

        public OfferSkillService(ProjectDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OfferSkill AddOfferSkill(OfferSkill offerSkill)
        {
            _dbContext.OfferSkills.Add(offerSkill);
            _dbContext.SaveChanges();

            return offerSkill;
        }

        public void DeleteOfferSkill(int Id)
        {
            OfferSkill DeleteOfferSkill = _dbContext.OfferSkills.Find(Id);
            if (DeleteOfferSkill != null)
            {
                _dbContext.OfferSkills.Remove(DeleteOfferSkill);

                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Candidate not found");
            }
        }

        public List<OfferSkill> GetAllOfferSkills()
        {
            return _dbContext.OfferSkills.Include(x => x.Offer).Include(x => x.Skill).ToList();
        }

        public OfferSkill GetOfferSkillsById(int Id)
        {
            OfferSkill offerSkill = _dbContext.OfferSkills.Find(Id);
            if (offerSkill == null)
            {
                throw new Exception("Candidate not found");
            }
            return offerSkill;
        }

        public OfferSkill UpdateOfferSkill(int Id, OfferSkill offerSkill)
        {
            OfferSkill updateOfferSkill = _dbContext.OfferSkills.Find(Id);
            if (updateOfferSkill != null)
            {
                updateOfferSkill.IdOffer = offerSkill.IdOffer;
                updateOfferSkill.SkillId = offerSkill.SkillId;
                _dbContext.SaveChanges();
                return updateOfferSkill;

            }
            else
            {
                throw new Exception("Candidate not found");
            }
        }
    }
}