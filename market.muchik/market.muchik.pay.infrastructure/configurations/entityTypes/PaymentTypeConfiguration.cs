using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using market.muchik.pay.domain.entities;

namespace market.muchik.pay.infrastructure.configurations.entityTypes
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("payment");

            builder.Property(e => e.OperationId).HasColumnName("id_operation");

            builder.HasKey(e => e.OperationId);

            builder.Property(e => e.DatePay)
                .HasColumnType("datetime")
                .HasColumnName("date_pay");

            builder.Property(e => e.InvoiceId)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("id_invoice");
        }
    }
}
