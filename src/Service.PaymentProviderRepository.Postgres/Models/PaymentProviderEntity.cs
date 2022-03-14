namespace Service.PaymentProviderRepository.Postgres.Models
{
	public class PaymentProviderEntity
	{
		public int? Id { get; set; }

		public string Code { get; set; }

		public int Weight { get; set; }

		public bool? Disabled { get; set; }

		public string Currencies { get; set; }

		public string SupportCountries { get; set; }

		public string RestrictedCountries { get; set; }

		public bool? KycNeeded { get; set; }
	}
}