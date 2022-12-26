using CozyThings.Services.ShoppingCartApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CozyThings.Services.ProductApi.Data.Configurations
{
    public class CartHeaderConfiguration : IEntityTypeConfiguration<CartHeader>
    {
        public void Configure(EntityTypeBuilder<CartHeader> builder)
        {
            builder.ToTable(schema: "dbo", name: "CartHeader");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
