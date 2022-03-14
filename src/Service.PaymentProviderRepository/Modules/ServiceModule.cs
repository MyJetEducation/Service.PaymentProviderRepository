using Autofac;
using Service.PaymentProviderRepository.Postgres.Services;

namespace Service.PaymentProviderRepository.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
	        builder.RegisterType<ProviderRepository>().AsImplementedInterfaces().SingleInstance();
        }
    }
}
