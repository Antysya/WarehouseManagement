using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WarehouseManagerClient;
using MudBlazor.Services;
using HttpApiClient;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient() { });
builder.Services.AddSingleton(provider
    => new WarehouseApiClient(provider.GetRequiredService<HttpClient>(), "https://192.168.43.6:7181" /*"https://192.168.1.70:7181"*/));
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IdentityAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityAuthenticationStateProvider>();
builder.Services.AddScoped<AuthorizeApi>();

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
