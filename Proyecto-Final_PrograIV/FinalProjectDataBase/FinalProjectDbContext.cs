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
            // 🔹 Semilla de compañías
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, Name = "Empresa Demo 1", Email = "demo1@empresa.com", WebSite = "https://demo1.empresa.com" },
                new Company { CompanyId = 2, Name = "Empresa Demo 2", Email = "demo2@empresa.com", WebSite = "https://demo2.empresa.com" },
                new Company { CompanyId = 3, Name = "Empresa Demo 3", Email = "demo3@empresa.com", WebSite = "https://demo3.empresa.com" }
            );

            // 🔹 Semilla de habilidades
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 1, Name = "C#" },
                new Skill { SkillId = 2, Name = "SQL" },
                new Skill { SkillId = 3, Name = "Nest" },
                new Skill { SkillId = 4, Name = "MySQL" },
                new Skill { SkillId = 5, Name = "JavaScript" },
                new Skill { SkillId = 6, Name = "TypeScript" },
                new Skill { SkillId = 7, Name = "React" },
                new Skill { SkillId = 8, Name = "Node.js" },
                new Skill { SkillId = 9, Name = "Python" },
                new Skill { SkillId = 10, Name = "HTML" },
                new Skill { SkillId = 11, Name = "CSS" },
                new Skill { SkillId = 12, Name = "Docker" },
                new Skill { SkillId = 13, Name = "Git" },
                new Skill { SkillId = 14, Name = "Azure" }
            );

            // 🔹 Semilla de ofertas
            modelBuilder.Entity<Offer>().HasData(
                new Offer { OfferId = 1, Job = "QA", Description = "Revisión", CompanyId = 2 },
                new Offer { OfferId = 2, Job = "Desarrollo web", Description = "Desarrollar sistemas", CompanyId = 1 },
                new Offer { OfferId = 3, Job = "Programador backend", Description = "Servicios API", CompanyId = 2 },
                new Offer { OfferId = 4, Job = "Gerente IT", Description = "Administrar proyectos TI", CompanyId = 3 },
                new Offer { OfferId = 5, Job = "Frontend Developer", Description = "Interfaces modernas", CompanyId = 1 },
                new Offer { OfferId = 6, Job = "DevOps Engineer", Description = "Pipelines y despliegues", CompanyId = 2 },
                new Offer { OfferId = 7, Job = "Administrador de BD", Description = "Gestión de bases de datos", CompanyId = 3 },
                new Offer { OfferId = 8, Job = "Mobile Developer", Description = "Apps móviles con React Native", CompanyId = 1 },
                new Offer { OfferId = 9, Job = "Fullstack Developer", Description = "Frontend y Backend", CompanyId = 2 },
                new Offer { OfferId = 10, Job = "Soporte Técnico", Description = "Atención a usuarios", CompanyId = 3 }
            );

            // 🔹 Relación Oferta-Habilidad (OfferSkill)
            modelBuilder.Entity<OfferSkill>().HasData(
                new OfferSkill { Id = 1, OfferId = 1, SkillId = 2 }, // QA - SQL
                new OfferSkill { Id = 2, OfferId = 1, SkillId = 3 }, // QA - Nest

                new OfferSkill { Id = 3, OfferId = 2, SkillId = 1 }, // Desarrollo web - C#
                new OfferSkill { Id = 4, OfferId = 2, SkillId = 2 },
                new OfferSkill { Id = 5, OfferId = 2, SkillId = 3 },

                new OfferSkill { Id = 6, OfferId = 3, SkillId = 1 }, // Backend - C#
                new OfferSkill { Id = 7, OfferId = 3, SkillId = 8 }, // Backend - Node.js
                new OfferSkill { Id = 8, OfferId = 3, SkillId = 12 }, // Docker

                new OfferSkill { Id = 9, OfferId = 4, SkillId = 14 }, // Gerente - Azure
                new OfferSkill { Id = 10, OfferId = 4, SkillId = 13 }, // Git

                new OfferSkill { Id = 11, OfferId = 5, SkillId = 7 }, // Frontend - React
                new OfferSkill { Id = 12, OfferId = 5, SkillId = 10 }, // HTML
                new OfferSkill { Id = 13, OfferId = 5, SkillId = 11 }, // CSS

                new OfferSkill { Id = 14, OfferId = 6, SkillId = 12 }, // DevOps - Docker
                new OfferSkill { Id = 15, OfferId = 6, SkillId = 13 }, // Git
                new OfferSkill { Id = 16, OfferId = 6, SkillId = 14 }, // Azure

                new OfferSkill { Id = 17, OfferId = 7, SkillId = 2 }, // BD - SQL
                new OfferSkill { Id = 18, OfferId = 7, SkillId = 4 }, // BD - MySQL

                new OfferSkill { Id = 19, OfferId = 8, SkillId = 5 }, // Mobile - JS
                new OfferSkill { Id = 20, OfferId = 8, SkillId = 6 }, // TS
                new OfferSkill { Id = 21, OfferId = 8, SkillId = 7 }, // React

                new OfferSkill { Id = 22, OfferId = 9, SkillId = 1 }, // Fullstack
                new OfferSkill { Id = 23, OfferId = 9, SkillId = 7 },
                new OfferSkill { Id = 24, OfferId = 9, SkillId = 8 },

                new OfferSkill { Id = 25, OfferId = 10, SkillId = 9 }, // Soporte - Python
                new OfferSkill { Id = 26, OfferId = 10, SkillId = 13 } // Git
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
