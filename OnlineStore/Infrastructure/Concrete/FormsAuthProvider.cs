using System.Web.Security;
using OnlineStore.Infrastructure.Abstract;

namespace OnlineStore.Infrastructure.Concrete
{
    public class FormsAuthProvider: IAuthProvider
    {
        public bool Authenticate(string username, string password)
        {
            var result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }
    }
}