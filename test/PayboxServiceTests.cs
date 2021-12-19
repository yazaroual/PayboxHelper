using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Moq;

using PayboxHelper.IO;

using Xunit;

namespace PayboxHelper.Tests
{
    /// <summary>
    /// Testing the generated PBX_HMAC couldn't be done since it's based on current datetime.
    /// </summary>
    public class PayboxServiceTests
    {
        private readonly IOptions<PayboxConfigOptions> _options;
        private readonly Mock<ILogger<PayboxService>> _loggerStub;
        private readonly Mock<IFileIOWrapper> _fileIoStub;

        private PayboxService _payboxService;

        public PayboxServiceTests()
        {
            _options = GetTestConfiguration();
            _loggerStub = new Mock<ILogger<PayboxService>>();
            _fileIoStub = new Mock<IFileIOWrapper>();

            _fileIoStub.Setup(x => x.Exists(It.IsAny<string>())).Returns(true);
        }


        [Fact]
        public async void GetPaymentPageParametersAsync_Returns_ParsedResponse()
        {
            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PaymentPageParameters response = await _payboxService.GetPaymentPageParametersAsync(request);
            Assert.NotNull(response.PBX_HMAC);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_PBX_DEVISE()
        {
            _options.Value.PBX_DEVISE = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for PBX_DEVISE.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_PBX_HASH()
        {
            _options.Value.PBX_HASH = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for PBX_HASH.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_PBX_RANG()
        {
            _options.Value.PBX_RANG = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for PBX_RANG.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_PBX_SITE()
        {
            _options.Value.PBX_SITE = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for PBX_SITE.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_PBX_RETOUR()
        {
            _options.Value.PBX_RETOUR = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for PBX_RETOUR.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_ShopSecreteKey()
        {
            _options.Value.MerchantSecreteKey = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for ShopSecreteKey.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_MainServerTestUrl()
        {
            _options.Value.MainServerTestUrl = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for MainServerTestUrl.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_MainServerUrl()
        {
            _options.Value.MainServerUrl = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for MainServerUrl.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_BackupServerTestUrl()
        {
            _options.Value.BackupServerTestUrl = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for BackupServerTestUrl.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_BackupServerUrl()
        {
            _options.Value.BackupServerUrl = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for BackupServerUrl.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_PayboxServersIPsWhitelist()
        {
            _options.Value.PayboxServersIPsWhitelist = new string[1];

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide IPs for PayboxServersIPsWhitelist.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_PublicKeyAbsolutePath()
        {
            _options.Value.PublicKeyAbsolutePath = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for PublicKeyAbsolutePath.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_PBX_IDENTIFIANT()
        {
            _options.Value.PBX_IDENTIFIANT = "";

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("A configuration key is missing. Please provide a value for PBX_IDENTIFIANT.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_MissingConfig_PEMCertificateExists()
        {
            _fileIoStub.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);

            var request = GetPaymentRequest();

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("Unable to load the Paybox Public Key. Please check your PublicKeyAbsolutePath value.", exception.Message);
        }

        [Fact]
        public void GetPaymentPageParametersAsync_Throw_KIsMisplaced()
        {

            _options.Value.PBX_RETOUR = "Mt:M;Ref:R;Auto:A;RefPbx:S;Erreur:E";

            var request = GetPaymentRequest();
            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.GetPaymentPageParametersAsync(request)).Result;
            Assert.Equal("K data value should be declared last on PBX_RETOUR config property.", exception.Message);
        }

        [Fact]
        public async void VerifyPaymentResponseAsync_Verify_Success()
        {
            _fileIoStub.Setup(x => x.ReadAllTextAsync(It.IsAny<string>()).Result).Returns(
                @"-----BEGIN PUBLIC KEY-----
                MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCx0IFCxQo9zMs9u9h01utAnMNq
                MvmT7OFJv3ewUeV7t86fJRllZsmtsAw0W0SfqIlXi0hPKT4ANAwivNk25VeR4eI6
                QAunQgEbkPws6HRktSpD924QdZ4uRwNPsbh4pvM8Uslezjnr35lqvt0jHAh7Uiz8
                SwCfxY0GRW2N6pBzWwIDAQAB
                -----END PUBLIC KEY-----"
            );

            var payment = GetPaymentToVerify();
            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);


            PaymentResponse response = await _payboxService.VerifyPaymentResponseAsync(payment);
            Assert.Equal("00000", response.E);

        }

        [Fact]
        public void VerifyPaymentResponseAsync_Throw_UnauthorizedIP()
        {

            var payment = GetPaymentToVerify();
            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);

            payment.CallingIp = "127.0.0.1";

            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.VerifyPaymentResponseAsync(payment)).Result;
            Assert.Equal($"The Paybox response comes from an unauthorized server. Check the IPs whitelist in the config file. Calling IP : {payment.CallingIp}", exception.Message);
        }

        [Fact]
        public void VerifyPaymentResponseAsync_Throw_WrongSignature()
        {
            _fileIoStub.Setup(x => x.ReadAllTextAsync(It.IsAny<string>()).Result).Returns(
                @"-----BEGIN PUBLIC KEY-----
                MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCx0IFCxQo9zMs9u9h01utAnMNq
                MvmT7OFJv3ewUeV7t86fJRllZsmtsAw0W0SfqIlXi0hPKT4ANAwivNk25VeR4eI6
                QAunQgEbkPws6HRktSpD924QdZ4uRwNPsbh4pvM8Uslezjnr35lqvt0jHAh7Uiz8
                SwCfxY0GRW2N6pBzWwIDAQAB
                -----END PUBLIC KEY-----"
            );

            var payment = GetPaymentToVerify();
            string changedValues = "Mt=1000&Ref=" + "FakeRefXXX" + "&Auto=XXXXXX&RefPbx=1111&Erreur=00000&sign=WW9EkzwKh%2FC%2F6yI1UdWUd3l1b2Qq9Plx9HQXTfBq%2BcU%2FkfRfpRvDCBZjX2ckOdbeFAb2mqeGMlYrwt9OOBk4eD3w5pdZamfJ3%2BfG7R19ePdDP0NZYe8Lgvk5o5jj6C7P8adBwK2BkH6zR8TTw0e%2FyXSPPFTdKLAWNIggWyKoEUw%3D";
            payment.Values = changedValues;

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);


            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.VerifyPaymentResponseAsync(payment)).Result;
            Assert.StartsWith($"Response signature and values does not match.", exception.Message);
        }

        [Fact]
        public void VerifyPaymentResponseAsync_Throw_WrongAmount()
        {
            _fileIoStub.Setup(x => x.ReadAllTextAsync(It.IsAny<string>()).Result).Returns(
                @"-----BEGIN PUBLIC KEY-----
                MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCx0IFCxQo9zMs9u9h01utAnMNq
                MvmT7OFJv3ewUeV7t86fJRllZsmtsAw0W0SfqIlXi0hPKT4ANAwivNk25VeR4eI6
                QAunQgEbkPws6HRktSpD924QdZ4uRwNPsbh4pvM8Uslezjnr35lqvt0jHAh7Uiz8
                SwCfxY0GRW2N6pBzWwIDAQAB
                -----END PUBLIC KEY-----"
            );

            var payment = GetPaymentToVerify();
            payment.ExpectedAmount = "1";

            _payboxService = new PayboxService(
                _options,
                _loggerStub.Object,
                _fileIoStub.Object);


            PayboxException exception = Assert.ThrowsAsync<PayboxException>(async () => await _payboxService.VerifyPaymentResponseAsync(payment)).Result;
            Assert.StartsWith($"Verifying values failed.", exception.Message);
        }

        private static PaymentRequest GetPaymentRequest()
        {
            return new PaymentRequest()
            {
                TransactionId = "XXXX",
                CustomerEmail = "MyMail",
                PaymentAmount = "10000"
            };

        }

        private static PaymentToVerify GetPaymentToVerify()
        {
            //Signature was generated using the test protocol described in chapter § 5.3.4.1 - Verifone Signature
            //A local certificate was used
            return new PaymentToVerify()
            {
                CallingIp = "195.101.99.73",
                Values = "Mt=1000&Ref=2222&Auto=XXXXXX&RefPbx=1111&Erreur=00000&sign=CX7B1oSK%2FfGq%2FabJwDtrTqr14rz5R5%2BseHY1eIerrnXyLxQoS1R4T2A2%2FX7A3v8SjLtUu%2FRLuFCpCKyC30cUrbaz1fLWC3Uuz834B%2BevQld1ZdnAVhwhmGyLp2%2BBuFAHdw3QqwwTJuJlXHVtsoabuE7%2FxMch%2B5mEnLCBeiPoTBk%3D",
                ExpectedAmount = "1000"
            };
        }
        private static IOptions<PayboxConfigOptions> GetTestConfiguration()
        {
            //PBX_SITE, PBX_RANG, PBX_IDENTIFIANT and MerchantSecretKey are all taken from the Test Parameters V8.1 document
            //available in the paybox documentation website
            PayboxConfigOptions options = new();
            options.MainServerUrl = "https://preprod-tpeweb.paybox.com/cgi/MYchoix_pagepaiement.cgi";
            options.MainServerTestUrl = "https://preprod-tpeweb.paybox.com/load.html";
            options.BackupServerUrl = "https://preprod-tpeweb.paybox.com/cgi/MYchoix_pagepaiement.cgi";
            options.BackupServerTestUrl = "https://preprod-tpeweb.paybox.com/load.html";
            options.PBX_SITE = "1999888";
            options.PBX_RANG = "32";
            options.PBX_IDENTIFIANT = "110647233";
            options.PBX_DEVISE = "978";
            options.PBX_RETOUR = "Mt:M;Ref:R;Auto:A;RefPbx:S;Erreur:E;Sign:K";
            options.PBX_REPONDRE_A = "https://localhost/PaymentAutoResponse";
            options.PBX_EFFECTUE = "https://localhost:5001/PaymentSuccess";
            options.PBX_REFUSE = "https://localhost:5001/PaymentDenied";
            options.PBX_ANNULE = "https://localhost:5001/PaymentCanceled";
            options.PBX_ATTENTE = "https://localhost:5001/PaymentPending";
            options.PBX_HASH = "SHA512";
            options.PBX_ERRORCODETEST = "";
            options.MerchantSecreteKey = "0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF";
            options.PublicKeyAbsolutePath = "/paybox/pubkey.pem";
            options.PayboxServersIPsWhitelist = new string[] { "195.101.99.73" };

            return Options.Create(options);
        }
    }
}
