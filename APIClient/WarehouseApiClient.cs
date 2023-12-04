using System.Net.Http.Json;
using System.Xml.Linq;
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

        //справочники. Можно просматривать, добавлять, отредактировать

        //OrderTypes
        public async Task<IEnumerable<OrderTypes>> GetOrderTypesAsync()
        {
            var uri = $"{_host}/api/order-type/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<OrderTypes>>(uri);
            return item!;
        }
        public async Task<OrderTypes> AddOrderTypesAsync(OrderTypes element)
        {
            var uri = $"{_host}/api/order-type/add";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<OrderTypes>();
            return item!;
        }

        public async Task<OrderTypes> UpdateOrderTypeAsync(OrderTypes element)
        {
            var uri = $"{_host}/api/order-type/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<OrderTypes>();
            return item!;
        }

        //OrderStatuses
        public async Task<IEnumerable<OrderStatuses>> GetOrderStatusesAsync()
        {
            var uri = $"{_host}/api/order-statuses/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<OrderStatuses>>(uri);
            return item!;
        }
        public async Task<OrderStatuses> AddOrderStatusesAsync(OrderStatuses element)
        {
            var uri = $"{_host}/api/order-statuses/add";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<OrderStatuses>();
            return item!;
        }
        public async Task<OrderStatuses> UpdateOrderStatusesAsync(OrderStatuses element)
        {
            var uri = $"{_host}/api/order-statuses/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<OrderStatuses>();
            return item!;
        }

        //ProductGroup
        public async Task<IEnumerable<ProductGroup>> GetProductGroupAsync()
        {
            var uri = $"{_host}/api/product-group/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<ProductGroup>>(uri);
            return item!;
        }
        public async Task<ProductGroup> AddProductGroupAsync(ProductGroup element)
        {
            var uri = $"{_host}/api/product-group/add";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductGroup>();
            return item!;
        }
        public async Task<ProductGroup> UpdateProductGroupAsync(ProductGroup element)
        {
            var uri = $"{_host}/api/product-group/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductGroup>();
            return item!;
        }

        //ProductStatuses
        public async Task<IEnumerable<ProductStatuses>> GetProductStatusesAsync()
        {
            var uri = $"{_host}/api/product-statuses/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<ProductStatuses>>(uri);
            return item!;
        }
        public async Task<ProductStatuses> AddProductStatusesAsync(ProductStatuses element)
        {
            var uri = $"{_host}/api/product-statuses/add";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductStatuses>();
            return item!;
        }
        public async Task<ProductStatuses> UpdateProductStatusesAsync(ProductStatuses element)
        {
            var uri = $"{_host}/api/product-statuses/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductStatuses>();
            return item!;
        }

        //ProductStatusInOrder
        public async Task<IEnumerable<ProductStatusInOrder>> GetProductStatusInOrderAsync()
        {
            var uri = $"{_host}/api/product-status-in-order/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<ProductStatusInOrder>>(uri);
            return item!;
        }
        public async Task<ProductStatusInOrder> AddProductStatusInOrderAsync(ProductStatusInOrder element)
        {
            var uri = $"{_host}/api/product-status-in-order/add";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductStatusInOrder>();
            return item!;
        }
        public async Task<ProductStatusInOrder> UpdateProductStatusInOrderAsync(ProductStatusInOrder element)
        {
            var uri = $"{_host}/api/product-status-in-order/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductStatusInOrder>();
            return item!;
        }
    }
}
