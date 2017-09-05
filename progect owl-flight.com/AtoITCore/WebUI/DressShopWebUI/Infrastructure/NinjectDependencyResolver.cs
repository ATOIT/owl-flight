using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Abstrac;
using Domain.Concrete;
using DressShopWebUI.Infrastructure.Abstract;
using DressShopWebUI.Infrastructure.Concrete;
using Ninject;

namespace DressShopWebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IProductRepository>().To<EfProductRepository>();
            _kernel.Bind<ISliderRepository>().To<EfSliderRepository>();
            _kernel.Bind<IOrderRepository>().To<EfOrderRepository>();
            _kernel.Bind<IEmailSending>().To<EmailSending>();
            _kernel.Bind<IAuthProvider>().To<FormAuthProvider>();
        }
    }
}