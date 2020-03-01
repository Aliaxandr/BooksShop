using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private AppDbContent appDbContent;
        private CartItems cartItems;
        
        
        public string id { get; set; }
        public List<CartItems> shopCartItems { get; set; }

        public ShopCart(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;            
        }
        public ShopCart()
        {
            
        }

        public ShopCart(AppDbContent appDbContent, CartItems cartItems)
        {
            this.appDbContent = appDbContent;
            this.cartItems = cartItems;
        }
     

        public static ShopCart GetCart(IServiceProvider services)
        {
            // получение сессии 
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { id = shopCartId };
        }


        public void AddToCart(Book book)
        {
            

            if (appDbContent.CartItems.Any(c=>c.cartId==id) & appDbContent.CartItems.Any(s => s.bookID == book.id))
            {
                
                var item = GetShopItems();
                foreach(var el in item)
                {
                    if (el.bookID == book.id)
                    {
                        el.quantity++;
                        el.price += book.price;
                        
                    }                        
                }
            }

            else
            {
                var cartitems = new CartItems
                {
                    cartId = id,
                    name = book.name,
                    book = book,
                    quantity = 1,
                    price = book.price
                    
                };
                
                appDbContent.CartItems.Add(cartitems);
            }
            
            appDbContent.SaveChanges();            
                                                          
        }

       

        public List<CartItems> GetShopItems()
        {
            return appDbContent.CartItems.Where(c => c.cartId == id).Include(s => s.book).ToList();
        }
       
    }
}
