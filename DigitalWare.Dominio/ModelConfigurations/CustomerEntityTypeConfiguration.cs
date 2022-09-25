
using DigitalWare.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalWare.Domain.ModelConfigurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerID);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Address).HasMaxLength(60);
            builder.Property(x => x.Phone).HasMaxLength(25);
            builder.Property(x => x.City).HasMaxLength(60);
            builder.Property(x => x.Birthday).IsRequired();
        }
    }
}
