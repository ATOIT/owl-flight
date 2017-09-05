using System.Web.Mvc;
using System.Web.Routing;
using Domain.Entityes;
using DressShopWebUI.Infrastructure.Binders;
using DressShopWebUI.Models;

namespace DressShopWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //проверка наличия записей в БД, для дебага
            DebugDb.TestDb();
            // запускаем связыватель модели, для опредиления сессий
            ModelBinders.Binders.Add(typeof(Basket), new BasketModelBinder());
        }
    }
}
