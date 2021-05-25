using CRUD.Models;

using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class ModelsContext : DbContext
    {
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Model> Models { get; set; }

        public ModelsContext(DbContextOptions<ModelsContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>()
                .HasOne<Body>()
                .WithMany()
                .HasForeignKey(m => m.BodyId);

            modelBuilder.Entity<Model>()
                .HasOne<Engine>()
                .WithMany()
                .HasForeignKey(m => m.EngineId);
        }
    }
}
