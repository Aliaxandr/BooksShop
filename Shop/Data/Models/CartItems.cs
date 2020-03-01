using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class CartItems
    {
        public int id { get; set; }
        public int bookID { get; set; }
        public string bookImg { get; set; }
        public string name { get; set; }
        public Book book { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string cartId {get;set;}
    }
}
