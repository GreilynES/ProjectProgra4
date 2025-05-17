using Microsoft.EntityFrameworkCore;
using Proyecto_Final_PrograIV.Entities;

namespace ProyectoProgra4.ProjectDataBase
{
    public class ProjectDataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "JWTDataBase");
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<CandidateOffer> CandidateOffers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            // Candidate * - * Offer (via CandidateOffer)
            modelBuilder.Entity<CandidateOffer>()
                .HasKey(co => new { co.CandidateId, co.OfferId }); 

            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Candidate)
                .WithMany(c => c.CandidateOffers)
                .HasForeignKey(co => co.CandidateId);

            modelBuilder.Entity<CandidateOffer>()
                .HasOne(co => co.Offer)
                .WithMany(o => o.CandidateOffers)
                .HasForeignKey(co => co.OfferId);
        }
    }
}//cambio

