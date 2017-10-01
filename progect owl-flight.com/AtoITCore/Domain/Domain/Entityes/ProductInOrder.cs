using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entityes
{
  public  class ProductInOrder
    {

        [Key]
        [ScaffoldColumn(false)]
        public int ProductInOrderId { get; set; }

        [Required]
        public string ProductInOrderPhoto { get; set; }

        [Display(Name = "Назва товару")]
        [Required]
        public string ProductInOrderName { get; set; }

        [Display(Name = "Ціна(грн)")]
        [Required]
        public double ProductInOrderPrice { get; set; }

        [Display(Name = "Оберіть розмір")]
        public string ProductInOrderSize { get; set; }

        public virtual OrderDetails OrderDetails { get; set; }

    }
}
