using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrderRepository : IOrders
    {
        private AppDbContent _appDbContent;
        private ShopCart _shopCart;

        

        public OrderRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            _appDbContent = appDbContent;
            _shopCart = shopCart;
            
        }

        public IEnumerable<Order> AllOrders => _appDbContent.Order;
        public Order GetObjectOrder(int orderid) => _appDbContent.Order.FirstOrDefault(c => c.id == orderid);

        public void createOrder(Order order)
        {
            order.dateTime = DateTime.Now;
            _appDbContent.Order.Add(order);

            var items = _shopCart.shopCartItems;
            foreach (var el in items)
            {
                var orederDetail = new OrderDetails
                {
                    status = false,
                    bookId = el.book.id,
                    orderId = order.id,
                    price = el.book.price
                    
                    
                };

                _appDbContent.OrderDetails.Add(orederDetail);
            }
            foreach (var el in _appDbContent.CartItems)
            {
                _appDbContent.CartItems.Remove(el);
            }
            _appDbContent.SaveChanges();
        }
    }
}
