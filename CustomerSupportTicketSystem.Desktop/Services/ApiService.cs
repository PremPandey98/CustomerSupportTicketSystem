using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using CustomerSupportTicketSystem.Desktop.Managers;

namespace CustomerSupportTicketSystem.Desktop.Services;

/// <summary>
/// Base service class for making HTTP API calls
/// </summary>
public class ApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7254/api/";

    public ApiService()
    {
        // Bypass SSL certificate validation for development
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        
        _httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(BaseUrl)
        };
    }

    protected async Task<T?> GetAsync<T>(string endpoint)
    {
        AddAuthHeader();
        var response = await _httpClient.GetAsync(endpoint);
        return await HandleResponse<T>(response);
    }

    protected async Task<T?> PostAsync<T>(string endpoint, object? data = null)
    {
        AddAuthHeader();
        var json = data != null ? JsonConvert.SerializeObject(data) : string.Empty;
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(endpoint, content);
        return await HandleResponse<T>(response);
    }

    protected async Task<T?> PutAsync<T>(string endpoint, object? data = null)
    {
        AddAuthHeader();
        var json = data != null ? JsonConvert.SerializeObject(data) : string.Empty;
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync(endpoint, content);
        return await HandleResponse<T>(response);
    }

    protected async Task PutAsync(string endpoint, object? data = null)
    {
        AddAuthHeader();
        var json = data != null ? JsonConvert.SerializeObject(data) : string.Empty;
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync(endpoint, content);
        await HandleResponse(response);
    }

    protected async Task PostAsync(string endpoint, object? data = null)
    {
        AddAuthHeader();
        var json = data != null ? JsonConvert.SerializeObject(data) : string.Empty;
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(endpoint, content);
        await HandleResponse(response);
    }

    protected async Task DeleteAsync(string endpoint)
    {
        AddAuthHeader();
        var response = await _httpClient.DeleteAsync(endpoint);
        await HandleResponse(response);
    }

    private void AddAuthHeader()
    {
        var token = AuthManager.Instance.Token;
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);
        }
    }

    private async Task<T?> HandleResponse<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            // Log the full error details for debugging
            var requestUri = response.RequestMessage?.RequestUri?.ToString() ?? "Unknown";
            var statusCode = response.StatusCode;
            var errorMessage = TryParseErrorMessage(content) ?? content;
            
            var detailedError = $"API Request to {requestUri} failed with {statusCode}.\nResponse: {errorMessage}";
            throw new HttpRequestException(detailedError);
        }

        if (string.IsNullOrWhiteSpace(content))
            return default;

        return JsonConvert.DeserializeObject<T>(content);
    }

    private async Task HandleResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var errorMessage = TryParseErrorMessage(content) ?? $"API Error: {response.StatusCode}";
            throw new HttpRequestException(errorMessage);
        }
    }

    private string? TryParseErrorMessage(string content)
    {
        try
        {
            var error = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            return error?.ContainsKey("message") == true ? error["message"] : null;
        }
        catch
        {
            return null;
        }
    }
}
