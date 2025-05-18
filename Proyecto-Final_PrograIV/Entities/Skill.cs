using System.Text.Json.Serialization;

namespace Proyecto_Final_PrograIV.Entities

{
    public class Skill
    {
        public int SkillId { get; set; }

        public string? Name { get; set; }

        // Relación M:N con ofertas
        [JsonIgnore]
        public List<OfferSkill> OfferSkills { get; set; } = new();
    }
}
