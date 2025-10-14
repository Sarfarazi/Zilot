using Microsoft.AspNetCore.Mvc;

namespace Zelut.LandingPage.Components;

public class BlogsViewComponent : ViewComponent
{
    private readonly HttpClient _httpClient;
    public BlogsViewComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("zelut-api");
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var web_sevrice_result = await _httpClient.RestApiGetAsync
        return View();
    }
}
