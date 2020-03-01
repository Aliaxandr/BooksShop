using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interfaces
{
    public interface IOrderDetails
    {
        IEnumerable<OrderDetails> AllOrderDetails { get; }

        IEnumerable<OrderDetails> GetNewOrder { get; }

        OrderDetails GetObjectOrderDetails(int odId);
    }
}
