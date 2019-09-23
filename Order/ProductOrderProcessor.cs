using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class ProductOrderProcessor : IOrderProcessorProxy
    {
        public void Submit(OrderModel order)
        {
            Console.WriteLine("提交商品订单");
        }
    }
}
