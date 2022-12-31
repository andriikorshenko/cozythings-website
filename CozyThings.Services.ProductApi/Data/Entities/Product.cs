
using CozyThings.Services.ProductApi.Data.Abstractions;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


namespace CozyThings.Services.ProductApi.Data.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; } // TODO: Validate as Required!

        public double Price { get; set; } // TODO: Validate from 1 to 1000!

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string ImageUrl { get; set; }
    }
}
