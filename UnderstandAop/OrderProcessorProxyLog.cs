using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop
{
     public class OrderProcessorProxyLog
    {
        ProductOrderProcessor _productOrderProcessor;

        public OrderProcessorProxyLog(ProductOrderProcessor productOrderProcessor)
        {
            _productOrderProcessor = productOrderProcessor;
        }

        public void SubmitAndLog(OrderModel orderModel)
        {
            Console.WriteLine("提交订单前的日志逻辑");
            try
            {
                _productOrderProcessor.Submit(orderModel);
            }
            catch
            {
                Console.WriteLine("提交订单出现异常");
            }
            Console.WriteLine("提交订单后的日志逻辑");
        }
    }
}
