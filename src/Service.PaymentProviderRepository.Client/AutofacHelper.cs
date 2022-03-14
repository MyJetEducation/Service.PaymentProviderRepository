using Autofac;
using Microsoft.Extensions.Logging;
using Service.PaymentProviderRepository.Grpc;
using Service.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.PaymentProviderRepository.Client
{
    public static class AutofacHelper
    {
        public static void RegisterPaymentProviderRepositoryClient(this ContainerBuilder builder, string grpcServiceUrl, ILogger logger)
        {
            var factory = new PaymentProviderRepositoryClientFactory(grpcServiceUrl, logger);

            builder.RegisterInstance(factory.GetPaymentProviderRepositoryService()).As<IGrpcServiceProxy<IPaymentProviderRepositoryService>>().SingleInstance();
        }
    }
}
