using System;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entityes
{

    /// <summary>
    /// Сущьность продукта
    /// </summary>
    public class Product
    {
       
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Required]
        public string Photo { get; set; }
        
        [Display(Name = "Назва товару")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Назва повинна бути від 3 до 50 символів")]
        [Required(ErrorMessage = "Будь ласка, введіть назву товара")]
        public string Name { get; set; }

        [Display(Name = "Ціна(грн)")]
        [Required(ErrorMessage = "Будь ласка, введите ціну товара")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Будь ласка, введіть коректную ціну")]
        public double Price { get; set; }

        [Display(Name = "Склад")]
        [DataType(DataType.MultilineText)]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Склад повинен бути від 3 до 250 символів")]
        public string Composition { get; set; }

        [Display(Name = "Щільність")]
        [DataType(DataType.MultilineText)]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Щільність від 3 до 250 символів")]
        public string Density { get; set; }

        [Display(Name = "Країна-виробник")]
        [DataType(DataType.MultilineText)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Назва від 3 до 50 символів")]
        public string Producer { get; set; }
        
        [Display(Name = "Опис")]
        [DataType(DataType.MultilineText)]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Опис повинен бути від 3 до 250 символів")]
        public string Description { get; set; }

        [Display(Name = "Стиль")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Назва стилю від 3 до 50 символів")]
        public string Style { get; set; }

        [Display(Name = "Дата додавання товару")]
        [Required]
        public DateTime DateCreate { get; set; }

        [Display(Name = "S")]
        [Required]
        public bool S { get; set; }

        [Display(Name = "M")]
        [Required]
        public bool M { get; set; }

        [Display(Name = "L")]
        [Required]
        public bool L { get; set; }

        [Display(Name = "XL")]
        [Required]
        public bool Xl { get; set; }

        [Display(Name = "XXL")]
        [Required]
        public bool Xxl { get; set; }

        [Display(Name = "3XL")]
        [Required]
        public bool Xl3 { get; set; }

        [Display(Name = "4XL")]
        [Required]
        public bool Xl4 { get; set; }

        [Display(Name = "Оберіть розмір")]
        [Required(ErrorMessage = "Будь ласка, оберіть розмір футболки")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Будь ласка, оберіть розмір футболки")]
        public string SelectedSize { get; set; }

    }
}
