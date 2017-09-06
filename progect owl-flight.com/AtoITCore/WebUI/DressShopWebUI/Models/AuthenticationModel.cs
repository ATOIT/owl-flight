using System.ComponentModel.DataAnnotations;

namespace DressShopWebUI.Models
{
    /// <summary>
    /// Модель для ввода нанных Администратора
    /// </summary>
    public class AuthenticationModel
    {

        [Required(ErrorMessage = "Невірний логін")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Невірний пароль")]
        public string Password { get; set; }
    }
}