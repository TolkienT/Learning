using Grpc.Core;
using GrpcDemo.Service;
using Microsoft.Extensions.Logging;

namespace GrpcDemo.Service.Services
{
    public class OrderService : Order.OrderBase
    {
        private readonly ILogger<OrderService> _logger;
        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }

        public override Task<CreateOrderReply> CreateOrder(CreateOrderRequest request, ServerCallContext context)
        {
            return Task.FromResult(new CreateOrderReply
            {
                Result = true,
                Message = "Success"
            });
        }

        public override Task<QueryOrderReply> QueryOrder(QueryOrderRequest request, ServerCallContext context)
        {
            return Task.FromResult(new QueryOrderReply
            {
                Id = request.Id,
                OrderNo = DateTime.Now.ToString("yyyyMMddHHmmss"),
                OrderName = "冰箱",
                Price = 1288
            });
        }
    }
}
