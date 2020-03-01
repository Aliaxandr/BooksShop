using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewsModels
{
    public class OrderListViewsModels
    {
        public IEnumerable<Order> allOrder { get; set; }
    }
}
