using System.Runtime.Serialization;

namespace Service.PaymentProviderRepository.Grpc.Models
{
	[DataContract]
	public class PaymentProvidersGrpcResponse
	{
		[DataMember(Order = 1)]
		public PaymentProviderGrpcModel[] Items { get; set; }
	}

	[DataContract]
	public class PaymentProviderGrpcModel
	{
		[DataMember(Order = 1)]
		public string Code { get; set; }

		[DataMember(Order = 2)]
		public int Weight { get; set; }

		[DataMember(Order = 3)]
		public string[] Currencies { get; set; }

		[DataMember(Order = 4)]
		public string[] SupportCountries { get; set; }

		[DataMember(Order = 5)]
		public string[] RestrictedCountries { get; set; }

		[DataMember(Order = 6)]
		public bool? KycNeeded { get; set; }
	}
}