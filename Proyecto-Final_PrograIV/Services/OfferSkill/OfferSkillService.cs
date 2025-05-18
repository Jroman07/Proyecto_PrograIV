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
            return _dbContext.OfferSkills.ToList();
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
                updateOfferSkill.OfferId = offerSkill.OfferId;
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
