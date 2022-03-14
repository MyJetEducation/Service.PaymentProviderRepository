using System;
using System.Linq;
using System.Threading.Tasks;
using Service.Core.Client.Extensions;
using Service.PaymentProviderRepository.Grpc;
using Service.PaymentProviderRepository.Grpc.Models;
using Service.PaymentProviderRepository.Postgres.Models;
using Service.PaymentProviderRepository.Postgres.Services;

namespace Service.PaymentProviderRepository.Services
{
	public class PaymentProviderRepositoryService : IPaymentProviderRepositoryService
	{
		private readonly IProviderRepository _providerRepository;

		public PaymentProviderRepositoryService(IProviderRepository providerRepository) => _providerRepository = providerRepository;

		public async Task<PaymentProvidersGrpcResponse> GetProviders()
		{
			PaymentProviderEntity[] items = await _providerRepository.GetProviders();

			return new PaymentProvidersGrpcResponse
			{
				Items = items.Select(entity => new PaymentProviderGrpcModel
				{
					Code = entity.Code,
					Weight = entity.Weight,
					KycNeeded = entity.KycNeeded == true,
					Currencies = ParseMultiple(entity.Currencies),
					RestrictedCountries = ParseMultiple(entity.RestrictedCountries),
					SupportCountries = ParseMultiple(entity.SupportCountries)
				}).ToArray()
			};
		}

		private static string[] ParseMultiple(string value) => value.IsNullOrWhiteSpace() ? Array.Empty<string>() : value.Split("|");
	}
}