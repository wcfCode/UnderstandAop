using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop4
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AopAttribute : ProxyAttribute
    {
        private IAopProxyBuilder builder = null;
        public AopAttribute(Type builderType)
        {
            this.builder = (IAopProxyBuilder)Activator.CreateInstance(builderType);
        }

        public override MarshalByRefObject CreateInstance(Type serverType)
        {
            AopProxy realProxy = new AopProxy(serverType);
            return realProxy.GetTransparentProxy() as MarshalByRefObject;
        }
    }
}
