using BooksStore.Domain.Abstract;
using BooksStore.Domain.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Configuration;
using BooksStore.Domain.Entities;
using BooksStore.WebUI.Infrastructure.Abstract;
using BooksStore.WebUI.Infrastructure.Concrete;

namespace BooksStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        void AddBindings()
        {
            kernel.Bind<IBookRepository>().To<EFBookRepository>();
            kernel.Bind<IGenreRepository>().To<EFGenreRepository>();
            kernel.Bind<IAuthorRepository>().To<EFAuthorRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = Boolean.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("emailSettings", emailSettings);
        }

        public object GetService(Type serviceType) => kernel.TryGet(serviceType);

        public IEnumerable<object> GetServices(Type serviceType) => kernel.GetAll(serviceType);
    }
}