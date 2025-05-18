using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.Services
{
    public interface IOfferSkillService
    {
        public List<OfferSkill> GetAllOfferSkills();
        public OfferSkill GetOfferSkillsById(int Id);
        public OfferSkill AddOfferSkill(OfferSkill offerSkill);
        public OfferSkill UpdateOfferSkill(int Id, OfferSkill offerSkill);
        public void DeleteOfferSkill(int Id);
    }
}
