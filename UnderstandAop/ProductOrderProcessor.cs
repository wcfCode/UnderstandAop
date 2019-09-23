using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop
{
    public class ProductOrderProcessor
    {
        public void Submit(OrderModel orderModel)
        {
            //Console.WriteLine("提交订单前的日志逻辑");

            Console.WriteLine("提交订单业务逻辑执行");

            //Console.WriteLine("提交订单前的日志逻辑");
        }
    }
}
