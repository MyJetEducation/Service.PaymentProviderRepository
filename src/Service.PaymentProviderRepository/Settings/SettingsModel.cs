using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.PaymentProviderRepository.Settings
{
    public class SettingsModel
    {
        [YamlProperty("PaymentProviderRepository.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("PaymentProviderRepository.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("PaymentProviderRepository.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }

        [YamlProperty("PaymentProviderRepository.PostgresConnectionString")]
        public string PostgresConnectionString { get; set; }
    }
}
