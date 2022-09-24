using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalWareTestAPI.Data.Models
{
    public class Order_DetailEntityTypeConfiguration : IEntityTypeConfiguration<Order_Detail>
    {
        public void Configure(EntityTypeBuilder<Order_Detail> builder)
        {
            builder.HasKey(x => new {x.OrderID, x.ProductID});
        }
    }
}








