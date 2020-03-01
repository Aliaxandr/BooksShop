using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        public int id { get; set; }
        [MinLength(2)]        
        [Required(ErrorMessage = "Пожалуйста введите ваше имя")]
        public string name { get; set; }
        [MinLength(7)]
        [Required(ErrorMessage = "Пожалуйста введите ваш телефон")]
        public string phone { get; set; }
        [MinLength(10)]
        [Required(ErrorMessage = "Пожалуйста введите ваш адрес")]
        public string adress { get; set; }
        [MinLength(9)]
        [Required(ErrorMessage = "Пожалуйста введите ваш e-mail")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Пожалуйста введите корректный e-mail")]
        public string email { get; set; }
        public DateTime dateTime { get; set; }
        public List<OrderDetails> orderDetails { get; set; }
    }
}
