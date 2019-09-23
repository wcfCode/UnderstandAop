using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandAop5
{
    public interface IUserProcessor
    {
        void RegUser();
    }

    public class UserProcessor : IUserProcessor
    {
        public virtual void RegUser()
        {
            Console.WriteLine("用户已注册。Name:{0},PassWord:{1}");
        }

        public virtual void Submit66666666666666()
        {
            Console.WriteLine("用户已注册。Name:{0},PassWord:{1}");
        }
    }
}
