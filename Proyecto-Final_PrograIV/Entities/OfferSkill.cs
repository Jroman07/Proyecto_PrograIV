using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities
{
    public class OfferSkill
    {
        
        public int OfferId { get; set; }
        [JsonIgnore]
        public Offer Offer {get; set;}
        
        public int SkillId {get; set;}
        [JsonIgnore]
        public Skill Skill {get;set;}

    }
}
