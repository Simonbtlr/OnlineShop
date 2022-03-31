using Microsoft.AspNetCore.Components;

namespace OnlineShop.Client.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly NavigationManager _navigationManager;

    public OrderService(HttpClient httpClient, AuthenticationStateProvider authStateProvider, 
        NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
        _navigationManager = navigationManager;
    }

    private async Task<bool> IsUserAuthenticatedAsync()
    {
        return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
    }

    public async Task PlaceOrderAsync()
    {
        if (await IsUserAuthenticatedAsync())
            await _httpClient.PostAsync("api/order", null);
        else
            _navigationManager.NavigateTo("login");

    }

    public async Task<List<OrderOverviewResponse>> GetOrdersAsync()
    {
        var result = 
            await _httpClient.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");

        return result.Data;
    }
}