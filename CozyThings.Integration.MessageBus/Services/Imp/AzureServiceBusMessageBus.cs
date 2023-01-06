using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace CozyThings.Integration.MessageBus.Services.Imp
{
    public class AzureServiceBusMessageBus : IMessageBus
    {
        private string connectionString = 
            @"Endpoint=sb://cozythings.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=W8Y8N3oJVEktw0FFY13ZAik0gBb3KnqrX1h/+E5z6cI=";

        public async Task PublishMessage(BaseMessage baseMessage, string topicName)
        {
            await using var client = new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(topicName);

            var jsonMessage = JsonConvert.SerializeObject(baseMessage);
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await sender.SendMessageAsync(finalMessage);

            await client.DisposeAsync();
        }
    }
}
