using System.ComponentModel.DataAnnotations;

namespace DressShopWebUI.Models
{
    /// <summary>
    /// Модель для ввода нанных Администратора
    /// </summary>
    public class AuthenticationModel
    {

        [Required(ErrorMessage = "Неверный логин")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Неверный пароль")]
        public string Password { get; set; }
    }
}