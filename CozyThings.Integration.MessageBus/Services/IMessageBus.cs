namespace CozyThings.Integration.MessageBus.Services
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage baseMessage, string topicName);
    }
}