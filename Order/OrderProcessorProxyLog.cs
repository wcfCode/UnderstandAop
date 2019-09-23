using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class OrderProcessorProxyLog : IOrderProcessorProxy
    {
        private readonly IOrderProcessorProxy _decorated;
        public OrderProcessorProxyLog(IOrderProcessorProxy decorated)
        {
            _decorated = decorated;
        }
        public void Submit(OrderModel order)
        {
            Log.Write("订单提交前的日志");
            try
            {
                _decorated.Submit(order);
            }
            catch
            {
                Log.Write("提交订饭出现异常");
            }
            Log.Write("订单完成后的日志");
        }
    }
}
