using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Service.PaymentProviderRepository.Grpc;
using Service.Grpc;

namespace Service.PaymentProviderRepository.Client
{
    [UsedImplicitly]
    public class PaymentProviderRepositoryClientFactory : GrpcClientFactory
    {
        public PaymentProviderRepositoryClientFactory(string grpcServiceUrl, ILogger logger) : base(grpcServiceUrl, logger)
        {
        }

        public IGrpcServiceProxy<IPaymentProviderRepositoryService> GetPaymentProviderRepositoryService() => CreateGrpcService<IPaymentProviderRepositoryService>();
    }
}
