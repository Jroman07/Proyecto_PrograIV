using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;

namespace Proyecto_Final_PrograIV.FinalProjectDataBase
{
    public class FinalProjectDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "FinalProjectDataBase");
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<OfferSkill> OfferSkills { get; set; }
        public DbSet<CandidateOffer> CandidateOffers { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Skill>().HasData(
            //    new List<Skill>
            //    {
            //        new Skill { SkillId=1, Name ="C#"},
            //        new Skill { SkillId=2, Name ="C++"},
            //        new Skill { SkillId=3, Name ="Java"},
            //        new Skill { SkillId=4, Name ="PHP"},
            //        new Skill { SkillId=5, Name ="Tailwind CSS"},
            //        new Skill { SkillId=6, Name ="React"},
            //        new Skill { SkillId=7, Name ="MySQL"},
            //        new Skill { SkillId=8, Name ="Git"},
            //        new Skill { SkillId=9, Name ="GitHub"},
            //        new Skill { SkillId=10, Name ="Azure DevOps"},

            //    });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 1, Name = "C#" },
                new Skill { SkillId = 2, Name = "JavaScript" },
                new Skill { SkillId = 3, Name = "Python" },
                new Skill { SkillId = 4, Name = "SQL" },
                new Skill { SkillId = 5, Name = "HTML" }
            );

            // Company 1 - * Offer
            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Company)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.CompanyId);

            // Offer * - * Skill (via OfferSkill)
            modelBuilder.Entity<OfferSkill>()
                .HasKey(cs => cs.Id); // Composite key

            modelBuilder.Entity<OfferSkill>()
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd();

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
                .HasKey(cs => cs.Id); // Composite key

            modelBuilder.Entity<CandidateOffer>()
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Candidate)
                .WithMany(c => c.CandidateOffers)
                .HasForeignKey(co => co.CandidateId);

            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Offer)
                .WithMany(o => o.CandidateOffers)
                .HasForeignKey(co => co.OfferId);

            // Candidate * - * Skill
            modelBuilder.Entity<CandidateSkill>()
                .HasKey(cs => cs.Id);

            modelBuilder.Entity<CandidateSkill>()
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd(); 

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
