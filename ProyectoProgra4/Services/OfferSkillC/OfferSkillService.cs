using Microsoft.EntityFrameworkCore;
using ProyectoProgra4.DTO;
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

        public List<OfferSkillDTO> GetAllOfferSkills()
        {
            return _dbContext.OfferSkills
                .Include(os => os.Offer)
                .Include(os => os.Skill)
                .Select(os => new OfferSkillDTO
                {
                    OfferId = os.IdOffer,
                    CompanyName = os.Offer.Company.Name,
                    OfferName = os.Offer.Name,
                    OfferDescription = os.Offer.Description,
                    SkillId = os.SkillId,
                    SkillName = os.Skill.Name
                })
                .ToList();
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

        public List<OfferSkillDTO> GetMatchedOffersByCandidate(int candidateId)
        {
            // 1. Obtener IDs de habilidades del candidato
            var candidateSkillIds = _dbContext.CandidateSkills
                .Where(cs => cs.CandidateId == candidateId)
                .Select(cs => cs.IdSkill)
                .ToList();

            // 2. Obtener IDs de ofertas que coinciden con al menos una habilidad
            var matchingOfferIds = _dbContext.OfferSkills
                .Where(os => candidateSkillIds.Contains(os.SkillId))
                .Select(os => os.IdOffer)
                .Distinct()
                .ToList();

            // 3. De esas ofertas, traer TODAS sus habilidades
            var allSkillsFromMatchingOffers = _dbContext.OfferSkills
                .Include(os => os.Offer)
                    .ThenInclude(o => o.Company)
                .Include(os => os.Skill)
                .Where(os => matchingOfferIds.Contains(os.IdOffer))
                .Select(os => new OfferSkillDTO
                {
                    OfferId = os.IdOffer,
                    CompanyName = os.Offer.Company.Name,
                    OfferName = os.Offer.Name,
                    OfferDescription = os.Offer.Description,
                    SkillId = os.SkillId,
                    SkillName = os.Skill.Name
                })
                .ToList();

            return allSkillsFromMatchingOffers;
        }


    }
}