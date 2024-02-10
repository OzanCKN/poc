using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostgresqlGemini.Domain.Features.TestData;

namespace PostgresqlGemini.Infrastructure.EfConfigurations;

internal sealed class TestDataConfiguration : IEntityTypeConfiguration<TestData>
{
    public void Configure(EntityTypeBuilder<TestData> builder)
    {
        builder.ToTable("TestData");

        builder.HasKey(testData => testData.Id);
         
        builder.Property(testData => testData.FirstName)
            .HasMaxLength(40)
            .HasConversion(name => name.Value, value => new FirstName(value));

        builder.Property(testData => testData.LastName)
            .HasMaxLength(40)
            .HasConversion(description => description.Value, value => new LastName(value));

        builder.Property(testData => testData.Email)
            .HasMaxLength(40)
            .HasConversion(description => description.Value, value => new Email(value));
        //builder.HasOne<User>()
        //    .WithMany()
        //    .HasForeignKey(booking => booking.UserId);
        //builder.HasMany(dataSub => dataSub.Addresses)
        //    .WithMany()
        //    .UsingEntity<Addresses>();

        //Optimistic deneme 1
        builder.Property<uint>("Version").IsRowVersion();

    }
}
