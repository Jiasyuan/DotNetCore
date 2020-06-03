using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.MVC5MSDI.Resolver
{
    public class CoreDIDependencyResolver :IDependencyResolver
    {
        private ServiceProvider serviceProvider;

        public CoreDIDependencyResolver(ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}