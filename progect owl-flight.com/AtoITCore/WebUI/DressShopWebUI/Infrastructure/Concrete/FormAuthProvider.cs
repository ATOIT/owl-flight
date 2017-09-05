using System.Web.Security;
using DressShopWebUI.Infrastructure.Abstract;

namespace DressShopWebUI.Infrastructure.Concrete
{
    public class FormAuthProvider : IAuthProvider
    {
        public  bool Authenticate(string username, string password)
        {
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
                FormsAuthentication.SetAuthCookie(username, false);
            return result;
        }
    }
}