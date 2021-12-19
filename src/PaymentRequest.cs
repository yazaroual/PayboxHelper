namespace PayboxHelper
{
    /// <summary>
    /// Values necesseray to calculate the Payment properties needed by Paybox and build a PaymentPageParameters object.
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// Internal Transaction ID
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Customer Email will be used by Paybox to send the receipt
        /// </summary>
        /// <value></value>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Amount that must be charged for this payment
        /// </summary>
        /// <value>Expressed in centimes. A value of 10000 = 100 €</value>
        public string PaymentAmount { get; set; }
    }
}