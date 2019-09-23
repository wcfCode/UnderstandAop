using Castle.DynamicProxy;
using Castle.DynamicProxy.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop5
{
    public class SimulateCastle
    {
        public TClass CreateClassProxy<TClass>(params Castle.DynamicProxy.IInterceptor[] interceptors) where TClass : class
        {
            return (TClass)CreateClassProxy(typeof(TClass), interceptors);
        }

        public virtual object CreateClassProxy(Type classToProxy, object[] constructorArguments, params IInterceptor[] interceptors)
        {
            //Type type = CreateClassType();
            return null;
        }

        protected Type CreateClassType(CacheKey cacheKey, Func<string, INamingScope, Type> factory)
        {
            var proxyType = factory.Invoke(name, Scope.NamingScope.SafeSubScope());

        }

    }
}
