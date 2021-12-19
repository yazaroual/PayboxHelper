using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PayboxHelper.Demo.Pages
{
    public class IndexModel : PageModel
    {

        public PaymentPageParameters PaymentParams { get; set; }
        private readonly IPayboxService _paybox;

        public IndexModel(IPayboxService paybox)
        {
            _paybox = paybox;
        }

        public async Task<IActionResult> OnGetAsync()
        {

            var request = new PaymentRequest()
            {
                TransactionId = "Ref" + new Random().Next(1, 10000),
                CustomerEmail = "myemail@junkmail.com",
                PaymentAmount = "10000"
            };

            PaymentParams = await _paybox.GetPaymentPageParametersAsync(request);
            return Page();
        }
    }
}
