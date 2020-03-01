using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewsModels
{
    public class OrderDetailsViewModels
    {
        public IEnumerable<OrderDetails> allOrderDetails { get; set; }
        public IEnumerable<OrderDetails> getNewOrder { get; set; }
    }
}
