using CozyThings.Services.OrderApi.Data.Abstractions;

namespace CozyThings.Services.OrderApi.Data.Entities
{
    public class OrderDetails : Entity
    {
        public int OrderHeaderId { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }
    }
}
