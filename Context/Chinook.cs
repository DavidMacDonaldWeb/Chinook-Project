using Microsoft.EntityFrameworkCore;
using UWS.Shared;

namespace UWS.Shared
{
    public class Chinook : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Media_Type> Media_Types { get; set; }
        public DbSet<Genre> Genres { get; set; }
        

       public Chinook(DbContextOptions<Chinook> options)
         : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Album>()
              .HasOne(p => p.Artist)
              .WithMany(s => s.Albums)
              .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Artist>()
              .HasMany(p => p.Albums)
              .WithOne(s => s.Artist)
              .OnDelete(DeleteBehavior.ClientCascade);  

              modelBuilder.Entity<Album>()
              .HasMany(t => t.Tracks)
              .WithOne(a => a.Albums);  

              modelBuilder.Entity<Media_Type>()
              .HasKey(c => new { c.MediaTypeID});

        }
    }
}
