namespace CozyThings.Frontend.Web.Models.Product
{
    public record ProductUpdateDto
    {
        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public double Price { get; init; }

        public string Description { get; init; } = string.Empty;

        public string CategoryName { get; init; } = string.Empty;

        public string ImageUrl { get; init; } = string.Empty;

        public int Count { get; init; }
    }
}
