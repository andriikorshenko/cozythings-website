namespace CozyThings.Frontend.Web
{
    public static class StaticDetails
    {
        public static string ProductApiBase { get; set; } = string.Empty;
    }

    public enum ApiType
    {
        GET, POST, PUT, DELETE
    }
}