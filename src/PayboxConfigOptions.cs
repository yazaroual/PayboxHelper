using PayboxHelper.Configuration;

namespace PayboxHelper
{
    /// <summary>
    /// Options can be binded directly from a PayboxSettings key your appsettings.json and must be injected through DI.
    /// </summary>
    public class PayboxConfigOptions : ConfigurablePayboxParameters
    {
        /// <summary>
        /// Name of the Paybox setting in appsettings.json
        /// </summary>
        public const string PayboxSettings = "PayboxSettings";

        /// <summary>
        /// Main Paybox server URL
        /// </summary>
        public string MainServerUrl { get; set; }

        /// <summary>
        /// Test endpoint for the main Paybox server URL
        /// </summary>
        public string MainServerTestUrl { get; set; }

        /// <summary>
        /// Backup Paybox server URL
        /// </summary>
        public string BackupServerUrl { get; set; }

        /// <summary>
        /// Test endpoint for the backup Paybox server
        /// </summary>
        public string BackupServerTestUrl { get; set; }

        /// <summary>
        /// Clé secréte du commerçant
        /// <para>Seller Secret Key</para>
        /// </summary>
        public string MerchantSecreteKey { get; set; }

        /// <summary>
        /// Paybox servers IPs that must be verified when a payment response is received.
        /// </summary>
        public string[] PayboxServersIPsWhitelist { get; set; }

        /// <summary>
        /// Public key absolute path
        /// As the public key can be changed at any time by Paybox, it's easier to let it be managed
        /// by the host project ratter than include it in the Paybox Helper.
        /// </summary>
        public string PublicKeyAbsolutePath { get; set; }
    }
}