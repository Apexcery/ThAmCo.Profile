using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Profile.Data
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<ProfileModel> Profiles { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
