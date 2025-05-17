using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Proyecto_Final_PrograIV.Entities
{
    public class OfferSkill
    {
        
        public int OfferId { get; set; }
        public Offer Offer {get; set;}
        
        public int SkillId {get; set;}
        public Skill Skill {get;set;}

    }
}
