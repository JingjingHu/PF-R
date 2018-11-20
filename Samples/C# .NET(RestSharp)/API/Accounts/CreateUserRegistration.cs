/// <summary>
/// API Request to create a customer's registration key on PayFabric Receivables
/// </summary>
/// <param name="json">JSON string to be sent</param>
/// <param name="URL">URL of the PayFabric Receivables site</param>
/// <param name="token">PayFabric Receivables token object</param>
/// <param name="responses">Returned response object</param>
public void CreateUsers(string json, string URL, Token token, ref RegistrationResponse responses)
{
	// Sample request and response
	// ------------------------------------------------------
	// Go to https://github.com/NodusTechnologies/ePay-Advantage/blob/master/Sections/Cloud%20API%20Guide/Sections/APIs/API/Accounts.md for more details about request and response.
	// Go to https://github.com/NodusTechnologies/ePay-Advantage/blob/master/Sections/Cloud%20API%20Guide/Sections/Objects/Accounts.md for more details about the object.
	// ------------------------------------------------------
	
	var client = new RestClient(URL + "API/users/registration");
	var request = new RestRequest(Method.POST);
	request.AddHeader("content-type", "application/json");
	request.AddHeader("authorization", "Bearer " + token.access_token);
	request.AddParameter("application/json", json, ParameterType.RequestBody);
	IRestResponse response = client.Execute(request);

	if (response.StatusCode == System.Net.HttpStatusCode.OK)
	{
		try
		{
			JsonDeserializer deserial = new JsonDeserializer();
			responses = deserial.Deserialize<RegistrationResponse>(response);
		}
		catch
		{
			responses.Message = "Token validation failed";
			responses.RegistrationKey = "00000000-0000-0000-0000-000000000000";
		}
	}
	else
	{
		responses.Message = "Bad HTTP Request";
		responses.RegistrationKey = "00000000-0000-0000-0000-000000000000";
	}
}