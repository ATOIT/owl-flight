using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public class Order
    {

        [Display(Name = "Им'я")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Довжина від 3 до 20 символів")]
        [Required(ErrorMessage = "Будь ласка, вкажіть Ваше им'я")]
        public string ClientName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Вкажіть Ваш E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Не коректний E-mail")]
        public string Email { get; set; }

        [Display(Name = "Доставка")]
        [Required(ErrorMessage = "Вы не обрали спосіб доставки")]
        public string Delivery { get; set; }

        [Display(Name = "Оплата")]
        [Required(ErrorMessage = "Вы не обрали спосіб оплати")]
        public string Payment { get; set; }

        [Display(Name = "Адреса")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Вкажіть адрессу (від 3 до 500 символів)")]
        public string Address { get; set; }

        [Display(Name = "Телефон")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Не коректний номер телефону!")]
        public string Phone { get; set; }

        [Display(Name = "Комментарій")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Довжина коментарія від 3 до 500 символів")]
        public string Сomment { get; set; }
        [Display(Name = "Дата заказа")]
        [Required]
        public DateTime DateOrder
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
               value = DateOrder ;
            }
        }
    }
}
