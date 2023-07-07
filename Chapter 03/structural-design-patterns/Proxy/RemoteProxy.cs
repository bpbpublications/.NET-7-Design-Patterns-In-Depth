using System;
using System.Net.Http;
using System.Threading.Tasks;

public interface IRemoteService
{
    Task<string> GetAllAsync();
    Task<string> GetAsync(int id);
}
public class RemoteProxy : IRemoteService
{
    readonly HttpClient _client;
    public RemoteProxy() => _client = new HttpClient
    {
        BaseAddress = new Uri("https://reqres.in/api")
    };
    public async Task<string> GetAsync(int id) => await (await _client.GetAsync($"/users/{id}")).Content.ReadAsStringAsync();

    public async Task<string> GetAllAsync() => await (await _client.GetAsync("/users")).Content.ReadAsStringAsync();
}