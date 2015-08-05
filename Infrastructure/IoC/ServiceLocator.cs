using ActionImplementation.ActionImplementation;
using InterfaceActions.Notify;
using Ninject;

namespace Infrastructure.IoC
{
     internal static class ServiceLocator
     {
          private static readonly IKernel Kernel = new StandardKernel();

          public static void RegisterAll()
          {
               Kernel.Bind<ISendNotification>().To<CallNotification>();
          }

          public static T Get<T>()
          {
               return Kernel.Get<T>();
          }
     }
} 