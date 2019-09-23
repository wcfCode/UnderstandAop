using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop3
{
    class DynamicProxy<T> : RealProxy
    {
        private readonly T _decorated;
        public DynamicProxy(T decorated)
          : base(typeof(T))
        {
            _decorated = decorated;
        }
        private void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;

            try
            {
                Log("开始提交订单");
                var result = methodInfo.Invoke(_decorated, methodCall.InArgs);
                Log("订单执行后");
                return new ReturnMessage(result, null, 0,
                  methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                Log(string.Format(
                  "出现异常{0},{1}", e,
                  methodCall.MethodName));
                return new ReturnMessage(e, methodCall);
            }
        }
    }
}
