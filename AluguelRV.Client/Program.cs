global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Authorization;
global using AluguelRV.Shared.ViewModels;
global using AluguelRV.Client.Services;
global using Blazored.LocalStorage;
using AluguelRV.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });

builder.Services.AddScoped<RentService>();
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<AuthenticationStateProvider, RVAuthProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();