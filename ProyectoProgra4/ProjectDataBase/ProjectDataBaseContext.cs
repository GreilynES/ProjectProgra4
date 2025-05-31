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
            // 🔹 seed de empresas
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Empresa Demo 1", Email = "demo1@empresa.com", WebSite = "https://demo1.empresa.com" },
                new Company { Id = 2, Name = "Empresa Demo 2", Email = "demo2@empresa.com", WebSite = "https://demo2.empresa.com" },
                new Company { Id = 3, Name = "Empresa Demo 3", Email = "demo3@empresa.com", WebSite = "https://demo3.empresa.com" },
                new Company { Id = 4, Name = "Tech Solutions CR", Email = "contacto@techsolutions.cr", WebSite = "https://techsolutions.cr" },
                new Company { Id = 5, Name = "AgroSoft Systems", Email = "info@agrosoft.co", WebSite = "https://agrosoft.co" },
                new Company { Id = 6, Name = "Finanzas Digitales", Email = "soporte@finanzasdigitales.com", WebSite = "https://finanzasdigitales.com" }
            );

            // 🔹 seed de ofertas
            modelBuilder.Entity<Offer>().HasData(
                new Offer
                {
                    Id = 1,
                    Name = "Especialista en QA (Quality Assurance)",
                    Description = "Buscamos un especialista en aseguramiento de la calidad para liderar pruebas funcionales y automatizadas. El candidato ideal debe tener experiencia en herramientas como Selenium, Postman y JIRA, y será responsable de asegurar que todos los productos cumplan con los estándares establecidos antes de su lanzamiento.",
                    IdCompany = 2
                },
                new Offer
                {
                    Id = 2,
                    Name = "Desarrollador Web Full Stack",
                    Description = "Se requiere desarrollador web con experiencia comprobada en tecnologías como React, Node.js y bases de datos relacionales. Será parte de un equipo ágil, responsable de crear y mantener aplicaciones empresariales con enfoque en rendimiento, seguridad y experiencia de usuario.",
                    IdCompany = 1
                },
                new Offer
                {
                    Id = 3,
                    Name = "Ingeniero de Software - Programación Avanzada",
                    Description = "Empresa de tecnología busca ingeniero de software para diseñar y desarrollar soluciones escalables. Se valorará experiencia en arquitecturas limpias, patrones de diseño, integración continua, y lenguajes como C#, Java o Python. Trabajo híbrido y remuneración competitiva.",
                    IdCompany = 2
                },
                new Offer
                {
                    Id = 4,
                    Name = "Gerente de Tecnología Informática",
                    Description = "Se necesita un gerente informático con experiencia en liderazgo de proyectos, gestión de equipos técnicos y planificación estratégica de sistemas. Será responsable de supervisar la infraestructura TI de la empresa y coordinar el desarrollo de soluciones tecnológicas innovadoras para distintas áreas de negocio.",
                    IdCompany = 3
                },
                new Offer
                {
                    Id = 5,
                    Name = "Desarrollador Frontend React",
                    Description = "Estamos en búsqueda de un desarrollador frontend altamente competente en React para trabajar en una plataforma de e-commerce. Se espera experiencia en consumo de APIs REST, responsive design y testing con herramientas como Jest. Conocimiento en Git y metodologías ágiles es un plus.",
                    IdCompany = 4
                },
                    new Offer
                    {
                        Id = 6,
                        Name = "Ingeniero en Datos con Python",
                        Description = "AgroSoft Systems necesita un ingeniero en datos que se encargue del procesamiento de información agrícola. Se requiere dominio en Python, manejo de bases de datos (MySQL), uso de contenedores Docker y conocimientos de pipelines ETL. Experiencia en análisis predictivo será valorada.",
                        IdCompany = 5
                    },
                    new Offer
                    {
                        Id = 7,
                        Name = "Scrum Master / Coordinador de Proyectos",
                        Description = "Finanzas Digitales busca un Scrum Master con certificación y experiencia en gestión de equipos de desarrollo. Será responsable de facilitar ceremonias Scrum, eliminar obstáculos, y asegurar la entrega efectiva de productos financieros digitales.",
                        IdCompany = 6
                    }
            );

            // 🔹 seed (Skills)
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "SQL" },
                new Skill { Id = 3, Name = "Nest" },
                new Skill { Id = 4, Name = "MySQL" },
                new Skill { Id = 5, Name = "React" },
                new Skill { Id = 6, Name = "JavaScript" },
                new Skill { Id = 7, Name = "Python" },
                new Skill { Id = 8, Name = "Docker" },
                new Skill { Id = 9, Name = "Git" },
                new Skill { Id = 10, Name = "Scrum" }
            );

            // 🔹 Relación Oferta-Habilidad (OfferSkill)
            // Usa la clave compuesta {IdOffer, SkillId}
            modelBuilder.Entity<OfferSkill>().HasData(
                new OfferSkill { Id = 1, IdOffer = 1, SkillId = 2 }, // Oferta 1 requiere SQL
                new OfferSkill { Id = 2, IdOffer = 1, SkillId = 3 }, // Oferta 1 requiere Nest
                new OfferSkill { Id = 3, IdOffer = 2, SkillId = 1 }, // Oferta 2 requiere C#
                new OfferSkill { Id = 4, IdOffer = 2, SkillId = 2 }, // Oferta 2 requiere SQL
                new OfferSkill { Id = 5, IdOffer = 2, SkillId = 3 }, // Oferta 2 requiere Nest
                new OfferSkill { Id = 6, IdOffer = 3, SkillId = 1 }, // Oferta 3 requiere C#
                new OfferSkill { Id = 7, IdOffer = 3, SkillId = 4 }, // Oferta 3 requiere MySQL
                new OfferSkill { Id = 8, IdOffer = 3, SkillId = 7 }, // Oferta 3 requiere Python
                new OfferSkill { Id = 9, IdOffer = 4, SkillId = 10 }, // Oferta 4 requiere Scrum
                new OfferSkill { Id = 10, IdOffer = 4, SkillId = 9 }, // Oferta 4 requiere Git
                new OfferSkill { Id = 11, IdOffer = 4, SkillId = 6 }, // Oferta 4 requiere JavaScript
                new OfferSkill { Id = 12, IdOffer = 2, SkillId = 5 }, // Oferta 2 también requiere React
                new OfferSkill { Id = 13, IdOffer = 1, SkillId = 9 },  // Oferta 1 también requiere Git
                new OfferSkill { Id = 14, IdOffer = 5, SkillId = 5 }, // React
                new OfferSkill { Id = 15, IdOffer = 5, SkillId = 6 }, // JavaScript
                new OfferSkill { Id = 16, IdOffer = 5, SkillId = 9 }, // Git
                new OfferSkill { Id = 17, IdOffer = 6, SkillId = 7 }, // Python
                new OfferSkill { Id = 18, IdOffer = 6, SkillId = 4 }, // MySQL
                new OfferSkill { Id = 19, IdOffer = 6, SkillId = 8 }, // Docker
                new OfferSkill { Id = 20, IdOffer = 7, SkillId = 10 }, // Scrum
                new OfferSkill { Id = 21, IdOffer = 7, SkillId = 9 }   // Git
            );


            // 🔹 Clave compuesta para OfferSkill
            modelBuilder.Entity<OfferSkill>()
                .HasKey(os => new { os.IdOffer, os.SkillId });

            // 🔹 Relaciones CandidateOffer
            modelBuilder.Entity<OfferSkill>()
             .HasKey(cs => cs.Id); // Composite key

            modelBuilder.Entity<OfferSkill>()
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

            // 🔹 Relaciones CandidateSkill
            modelBuilder.Entity<OfferSkill>()
            .HasKey(cs => cs.Id); // Composite key

            modelBuilder.Entity<OfferSkill>()
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd();

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
            .HasKey(cs => cs.Id); // Composite key

            modelBuilder.Entity<OfferSkill>()
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd();

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