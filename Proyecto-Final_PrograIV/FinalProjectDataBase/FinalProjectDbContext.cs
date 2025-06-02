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

            //  preloaded companies 
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId = 1, Name = "Innowise", Email = "contact@innowise.com", WebSite = "https://innowise.com/es/tecnologias/desarrollo-dot-net/" },
                new Company { CompanyId = 2, Name = "TURING", Email = "contact@turing.com", WebSite = "https://www.turing.com/es/jobs/remote-react-js-developer" },
                new Company { CompanyId = 3, Name = "Parallel Devs", Email = "info@paralleldevs.com", WebSite = "https://www.paralleldevs.com/" }
            );


            //  preloaded skills
            modelBuilder.Entity<Skill>().HasData(
                new Skill { SkillId = 1,  Name = "C#",         Icon = "https://www.svgrepo.com/show/452184/csharp.svg" },
                new Skill { SkillId = 2,  Name = "SQL",        Icon = "https://www.svgrepo.com/show/331761/sql-database-sql-azure.svg" },
                new Skill { SkillId = 3,  Name = "Nest",       Icon = "https://upload.wikimedia.org/wikipedia/commons/a/a8/NestJS.svg" },
                new Skill { SkillId = 4,  Name = "MySQL",      Icon = "https://www.svgrepo.com/show/354099/mysql.svg" },
                new Skill { SkillId = 5,  Name = "JavaScript", Icon = "https://upload.wikimedia.org/wikipedia/commons/9/99/Unofficial_JavaScript_logo_2.svg" },
                new Skill { SkillId = 6,  Name = "TypeScript", Icon = "https://upload.wikimedia.org/wikipedia/commons/4/4c/Typescript_logo_2020.svg" },
                new Skill { SkillId = 7,  Name = "React",      Icon = "https://upload.wikimedia.org/wikipedia/commons/a/a7/React-icon.svg" },
                new Skill { SkillId = 8,  Name = "Node.js",    Icon = "https://www.svgrepo.com/show/452075/node-js.svg" },
                new Skill { SkillId = 9,  Name = "Python",     Icon = "https://upload.wikimedia.org/wikipedia/commons/c/c3/Python-logo-notext.svg" },
                new Skill { SkillId = 10, Name = "HTML",       Icon = "https://www.svgrepo.com/show/452228/html-5.svg" },
                new Skill { SkillId = 11, Name = "CSS",        Icon = "https://www.svgrepo.com/show/452185/css-3.svg" },
                new Skill { SkillId = 12, Name = "Docker",     Icon = "https://www.svgrepo.com/show/354926/docker.svg" },
                new Skill { SkillId = 13, Name = "Git",        Icon = "https://upload.wikimedia.org/wikipedia/commons/3/3f/Git_icon.svg" },
                new Skill { SkillId = 14, Name = "Azure",      Icon = "https://upload.wikimedia.org/wikipedia/commons/f/fa/Microsoft_Azure.svg" }
            );


            //  preloaded offers 
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


            //  preloaded skills-offers 
            modelBuilder.Entity<OfferSkill>().HasData(
                new OfferSkill { Id = 1, OfferId = 1, SkillId = 2 },
                new OfferSkill { Id = 2, OfferId = 1, SkillId = 3 }, 
                new OfferSkill { Id = 3, OfferId = 2, SkillId = 1 }, 
                new OfferSkill { Id = 4, OfferId = 2, SkillId = 2 },
                new OfferSkill { Id = 5, OfferId = 2, SkillId = 3 },
                new OfferSkill { Id = 6, OfferId = 3, SkillId = 1 }, 
                new OfferSkill { Id = 7, OfferId = 3, SkillId = 8 }, 
                new OfferSkill { Id = 8, OfferId = 3, SkillId = 12 }, 
                new OfferSkill { Id = 9, OfferId = 4, SkillId = 14 }, 
                new OfferSkill { Id = 10, OfferId = 4, SkillId = 13 }, 
                new OfferSkill { Id = 11, OfferId = 5, SkillId = 7 },
                new OfferSkill { Id = 12, OfferId = 5, SkillId = 10 }, 
                new OfferSkill { Id = 13, OfferId = 5, SkillId = 11 }, 
                new OfferSkill { Id = 14, OfferId = 6, SkillId = 12 }, 
                new OfferSkill { Id = 15, OfferId = 6, SkillId = 13 }, 
                new OfferSkill { Id = 16, OfferId = 6, SkillId = 14 }, 
                new OfferSkill { Id = 17, OfferId = 7, SkillId = 2 }, 
                new OfferSkill { Id = 18, OfferId = 7, SkillId = 4 }, 
                new OfferSkill { Id = 19, OfferId = 8, SkillId = 5 }, 
                new OfferSkill { Id = 20, OfferId = 8, SkillId = 6 }, 
                new OfferSkill { Id = 21, OfferId = 8, SkillId = 7 }, 
                new OfferSkill { Id = 22, OfferId = 9, SkillId = 1 }, 
                new OfferSkill { Id = 23, OfferId = 9, SkillId = 7 },
                new OfferSkill { Id = 24, OfferId = 9, SkillId = 8 },
                new OfferSkill { Id = 25, OfferId = 10, SkillId = 9 }, 
                new OfferSkill { Id = 26, OfferId = 10, SkillId = 13 } 
            );


            // Company 1 - * Offer
            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Company)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.CompanyId);

            // Offer * - * Skill (via OfferSkill)
            modelBuilder.Entity<OfferSkill>()
                .HasKey(cs => cs.Id); 

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
                .HasKey(cs => cs.Id); 

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
