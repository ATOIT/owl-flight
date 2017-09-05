using Domain.Entityes;

namespace DressShopWebUI.Models
{
    /// <summary>
    /// Сущность для привязки корзины (сессия), адреса возврата на страницу, и данных для оформления заказа
    /// </summary>
    public class BasketViewModel
    {
        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }

        //поле с сущностью для оформления покупки
        public Order Orders { get; set; }

    }
}