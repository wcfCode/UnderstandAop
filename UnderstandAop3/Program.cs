using Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop3
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderModel orderModel = new OrderModel();

            var repository = new OrderProcessor();

            var dynamicProxy = new DynamicProxy<IOrderProcessor>(repository);

            IOrderProcessor order= dynamicProxy.GetTransparentProxy() as IOrderProcessor;

            order.Submit(orderModel);

            Console.ReadLine();
        }
    }
}
