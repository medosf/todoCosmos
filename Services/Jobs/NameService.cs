using TodoComos.Models;
using Newtonsoft.Json;


namespace TodoComos.Service
{
    public class NameService
    {
     
     private readonly HttpClient _httpClient;
     public NameService(HttpClient httpClient)
     {
        _httpClient = httpClient;  
     }

     public async Task<NameItem> GetNames(string nameQuery)
     {
        var response = await _httpClient.GetAsync($"https://api.nationalize.io/?name={nameQuery}");
        var content = await response.Content.ReadAsStringAsync();
         NameItem name = JsonConvert.DeserializeObject<NameItem>(content);
         //TODO map country Abbr to country name
         return name;
     }
    }
}