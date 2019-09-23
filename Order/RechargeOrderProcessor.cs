using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class RechargeOrderProcessor : IOrderProcessorProxy
    {
        public void Submit(OrderModel order)
        {
            Console.WriteLine("提交充值订单");
        }
    }
}
