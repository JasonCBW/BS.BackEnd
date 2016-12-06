using Autofac;
using Autofac.Integration.Mvc;
using BS.RepositoryIService;
using BS.RepositoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace BS.BackEnd
{
    public class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            //单个注册
            //builder.RegisterType<NewsService>().As<INewsService>().InstancePerRequest();

            //通过程序集，一次性注册所有
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(assemblys.ToArray())
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}