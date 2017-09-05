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

        [Display(Name = "Заказ")]
        [DataType(DataType.MultilineText)]
        public string Order { get; set; }
    }
}
