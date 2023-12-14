using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebServer.IRepository.Base;
using WebServer.Repository.Base;

namespace WebServer.Extensions.ServiceExtensions
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();//注册仓储

            //注册service
            var assemblysServices = Assembly.Load("WebServer.Service");
            builder.RegisterAssemblyTypes(assemblysServices)
                .InstancePerDependency()//默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
                .AsImplementedInterfaces()//是以接口方式进行注入,注入这些类的所有的公共接口作为服务（除了释放资源）
                .EnableInterfaceInterceptors();//引用Autofac.Extras.DynamicProxy;应用拦截器

            //注册Repository
            var assemblysRepository = Assembly.Load("WebServer.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository)
                .InstancePerDependency()//默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
               .AsImplementedInterfaces()//是以接口方式进行注入,注入这些类的所有的公共接口作为服务（除了释放资源）
               .EnableInterfaceInterceptors(); //引用Autofac.Extras.DynamicProxy;应用拦截器

        }
    }
}
