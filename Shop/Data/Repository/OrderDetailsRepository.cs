using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrderDetailsRepository : IOrderDetails
    {
        private AppDbContent appDbContent;

        public OrderDetailsRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<OrderDetails> AllOrderDetails => appDbContent.OrderDetails.Include(c => c.order).Include(c => c.book);

        public IEnumerable<OrderDetails> GetNewOrder => appDbContent.OrderDetails.Where(p => p.status == false).Include(c => c.order).Include(c => c.book);

        public OrderDetails GetObjectOrderDetails(int odId) => appDbContent.OrderDetails.FirstOrDefault(c => c.id == odId);

    }
}
