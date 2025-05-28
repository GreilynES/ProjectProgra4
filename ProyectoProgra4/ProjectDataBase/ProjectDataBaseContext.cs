using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;
using ProyectoProgra4.Entities;

namespace ProyectoProgra4.ProjectDataBase
{
    public class ProjectDataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProjectDataBase");
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<CandidateOffer> CandidateOffers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<OfferSkill> OfferSkills { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 🔹 Semilla de empresas
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Empresa Demo 1", Email = "demo1@empresa.com", WebSite = "https://demo1.empresa.com" },
                new Company { Id = 2, Name = "Empresa Demo 2", Email = "demo2@empresa.com", WebSite = "https://demo2.empresa.com" },
                new Company { Id = 3, Name = "Empresa Demo 3", Email = "demo3@empresa.com", WebSite = "https://demo3.empresa.com" }
            );

            // 🔹 Semilla de ofertas
            modelBuilder.Entity<Offer>().HasData(
                new Offer { Id = 1, Name = "QA", Description = "Revisión", IdCompany = 2 },
                new Offer { Id = 2, Name = "Desarrollo web", Description = "Desarrollar sistemas", IdCompany = 1 },
                new Offer { Id = 3, Name = "Programacion", Description = "Desarrollo de software", IdCompany = 2 },
                new Offer { Id = 4, Name = "Gerente informatico", Description = "Administrar proyectos", IdCompany = 3 }
            );

            // 🔹 Habilidades (Skills)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "SQL" },
                new Skill { Id = 3, Name = "Nest" },
                new Skill { Id = 4, Name = "MySQL" }
            );

            // 🔹 Relación Oferta-Habilidad (OfferSkill)
            // Usa la clave compuesta {IdOffer, SkillId}
            modelBuilder.Entity<OfferSkill>().HasData(
                new OfferSkill { IdOffer = 1, SkillId = 2}, // Oferta 1 requiere SQL
                new OfferSkill { IdOffer = 1, SkillId = 3 }, // Oferta 1 requiere Nest
                new OfferSkill { IdOffer = 2, SkillId = 1 },  // Oferta 2 requiere C#
                new OfferSkill { IdOffer = 2, SkillId = 2 },
                new OfferSkill { IdOffer = 2, SkillId = 3 },
                new OfferSkill { IdOffer = 3, SkillId = 1 },
                new OfferSkill { IdOffer = 3, SkillId = 4 }
            );

            // 🔹 Clave compuesta para OfferSkill
            modelBuilder.Entity<OfferSkill>()
                .HasKey(os => new { os.IdOffer, os.SkillId });

            // 🔹 Relaciones CandidateOffer
            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Candidate)
                .WithMany(c => c.CandidateOffers)
                .HasForeignKey(co => co.CandidateId);

            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Offer)
                .WithMany(o => o.CandidateOffers)
                .HasForeignKey(co => co.OfferId);

            // 🔹 Relaciones CandidateSkill
            modelBuilder.Entity<CandidateSkill>()
                .HasOne(cs => cs.Candidate)
                .WithMany(c => c.CandidateSkills)
                .HasForeignKey(cs => cs.CandidateId);

            modelBuilder.Entity<CandidateSkill>()
                .HasOne(cs => cs.Skill)
                .WithMany(s => s.CandidateSkills)
                .HasForeignKey(cs => cs.IdSkill);

            // 🔹 Relaciones OfferSkill
            modelBuilder.Entity<OfferSkill>()
                .HasOne(os => os.Offer)
                .WithMany(o => o.OfferSkills)
                .HasForeignKey(os => os.IdOffer);

            modelBuilder.Entity<OfferSkill>()
                .HasOne(os => os.Skill)
                .WithMany(s => s.OfferSkills)
                .HasForeignKey(os => os.SkillId);

            // 🔹 Relación Offer → Company
            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Company)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.IdCompany);
        }
    }
}
