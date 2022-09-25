using DigitalWare.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DigitalWare.DAL.ModelConfigurations
{
    public class Order_DetailEntityTypeConfiguration : IEntityTypeConfiguration<Order_Detail>
    {
        public void Configure(EntityTypeBuilder<Order_Detail> builder)
        {
            builder.HasKey(x => new { x.OrderID, x.ProductID });
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            
        }
    }
}
