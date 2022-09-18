using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalWareTestAPI.Data.Models
{
    public class Order_DetailEntityTypeConfiguration : IEntityTypeConfiguration<Order_Detail>
    {
        public void Configure(EntityTypeBuilder<Order_Detail> builder)
        {
            builder.ToTable("Order_Details");
            builder.HasKey(x => new {x.OrderID, x.ProductID});
            builder.Property(x => new {x.OrderID, x.ProductID, x.Quantity, x.UnitPrice}).IsRequired();
            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.Order_Details);
        }
    }
}
