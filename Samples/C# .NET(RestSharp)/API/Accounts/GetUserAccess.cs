/// <summary>
/// API Request to verify the access code on PayFabric Receivables
/// </summary>
/// <param name="URL">URL of the PayFabric Receivables site</param>
/// <param name="accessCode">Access Code string to be retrieved</param>
/// <param name="token">PayFabric Receivables token object</param>
/// <param name="responses">Returned response object</param>
public void GetUsersByName(string URL, string accessCode, Token token, ref AccessCode access)
{
	// Sample request and response
	// ------------------------------------------------------
	// Go to https://github.com/NodusTechnologies/ePay-Advantage/blob/master/Sections/Cloud%20API%20Guide/Sections/APIs/API/Accounts.md for more details about request and response.
	// Go to https://github.com/NodusTechnologies/ePay-Advantage/blob/master/Sections/Cloud%20API%20Guide/Sections/Objects/Accounts.md for more details about the object.
	// ------------------------------------------------------
	
	var client = new RestClient(URL + "API/users/isaccessible?accessCode=" + accessCode);
	var request = new RestRequest(Method.GET);
	request.AddHeader("content-type", "application/json");
	request.AddHeader("authorization", "Bearer " + token.access_token);
	IRestResponse response = client.Execute(request);

	if (response.StatusCode == System.Net.HttpStatusCode.OK)
	{
		try
		{
			JsonDeserializer deserial = new JsonDeserializer();
			access = deserial.Deserialize<User>(response);
		}
		catch
		{
			access = null;
		}
	}
	else
	{
		access = null;
	}
}