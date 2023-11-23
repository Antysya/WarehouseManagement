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

        public async Task<List<Products>> GetProductsAsync()
        {
            var uri = $"{_host}/api/products";
            var products = await _httpClient.GetFromJsonAsync<List<Products>>(uri);
            return products!;
        }

        public async Task<IReadOnlyList<OrderTypes>> GetOrderTypesAsync()
        {
            var uri = $"{_host}/api/order-type";
            var type = await _httpClient.GetFromJsonAsync<IReadOnlyList<OrderTypes>>(uri);
            return type!;
        }
        public async Task<IReadOnlyList<OrderStatuses>> GetOrderStatusesAsync()
        {
            var uri = $"{_host}/api/order-statuses";
            var type = await _httpClient.GetFromJsonAsync<IReadOnlyList<OrderStatuses>>(uri);
            return type!;
        }

        public async Task<IReadOnlyList<ProductGroup>> GetProductGroupAsync()
        {
            var uri = $"{_host}/api/product-group";
            var type = await _httpClient.GetFromJsonAsync<IReadOnlyList<ProductGroup>>(uri);
            return type!;
        }
        public async Task<IReadOnlyList<ProductStatuses>> GetProductStatusesAsync()
        {
            var uri = $"{_host}/api/product-status";
            var type = await _httpClient.GetFromJsonAsync<IReadOnlyList<ProductStatuses>>(uri);
            return type!;
        }
        public async Task<IReadOnlyList<ProductStatusInOrder>> GetProductStatusInOrderAsync()
        {
            var uri = $"{_host}/api/product-in-order";
            var type = await _httpClient.GetFromJsonAsync<IReadOnlyList<ProductStatusInOrder>>(uri);
            return type!;
        }
    }
}
