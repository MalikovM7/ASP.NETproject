using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastrcuture;
using Microsoft.AspNetCore.Identity;
using Persistence;
using Services.Implementation.Registration;

namespace WebUI
{
    public class IoCFactory : AutofacServiceProviderFactory
    {
        public IoCFactory() 
            :base(Register)
        {

        }

        private static void Register(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceRegisterModule>();

            builder.RegisterModule<ServiceRegisterModule>();
        }
    }
}
