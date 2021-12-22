using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using PayboxHelper.IO;

namespace PayboxHelper
{

    /// <summary>
    /// Paybox Service wraps all the workload necesseray to sign and verify data exchanged with Paybox.
    /// <para>Logic is based on the following documentation : PAYBOX SYSTEM – Manuel d’intégration  |  Version 8.1  |  2021-01-26</para>
    /// <para>To use the PayboxService you need to :</para>
    /// <para>1. Download Paybox Public certificate</para>
    /// <para>2. Configure your appsettings and inject the config at startup using AddPayboxHelper extension</para>
    /// <para>3. Call GetPaymentPageParametersAsync to build the payment form</para>
    /// 4. Once Paybox result is returned, call VerifyPaymentResponseAsync to verify the signature and returne a PaymentResponse object you can use on your business logic
    /// </summary>
    public class PayboxService : IPayboxService
    {
        private readonly PayboxConfigOptions _options;
        private readonly ILogger<PayboxService> _logger;
        private readonly IFileIOWrapper _fileIO;

        /// <summary>
        /// Create a PayboxService
        /// </summary>
        /// <param name="options">A PayboxConfigOptions set with your Paybox config</param>
        /// <param name="logger">Logger Instance</param>
        /// <param name="fileIO">IO Wrapper to abstract files access</param>
        public PayboxService(IOptions<PayboxConfigOptions> options,
        ILogger<PayboxService> logger,
        IFileIOWrapper fileIO)
        {
            _logger = logger;
            _options = options.Value;
            _fileIO = fileIO;
        }

        private void VerifyMandatoryConfiguration()
        {
            if (string.IsNullOrEmpty(_options.PBX_DEVISE))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for PBX_DEVISE.");
            }

            if (string.IsNullOrEmpty(_options.PBX_HASH))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for PBX_HASH.");
            }

