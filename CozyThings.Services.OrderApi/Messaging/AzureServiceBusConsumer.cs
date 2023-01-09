using AutoMapper;
using Azure.Messaging.ServiceBus;
using CozyThings.Services.OrderApi.Data.Entities;
using CozyThings.Services.OrderApi.Models;
using CozyThings.Services.OrderApi.Repository.Imp;
using Newtonsoft.Json;
using System.Text;

namespace CozyThings.Services.OrderApi.Messaging
{
    public class AzureServiceBusConsumer
    {
        private readonly OrderRepository orderRepository;
        private readonly IMapper mapper;

        public AzureServiceBusConsumer(OrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        private async Task OnCheckoutMessageReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);

            var orderHeader = mapper.Map<OrderHeader>(checkoutHeaderDto);

            foreach (var item in checkoutHeaderDto.CartDetails)
            {
                OrderDetails orderDetails = new()
                {
                    Id = item.Id,
                    ProductName = item.Product.Name,
                    ProductPrice = item.Product.Price,
                    Count = item.Count
                };
                orderHeader.CartTotalItems += item.Count;
                orderHeader.OrderDetails.Add(orderDetails);
            }
            await orderRepository.AddOrder(orderHeader);
        }
    }
}
