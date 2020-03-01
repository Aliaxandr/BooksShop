using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IOrders
    {
        void createOrder(Order order);

        Order GetObjectOrder(int orderid);

        IEnumerable<Order> AllOrders { get; }
    }
}
