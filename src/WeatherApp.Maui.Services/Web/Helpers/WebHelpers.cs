namespace Poc.Maui.Services.Web.Helpers;

public static class WebHelpers
{
    public static void SetAuthToken(this HttpClient client, string accessToken)
    {
        client.DefaultRequestHeaders.Remove("Authorization");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
    }
}
