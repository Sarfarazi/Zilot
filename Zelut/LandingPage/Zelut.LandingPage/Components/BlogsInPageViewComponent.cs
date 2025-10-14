using Microsoft.AspNetCore.Mvc;
using Zelut.LandingPage.DTOs;

public class BlogsInPageViewComponent : ViewComponent
{
    private readonly HttpClient _httpClient;
    public BlogsInPageViewComponent(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("zelut-api");
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var web_sevrice_result = await _httpClient.RestApiGetAsync<ResultData<List<BlogDto>>>(AppConfig.RestApiConfig.ZelutUrls.GetBlogsUrl);
        return View("BlogsInPage", web_sevrice_result.Data);
    }
}