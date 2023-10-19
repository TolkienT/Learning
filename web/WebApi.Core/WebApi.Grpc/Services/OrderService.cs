using Grpc.Core;
using GrpcDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Grpc.Services
{
    public class OrderService : Order.OrderBase
    {
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
