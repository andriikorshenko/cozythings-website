namespace CozyThings.Services.ProductApi.Data.Abstractions
{
    public interface IEntity
    {
        int Id { get; }
    }

    public abstract class Entity
    {
        public int Id { get; set; }
    }
}
