using System.ServiceModel;
using System.Threading.Tasks;
using Service.PaymentProviderRepository.Grpc.Models;

namespace Service.PaymentProviderRepository.Grpc
{
    [ServiceContract]
    public interface IPaymentProviderRepositoryService
    {
        [OperationContract]
        Task<PaymentProvidersGrpcResponse> GetProviders();
    }
}
