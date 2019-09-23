using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop4
{
    partial interface IAopAction
      {  
           void PreProcess(IMessage requestMsg);  
           void PostProcess(IMessage requestMsg, IMessage Respond);  
      }  
       public class AopProxy : RealProxy, IAopAction  
      {  
           public AopProxy(Type serverType)
         : base(serverType)  
     {  
     }  
     public virtual void PreProcess(object obj, string method = "", int argCount = 0, object[] args = null)
     {  
         var o = obj as AopClass;  
         if (o!=null)  
         {  
             o.IsLock=false;  
             o.Name="999999";  
         }  
     }  

     public virtual void PreProcess(IMessage requestMsg)
     {    
         var o = GetUnwrappedServer();  
         IMethodCallMessage call = requestMsg as IMethodCallMessage;  
         if (call!=null)  
         {  
             this.PreProcess(o, call.MethodName, call.InArgCount, call.Args);  
         }  
         else  
         {  
             this.PreProcess(o);  
         }  
                 
     }  

     public virtual void PostProcess(object obj, object returnValue = null, string method = "", int argCount = 0, object[] args = null)
     {  
         var o = obj as AopClass;  
         if (o!=null)  
         {  
             o.IsLock=true;  
             o.Name="10101010";  
         }  
         

     }  
     public virtual void PostProcess(IMessage requestMsg, IMessage Respond)
     {  
           var o = GetUnwrappedServer();           
             ReturnMessage mm = Respond as ReturnMessage;  
             var ret = mm.ReturnValue;  
             IMethodCallMessage call = requestMsg as IMethodCallMessage;  
             if (call!=null)  
             {  
                 this.PostProcess(o, ret, call.MethodName, call.InArgCount, call.Args);  
             }  
             else  
             {  
                 this.PostProcess(o, ret);  
             }  
     }  

     //public virtual IMessage Proessed(IMessage msg,MarshalByRefObject target)  
     //{  
     //    IMethodCallMessage call = (IMethodCallMessage)msg;  
     //    IConstructionCallMessage ctor = call as IConstructionCallMessage;  
     //    if (ctor != null)  
     //    {  
     //        //获取最底层的默认真实代理    
     //        RealProxy default_proxy = System.Runtime.Remoting.RemotingServices.GetRealProxy(target);  

     //        default_proxy.InitializeServerObject(ctor);  
     //        MarshalByRefObject tp = (MarshalByRefObject)this.GetTransparentProxy();  
     //        //自定义的透明代理 this    

     //        return System.Runtime.Remoting.Services.EnterpriseServicesHelper.CreateConstructionReturnMessage(ctor, tp);  
     //    }  

     //    IMethodReturnMessage result_msg =  System.Runtime.Remoting.RemotingServices.ExecuteMessage(target, call);  
     //    //将消息转化为堆栈，并执行目标方法，方法完成后，再将堆栈转化为消息    
     //    return result_msg;  
     //}  

     public virtual IMessage Proessed(IMessage msg)
     {  
         IMessage message;  
         if (msg is IConstructionCallMessage)  
         {  
             message=this.ProcessConstruct(msg);  
         }  
         else  
         {  
             message=this.ProcessInvoke(msg);  
         }  
         return message;  
     }  
     public virtual void ChangeReturnValue(IMessage msg, ref object o)
     {  
         if (msg is IMethodCallMessage)  
         {  
             var m = msg as IMethodCallMessage;  
             string name = m.MethodName;  
             if(name=="Hello")  
               o="Hello,Lucy!";  
         }  
     }  
     public virtual IMessage ProcessInvoke(IMessage msg)
     {  
         IMethodCallMessage callMsg = msg as IMethodCallMessage;  
         IMessage message;  
         try  
         {     
             object[] args = callMsg.Args;   //方法参数                   
             object o = callMsg.MethodBase.Invoke(GetUnwrappedServer(), args);  //调用 原型类的 方法         
             ChangeReturnValue(msg, ref o);  
             message = new ReturnMessage(o, args, args.Length, callMsg.LogicalCallContext, callMsg);   // 返回类型 Message  
         }  
         catch (Exception e)  
         {  
             message = new ReturnMessage(e, callMsg);  
         }  

         //Console.WriteLine("Call Method:"+callMsg.MethodName);  
         //Console.WriteLine("Return:"+ message.Properties["__Return"].ToString());  
         return message;  
     }  
     public virtual IMessage ProcessConstruct(IMessage msg)
     {  
         IConstructionCallMessage constructCallMsg = msg as IConstructionCallMessage;  
         //构造函数 初始化  
         IConstructionReturnMessage constructionReturnMessage = this.InitializeServerObject((IConstructionCallMessage)msg);  
         RealProxy.SetStubData(this, constructionReturnMessage.ReturnValue);  

         //Console.WriteLine("Call constructor:"+constructCallMsg.MethodName);  
         //Console.WriteLine("Call constructor arg count:"+constructCallMsg.ArgCount);  

         return constructionReturnMessage;  
     }  

     public override IMessage Invoke(IMessage msg)
     {  
          
          
         #region  获取AdviceType  
         AdviceType type = AdviceType.None;  
         IMethodCallMessage call = (IMethodCallMessage)msg;             
         foreach (Attribute attr in call.MethodBase.GetCustomAttributes(false))  
         {  
             MethodAopAdviceAttribute mehodAopAttr = attr as MethodAopAdviceAttribute;  
             if (mehodAopAttr != null)  
             {  
                 type=mehodAopAttr.AdviceType;  
                 break;  
             }  
         }  
         #endregion  
         IMessage message;           
           
          
         if (type==AdviceType.Before || type==AdviceType.Around)  
         {  
             this.PreProcess(msg);   
             Console.WriteLine("::Before Or Around");  
         }  
         message=this.Proessed(msg);  
         if (type==AdviceType.After || type==AdviceType.Around)  
         {
                 this.PostProcess(msg, message);
                 Console.WriteLine("::After Or Around");
             }  

         return message;  
     }  
 }  
}
