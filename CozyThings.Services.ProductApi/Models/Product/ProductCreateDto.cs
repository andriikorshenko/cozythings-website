namespace CozyThings.Services.ProductApi.Models.Product
{
    public record ProductCreateDto
    {
        public string Name { get; init; } = string.Empty;

        public double Price { get; init; }

        public string Description { get; init; } = string.Empty;

        public string CategoryName { get; init; } = string.Empty;

        public string ImageUrl { get; init; } = string.Empty;
    }
}
