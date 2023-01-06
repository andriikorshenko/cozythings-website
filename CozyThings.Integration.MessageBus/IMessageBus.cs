namespace CozyThings.Integration.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage baseMessage, string topicName);
    }
}