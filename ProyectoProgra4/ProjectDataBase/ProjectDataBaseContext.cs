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
            // 🔹 company seed
            modelBuilder.Entity<Company>().HasData(
              new Company { Id = 1, Name = "NovaTech Labs", Email = "info@novatechlabs.com", WebSite = "https://novatechlabs.com" },
              new Company { Id = 2, Name = "BlueOcean Systems", Email = "contact@blueoceansys.com", WebSite = "https://blueoceansys.com" },
              new Company { Id = 3, Name = "Skyline Innovations", Email = "hello@skylineinnovations.com", WebSite = "https://skylineinnovations.com" },
              new Company { Id = 4, Name = "QuantumCore Solutions", Email = "support@quantumcore.io", WebSite = "https://quantumcore.io" },
              new Company { Id = 5, Name = "GreenFields Data", Email = "team@greenfieldsdata.com", WebSite = "https://greenfieldsdata.com" },
              new Company { Id = 6, Name = "FinEdge Group", Email = "services@finedgegroup.com", WebSite = "https://finedgegroup.com" }
        );

            // 🔹 offer seed
            modelBuilder.Entity<Offer>().HasData(
                new Offer
                {
                    Id = 1,
                    Name = "QA (Quality Assurance) Specialist",
                    Description = "We are looking for a quality assurance specialist to lead functional and automated tests. The ideal candidate should have experience with tools like Selenium, Postman, and JIRA, and will be responsible for ensuring that all products meet established standards before release.",
                    IdCompany = 2
                },
                new Offer
                {
                    Id = 2,
                    Name = "Full Stack Web Developer",
                    Description = "Web developer needed with proven experience in technologies like React, Node.js, and relational databases. Will be part of an agile team, responsible for creating and maintaining enterprise applications focused on performance, security, and user experience.",
                    IdCompany = 1
                },
                new Offer
                {
                    Id = 3,
                    Name = "Software Engineer - Advanced Programming",
                    Description = "Tech company is seeking a software engineer to design and develop scalable solutions. Experience in clean architectures, design patterns, continuous integration, and languages like C#, Java, or Python is valued. Hybrid work and competitive salary.",
                    IdCompany = 2
                },
                new Offer
                {
                    Id = 4,
                    Name = "IT Manager",
                    Description = "We need an IT manager with experience in project leadership, technical team management, and strategic IT planning. Responsible for overseeing the company’s IT infrastructure and coordinating the development of innovative technological solutions for different business areas.",
                    IdCompany = 3
                },
                new Offer
                {
                    Id = 5,
                    Name = "React Frontend Developer",
                    Description = "We are looking for a highly skilled React frontend developer to work on an e-commerce platform. Experience in consuming REST APIs, responsive design, and testing with tools like Jest is expected. Knowledge in Git and agile methodologies is a plus.",
                    IdCompany = 4
                },
                new Offer
                {
                    Id = 6,
                    Name = "Data Engineer with Python",
                    Description = "AgroSoft Systems is looking for a data engineer to handle agricultural information processing. Python expertise, database management (MySQL), Docker containers, and ETL pipelines knowledge required. Predictive analysis experience is a plus.",
                    IdCompany = 5
                },
                new Offer
                {
                    Id = 7,
                    Name = "Scrum Master / Project Coordinator",
                    Description = "Digital Finance is seeking a certified Scrum Master with experience managing development teams. Responsible for facilitating Scrum ceremonies, removing obstacles, and ensuring effective delivery of digital financial products.",
                    IdCompany = 6
                },
                new Offer
                {
                    Id = 8,
                    Name = "Mobile App Developer",
                    Description = "Looking for a developer with experience in building mobile apps using Flutter or React Native. Must have experience with state management and deployment processes.",
                    IdCompany = 1
                },
                new Offer
                {
                    Id = 9,
                    Name = "UI/UX Designer",
                    Description = "Seeking a creative UI/UX designer to improve user interfaces and user experiences across our digital products. Knowledge of Figma or Adobe XD required.",
                    IdCompany = 2
                },
                new Offer
                {
                    Id = 10,
                    Name = "DevOps Engineer",
                    Description = "Hiring a DevOps Engineer with experience in CI/CD pipelines, Docker, Kubernetes, and cloud platforms like AWS or Azure.",
                    IdCompany = 3
                },
                new Offer
                {
                    Id = 11,
                    Name = "Cybersecurity Analyst",
                    Description = "We need a cybersecurity specialist to manage vulnerabilities, perform risk assessments, and lead security audits.",
                    IdCompany = 4
                },
                new Offer
                {
                    Id = 12,
                    Name = "AI/Machine Learning Engineer",
                    Description = "Seeking an ML Engineer experienced in building and deploying models using TensorFlow, PyTorch or Scikit-learn.",
                    IdCompany = 5
                },
                new Offer
                {
                    Id = 13,
                    Name = "Product Manager",
                    Description = "Looking for a product manager to lead cross-functional teams, define roadmaps, and drive product vision and execution.",
                    IdCompany = 6
                },
                new Offer
                {
                    Id = 14,
                    Name = "Backend Developer (Node.js)",
                    Description = "Hiring backend developers skilled in Node.js, Express, and MongoDB for scalable RESTful API development.",
                    IdCompany = 1
                },
                new Offer
                {
                    Id = 15,
                    Name = "Cloud Solutions Architect",
                    Description = "Looking for an experienced cloud architect to design and implement infrastructure on AWS and Azure.",
                    IdCompany = 2
                },
                new Offer
                {
                    Id = 16,
                    Name = "Business Intelligence Analyst",
                    Description = "Seeking BI analyst to create dashboards, analyze KPIs, and provide insights using Power BI or Tableau.",
                    IdCompany = 3
                },
                new Offer
                {
                    Id = 17,
                    Name = "Technical Support Specialist",
                    Description = "Customer-focused support specialist needed for tier-2 technical issues. Experience with CRM and troubleshooting required.",
                    IdCompany = 4
                }

            );

            // 🔹 skill seed
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "SQL" },
                new Skill { Id = 3, Name = "Nest" },
                new Skill { Id = 4, Name = "MySQL" },
                new Skill { Id = 5, Name = "React" },
                new Skill { Id = 6, Name = "JavaScript" },
                new Skill { Id = 7, Name = "Python" },
                new Skill { Id = 8, Name = "Java" },
                new Skill { Id = 9, Name = "Git" },
                new Skill { Id = 10, Name = "Scrum" }
            );

            // 🔹 Offer-Skill relationship
            modelBuilder.Entity<OfferSkill>().HasData(
                new OfferSkill { Id = 1, IdOffer = 1, SkillId = 2 },
                new OfferSkill { Id = 2, IdOffer = 1, SkillId = 3 },
                new OfferSkill { Id = 3, IdOffer = 2, SkillId = 1 },
                new OfferSkill { Id = 4, IdOffer = 2, SkillId = 2 },
                new OfferSkill { Id = 5, IdOffer = 2, SkillId = 3 },
                new OfferSkill { Id = 6, IdOffer = 3, SkillId = 1 },
                new OfferSkill { Id = 7, IdOffer = 3, SkillId = 4 },
                new OfferSkill { Id = 8, IdOffer = 3, SkillId = 7 },
                new OfferSkill { Id = 9, IdOffer = 4, SkillId = 10 },
                new OfferSkill { Id = 10, IdOffer = 4, SkillId = 9 },
                new OfferSkill { Id = 11, IdOffer = 4, SkillId = 6 },
                new OfferSkill { Id = 12, IdOffer = 2, SkillId = 5 },
                new OfferSkill { Id = 13, IdOffer = 1, SkillId = 9 },
                new OfferSkill { Id = 14, IdOffer = 5, SkillId = 5 },
                new OfferSkill { Id = 15, IdOffer = 5, SkillId = 6 },
                new OfferSkill { Id = 16, IdOffer = 5, SkillId = 9 },
                new OfferSkill { Id = 17, IdOffer = 6, SkillId = 7 },
                new OfferSkill { Id = 18, IdOffer = 6, SkillId = 4 },
                new OfferSkill { Id = 19, IdOffer = 6, SkillId = 8 },
                new OfferSkill { Id = 20, IdOffer = 7, SkillId = 10 },
                new OfferSkill { Id = 21, IdOffer = 7, SkillId = 9 }
            );

            // 🔹 composite key for OfferSkill
            modelBuilder.Entity<OfferSkill>()
                .HasKey(os => new { os.IdOffer, os.SkillId });

            modelBuilder.Entity<OfferSkill>()
             .HasKey(cs => cs.Id);

            modelBuilder.Entity<OfferSkill>()
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd();

            // 🔹 CandidateOffer relationships
            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Candidate)
                .WithMany(c => c.CandidateOffers)
                .HasForeignKey(co => co.CandidateId);

            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Offer)
                .WithMany(o => o.CandidateOffers)
                .HasForeignKey(co => co.OfferId);

            // 🔹 CandidateSkill relationships
            modelBuilder.Entity<CandidateSkill>()
                .HasOne(cs => cs.Candidate)
                .WithMany(c => c.CandidateSkills)
                .HasForeignKey(cs => cs.CandidateId);

            modelBuilder.Entity<CandidateSkill>()
                .HasOne(cs => cs.Skill)
                .WithMany(s => s.CandidateSkills)
                .HasForeignKey(cs => cs.IdSkill);

            // 🔹 OfferSkill relationships
            modelBuilder.Entity<OfferSkill>()
                .HasOne(os => os.Offer)
                .WithMany(o => o.OfferSkills)
                .HasForeignKey(os => os.IdOffer);

            modelBuilder.Entity<OfferSkill>()
                .HasOne(os => os.Skill)
                .WithMany(s => s.OfferSkills)
                .HasForeignKey(os => os.SkillId);

            // 🔹 Offer → Company
            modelBuilder.Entity<Offer>()
                .HasOne(o => o.Company)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.IdCompany);
        }
    }
}
