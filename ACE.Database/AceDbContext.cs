using ACE.Model;
using Microsoft.EntityFrameworkCore;

namespace ACE.Database
{
    public class AceDbContext : DbContextBase
    {
        public AceDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Family> Families { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Contribution> Contributions { get; set; }

        public DbSet<ContributionType> ContributionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contribution>()
                .HasOne(ci => ci.Member)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
