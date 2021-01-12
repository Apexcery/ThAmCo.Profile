using Microsoft.EntityFrameworkCore;
using ThAmCo.Profile.Data.Entities;

namespace ThAmCo.Profile.Data
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<ProfileEntity> Profiles { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProfileEntity>().HasMany(x => x.Addresses).WithOne().HasForeignKey("ProfileId");
            modelBuilder.Entity<ProfileAddress>().ToTable("Addresses");
        }
    }
}
