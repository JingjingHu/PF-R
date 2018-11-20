/// <summary>
/// API Request to get the payment method create url on PayFabric Receivables
/// </summary>
/// <param name="URL">URL of the PayFabric Receivables site</param>
/// <param name="tenderType">Tender type (CreditCard/ECheck)</param>
/// <param name="currencyCode">Currency code object to get</param>
/// <param name="token">PayFabric Receivables token object</param>
/// <param name="paymentMethods">Returned payment method object</param>
public void GetPaymentMethodsCreateURL(string URL, string tenderType, string currencyCode, Token token, ref string walletUrl)
{
	// Sample request and response
	// ------------------------------------------------------
	// Go to https://github.com/NodusTechnologies/ePay-Advantage/blob/master/Sections/Cloud%20API%20Guide/Sections/APIs/API/PaymentMethods.md for more details about request and response.
	// Go to https://github.com/NodusTechnologies/ePay-Advantage/blob/master/Sections/Cloud%20API%20Guide/Sections/Objects/PaymentMethods.md for more details about the object.
	// ------------------------------------------------------
	
	var client = new RestClient(URL + "API/paymentmethods/" + tenderType + "/url?currencycode=" + currencyCode);
	var request = new RestRequest(Method.GET);
	request.AddHeader("content-type", "application/json");
	request.AddHeader("authorization", "Bearer " + token.access_token);
	IRestResponse response = client.Execute(request);

	if (response.StatusCode == System.Net.HttpStatusCode.OK)
	{
		try
		{
			JsonDeserializer deserial = new JsonDeserializer();
			walletUrl = deserial.Deserialize<string>(response);
		}
		catch
		{
			walletUrl = null;
		}
	}
	else
		walletUrl = null;
}