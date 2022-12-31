using CozyThings.Services.ProductApi.Data.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace CozyThings.Services.ShoppingCartApi.Data.Entities.Cart
{
    public class CartDetails : Entity
    {
        public int CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int Count { get; set; }
    }
}
