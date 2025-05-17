using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.FinalProjectDataBase;

namespace Proyecto_Final_PrograIV.Services
{
    public class OfferSkillService : IOfferSkillService
    {
        private readonly FinalProjectDbContext _dbContext;

        public OfferSkillService(FinalProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSkillToOffer(int offerId, int skillId)
        {
            OfferSkill newRelation = new OfferSkill
            {
                OfferId = offerId,
                SkillId = skillId
            };

            _dbContext.OfferSkills.Add(newRelation);
            _dbContext.SaveChanges();
        }

        public void RemoveSkillFromOffer(int offerId, int skillId)
        {
            OfferSkill? existingRelation = _dbContext.OfferSkills
                .FirstOrDefault(os => os.OfferId == offerId && os.SkillId == skillId);

            if (existingRelation != null)
            {
                _dbContext.OfferSkills.Remove(existingRelation);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Relation between Offer and Skill not found");
            }
        }

        public List<Skill> GetSkillsByOffer(int offerId)
        {
            List<Skill> skills = _dbContext.OfferSkills
                .Where(os => os.OfferId == offerId)
                .Select(os => os.Skill)
                .ToList();

            return skills;
        }

        public List<Offer> GetOffersBySkill(int skillId)
        {
            List<Offer> offers = _dbContext.OfferSkills
                .Where(os => os.SkillId == skillId)
                .Select(os => os.Offer)
                .ToList();

            return offers;
        }
    }
}
