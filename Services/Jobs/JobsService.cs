using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TodoComos.Models;


namespace TodoComos.Service
{
    public class JobsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<JobsService> _logger;

        public JobsService(HttpClient httpClient, ILogger<JobsService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<string> GetJobs()
        {
            var response = await _httpClient.GetAsync("https://jobicy.com/api/v2/remote-jobs");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return content;
            }
            else
            {
                _logger.LogError("Failed to get jobs");
                return null;
            }
        }
    }
}