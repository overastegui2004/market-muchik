using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using market.muchik.invoice.domain.entities;

namespace market.muchik.invoice.infrastructure.configurations.entityTypes
{
    public class InvoiceTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("home_delivery");

            builder.Property(e => e.InvoiceId).HasColumnName("id_invoice");

            builder.HasKey(c => c.InvoiceId);

            builder.Property(e => e.Amount).HasColumnName("amount");

            builder.Property(e => e.State).HasColumnName("state");
        }
    }
}
