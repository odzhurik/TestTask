using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.DAL;
using TestTask.Models;
using TestTask.Services;

namespace TestTask.IoC
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IPageMeasurementRepository>().To<PageMeasurementRepository>();
            kernel.Bind<IRequestTime>().To<RequestTime>();
            kernel.Bind<IUrlParser>().To<UrlParser>();
        }
    }
}