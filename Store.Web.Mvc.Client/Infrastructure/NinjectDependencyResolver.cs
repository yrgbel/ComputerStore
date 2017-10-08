using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Default;
using Ninject;
using Store.Data;
using Store.Data.Contracts;
using Store.Data.Helpers;

namespace Store.Web.Mvc.Client.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
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
            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            _kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();

            _kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            _kernel.Bind<IStoreUow>().To<StoreUow>();
        }
    }
}