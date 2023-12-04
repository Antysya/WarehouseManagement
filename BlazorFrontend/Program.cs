using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WarehouseManagerClient;
using MudBlazor.Services;
using HttpApiClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient() { });
builder.Services.AddSingleton(provider
    => new WarehouseApiClient(provider.GetRequiredService<HttpClient>(), "https://localhost:7181"));
builder.Services.AddMudServices();

await builder.Build().RunAsync();
