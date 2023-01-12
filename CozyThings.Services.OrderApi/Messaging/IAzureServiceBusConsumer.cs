namespace CozyThings.Services.OrderApi.Messaging
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();

        Task Stop();
    }
}
