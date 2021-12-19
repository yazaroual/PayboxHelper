namespace PayboxHelper.Configuration
{
    /// <summary>
    /// Base class used to share Paybox parameters that are configurable by the host.
    /// <para>Inherited by PayboxConfigOption and PaymentPageParemters</para>
    /// </summary>
    public abstract class ConfigurablePayboxParameters
    {
        /// <summary>
        /// Données spécifique 1euro.com
        /// <para>Specific data for 1euro.com</para>
        /// </summary>
        public string PBX_1EURO_CODEEXTERNE { get; set; }

        /// <summary>
        /// Données spécifique 1euro.com
        /// <para>Specific data for 1euro.com</para>
        /// </summary>
        public string PBX_1EURO_DATA { get; set; }

        /// <summary>
        /// Paiement en plusieurs fois : Montant de la premiére échéances.
        /// <para>Several times payment : amount of terms of the first payment.</para>
        /// </summary>
        public string PBX_2MONT1 { get; set; }

        /// <summary>
        /// Paiement en plusieurs fois : Montant de la deuxiéme échéances.
        /// <para>Several times payment : amount of terms of the second payment.</para>
        /// </summary>
        public string PBX_2MONT2 { get; set; }

        /// <summary>
        /// Paiement en plusieurs fois : Montant de la troisiéme échéances.
        /// <para>Several times payment : amount of terms of the third payment.</para>
        /// </summary>
        public string PBX_2MONT3 { get; set; }

        /// <summary>
        /// Désactivation 3-D Secure ponctuelle.
        /// <para>Temporary 3-D Secure deactivation.</para>
        /// </summary>
        public string PBX_3DS { get; set; }

        /// <summary>
        /// URL de retour en cas d’abandon.
        /// <para>Callback URL in case of transaction aborted/cancelled.</para>
        /// </summary>
        public string PBX_ANNULE { get; set; }

        /// <summary>
        /// Référence archivage.
        /// <para>Archiving reference.</para>
        /// </summary>
        public string PBX_ARCHIVAGE { get; set; }

        /// <summary>
        /// URL de retour en cas de paiement en attente de validation.
        /// <para>Callback URL in cas of transaction waiting confirmation.</para>
        /// </summary>
        public string PBX_ATTENTE { get; set; }

        /// <summary>
        /// Ne pas envoyer ce paiement à la banque immédiatement.
        /// <para>Authorization only (no capture).</para>
        /// </summary>
        public string PBX_AUTOSEULE { get; set; }

        /// <summary>
        /// Forçage d’un mode de paiement Carte Cadeau uniquement (non mixte)
        /// <para>Force the payment with only gift cards.</para>
        /// </summary>
        public string PBX_CK_ONLY { get; set; }

        /// <summary>
        /// Données spécifique Cofinoga.
        /// <para>Specific data for Cofinoga.</para>
        /// </summary>
        public string PBX_CODEFAMILLE { get; set; }

        /// <summary>
        /// Paiement en plusieurs fois : Dates de la premiére échéance.
        /// <para>Several times payment : date of terms of the first payment.</para>
        /// </summary>
        public string PBX_DATE1 { get; set; }

        /// <summary>
        /// Paiement en plusieurs fois : Dates de la deuxiéme échéance.
        /// <para>Several times payment : date of terms of the second payment.</para>
        /// </summary>
        public string PBX_DATE2 { get; set; }

        /// <summary>
        /// Paiement en plusieurs fois : Dates de la troisiéme échéance.
        /// <para>Several times payment : date of terms of the third payment.</para>
        /// </summary>
        public string PBX_DATE3 { get; set; }

        /// <summary>
        /// Devise de la transaction.
        /// <para>Currency.</para>
        /// </summary>
        public string PBX_DEVISE { get; set; }

        /// <summary>
        /// Nombre de jours pour un paiement différé.
        /// <para>Number of days of shifting in case of delayed payment.</para>
        /// </summary>
        public string PBX_DIFF { get; set; }

        /// <summary>
        /// Timeout de la page de paiement.
        /// <para>Payment page Timeout.</para>
        /// </summary>
        public string PBX_DISPLAY { get; set; }

        /// <summary>
        /// URL de retour en cas de succès.
        /// <para>Callback URL in case of transaction accepted.</para>
        /// </summary>
        public string PBX_EFFECTUE { get; set; }

        /// <summary>
        /// Empreinte fournie lors d’un premier paiement.
        /// <para>Hash given after a payment.</para>
        /// </summary>
        public string PBX_EMPREINTE { get; set; }

        /// <summary>
        /// Référence numérique d’un subdivision.
        /// <para>Numeric reference for subdivision (geographical, organizational ...)</para>
        /// </summary>
        public string PBX_ENTITE { get; set; }

        /// <summary>
        /// Permet de définir un code  erreur  volontairement.
        ///<para>
        /// Attention :
        /// Ne pas la mettre à 00000, cela provoque une erreur d'authentification côté Paybox.
        /// Donc si non utilisé, garder le champs vide dans les config
        /// Un code incorrecte provoque aussi une erreur d'authentification. Par exemple
        /// si l'on met 6 caractéres au lieu de 5.
        /// </para>
        /// <para>Error code to send back (for tests)</para>
        /// </summary>
        public string PBX_ERRORCODETEST { get; set; }

        /// <summary>
        /// Groupe pour Paybox Version ++
        /// <para>Merchant group for Paybox Version ++</para>
        /// </summary>
        public string PBX_GROUPE { get; set; }

        /// <summary>
        /// Type d’algorithme de hachage pour le calcul de l’empreinte.
        /// <para>Algorithm used to calculate the HMAC hash.</para>
        /// </summary>
        public string PBX_HASH { get; set; }

        /// <summary>
        /// Numéro d’abonnement.
        /// <para>Subscription number.</para>
        /// </summary>
        public string PBX_IDABT { get; set; }

        /// <summary>
        /// Identifiant interne(fourni par Paybox).
        /// <para>Paybox identifier.</para>
        /// </summary>
        public string PBX_IDENTIFIANT { get; set; }

        /// <summary>
        /// Langue de la page de paiement.
        /// <para>Payment page language.</para>
        /// </summary>
        public string PBX_LANGUE { get; set; }

        /// <summary>
        /// Specific data for Maxichèque.
        /// <para>Donnée spécifique Maxichèque.</para>
        /// </summary>
        public string PBX_MAXICHEQUE_DATA { get; set; }

        /// <summary>
        /// Nombre max de cartes cadeau utilisables par le porteur.
        /// <para>Maximum number of gift cards for 1 payment.</para>
        /// </summary>
        public string PBX_NBCARTESKDO { get; set; }

        /// <summary>
        /// Données spécifique Net Serve.
        /// <para>Specific data for Net Serve.</para>
        /// </summary>
        public string PBX_NETRESERVE_DATA { get; set; }

        /// <summary>
        /// Nom d’Enseigne affichée sur la page de paiement.
        /// <para>Merchant name in payment page. This value is unfound in the official english documentation ...</para>
        /// </summary>
        public string PBX_NOM_MARCHAND { get; set; }

        /// <summary>
        /// Données spécifique Oney.
        /// <para>Specific data for Oney.</para>
        /// </summary>
        public string PBX_ONEY_DATA { get; set; }

        /// <summary>
        /// Données spécifique Paypal.
        /// <para>Specific data for Paypal.</para>
        /// </summary>
        public string PBX_PAYPAL_DATA { get; set; }

        /// <summary>
        /// Numéro de rang(fourni par Paybox).
        /// <para>Rank number provided by the bank.</para>
        /// </summary>
        public string PBX_RANG { get; set; }

        /// <summary>
        /// Référence de l’abonne (version Plus).
        /// <para>Subscriber reference (version Plus).</para>
        /// </summary>
        public string PBX_REFABONNE { get; set; }

        /// <summary>
        /// URL de retour en cas de refus du paiement.
        /// <para>Callback URL in case of payment rejected.</para>
        /// </summary>
        public string PBX_REFUSE { get; set; }

        /// <summary>
        ///  URL de retour automatique.
        /// <para>IPN URL.</para>
        /// </summary>
        public string PBX_REPONDRE_A { get; set; }

        /// <summary>
        /// Liste des variables à retourner par Paybox.
        /// <para>Data configuration in the answer.</para>
        /// </summary>
        public string PBX_RETOUR { get; set; }

        /// <summary>
        /// Méthode d’appel de l’URL IPN.
        /// <para>Calling method for the IPN URL.</para>
        /// </summary>
        public string PBX_RUF1 { get; set; }

        /// <summary>
        /// Numéro de site(fourni par Paybox).
        /// <para>Merchant contract number provided by the bank.</para>
        /// </summary>
        public string PBX_SITE { get; set; }

        /// <summary>
        /// Format de la page de paiement (pour paiement mobile).
        /// <para>Format of the payment page (for payment on mobile).</para>
        /// </summary>
        public string PBX_SOURCE { get; set; }

        /// <summary>
        /// Forçage du moyen de paiement.
        /// <para>Card type forcing.</para>
        /// </summary>
        public string PBX_TYPECARTE { get; set; }

        /// <summary>
        /// Forçage du moyen de paiement.
        /// <para>FPayment type forcing.</para>
        /// </summary>
        public string PBX_TYPEPAIEMENT { get; set; }
    }
}