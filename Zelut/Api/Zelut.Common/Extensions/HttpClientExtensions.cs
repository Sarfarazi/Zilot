using Newtonsoft.Json;
using System.Text;

public static class HttpClientExtensions
{
    #region  Methods

    public static async Task<T?> RestApiGetAsync<T>(this HttpClient client, string url, CancellationToken cancellationToken = default)
    {
        var response = await client.GetAsync(url, cancellationToken);
        return await HandleResponse<T>(response);
    }

    public static async Task<TResponse?> RestApiPostAsync<TRequest, TResponse>(this HttpClient client, string url, TRequest data, CancellationToken cancellationToken  = default)
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, content, cancellationToken);
        return await HandleResponse<TResponse>(response);
    }

    public static async Task<TResponse?> RestApiPutAsync<TRequest, TResponse>(this HttpClient client, string url, TRequest data, CancellationToken cancellationToken = default)
    {
        var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
        var response = await client.PutAsync(url, content, cancellationToken);
        return await HandleResponse<TResponse>(response);
    }

    public static async Task<bool> RestApiDeleteAsync(this HttpClient client, string url, CancellationToken cancellationToken = default)
    {
        var response = await client.DeleteAsync(url, cancellationToken);
        if (response.IsSuccessStatusCode) return true;

        var error = await response.Content.ReadAsStringAsync();
        throw new HttpRequestException($"Delete failed ({(int)response.StatusCode}): {error}");
    }

    #endregion

    #region Private
    private static async Task<T?> HandleResponse<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(content))
        {
            return default;
        }
        return JsonConvert.DeserializeObject<T>(content);
    }
    #endregion
}