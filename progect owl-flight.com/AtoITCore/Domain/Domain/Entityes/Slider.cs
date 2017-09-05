using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entityes
{
    /// <summary>
    /// Сущность для наполнения слайдера
    /// </summary>
    public class Slider
    {
        [Key]
        [ScaffoldColumn(false)]
        public int SlideId { get; set; }

        [Required]
        public string SlidePhoto { get; set; }

        [Display(Name = "Заголовок")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Заголовок повинен бути від 3 до 50 символів")]
        [Required(ErrorMessage = "Будь ласка, введіть заголовок слайду")]
        public string Name { get; set; }

        [Display(Name = "Опис сладу")]
        [Required(ErrorMessage = "Опис не може бути пустим")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Опис повинен бути від 3 до 500 символів")]
        public string SlideDescription { get; set; }

        [Display(Name = "Номер слайду")]
        [Required(ErrorMessage = "Визначте номер слайду")]
        public int Number { get; set; }
    }
}
