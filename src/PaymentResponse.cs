namespace PayboxHelper
{
    /// <summary>
    /// A verified and parsed Paybox Payment returns.
    /// <para>Parameters that were not specified in PBX_RETOUR are set to Null.</para>
    /// </summary>
    public class PaymentResponse
    {

        /// <summary>
        /// <para>Montant de la transaction (précisé dans PBX_TOTAL).</para>
        /// <para> AMount of the transaction (given in PBX_TOTAL).</para>
        /// </summary>
        public string M { get; set; }

        /// <summary>
        /// <para> Référence commande (précisée dans PBX_CMD) : espace URL encodé </para>
        /// <para> Reference of the order (given in PBX_CMD) : space URL encoded </para>
        /// </summary>
        public string R { get; set; }

        /// <summary>
        /// <para> Numéro d’appel Paybox.</para>
        /// <para> Paybox Call Number.</para>
        /// </summary>
        public string T { get; set; }

        /// <summary>
        /// <para> A numéro d’Autorisation. </para>
        /// <para> Authorization number (reference given by the authorization center) : URL encoded</para>
        /// </summary>
        public string A { get; set; }

        /// <summary>
        /// <para> Numéro d’abonnement </para>
        /// <para> SuBscriber number (given by Verifone)</para>
        /// </summary>
        public string B { get; set; }

        /// <summary>
        /// <para> Type de Carte retenu </para>
        /// <para> Card type (cf. PBX_TYPECARTE)</para>
        /// </summary>
        public string C { get; set; }

        /// <summary>
        /// <para> Date de fin de validité de la carte du porteur. Format : AAMM </para>
        /// <para> Date of expiry of the card. Format: YYMM</para>
        /// </summary>
        public string D { get; set; }

        /// <summary>
        /// <para> Code réponse de la transaction </para>
        /// <para> Response  code  of  the  transaction </para>
        /// </summary>
        public string E { get; set; }

        /// <summary>
        /// <para> État de l’authentification du porteur vis-à-vis du programme 3-D Secure </para>
        /// <para> Status of authentication of the cardholder in 3-D Secure program</para>
        /// </summary>
        public string F { get; set; }

        /// <summary>
        /// <para> Garantie du paiement par le programme 3-D Secure. Format : O ou N </para>
        /// <para> Guarantee of the payment in 3-D Secure program. Format: O (Yes) or N (No)</para>
        /// </summary>
        public string G { get; set; }

        /// <summary>
        /// <para> Empreinte de la carte </para>
        /// <para> Card Hash</para>
        /// </summary>
        public string H { get; set; }

        /// <summary>
        /// <para> Code pays de l’adresse IP de l’internaute. Format : ISO 3166 (alphabétique) </para>
        /// <para> Country code of IP address of the cardholder. Format: ISO 3166 (alphabetical)</para>
        /// </summary>
        public string I { get; set; }

        /// <summary>
        /// <para> 2 derniers chiffres du numéro de carte du porteur </para>
        /// <para> 2 last digits of the PAN (card number)</para>
        /// </summary>
        public string J { get; set; }

        /// <summary>
        /// <para> Signature sur les variables de l’URL. Format </para>
        /// <para> Signature of the fields in the URL. Format: url-encoded</para>
        /// </summary>
        public string K { get; set; }

        /// <summary>
        /// <para> 6 premiers chiffres (« biN6 ») du numéro de carte de l’acheteur </para>
        /// <para> 6 first digits (« biN6 ») of the PAN (card number)</para>
        /// </summary>
        public string N { get; set; }

        /// <summary>
        /// <para> Enrolement du porteur au programme 3-D Secure </para>
        /// <para> Cardholder EnrOlment to the 3-D Secure program</para>
        /// </summary>
        public string O { get; set; }

        /// <summary>
        /// <para> Spécifique Cetelem : Option de paiement sélectionnée par le client </para>
        /// <para> Specific to Cetelem : Payment option chosen by the customer</para>
        /// </summary>
        public string OCetelem { get; set; }

        /// <summary>
        /// <para> Type de Paiement retenu </para>
        /// <para> Payment type (cf. PBX_TYPEPAIEMENT)</para>
        /// </summary>
        public string P { get; set; }

        /// <summary>
        /// <para> Heure de traitement de la transaction. Format : HH:MM:SS (24h) </para>
        /// <para> Transaction timestamp. Format: HH:MM:SS (24h)</para>
        /// </summary>
        public string Q { get; set; }

        /// <summary>
        /// <para> Numéro de TranSaction Paybox</para>
        /// <para> Paybox TranSaction number</para>
        /// </summary>
        public string S { get; set; }

        /// <summary>
        /// <para> Gestion des abonnements avec le traitement Paybox Direct Plus. </para>
        /// <para> Subscription management with Paybox Direct Plus.</para>
        /// </summary>
        public string U { get; set; }

        /// <summary>
        /// <para> Date de traitement de la transaction sur la plateforme Paybox. Format : JJMMAAAA </para>
        /// <para> Transaction processing date on the Verifone platform. Format: DDMMYYYY </para>
        /// </summary>
        public string W { get; set; }

        /// <summary>
        /// <para> Code paYs  de la banque émettrice de la carte. Format : ISO 3166 (alphabétique) </para>
        /// <para> Country code of the card issuer bank. Format: ISO 3166 (alphabetical)</para>
        /// </summary>
        public string Y { get; set; }

        /// <summary>
        /// <para> Index lors de l’utilisation des paiements mixtes </para>
        /// <para> Index used for mix payments (gist card associated with a complement as CB/Visa/MasterCard/Amex)</para>
        /// </summary>
        public string Z { get; set; }

        /// <summary>
        /// Get full text description of an error code.
        /// </summary>
        /// <param name="translateToEnglish">Set to true to get text in english. Default language is french.</param>
        /// <returns>Getting a "00008" error code will send you back "Incorrect expiry date."</returns>
        public string GetResponseDescription(bool translateToEnglish = false)
        {
            string description;
            if (translateToEnglish)
            {
                description = E switch
                {
                    "00000" => "Successful operation.",
                    "00001" => "Connection to the authorization center failed or an internal error occurred. In this case, it is advised to try on the backup site: tpeweb1.paybox.com.",
                    "00003" => "Paybox error. In this case, it is advised to try on the backup site: tpeweb1.paybox.com.",
                    "00004" => "Card number invalid or visual cryptogram invalid.",
                    "00006" => "Access refused or site/rank/identifier incorrect.",
                    "00008" => "Incorrect expiry date.",
                    "00009" => "Error when during subscriber creation.",
                    "00010" => "Unknown currency.",
                    "00011" => "Amount incorrect.",
                    "00015" => "Payment already done.",
                    "00016" => "Subscriber already exists (registration of a new subscriber). Value ‘U’ of PBX_RETOUR.",
                    "00021" => "Not authorized bin card. ",
                    "00029" => "Not the same card used for the first payment. Error code associated with the variable “PBX_EMPREINTE”.",
                    "00030" => "Time-out  >  15  mn  before  validation  by  the  buyer  when  the  buyer  is  on  the  page  of  payments of PAYBOX.",
                    "00033" => "Unauthorized country code of the IP address of the cardholder’s browser.",
                    "00040" => "Operation without 3DSecure authentication, blocked by the fraud filter.",
                    "00100" => "Transaction approved or successfully processed.",
                    "00101" => "Contact the card issuer.",
                    "00102" => "Contact the card issuer.",
                    "00103" => "Invalid retailer.",
                    "00104" => "Keep the card.",
                    "00105" => "Do not honor.",
                    "00107" => "Keep the card, special conditions.",
                    "00108" => "Approve after holder identification.",
                    "00112" => "Invalid transaction.",
                    "00113" => "Invalid amount.",
                    "00114" => "Invalid holder number.",
                    "00115" => "Card issuer unknown.",
                    "00117" => "Client cancellation.",
                    "00119" => "Repeat the transaction later.",
                    "00120" => "Error in reply (error in the server’s domain).",
                    "00124" => "File update not withstood.",
                    "00125" => "Impossible to situate the record in the file.",
                    "00126" => "Record duplicated, former record replaced.",
                    "00127" => "Error in ‘edit’ in file update field.",
                    "00128" => "Access to file denied.",
                    "00129" => "File update impossible.",
                    "00130" => "Error in format.",
                    "00131" => "Acquirer ID unknown",
                    "00133" => "Expired card",
                    "00134" => "Fraud suspicion",
                    "00138" => "Too many attempts at secret code.",
                    "00141" => "Lost card.",
                    "00143" => "Stolen card.",
                    "00151" => "Insufficient funds or over credit limit.",
                    "00154" => "Expiry date of the card passed.",
                    "00155" => "Error in secret code.",
                    "00156" => "Card absent from file.",
                    "00157" => "Transaction not permitted for this holder.",
                    "00158" => "Transaction forbidden at this terminal.",
                    "00159" => "Suspicion of fraud.",
                    "00160" => "Card accepter must contact purchaser.",
                    "00161" => "Amount of withdrawal past the limit.",
                    "00163" => "Security regulations not respected.",
                    "00168" => "Reply not forthcoming or received too late.",
                    "00175" => "Too many attempts at secret code.",
                    "00176" => "Holder already on stop, former record kept.",
                    "00189" => "Authentication failure.",
                    "00190" => "Temporary halt of the system.",
                    "00191" => "Card issuer not accessible.",
                    "00194" => "Request duplicated.",
                    "00196" => "System malfunctioning.",
                    "00197" => "Time of global surveillance has expired.",
                    "00198" => "server unreachable (put by the server).",
                    "00199" => "Incident initiating domain.",
                    "99999" => "Payment waiting confirmation from the issuer.",
                    _ => "Payment rejected by the authorization center. See §12.1 Response codes from the authorization center."
                };
            }
            else
            {
                description = E switch
                {
                    "00000" => "Opération réussie",
                    "00001" => "La connexion au centre d’autorisation a échoué ou une erreur interne est survenue. Dans ce cas, il est souhaitable de faire une tentative sur le site secondaire : tpeweb1.paybox.com.",
                    "00003" => "Erreur Paybox. Dans ce cas, il est souhaitable de faire une tentative sur le site secondaire FQDN tpeweb1.paybox.com.",
                    "00004" => "Numéro de porteur ou cryptogramme visuel invalide.",
                    "00006" => "Accès refusé ou site/rang/identifiant incorrect.",
                    "00008" => "Date de fin de validité incorrecte.",
                    "00009" => "Erreur de création d’un abonnement.",
                    "00010" => "Devise inconnue.",
                    "00011" => "Montant incorrect.",
                    "00015" => "Paiement déjà effectué.",
                    "00016" => "Abonné déjà existant (inscription nouvel abonné). Valeur ‘U’ de la variable PBX_RETOUR.",
                    "00021" => "Carte non autorisée.",
                    "00029" => "Carte non conforme. Code erreur renvoyé lors de la documentation de la variable « PBX_EMPREINTE ».",
                    "00030" => "Temps d’attente > 15 mn par l’internaute/acheteur au niveau de la page de paiements.",
                    "00033" => "Code pays de l’adresse IP du navigateur de l’acheteur non autorisé.",
                    "00040" => "Opération sans authentification 3-DSecure, bloquée par le filtre.",
                    "00101" => "Contacter l’émetteur de carte.",
                    "00102" => "Contacter l’émetteur de carte.",
                    "00103" => "Commerçant invalide.",
                    "00104" => "Conserver la carte.",
                    "00105" => "Ne pas honorer.",
                    "00107" => "Conserver la carte, conditions spéciales.",
                    "00108" => "Approuver après identification du porteur.",
                    "00112" => "Transaction invalide.",
                    "00113" => "Montant invalide",
                    "00114" => "Numéro de porteur invalide.",
                    "00115" => "Emetteur de carte inconnu.",
                    "00117" => "Annulation client.",
                    "00119" => "Répéter la transaction ultérieurement.",
                    "00120" => "Réponse erronée (erreur dans le domaine serveur).",
                    "00124" => "Mise à jour de fichier non supportée.",
                    "00125" => "Impossible de localiser l’enregistrement dans le fichier.",
                    "00126" => "Enregistrement dupliqué, ancien enregistrement remplacé.",
                    "00128" => "Accès interdit au fichier.",
                    "00129" => "Mise à jour de fichier impossible.",
                    "00130" => "Erreur de format.",
                    "00131" => "Identifiant de l’organisme acquéreur inconnu.",
                    "00133" => "Date de validité de la carte dépassée.",
                    "00134" => "Suspicion de fraude.",
                    "00138" => "Nombre d’essais code confidentiel dépassé.",
                    "00141" => "Carte perdue.",
                    "00143" => "Carte volée.",
                    "00151" => "Provision insuffisante ou crédit dépassé.",
                    "00154" => "Date de validité de la carte dépassée.",
                    "00155" => "Code confidentiel erroné.",
                    "00156" => "Carte absente du fichier.",
                    "00157" => "Transaction non permise à ce porteur.",
                    "00158" => "Transaction interdite au terminal.",
                    "00159" => "Suspicion de fraude.",
                    "00160" => "L’accepteur de carte doit contacter l’acquéreur.",
                    "00161" => "Dépasse la limite du montant de retrait.",
                    "00163" => "Règles de sécurité non respectées.",
                    "00168" => "Réponse non parvenue ou reçue trop tard.",
                    "00175" => "Nombre d’essais code confidentiel dépassé.",
                    "00176" => "Porteur déjà en opposition, ancien enregistrement conservé.",
                    "00177" => "Pas encore répertorié.",
                    "00182" => "CVV incorrect détecté par VISA.",
                    "00189" => "Echec de l’authentification.",
                    "00190" => "Arrêt momentané du système.",
                    "00191" => "Emetteur de cartes inaccessible.",
                    "00194" => "Demande dupliquée.",
                    "00196" => "Mauvais fonctionnement du système.",
                    "00197" => "Echéance de la temporisation de surveillance globale.",
                    "00198" => "Serveur inaccessible (positionné par le serveur).",
                    "00199" => "Incident domaine initiateur.",
                    "99999" => "Opération en attente de validation par l’émetteur du moyen de paiement",
                    _ => "Code réponse spécifique à un centre d'autorisation. Voir code associé dans la documentation."
                };
            }

            return description;
        }
    }
}