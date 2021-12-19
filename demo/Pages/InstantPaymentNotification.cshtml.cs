using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Extensions.Logging;

namespace PayboxHelper.Demo.Pages
{
    public class InstantPaymentNotificationModel : PageModel
    {
        private readonly ILogger<InstantPaymentNotificationModel> _logger;
        private readonly IPayboxService _paybox;

        public InstantPaymentNotificationModel(ILogger<InstantPaymentNotificationModel> logger
        , IPayboxService paybox)
        {
            _logger = logger;
            _paybox = paybox;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            //You need an HTTP tunnel to get called back by Paybox
            //I personnaly use ngrok with the following command :
            //ngrok http https://localhost:5001

            _logger.LogInformation($"Instant Payment Notification received : {HttpContext.Request.QueryString}");

            string values = HttpContext.Request.QueryString.ToString()[1..];
            string callingIp = HttpContext.Connection.RemoteIpAddress.ToString();

            var payment = new PaymentToVerify()
            {
                Values = values,
                ExpectedAmount = "10000",
                CallingIp = callingIp
            };

            try
            {
                var verifiedPayment = await _paybox.VerifyPaymentResponseAsync(payment);

                _logger.LogInformation(
                    @$"Instant Payment Notification is valid. Received values are :
                    Authorization Number : {verifiedPayment.A}
                    Paybox Reference : {verifiedPayment.S}
                    Internal Payment Reference : {verifiedPayment.R}
                    Response code : {verifiedPayment.E}"
                    );
            }
            catch (PayboxException ex)
            {
                _logger.LogError($"Instant Payment Notification verification failed. {ex.Message}");
            }


            return new OkResult();

        }
    }
}
