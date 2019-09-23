using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order;

namespace UnderstandAop2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 第一步
            //OrderModel orderModel = new OrderModel();

            //IOrderProcessorProxy orderProcessor = new OrderProcessorProxyLog(new ProductOrderProcessor());

            //orderProcessor = new OrderProcessorProxyAuthentication(orderProcessor);
            //orderProcessor.Submit(orderModel);

            #endregion

            #region 第二步

            //IOrderProcessorProxy orderProcessor = OrderProcessorProxyFactory.CreateOrderProcessorProxy(OrderProcessorProxyType.Recharge);

            IOrderProcessorProxy orderProcessor = OrderProcessorProxyFactory.CreateOrderProcessorProxyConfjg();

            OrderModel orderModel = new OrderModel();
            orderProcessor.Submit(orderModel);

            #endregion 

            Console.ReadLine();
        }
    }
}
