using Microsoft.EntityFrameworkCore;
using market.muchik.invoice.domain.entities;
using market.muchik.invoice.infrastructure.configurations.entityTypes;

namespace market.muchik.invoice.infrastructure.context
{
    public partial class InvoiceContext : DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoice { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvoiceTypeConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
