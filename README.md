# PayboxHelper
Integrate Paybox System faster into your .Net project

## What is Paybox System ?
Paybox is a payment system provided by Verifone. It displays a payment page and handles the usual payment checks.

Further informations can be found in their website : [Paybox Sytem](https://www1.paybox.com/espace-integrateur-documentation/page-de-paiement-en-redirection-paybox-system/?lang=en)

## What is Paybox Helper ?

Paybox Helper is a .Net library that will help you :
* Load Paybox configs from your config file
* Check that your config is correct
* Sign payment request
* Provide a helper to build an URL Encode form that will be sent to Paybox
* Verify response signature and data
* Get a full text description of the Response Code parameter (E)

Summaries of properties and methods are all provided in French and English.

This library was implemented using the following document : [Integration Guide for Paybox System V8.1 - FR](http://www1.paybox.com/espace-integrateur-documentation/manuels/)

## How to implement Paybox Helper ?

Start by taking a look at the demo project in this repository. Now, here are the steps you need to follow once you add this library to your project

### To Call Paybox System

1. Add a `PayboxSettings` section in your config file. This section must contain your dev or prod settings.

Here is a basic appsettings.json section with mandatory values and some optionnal ones :

```json
  "PayboxSettings": {
    "MainServerUrl": "https://preprod-tpeweb.paybox.com/cgi/MYchoix_pagepaiement.cgi",
    "MainServerTestUrl": "https://preprod-tpeweb.paybox.com/load.html",
    "BackupServerUrl": "https://preprod-tpeweb.paybox.com/cgi/MYchoix_pagepaiement.cgi",
    "BackupServerTestUrl": "https://preprod-tpeweb.paybox.com/load.html",
    "PBX_SITE": "YOUR_PBX_SITE",
    "PBX_RANG": "YOUR_PBX_RANG",
    "PBX_IDENTIFIANT": "YOUR_PBX_ID",
    "PBX_DEVISE": "978",
    "PBX_RETOUR": "Mt:M;Ref:R;Auto:A;RefPbx:S;Erreur:E;sign:K",
    "PBX_REPONDRE_A": "https://localhost:5001/InstantPaymentNotification",
    "PBX_EFFECTUE": "https://localhost:5001/PaymentConfirmation",
    "PBX_ANNULE": "https://localhost:5001/Index",
    "PBX_REFUSE": "https://localhost:5001/PaymentConfirmation",
    "PBX_ATTENTE": "https://localhost:5001/PaymentConfirmation",
    "PBX_HASH": "SHA512",
    "PBX_ERRORCODETEST": "",
    "PBX_NOM_MARCHAND": "YOUR_SHOPE_NAME",
    "MerchantSecreteKey": "YOUR_SECRET_KEY",
    "PayboxServersIPsWhitelist": [
      "195.101.99.73",
      "::1"
    ],
    "PublicKeyAbsolutePath": "PUBLIC_KEY_PATH"
  }
```

`PayboxServersIPsWhitelist` is used to verify that the IPN is sent by an official Paybox server. IPs for production can be found in chapter *§12.6 - URLs to call and IP address*.

`PublicKeyAbsolutePath` Must be an absolute path to the Paybox Public Key. Key can be downladed from [here](http://www1.paybox.com/espace-integrateur-documentation/manuels/)

If you set an optional value to null or delete it it won't be used for building the request.
If you set a Mandatory value to null, an exception will be raised by Paybox Helper.

2. Configure Paybox helper in your startup.cs

```cs
services.AddPayboxHelper(Configuration.GetSection(PayboxConfigOptions.PayboxSettings));
```

3. From there, you can inject an `IPayboxService` object in the page/class you want to call Paybox from. See *demo/Pages/Index.cshtml*

4. Build a `PaymentRequest` object that will contain contextual data about the payment you want to make

```cs
var request = new PaymentRequest()
            {
                //Your internal reference
                TransactionId = "Ref" + new Random().Next(1, 10000),
                CustomerEmail = "user@email.com",
                //Amount of the shopping cart
                PaymentAmount = "10000"
            };
```

5. Call `_payboxService.GetPaymentPageParametersAsync(request);` If something is misconfigured or missing in your configuration file, a `PayboxException` exception will be thrown. Same if Paybox main and backup servers are unreachable. This method will also sign your request and provide it in the `PBX_HMAC` property.

> :warning: To sign values, a query string is build using each provided property in an alphabetical order !

6. Use the `PaymentPageParameters` object you got from the previous method to build your form

```html
<form method="POST" action="@Model.PaymentParams.PayboxUrl">
        @Html.Raw(@Model.PaymentParams.GetAsFormValues())
        <input type="submit" value="Go to Payment page" class="btn btn-primary">
    </form>
```

7. You should now have a button that will send your user to the Paybox Payment page !

### To verify the Instant Payment Notification (IPN)

1. As previously, you need to inject an `IPayboxService` object in the page/class that should process the response. See *demo/Pages/InstantPaymentNotification.cshtml.cs*

2. Get the Query String params and the remote IP of the request

```cs
//Remove the ? at the beggining of the Query string
string values = HttpContext.Request.QueryString.ToString()[1..];

string callingIp = HttpContext.Connection.RemoteIpAddress.ToString();

```

3. Create a `PaymentToVerify` object to contain the Query string, calling IP and the amount the customer should have paid. Paybox advises to always check the amount received by the IPN.

```cs
  var payment = new PaymentToVerify()
            {
                Values = values,
                //Must be the same value as in step 4 in 'How to call Paybox System'
                ExpectedAmount = "10000",
                CallingIp = callingIp
            };
```

If you do not provide an `ExpectedAmount` this value won't be checked and the verification will not fail. Making this value optional.

4. Call `_paybox.VerifyPaymentResponseAsync(payment);`. This method will :
* Check that the calling IP is in the configured whitelist
* Verify the signature using the Paybox Public Key.
* Verify that there is either an Authorisation OR error code provided.
* Verify that the paid amount linked to this IPN is correct. (If provided in the parameters)
* Parse the Query String to send you back an object with all the values you asked for in the `PBX_RETOUR` property.

5. Use the returned `PaymentResponse` object for your business needs. This object will contain all the available properties of `PBX_RETOUR`, see chapter *§11.1.7 - Mandatory Parameters / PBX_RETOUR*.


```cs
_logger.LogInformation(
        @$"Instant Payment Notification is valid. Received values are :
        Authorization Number : {verifiedPayment.A}
        Paybox Reference : {verifiedPayment.S}
        Internal Payment Reference : {verifiedPayment.R}
        Response code : {verifiedPayment.E}"
        );
```
You can access these properties using the same property names they use in the documentation. As seen above, `verifiedPayment.A` will give you the Authorization number, `verifiedPayment.R` will give you the payment reference you sent in `PBC_CMD`, etc. If a value was not asked for in `PBX_RETOUR` it will be set to null.

6. Using `PaymentResponse.GetResponseDescription()` method will also return you the description of the current response code.

## What's missing ?

The following features are missing :
* Getting the right response code description based on the authorization center. Right now, you can only get Mastercard/visa descriptions through `GetResponseDescription`. See chapter *§12.1 - Response codes from the authorization centers*.
* Subscription cancelation management. See Chapter *§7.4.1 - Ending of a Subscription*.
* Responsive pages URLs for smartphone users
* Secret keys will expire each year. We could add a warning when getting close to the expiration date.
* Checking that there are no forbiden charactere sent to Paybox. Accepted characters are all listed on chapter *§12.4 - Paybox Character Set*

## Something else is missing or buggy ?

Feel free to open an issue or contribute :smile: