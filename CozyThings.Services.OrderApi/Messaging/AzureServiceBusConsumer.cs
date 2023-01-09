using Azure.Messaging.ServiceBus;
using CozyThings.Services.OrderApi.Models;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace CozyThings.Services.OrderApi.Messaging
{
    public class AzureServiceBusConsumer
    {
        private async Task OnCheckoutMessageReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);
        }
    }
}
