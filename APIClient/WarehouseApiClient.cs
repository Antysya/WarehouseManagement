using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Xml.Linq;
using DataModel;
using DataModel.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;


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

        //регистрация
        public async Task Register(RegisterUserRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var uri = $"{_host}/api/users/register";
            var response = await _httpClient.PostAsJsonAsync(uri, request);
            response.EnsureSuccessStatusCode();
        }

        //авторизация
        public async Task<string> Authenticate(LoginUserRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var uri = $"{_host}/api/users/login";
            var response = await _httpClient.PostAsJsonAsync(uri, request);
            response.EnsureSuccessStatusCode();
            var token = await response.Content.ReadAsStringAsync();

            return token;
        }

        //Пользователи
        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            var uri = $"{_host}/api/users/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<Users>>(uri);
            return item!;
        }

        public async Task<Users> UpdateUserAsync(Users element)
        {
            var uri = $"{_host}/api/users/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<Users>();
            return item!;
        }

        //public async Task<IEnumerable<Roles>> GetRolesAsync()
        //{
        //    var uri = $"{_host}/api/roles/get_all";
        //    var item = await _httpClient.GetFromJsonAsync<IEnumerable<Roles>>(uri);
        //    return item!;
        //}
        //public async Task<Roles> AddRolesAsync(Roles element)
        //{
        //    var uri = $"{_host}/api/roles/add";
        //    var response = await _httpClient.PostAsJsonAsync(uri, element);
        //    response.EnsureSuccessStatusCode();

        //    var item = await response.Content.ReadFromJsonAsync<Roles>();
        //    return item!;
        //}
        //public async Task<Roles> UpdateRolesAsync(Roles element)
        //{
        //    var uri = $"{_host}/api/roles/update";
        //    var response = await _httpClient.PostAsJsonAsync(uri, element);
        //    response.EnsureSuccessStatusCode();

        //    var item = await response.Content.ReadFromJsonAsync<Roles>();
        //    return item!;
        //}

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

        //Основные, просмотр, редактирование, добавление, удаление
        //Products
        public async Task<IEnumerable<Products>> GetProductsAsync()
        {
            var uri = $"{_host}/api/products/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<Products>>(uri);
            return item!;
        }
        public async Task<Products> AddProductsAsync(Products element)
        {
            var uri = $"{_host}/api/products/add";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<Products>();
            return item!;
        }
        public async Task<Products> UpdateProductsAsync(Products element)
        {
            var uri = $"{_host}/api/products/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<Products>();
            return item!;
        }

        public async Task<Products> RemoveProductsAsync(Products element)
        {
            var uri = $"{_host}/api/products/remove";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<Products>();
            return item!;
        }

        //ProductsInOrders
        public async Task<IEnumerable<ProductsInOrders>> GetProductsInOrdersAsync()
        {
            var uri = $"{_host}/api/products-in-orders/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<ProductsInOrders>>(uri);
            return item!;
        }
        public async Task<ProductsInOrders> AddProductsInOrdersAsync(ProductsInOrders element)
        {
            var uri = $"{_host}/api/products-in-orders/add";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductsInOrders>();
            return item!;
        }
        public async Task<ProductsInOrders> UpdateProductsInOrdersAsync(ProductsInOrders element)
        {
            var uri = $"{_host}/api/products-in-orders/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductsInOrders>();
            return item!;
        }

        public async Task<ProductsInOrders> RemoveProductsInOrdersAsync(ProductsInOrders element)
        {
            var uri = $"{_host}/api/products-in-orders/remove";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductsInOrders>();
            return item!;
        }

        //ProductsOnShelves
        public async Task<IEnumerable<ProductsOnShelves>> GetProductsOnShelvesAsync()
        {
            var uri = $"{_host}/api/products-on-shelves/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<ProductsOnShelves>>(uri);
            return item!;
        }
        public async Task<ProductsOnShelves> AddProductsOnShelvesAsync(ProductsOnShelves element)
        {
            var uri = $"{_host}/api/products-on-shelves/add";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductsOnShelves>();
            return item!;
        }
        public async Task<ProductsOnShelves> UpdateProductsOnShelvesAsync(ProductsOnShelves element)
        {
            var uri = $"{_host}/api/products-on-shelves/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductsOnShelves>();
            return item!;
        }

        public async Task<ProductsOnShelves> RemoveProductsOnShelvesAsync(ProductsOnShelves element)
        {
            var uri = $"{_host}/api/products-on-shelves/remove";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<ProductsOnShelves>();
            return item!;
        }

        //Orders
        public async Task<IEnumerable<Orders>> GetOrdersAsync()
        {
            var uri = $"{_host}/api/orders/get_all";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<Orders>>(uri);
            return item!;
        }
        public async Task<Orders> AddProductsOnShelvesAsync(Orders element)
        {
            var uri = $"{_host}/api/orders/add";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<Orders>();
            return item!;
        }
        public async Task<Orders> UpdateOrdersAsync(Orders element)
        {
            var uri = $"{_host}/api/orders/update";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<Orders>();
            return item!;
        }

        public async Task<Orders> RemoveOrdersAsync(Orders element)
        {
            var uri = $"{_host}/api/orders/remove";
            var response = await _httpClient.PostAsJsonAsync(uri, element);
            response.EnsureSuccessStatusCode();

            var item = await response.Content.ReadFromJsonAsync<Orders>();
            return item!;
        }

        //Заказ отчет
        public async Task<IEnumerable<OrderReport>> GetReportOrders(string order)
        {
            var uri = $"{_host}/api/reports/get?name={order}";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<OrderReport>>(uri);
            return item!;
        }

        //Пополнить отчет
        public async Task<IEnumerable<ReplenishReport>> GetReplenishReport()
        {
            var uri = $"{_host}/api/reports/replenish";
            var item = await _httpClient.GetFromJsonAsync<IEnumerable<ReplenishReport>>(uri);
            return item!;
        }
    }
}
