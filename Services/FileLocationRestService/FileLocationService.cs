using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace Services.FileLocationRestService
{
    public class FileLocationService : IFileLocationProvider
    {
        private readonly HttpClient _client;
        private readonly IConfiguration Configuration;
        private string _baseURL;
        private string _getMethod;

        public FileLocationService(IConfiguration configuration)
        {
            Configuration = configuration;
            _client = new HttpClient();
            _baseURL = Configuration["ApplicationSetting:RestServiceBaseUrl"];
            _getMethod = Configuration["ApplicationSetting:RestServiceGetMethod"];
            if (string.IsNullOrEmpty(_baseURL) || string.IsNullOrEmpty(_getMethod))
                throw new ArgumentException("Please make sure your params are exist.");
        }

        public async Task<IList<SourceLocations>> GetLocation()
        {
            _client.BaseAddress = new Uri(_baseURL);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("User-Agent", "unknown");

            var response = await _client.GetAsync(_getMethod);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var locations = await JsonSerializer.DeserializeAsync<Root>(responseStream);
            return locations.SourceLocations;
        }
    }
}
