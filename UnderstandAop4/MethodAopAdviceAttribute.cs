using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop4
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]  
     public class MethodAopAdviceAttribute : Attribute  
      {  
    
          private AdviceType type = AdviceType.None;  
         public MethodAopAdviceAttribute(AdviceType advicetype)
          {  
            this.type = advicetype;  
          }  
   
         public AdviceType AdviceType
         {  
             get  
             {  
                 return this.type;  
             }  
         }  
     }  
   
     public enum AdviceType
     {  
         None,  
         Before,  
         After,  
         Around  
     } 
}
