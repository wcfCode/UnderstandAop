using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace Order
{
    public class OrderProcessorProxyFactory
    {

        #region  第一步
        public static IOrderProcessorProxy CreateOrderProcessorProxy(OrderProcessorProxyType processorProxyType)
        {
            IOrderProcessorProxy orderProcessorProxy=null;
            switch (processorProxyType)
            {
                case OrderProcessorProxyType.Product:
                    orderProcessorProxy= new ProductOrderProcessor();
                    break;
                case OrderProcessorProxyType.Recharge:
                    orderProcessorProxy = new RechargeOrderProcessor();
                    break;
                default:
                    throw new Exception("没有找到订单类型");
            }
            orderProcessorProxy = new OrderProcessorProxyLog(orderProcessorProxy);
            orderProcessorProxy = new OrderProcessorProxyAuthentication(orderProcessorProxy);
            return orderProcessorProxy;
        }

        #endregion

        #region 
        private static string OrderProcessorProxyName = ConfigurationManager.AppSettings["OrderProcessorProxy"];
        private static string DllName = OrderProcessorProxyName.Split('.')[0];

        public static IOrderProcessorProxy CreateOrderProcessorProxyConfjg()
        {
            Assembly assembly = Assembly.Load(DllName);
            IOrderProcessorProxy orderProcessorProxy = assembly.CreateInstance(OrderProcessorProxyName) as IOrderProcessorProxy;
            orderProcessorProxy = new OrderProcessorProxyLog(orderProcessorProxy);
            orderProcessorProxy = new OrderProcessorProxyAuthentication(orderProcessorProxy);

            return orderProcessorProxy;
        }
        #endregion
    }

    public enum OrderProcessorProxyType
    {
        Product,
        Recharge
    }
}
