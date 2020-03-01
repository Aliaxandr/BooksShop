using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class OrderDetails
    {
        public int id { get; set; }
        public int bookId { get; set; }
        public int orderId { get; set; }
        public double price { get; set; }     
        public bool status { get; set; }
        public Book book { get; set; }
        public Order order { get; set; }
    }
}
