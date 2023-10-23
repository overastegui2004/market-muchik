using Microsoft.EntityFrameworkCore;
using market.muchik.security.domain.entities;
using market.muchik.security.infra.configurations.entityTypes;

namespace market.muchik.security.infra.context
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Users");
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
