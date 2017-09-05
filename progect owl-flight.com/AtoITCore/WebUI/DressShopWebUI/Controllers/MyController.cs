using System.Web.Mvc;
using DressShopWebUI.Infrastructure.Abstract;
using DressShopWebUI.Models;

namespace DressShopWebUI.Controllers
{
    /// <summary>
    /// Контроллер для аунтификации администратора
    /// </summary>
    public class MyController : Controller
    {
        private readonly IAuthProvider _authProvider;
        public MyController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthenticationModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.Name, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("MyPanel", "Admin"));
                }
                ModelState.AddModelError("", "Неправильный логин или пароль");
                return View();
            }
            return View();
        }
    }
}
