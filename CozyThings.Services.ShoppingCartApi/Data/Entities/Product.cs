using CozyThings.Services.ProductApi.Data.Abstractions;

namespace CozyThings.Services.ShoppingCartApi.Data.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; } 

        public double Price { get; set; } 

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }

        public int Count { get; set; }
    }
}
