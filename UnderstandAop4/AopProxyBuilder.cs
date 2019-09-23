using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop4
{
  public interface IAopProxyBuilder
     {  
         AopProxy CreateAopProxyInstance(Type type);  
     }  
   
     public class AopProxyBuilder : IAopProxyBuilder  
     {          
         public AopProxy CreateAopProxyInstance(Type type)
         {  
             return new AopProxy(type);  
         }  
     }  
}
