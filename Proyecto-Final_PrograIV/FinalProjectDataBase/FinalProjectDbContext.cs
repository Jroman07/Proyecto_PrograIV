using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.FinalProjectDataBase
{
    public class FinalProjectDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "JWTDataBase");
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<OfferSkill> OfferSkills { get; set; }
        public DbSet<CandidateOffer> CandidateOffers { get; set; }
        public DbSet<CandidateSkill> CandidateSkill { get; set; }
        public DbSet<CandidateOffer> CandidateOffer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Company 1 - * Offer
            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Company)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.CompanyId);

            // Offer * - * Skill (via OfferSkill)
            modelBuilder.Entity<OfferSkill>()
                .HasKey(os => new { os.OfferId, os.SkillId }); // Composite key

            modelBuilder.Entity<OfferSkill>()
                .HasOne(os => os.Offer)
                .WithMany(o => o.OfferSkills)
                .HasForeignKey(os => os.OfferId);

            modelBuilder.Entity<OfferSkill>()
                .HasOne(os => os.Skill)
                .WithMany(s => s.OfferSkills)
                .HasForeignKey(os => os.SkillId);

            // Candidate * - * Offer (via CandidateOffer)
            modelBuilder.Entity<CandidateOffer>()
                .HasKey(co => new { co.CandidateId, co.OfferId }); // Composite key

            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Candidate)
                .WithMany(c => c.CandidateOffers)
                .HasForeignKey(co => co.CandidateId);

            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Offer)
                .WithMany(o => o.CandidateOffers)
                .HasForeignKey(co => co.OfferId);

            // Candidate 1 - * Skill
            modelBuilder.Entity<CandidateSkill>()
                .HasKey(co => new { co.CandidateId, co.SkillId });

            modelBuilder.Entity<CandidateSkill>()
                .HasOne(co => co.Skill) 
                .WithMany (o => o.CandidateSkills)
                .HasForeignKey (co => co.SkillId);

            modelBuilder.Entity<CandidateSkill>()
                .HasOne(co => co.Candidate)
                .WithMany(o => o.CandidateSkills)
                .HasForeignKey(co => co.CandidateId);

        }


    }
}
