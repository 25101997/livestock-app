using API.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        //public required DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<AnimalStatus> Statuses => Set<AnimalStatus>();
        public DbSet<AnimalOrigin> Origins => Set<AnimalOrigin>();
        public DbSet<AnimalStage> Stages => Set<AnimalStage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones (puedes omitirlas si EF las infiere bien)
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Origin)
                .WithMany(o => o.Animals)
                .HasForeignKey(a => a.OriginId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Status)
                .WithMany(s => s.Animals)
                .HasForeignKey(a => a.StatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Stage)
                .WithMany(st => st.Animals)
                .HasForeignKey(a => a.StageId)
                .OnDelete(DeleteBehavior.Restrict);
        }       
    }
}