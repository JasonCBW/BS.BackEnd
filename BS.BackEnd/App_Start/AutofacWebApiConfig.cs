using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Reflection;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using System.Web.Compilation;

namespace BS.BackEnd
{
    public class AutofacWebApiConfig
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;

            //注册所有的Controllers(这里将MVC的控制器也放在一起进行注册)
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //注册所有的ApiControllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            //WebAPI只用引用services和repository的接口，不用引用实现的dll。
            //如需加载实现的程序集，将dll拷贝到bin目录下即可，不用引用dll
            var iServices = Assembly.Load("RepositoryIService");
            var services = Assembly.Load("RepositoryService");

            //根据名称约定（服务层的接口和实现均以Services结尾），实现服务接口和服务实现的依赖
            builder.RegisterAssemblyTypes(iServices, services)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces();

            var container = builder.Build();
            //注册api容器需要使用HttpConfiguration对象
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}