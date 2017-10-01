using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
    public class OrderDetails : Order
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [Display(Name = "Статус заказу")]
        [Required]
        public string Status  { get; set; }

        [Display(Name = "Дата заказа")]
        [Required]
        public DateTime DateOrder { get; set; }

        public virtual ICollection<ProductInOrder> ProductInOrders { get; set; }
    }
}
