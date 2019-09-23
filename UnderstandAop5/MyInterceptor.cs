using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop5
{
    class MyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            PreProceed(invocation);
            invocation.Proceed();
            PostProceed(invocation);
        }
        public void PreProceed(IInvocation invocation)
        {
            Console.WriteLine("方法执行前");
        }

        public void PostProceed(IInvocation invocation)
        {
            Console.WriteLine("方法执行后");
        }

    }
}
