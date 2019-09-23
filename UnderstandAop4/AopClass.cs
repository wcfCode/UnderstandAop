using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop4
{
  [AopAttribute(typeof(AopProxyBuilder))]  
    public class AopClass : ContextBoundObject  
    {  
       
        public string Name  
        {  
            get;  
            set;  
        }  
        public bool IsLock = true;  
        public AopClass(string name)
        {  
            Name=name;  
            Console.WriteLine("Aop Class Create Name:"+Name);  
        }  
  
        public AopClass()
        {  
            Console.WriteLine("Aop Class Create");  
        }  
  
          
  
        [MethodAopAdvice(AdviceType.Around)]  
        public string Hello()
        {  
            Console.WriteLine("hello world:");  
            return "hello world:";  
        }  
  
        [MethodAopAdvice(AdviceType.Before)]  
        public string Say(string content)
        {    
            string c = "IsLock:" + IsLock + "\t " + Name + " :" + content;  
            Console.WriteLine(c);  
            return c;  
        }  
        public override string ToString()
        {  
            return string.Format("Name:{0},IsLock:{1}", this.Name, this.IsLock);  
  
        }  
    }  
}
