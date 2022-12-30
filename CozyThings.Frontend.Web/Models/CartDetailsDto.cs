using CozyThings.Frontend.Web.Models.Product;

namespace CozyThings.Frontend.Web.Models
{
    public class CartDetailsDto
    {
        public int Id { get; set; }

        public int CartHeaderId { get; set; }

        public virtual CartHeaderDto CartHeader { get; set; }

        public int ProductId { get; set; }

        public virtual ProductDto Product { get; set; }

        public int Count { get; set; }
    }
}
