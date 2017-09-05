using System.Web.Mvc;
using Domain.Entityes;

namespace DressShopWebUI.Infrastructure.Binders
{
    /// <summary>
    /// Класс - связыватель модели для сессии
    /// </summary>
    public class BasketModelBinder : IModelBinder
    {
        // ключь сессий
        private const string SessionKey = "Basket";

        /// <summary>
        /// Метод, возврашающий сущьность корзины для текущей сессии
        /// </summary>
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            // получаем сущьность корзины из сессии
            Basket basket = null;
            if (controllerContext.HttpContext.Session != null)
            {
                basket = (Basket) controllerContext.HttpContext.Session[SessionKey];
            }

            //если сущьность он не обнаружена, создаем сессию
            if (basket == null)
            {
                basket = new Basket();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = basket;
                }
            }

            return basket;

        }
    }
}


   