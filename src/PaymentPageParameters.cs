using System.Text;

using PayboxHelper.Configuration;

namespace PayboxHelper
{
    /// <summary>
    /// Paybox parameters needed to call the payment page
    /// </summary>
    public class PaymentPageParameters : ConfigurablePayboxParameters
    {
        /// <summary>
        /// Url du serveur à passer dans l'action du formulaire
        /// <para>Available Paybox URL to send the URL Encoded Form</para>
        /// </summary>
        public string PayboxUrl { get; set; }
        /// <summary>
        /// Référence commande côté commerçant
        /// <para>Order reference</para>
        /// </summary>
        public string PBX_CMD { get; set; }

        /// <summary>
        /// Adresse E-mail de l’acheteur
        /// <para>E-mail address of the customer</para>
        /// </summary>
        public string PBX_PORTEUR { get; set; }

        /// <summary>
        /// Montant total de la transaction
        /// <para>Amount</para>
        /// </summary>
        public string PBX_TOTAL { get; set; }

        /// <summary>
        /// Horodatage de la transaction
        /// <para>Timestamp of the message (and of the hash) </para>
        /// </summary>
        public string PBX_TIME { get; set; }

        /// <summary>
        /// Signature calculée avec la clé secrète. Les valeurs sont calculés par ordre Alphabetique.
        /// <para>Message hash. Values are hashed by alphabetical orderd.</para>
        /// </summary>
        public string PBX_HMAC { get; set; }

        /// <summary>
        /// Return the data as a Query string in Alphabetical order.
        /// </summary>
        public string GetAsQueryString()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_1EURO_CODEEXTERNE), PBX_1EURO_CODEEXTERNE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_1EURO_DATA), PBX_1EURO_DATA);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_2MONT1), PBX_2MONT1);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_2MONT2), PBX_2MONT2);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_2MONT3), PBX_2MONT3);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_3DS), PBX_3DS);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_ANNULE), PBX_ANNULE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_ARCHIVAGE), PBX_ARCHIVAGE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_ATTENTE), PBX_ATTENTE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_AUTOSEULE), PBX_AUTOSEULE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_CK_ONLY), PBX_CK_ONLY);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_CMD), PBX_CMD);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_CODEFAMILLE), PBX_CODEFAMILLE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_DATE1), PBX_DATE1);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_DATE2), PBX_DATE2);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_DATE3), PBX_DATE3);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_DEVISE), PBX_DEVISE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_DIFF), PBX_DIFF);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_DISPLAY), PBX_DISPLAY);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_EFFECTUE), PBX_EFFECTUE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_EMPREINTE), PBX_EMPREINTE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_ENTITE), PBX_ENTITE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_ERRORCODETEST), PBX_ERRORCODETEST);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_GROUPE), PBX_GROUPE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_HASH), PBX_HASH);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_IDABT), PBX_IDABT);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_IDENTIFIANT), PBX_IDENTIFIANT);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_LANGUE), PBX_LANGUE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_MAXICHEQUE_DATA), PBX_MAXICHEQUE_DATA);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_NBCARTESKDO), PBX_NBCARTESKDO);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_NETRESERVE_DATA), PBX_NETRESERVE_DATA);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_NOM_MARCHAND), PBX_NOM_MARCHAND);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_ONEY_DATA), PBX_ONEY_DATA);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_PAYPAL_DATA), PBX_PAYPAL_DATA);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_PORTEUR), PBX_PORTEUR);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_RANG), PBX_RANG);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_REFABONNE), PBX_REFABONNE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_REFUSE), PBX_REFUSE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_REPONDRE_A), PBX_REPONDRE_A);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_RETOUR), PBX_RETOUR);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_RUF1), PBX_RUF1);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_SITE), PBX_SITE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_SOURCE), PBX_SOURCE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_TIME), PBX_TIME);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_TOTAL), PBX_TOTAL);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_TYPECARTE), PBX_TYPECARTE);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_TYPEPAIEMENT), PBX_TYPEPAIEMENT);
            queryStringBuilder.AppendAsQueryParamIfNotNull(nameof(PBX_HMAC), PBX_HMAC);

            string queryString = queryStringBuilder.ToString();

            //As AppendAsQueryParamIfNotNull adds an & at the end of each param, we need to clean the last one.
            if (queryString[^1] == '&')
            {
                queryString = queryString.Remove(queryString.Length - 1);
            }

            return queryString;
        }

        /// <summary>
        /// Returns the data as HTML Input fields to be rendered in a Form. Values are in Alphabetical order.
        /// </summary>
        public string GetAsFormValues()
        {
            var inputFieldsBuilder = new StringBuilder();
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_1EURO_CODEEXTERNE), PBX_1EURO_CODEEXTERNE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_1EURO_DATA), PBX_1EURO_DATA);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_2MONT1), PBX_2MONT1);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_2MONT2), PBX_2MONT2);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_2MONT3), PBX_2MONT3);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_3DS), PBX_3DS);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_ANNULE), PBX_ANNULE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_ARCHIVAGE), PBX_ARCHIVAGE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_ATTENTE), PBX_ATTENTE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_AUTOSEULE), PBX_AUTOSEULE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_CK_ONLY), PBX_CK_ONLY);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_CMD), PBX_CMD);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_CODEFAMILLE), PBX_CODEFAMILLE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_DATE1), PBX_DATE1);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_DATE2), PBX_DATE2);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_DATE3), PBX_DATE3);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_DEVISE), PBX_DEVISE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_DIFF), PBX_DIFF);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_DISPLAY), PBX_DISPLAY);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_EFFECTUE), PBX_EFFECTUE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_EMPREINTE), PBX_EMPREINTE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_ENTITE), PBX_ENTITE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_ERRORCODETEST), PBX_ERRORCODETEST);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_GROUPE), PBX_GROUPE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_HASH), PBX_HASH);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_IDABT), PBX_IDABT);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_IDENTIFIANT), PBX_IDENTIFIANT);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_LANGUE), PBX_LANGUE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_MAXICHEQUE_DATA), PBX_MAXICHEQUE_DATA);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_NBCARTESKDO), PBX_NBCARTESKDO);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_NETRESERVE_DATA), PBX_NETRESERVE_DATA);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_NOM_MARCHAND), PBX_NOM_MARCHAND);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_ONEY_DATA), PBX_ONEY_DATA);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_PAYPAL_DATA), PBX_PAYPAL_DATA);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_PORTEUR), PBX_PORTEUR);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_RANG), PBX_RANG);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_REFABONNE), PBX_REFABONNE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_REFUSE), PBX_REFUSE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_REPONDRE_A), PBX_REPONDRE_A);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_RETOUR), PBX_RETOUR);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_RUF1), PBX_RUF1);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_SITE), PBX_SITE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_SOURCE), PBX_SOURCE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_TIME), PBX_TIME);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_TOTAL), PBX_TOTAL);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_TYPECARTE), PBX_TYPECARTE);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_TYPEPAIEMENT), PBX_TYPEPAIEMENT);
            inputFieldsBuilder.AppendAsFormValueIfNotNull(nameof(PBX_HMAC), PBX_HMAC);

            return inputFieldsBuilder.ToString();
        }
    }
}