using HttpApiClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Net.Mail;
using WarehouseManagerClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient()
{
    Timeout = TimeSpan.FromSeconds(5)
});
builder.Services.AddSingleton(provider
    => new WarehouseApiClient(provider.GetRequiredService<HttpClient>(), "https://localhost:7181"));

builder.Services.AddMudServices();

await builder.Build().RunAsync();
