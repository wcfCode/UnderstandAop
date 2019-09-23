using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
   public interface IOrderProcessorProxy
    {
        void Submit(OrderModel order);
    } 
}
