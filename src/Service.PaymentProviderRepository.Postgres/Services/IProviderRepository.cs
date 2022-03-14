using Service.PaymentProviderRepository.Postgres.Models;

namespace Service.PaymentProviderRepository.Postgres.Services
{
	public interface IProviderRepository
	{
		ValueTask<PaymentProviderEntity[]> GetProviders();
	}
}