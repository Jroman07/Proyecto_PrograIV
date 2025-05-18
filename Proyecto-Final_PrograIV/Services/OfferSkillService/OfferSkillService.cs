using Microsoft.EntityFrameworkCore;
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
            var exists = _dbContext.OfferSkills
                .Any(os => os.OfferId == offerId && os.SkillId == skillId);

            if (exists)
                throw new Exception("La relación ya existe.");

            var newRelation = new OfferSkill
            {
                OfferId = offerId,
                SkillId = skillId
            };

            _dbContext.OfferSkills.Add(newRelation);
            _dbContext.SaveChanges();
        }

        public void RemoveSkillFromOffer(int offerId, int skillId)
        {
            var existingRelation = _dbContext.OfferSkills
                .FirstOrDefault(os => os.OfferId == offerId && os.SkillId == skillId);

            if (existingRelation == null)
                throw new Exception("Relación entre Oferta y Habilidad no encontrada");

            _dbContext.OfferSkills.Remove(existingRelation);
            _dbContext.SaveChanges();
        }

        public List<OfferSkill> GetOfferSkills(int? offerId = null, int? skillId = null)
        {
            var query = _dbContext.OfferSkills
                .Include(os => os.Offer)
                .Include(os => os.Skill)
                .AsQueryable();

            if (offerId.HasValue)
                query = query.Where(os => os.OfferId == offerId.Value);

            if (skillId.HasValue)
                query = query.Where(os => os.SkillId == skillId.Value);

            return query.ToList();
        }
    }
}
