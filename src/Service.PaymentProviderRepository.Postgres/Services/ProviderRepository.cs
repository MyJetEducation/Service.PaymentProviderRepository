using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.PaymentProviderRepository.Postgres.Models;

namespace Service.PaymentProviderRepository.Postgres.Services
{
	public class ProviderRepository : IProviderRepository
	{
		private readonly DbContextOptionsBuilder<DatabaseContext> _dbContextOptionsBuilder;
		private readonly ILogger<ProviderRepository> _logger;

		public ProviderRepository(DbContextOptionsBuilder<DatabaseContext> dbContextOptionsBuilder, ILogger<ProviderRepository> logger)
		{
			_dbContextOptionsBuilder = dbContextOptionsBuilder;
			_logger = logger;
		}

		public async ValueTask<PaymentProviderEntity[]> GetProviders()
		{
			DatabaseContext context = GetContext();

			try
			{
				return await context
					.PaymentProviders
					.Where(entity => entity.Disabled == null)
					.ToArrayAsync();
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, exception.Message);
			}

			return await ValueTask.FromResult<PaymentProviderEntity[]>(null);
		}

		private DatabaseContext GetContext() => DatabaseContext.Create(_dbContextOptionsBuilder);
	}
}