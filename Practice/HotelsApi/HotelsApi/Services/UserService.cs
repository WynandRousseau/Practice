using HotelsApi.Models;
using Newtonsoft.Json;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<List<User>> GetUsersAsync()
    {
        var response = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users");
        return JsonConvert.DeserializeObject<List<User>>(response);
    }
}
