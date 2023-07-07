
public class WebAPIGateway
{
    private static readonly HttpClient HttpClient;
    static WebAPIGateway() => HttpClient = new HttpClient();
    public static async Task<string> GetDataAsync(string url)
    {
        try
        {
            var response = await HttpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch
        {
            throw new Exception("Unable to get data");
        }
    }
}