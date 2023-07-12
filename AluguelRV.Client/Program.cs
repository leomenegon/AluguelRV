global using AluguelRV.Domain.ViewModels;
global using AluguelRV.Client.Services;
using AluguelRV.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });
builder.Services.AddScoped<RentService>();
builder.Services.AddScoped<ExpenseService>();

await builder.Build().RunAsync();