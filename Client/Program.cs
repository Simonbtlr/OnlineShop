global using System.Net.Http.Json;
global using System.Net.Http.Headers;
global using System.Text.Json;
global using System.Security.Claims;
global using Blazored.LocalStorage;
global using Microsoft.AspNetCore.Components.Authorization;
global using OnlineShop.Shared;
global using OnlineShop.Shared.DTO.Shop;
global using OnlineShop.Shared.DTO.User;
global using OnlineShop.Shared.Models.Shop;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OnlineShop.Client;
using OnlineShop.Client.Services.AuthService;
using OnlineShop.Client.Services.CartService;
using OnlineShop.Client.Services.ProductService;
using OnlineShop.Client.Services.CategoryService;
using OnlineShop.Client.Services.OrderService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
