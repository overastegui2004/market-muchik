using Microsoft.EntityFrameworkCore;
using market.muchik.pay.domain.entities;
using market.muchik.pay.infrastructure.configurations.entityTypes;

namespace market.muchik.pay.infrastructure.context
{
    public partial class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payment> Payment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
