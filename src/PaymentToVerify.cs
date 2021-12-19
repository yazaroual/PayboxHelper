namespace PayboxHelper
{
    /// <summary>
    /// Values needed to verify Paybox response
    /// </summary>
    public class PaymentToVerify
    {
        /// <summary>
        /// Query string of the request minus the interogation point at the start.
        /// </summary>
        public string Values { get; set; }

        /// <summary>
        /// Remote Client IP. Must be Paybox's IP
        /// </summary>
        public string CallingIp { get; set; }

        /// <summary>
        /// You can provide the amount that should have been paid for this paiement.
        /// If no value is provided, verification will not fail but it's advised to check it on your side.
        /// </summary>
        public string ExpectedAmount { get; set; }
    }
}