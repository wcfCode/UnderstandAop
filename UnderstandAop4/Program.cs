using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            AopClass ap = new AopClass("XiaoQiang");
            Console.WriteLine("Show:" + ap.Hello());
            Console.WriteLine(ap.ToString());
            Console.WriteLine();
            Console.WriteLine("Show:" + ap.Say("hello,everybody!"));
            Console.WriteLine(ap.ToString());
            Console.WriteLine(ap.ToString());
            Console.ReadLine();
        }
    }
}
