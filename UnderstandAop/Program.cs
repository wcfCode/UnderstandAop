using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderModel orderModel = new OrderModel();

            ProductOrderProcessor orderProcessor = new ProductOrderProcessor();


            #region 第一步
            //orderProcessor.Submit(orderModel);
            #endregion

            #region 第二步
            //Console.WriteLine("提交订单前的日志逻辑");
            //orderProcessor.Submit(orderModel);
            //Console.WriteLine("提交订单后的日志逻辑");
            #endregion

            #region 第三步 
            //包一层
            //ProductOrderProcessorProxy(orderProcessor, orderModel);

            OrderProcessorProxyLog productOrderProcessor = new OrderProcessorProxyLog(orderProcessor);

            productOrderProcessor.SubmitAndLog(orderModel);

            #endregion  AOP 的思想讲完了

            #region 第四步 
            // 优化

            #endregion

            Console.ReadLine();
        }

        //public static void ProductOrderProcessorProxy(ProductOrderProcessor orderProcessor, OrderModel orderModel)
        //{
        //    Console.WriteLine("提交订单前的日志逻辑");
        //    try
        //    {
        //        orderProcessor.Submit(orderModel);
        //    }
        //    catch
        //    {
        //        Console.WriteLine("提交订单出现异常");
        //    }
        //    Console.WriteLine("提交订单后的日志逻辑");
        //}

    }



}
