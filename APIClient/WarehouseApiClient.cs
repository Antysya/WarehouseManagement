using System.Net.Http.Json;
using DataModel;


namespace HttpApiClient
{
    public class WarehouseApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _host;
        public WarehouseApiClient(HttpClient httpClient, string host)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                throw new ArgumentException($"'{nameof(host)}' host не может быть пустым");
            }
            if (httpClient is null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }
            _httpClient = httpClient;
            _host = host;
        }

        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
            var uri = $"{_host}/api/products";
            var products = await _httpClient.GetFromJsonAsync<IReadOnlyList<Products>>(uri);
            return products!;
        }
    }
}
