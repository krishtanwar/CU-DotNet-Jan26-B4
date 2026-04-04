using Front_End.Models;

namespace Front_End.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly HttpClient _http;
        //private readonly IHttpClientFactory

        public DestinationService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<IEnumerable<Destination>>("api/destinations");
            return result;
        }
    }
}
