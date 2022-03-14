using Microsoft.EntityFrameworkCore;
using MyJetWallet.Sdk.Postgres;
using MyJetWallet.Sdk.Service;
using Service.PaymentProviderRepository.Postgres.Models;

namespace Service.PaymentProviderRepository.Postgres
{
	public class DatabaseContext : MyDbContext
	{
		public const string Schema = "education";
		private const string PaymentProviderRepositoryTableName = "payment_provider";

		public DatabaseContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<PaymentProviderEntity> PaymentProviders { get; set; }

		public static DatabaseContext Create(DbContextOptionsBuilder<DatabaseContext> options)
		{
			MyTelemetry.StartActivity($"Database context {Schema}")?.AddTag("db-schema", Schema);

			return new DatabaseContext(options.Options);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema(Schema);

			SetUserInfoEntityEntry(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}

		private static void SetUserInfoEntityEntry(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PaymentProviderEntity>().ToTable(PaymentProviderRepositoryTableName);

			modelBuilder.Entity<PaymentProviderEntity>().Property(e => e.Id).ValueGeneratedOnAdd();
			modelBuilder.Entity<PaymentProviderEntity>().Property(e => e.Code).IsRequired();
			modelBuilder.Entity<PaymentProviderEntity>().Property(e => e.Weight).IsRequired();
			modelBuilder.Entity<PaymentProviderEntity>().Property(e => e.Disabled);
			modelBuilder.Entity<PaymentProviderEntity>().Property(e => e.Currencies);
			modelBuilder.Entity<PaymentProviderEntity>().Property(e => e.SupportCountries);
			modelBuilder.Entity<PaymentProviderEntity>().Property(e => e.RestrictedCountries);
			modelBuilder.Entity<PaymentProviderEntity>().Property(e => e.KycNeeded);

			modelBuilder.Entity<PaymentProviderEntity>().HasKey(e => e.Id);
			modelBuilder.Entity<PaymentProviderEntity>().HasIndex(e => e.Code);
		}
	}
}