            if (string.IsNullOrEmpty(_options.PBX_IDENTIFIANT))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for PBX_IDENTIFIANT.");
            }

            if (string.IsNullOrEmpty(_options.PBX_RANG))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for PBX_RANG.");
            }

            if (string.IsNullOrEmpty(_options.PBX_SITE))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for PBX_SITE.");
            }

            if (string.IsNullOrEmpty(_options.PBX_RETOUR))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for PBX_RETOUR.");
            }

            if (string.IsNullOrEmpty(_options.MerchantSecreteKey))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for ShopSecreteKey.");
            }

            if (string.IsNullOrEmpty(_options.MainServerTestUrl))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for MainServerTestUrl.");
            }

            if (string.IsNullOrEmpty(_options.MainServerUrl))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for MainServerUrl.");
            }

            if (string.IsNullOrEmpty(_options.BackupServerTestUrl))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for BackupServerTestUrl.");
            }

            if (string.IsNullOrEmpty(_options.BackupServerUrl))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for BackupServerUrl.");
            }

            if (_options.PayboxServersIPsWhitelist.Length == 0 || string.IsNullOrEmpty(_options.PayboxServersIPsWhitelist.FirstOrDefault()))
            {
                throw new PayboxException("A configuration key is missing. Please provide IPs for PayboxServersIPsWhitelist.");
            }

            if (string.IsNullOrEmpty(_options.PublicKeyAbsolutePath))
            {
                throw new PayboxException("A configuration key is missing. Please provide a value for PublicKeyAbsolutePath.");
            }

            if (!PEMCertificateExists())
            {
                throw new PayboxException("Unable to load the Paybox Public Key. Please check your PublicKeyAbsolutePath value.");
            }
        }

        private bool PEMCertificateExists()
        {
            return _fileIO.Exists(_options.PublicKeyAbsolutePath);
        }


        /// <summary>
        /// Prepare all the parameters needed to call Paybox payment page.
        /// </summary>
        /// <param name="request">Contains contextual data as the transaction ID, user email and payment amount.</param>
        /// <returns>A PaymentPageParameters object that can be used to build the form on your payment page.</returns>
        public async Task<PaymentPageParameters> GetPaymentPageParametersAsync(PaymentRequest request)
        {
            //Configuration is checked here instead of constructore to avoid uncatchable exception on DI.
            VerifyMandatoryConfiguration();
            _logger.LogDebug("GetPaymentPageParameters - Configuration is valid");

            var parameters = new PaymentPageParameters();

            string payboxServerUrl = await GetPayboxServerUrlAsync();

            if (string.IsNullOrEmpty(payboxServerUrl))
            {
                throw new PayboxException($"Unable to reach paybox servers. Please check your configuration values or contact Paybox customer support.");
            }
            else
            {
                _logger.LogDebug($"GetPaymentPageParameters - Paybox server URL is {payboxServerUrl}");
            }

            parameters.PBX_1EURO_CODEEXTERNE = _options.PBX_1EURO_CODEEXTERNE;
            parameters.PBX_1EURO_DATA = _options.PBX_1EURO_DATA;
            parameters.PBX_2MONT1 = _options.PBX_2MONT1;
            parameters.PBX_2MONT2 = _options.PBX_2MONT2;
            parameters.PBX_2MONT3 = _options.PBX_2MONT3;
            parameters.PBX_3DS = _options.PBX_3DS;
            parameters.PBX_ANNULE = _options.PBX_ANNULE;
            parameters.PBX_ARCHIVAGE = _options.PBX_ARCHIVAGE;
            parameters.PBX_ATTENTE = _options.PBX_ATTENTE;
            parameters.PBX_AUTOSEULE = _options.PBX_AUTOSEULE;
            parameters.PBX_CK_ONLY = _options.PBX_CK_ONLY;
            parameters.PBX_CODEFAMILLE = _options.PBX_CODEFAMILLE;
            parameters.PBX_DATE1 = _options.PBX_DATE1;
            parameters.PBX_DATE2 = _options.PBX_DATE2;
            parameters.PBX_DATE3 = _options.PBX_DATE3;
            parameters.PBX_DEVISE = _options.PBX_DEVISE;
            parameters.PBX_DIFF = _options.PBX_DIFF;
            parameters.PBX_DISPLAY = _options.PBX_DISPLAY;
            parameters.PBX_EFFECTUE = _options.PBX_EFFECTUE;
            parameters.PBX_EMPREINTE = _options.PBX_EMPREINTE;
            parameters.PBX_ENTITE = _options.PBX_ENTITE;
            parameters.PBX_ERRORCODETEST = _options.PBX_ERRORCODETEST;
            parameters.PBX_GROUPE = _options.PBX_GROUPE;
            parameters.PBX_HASH = _options.PBX_HASH;
            parameters.PBX_IDABT = _options.PBX_IDABT;
            parameters.PBX_IDENTIFIANT = _options.PBX_IDENTIFIANT;
            parameters.PBX_LANGUE = _options.PBX_LANGUE;
            parameters.PBX_MAXICHEQUE_DATA = _options.PBX_MAXICHEQUE_DATA;
            parameters.PBX_NBCARTESKDO = _options.PBX_NBCARTESKDO;
            parameters.PBX_NETRESERVE_DATA = _options.PBX_NETRESERVE_DATA;
            parameters.PBX_NOM_MARCHAND = _options.PBX_NOM_MARCHAND;
            parameters.PBX_ONEY_DATA = _options.PBX_ONEY_DATA;
            parameters.PBX_PAYPAL_DATA = _options.PBX_PAYPAL_DATA;
            parameters.PBX_RANG = _options.PBX_RANG;
            parameters.PBX_REFABONNE = _options.PBX_REFABONNE;
            parameters.PBX_REFUSE = _options.PBX_REFUSE;
            parameters.PBX_REPONDRE_A = _options.PBX_REPONDRE_A;
            parameters.PBX_RETOUR = _options.PBX_RETOUR;
            parameters.PBX_RUF1 = _options.PBX_RUF1;
            parameters.PBX_SITE = _options.PBX_SITE;
            parameters.PBX_SOURCE = _options.PBX_SOURCE;
            parameters.PBX_TYPECARTE = _options.PBX_TYPECARTE;
            parameters.PBX_TYPEPAIEMENT = _options.PBX_TYPEPAIEMENT;

            parameters.PayboxUrl = payboxServerUrl;
            parameters.PBX_CMD = request.TransactionId;
            parameters.PBX_PORTEUR = request.CustomerEmail;
            parameters.PBX_TOTAL = request.PaymentAmount;
            parameters.PBX_TIME = DateTime.Now.ToString("o");

            string contentForSignature = parameters.GetAsQueryString();

            //As described in chapter 5.3.4.1 Signature Verifone
            //K value should always be the last item specified in the return values
            if (parameters.PBX_RETOUR.Last() != 'K')
            {
                _logger.LogError("PayboxService - K data value should be declared last on PBX_RETOUR config property.");
                throw new PayboxException("K data value should be declared last on PBX_RETOUR config property.");
            }

            parameters.PBX_HMAC = SignData(contentForSignature).ToUpper();


            _logger.LogDebug($"GetPaymentPageParameters - Signing completed - Values : {contentForSignature} - Signature : {parameters.PBX_HMAC}");

            return parameters;
        }

        /// <summary>
        /// Tests availability of Paybox servers and returns the right URL.
        /// </summary>
        /// <returns>
        /// Returns Main or Backup server URL OR an empty string if both are unreachable.
        /// </returns>
        private async Task<string> GetPayboxServerUrlAsync()
        {
            bool serverIsAvailable = await ServerIsAvailableAsync(_options.MainServerTestUrl);

            if (serverIsAvailable)
            {
                return _options.MainServerUrl;
            }

            serverIsAvailable = await ServerIsAvailableAsync(_options.BackupServerTestUrl);

            if (serverIsAvailable)
            {
                return _options.BackupServerUrl;
            }

            return string.Empty;
        }

        /// <summary>
        /// Calls Paybox Server and search for an "OK" text in the returned document.
        /// </summary>
        private static async Task<bool> ServerIsAvailableAsync(string Url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(Url);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            var responseText = await response.Content.ReadAsStringAsync();
            if (responseText.Contains("OK"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private string SignData(string values)
        {
            //We had to reproduce the way PHP hashes data, Not using the FromHex methode will never produce the expected hash
            //the problems comes from PHP Pack(H* function ! when the key provided is a string it's ok but using Pack(H* to provide key give different result from C# GetBytes (probably because of internal PHP encoding)
            //Solution ici : https://stackoverflow.com/questions/12804231/c-sharp-equivalent-to-hash-hmac-in-php
            //Puis là : https://stackoverflow.com/questions/20508193/trying-to-reproduce-phps-packh-function-in-c-sharp
            var hash = new StringBuilder();
            byte[] secretkeyBytes = FromHex(_options.MerchantSecreteKey);
            byte[] inputBytes = Encoding.UTF8.GetBytes(values);
            using (var hmac = new HMACSHA512(secretkeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString().ToUpper();
        }

        private static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        /// <summary>
        /// Parses the paybox response query string, checks the signature and returns a PaymentResponse if everything is alright.
        /// </summary>
        /// <param name="payment">Contains the values necessary to verify the Paybox response</param>
        /// <returns>Returns a PaymentResponse or throws an Exception if checks fail</returns>
        public async Task<PaymentResponse> VerifyPaymentResponseAsync(PaymentToVerify payment)
        {
            //Configuration is checked here instead of constructore to avoid exception on DI.
            VerifyMandatoryConfiguration();
            _logger.LogDebug("VerifyPaymentResponse - Configuration is valid");

            PaymentResponse parsedResponse = await ParsePaymentResponseValuesAsync(payment.Values);

            if (VerifyCallingIp(payment.CallingIp))
            {
                _logger.LogDebug($"PayboxService - Calling IP found in the white liste - Calling IP : {payment.CallingIp}");
            }
            else
            {
                _logger.LogError($"PayboxService - Calling IP not found in the white liste  - Calling IP : {payment.CallingIp}");
                throw new PayboxException($"The Paybox response comes from an unauthorized server. Check the IPs whitelist in the config file. Calling IP : {payment.CallingIp}");
            }

            if (await VerifySignatureAsync(payment.Values, parsedResponse))
            {
                _logger.LogDebug($"PayboxService - Signature is legit - Signed Values : {payment.Values} - Signature : {parsedResponse.K}");

            }
            else
            {
                _logger.LogError($"PayboxService - Unable to verify Signature- Signed Values : {payment.Values} - Signature : {parsedResponse.K}");

                throw new PayboxException($"Response signature and values does not match. Signed Values : {payment.Values} - Signature : {parsedResponse.K}");
            }

            if (VerifyValues(parsedResponse, payment.ExpectedAmount))
            {
                _logger.LogDebug($"PayboxService - Values are coherente - E : {parsedResponse.E} - A : {parsedResponse.A} - Expected amount {payment.ExpectedAmount}");
            }

            return parsedResponse;
        }

        private async Task<PaymentResponse> ParsePaymentResponseValuesAsync(string values)
        {
            NameValueCollection valuesCollection = HttpUtility.ParseQueryString(values);

            //Get custom key values defined in the app config
            //This way, wathever the values were named, we can still assign them to the right property
            Dictionary<string, string> responseParams = _options.PBX_RETOUR.Split(';')
                .Select(value => value.Split(':'))
                .ToDictionary(pair => pair[1], pair => valuesCollection[pair[0]]);

            PaymentResponse response = await Task.Run(() => responseParams.ToObject<PaymentResponse>());

            return response;
        }

        private bool VerifyCallingIp(string ip)
        {
            if (_options.PayboxServersIPsWhitelist.Contains(ip))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> VerifySignatureAsync(string values, PaymentResponse parsedValues)
        {
            /*
            Signature verification :
            1. Load public PEM from  https://www1.paybox.com/wp-content/uploads/2014/03/pubkey.pem
            2. Split Query String to get only Signature
            3. URL decod the signature
            4. Convert it from Base64
            5. Verify the still encoded data using the Signature
            */

            string[] splitValues = values.Split('&');
            string valuesWithoutSignature = string.Join('&', splitValues.Take(splitValues.Length - 1));

            string publicKey = await GetPayboxPublicKeyAsync();

            var rsaCSP = new RSACryptoServiceProvider();
            rsaCSP.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out _);

            byte[] signedData = Encoding.UTF8.GetBytes(valuesWithoutSignature);
            byte[] signatureRaw = Convert.FromBase64String(parsedValues.K);
            bool dataOK = rsaCSP.VerifyData(signedData, CryptoConfig.MapNameToOID("SHA1"), signatureRaw);

            return dataOK;
        }

        private async Task<string> GetPayboxPublicKeyAsync()
        {
            var pathToFile = _options.PublicKeyAbsolutePath;

            try
            {
                string key = await _fileIO.ReadAllTextAsync(pathToFile);
                key = key.Replace("-----BEGIN PUBLIC KEY-----", "");
                key = key.Replace("-----END PUBLIC KEY-----", "");

                return key;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"GetPayboxPublicKey - Unable to Get Public key file - Path : {pathToFile} - Exception : {ex.Message}");
                throw;
            }
        }

        private static bool VerifyValues(PaymentResponse response, string expectedAmount)
        {
            //When a payment is refused A is empty
            //When a payment is accepted E is equal to 0000
            //There are no cases where A is empty and there is no returned Error codes
            if (response.E == "00000" && String.IsNullOrEmpty(response.A))
            {
                throw new PayboxException($"Verifying values failed. E is equal to 0000 (no error) but A is empty. This should not happen. Please check your raw A and E values.");
            }

            //Check that the amount returned by Paybox is the same as the one requested.
            //If Expected amount is provided
            if (!string.IsNullOrEmpty(expectedAmount) && expectedAmount != response.M)
            {
                throw new PayboxException($"Verifying values failed. Expected amount and returned amount differ. Expected amount {expectedAmount} - Returned amount {response.M} ");
            }

            return true;
        }

    }
}