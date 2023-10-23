using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using market.muchik.security.domain.entities;

namespace market.muchik.security.infra.configurations.entityTypes
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id)
                .ToJsonProperty("id");

            builder.Property(e => e.Username)
                .ToJsonProperty("username");

            builder.Property(e => e.Password)
                .ToJsonProperty("password");


            builder.HasNoDiscriminator();

            builder.HasPartitionKey(e => e.Id);

            builder.UseETagConcurrency();
        }
    }
}
