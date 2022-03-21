namespace OnlineShop.Shared;

public class ServiceResponse<T>
{
    public bool Success { get; set; } = true;
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
}