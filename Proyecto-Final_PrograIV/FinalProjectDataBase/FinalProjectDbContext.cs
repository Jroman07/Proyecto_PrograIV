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
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Skill>().HasData(
            //    new Skill { SkillId = 1, Name = "C#" },
            //    new Skill { SkillId = 2, Name = "JavaScript" },
            //    new Skill { SkillId = 3, Name = "Python" },
            //    new Skill { SkillId = 4, Name = "SQL" },
            //    new Skill { SkillId = 5, Name = "HTML" }
            //);

            // 🔹 Semilla de empresas
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, Name = "Empresa Demo 1", Email = "demo1@empresa.com", WebSite = "https://demo1.empresa.com" },
                new Company { CompanyId = 2, Name = "Empresa Demo 2", Email = "demo2@empresa.com", WebSite = "https://demo2.empresa.com" },
                new Company { CompanyId = 3, Name = "Empresa Demo 3", Email = "demo3@empresa.com", WebSite = "https://demo3.empresa.com" }
            );

            // 🔹 Semilla de ofertas
            modelBuilder.Entity<Offer>().HasData(
                new Offer { OfferId = 1, Job = "QA", Description = "Revisión", CompanyId = 2 },
                new Offer { OfferId = 2, Job = "Desarrollo web", Description = "Desarrollar sistemas", CompanyId = 1 },
                new Offer { OfferId = 3, Job = "Programacion", Description = "Desarrollo de software", CompanyId = 2 },
                new Offer { OfferId = 4, Job = "Gerente informatico", Description = "Administrar proyectos", CompanyId = 3 }
            );

            //🔹 Habilidades(Skills)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 1, Name = "C#" },
                new Skill { SkillId = 2, Name = "SQL" },
                new Skill { SkillId = 3, Name = "Nest" },
                new Skill { SkillId = 4, Name = "MySQL" }
            );

            // 🔹 Relación Oferta-Habilidad (OfferSkill)
            // Usa la clave compuesta {IdOffer, SkillId}
            modelBuilder.Entity<OfferSkill>().HasData(
                new OfferSkill { Id = 1, OfferId = 1, SkillId = 2 }, // Oferta 1 requiere SQL
                new OfferSkill { Id = 2, OfferId = 1, SkillId = 3 }, // Oferta 1 requiere Nest
                new OfferSkill { Id = 3, OfferId = 2, SkillId = 1 },  // Oferta 2 requiere C#
                new OfferSkill { Id = 4, OfferId = 2, SkillId = 2 },
                new OfferSkill { Id = 5, OfferId = 2, SkillId = 3 },
                new OfferSkill { Id = 6, OfferId = 3, SkillId = 1 },
                new OfferSkill { Id = 7, OfferId = 3, SkillId = 4 }
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
