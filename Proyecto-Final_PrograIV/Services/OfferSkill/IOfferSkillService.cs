using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services
{
    public interface IOfferSkillService
    {
        void AddSkillToOffer(int offerId, int skillId);
        void RemoveSkillFromOffer(int offerId, int skillId);
        List<Skill> GetSkillsByOffer(int offerId);
        List<Offer> GetOffersBySkill(int skillId);
    }
}
