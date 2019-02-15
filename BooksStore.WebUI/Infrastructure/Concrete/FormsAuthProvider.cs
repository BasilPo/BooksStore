using BooksStore.WebUI.Infrastructure.Abstract;
using System;
using System.Linq;
using System.Web.Security;

namespace BooksStore.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider, IDisposable
    {
        EFAuthContext context = new EFAuthContext();
        public bool Authenticate(string username, string password)
        {
            var result = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return true;
            }
            return false;
        }

        public void SignOut() => FormsAuthentication.SignOut();

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                    context.Dispose();
                disposedValue = true;
            }
        }

        public void Dispose() => Dispose(true);
    }
}