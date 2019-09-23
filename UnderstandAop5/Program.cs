using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop5
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyGenerator generator = new ProxyGenerator();
            MyInterceptor interceptor = new MyInterceptor();


            UserProcessor userProcessor = generator.CreateClassProxy<UserProcessor>(interceptor);

            userProcessor.Submit66666666666666();
            Console.ReadLine();
        }
    }
}
