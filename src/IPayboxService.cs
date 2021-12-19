using System.Threading.Tasks;

namespace PayboxHelper
{
    /// <summary>
    /// Paybox Service wraps all the workload necesseray to sign and verify data exchanged with Paybox.
    /// </summary>
    public interface IPayboxService
    {
        /// <summary>
        /// Parses the config and builds an object that will help you build the form to call the paybox payment page.
        /// Signature is also provided in PBX_HMAC
        /// </summary>
        Task<PaymentPageParameters> GetPaymentPageParametersAsync(PaymentRequest request);

        ///<summary>
        /// Parses the paybox response query string, checks the signature and returns a PaymentResponse if everything is alright.
        /// </summary>
        /// <param name="payment">Contains the values necessary to verify the Paybox response</param>
        /// <returns>Returns a PaymentResponse or throws an Exception if checks fail</returns>
        Task<PaymentResponse> VerifyPaymentResponseAsync(PaymentToVerify payment);
    }
}