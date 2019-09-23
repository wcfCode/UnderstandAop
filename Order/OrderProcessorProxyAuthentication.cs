using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class OrderProcessorProxyAuthentication : IOrderProcessorProxy
    {
        private readonly IOrderProcessorProxy _decorated;
        public OrderProcessorProxyAuthentication(IOrderProcessorProxy decorated)
        {
            _decorated = decorated;
        }

        public void Submit(OrderModel order)
        {
            Log.Write("权限校验成功进入提交订单");
            _decorated.Submit(order);
        }
    }
}
