using System.ComponentModel.DataAnnotations;

namespace Domain.Entityes
{
  public class ProductInOrder
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

        [Display(Name = "Розмір")]
        public string ProductInOrderSize { get; set; }

        public virtual OrderDetails OrderDetails { get; set; }

    }
}
