using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Newtonsoft.Json;
using System.Text;

namespace CozyThings.Integration.MessageBus.Services.Imp
{
    public class AzureServiceBusMessageBus : IMessageBus
    {
        private string connectionString = AppConfig.GetConnectionString();

        public async Task PublishMessage(BaseMessage baseMessage, string topicName)
        {
            ISenderClient senderClient = new TopicClient(connectionString, topicName);

            var jsonMessage = JsonConvert.SerializeObject(baseMessage);
            var finalMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await senderClient.SendAsync(finalMessage);

            await senderClient.CloseAsync();
        }
    }
}
