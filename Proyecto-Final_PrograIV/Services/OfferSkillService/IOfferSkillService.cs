using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services
{
    public interface IOfferSkillService
    {
        void AddSkillToOffer(int offerId, int skillId);
        void RemoveSkillFromOffer(int offerId, int skillId);

        // Método unificado con filtros opcionales
        List<OfferSkill> GetOfferSkills(int? offerId = null, int? skillId = null);
    }
}
