using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Zelut.Common.Helpers.File;

public class FileHelper : IFileHelper
{
    private readonly HttpClient _httpClient;
    public FileHelper(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("file-service");
    }

    public async Task<ResultData<string>> UploadFileAsync(IFormFile file)
    {
        var result = new ResultData<string>();

        if (file == null || file.Length == 0)
        {
            result.IsSuccess = false;
            result.Message = "فایل معتبر نیست";
            return result;
        }

        try
        {
            using var form = new MultipartFormDataContent();
            using var memoryStream = new MemoryStream();

            await file.CopyToAsync(memoryStream);
            var fileContent = new ByteArrayContent(memoryStream.ToArray());
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType ?? "application/octet-stream");

            form.Add(fileContent, "formFile", file.FileName);
            var response = await _httpClient.PostAsync("File/UploadFile", form);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            result.Data = responseContent;
            result.IsSuccess = true;
            result.Message = "آپلود با موفقیت انجام شد";
        }
        catch (Exception ex)
        {
            result.IsSuccess = false;
            result.Message = $"خطا در آپلود فایل";
        }

        return result;
    }
    public async Task<ResultData<string>> DeleteFileAsync(string fileName)
    {
        var url = string.Format("File/DelateFile/{0}", fileName);
        var rest_api_result = await _httpClient.RestApiGetAsync<dynamic>(url);
        return new ResultData<string>
        {
            IsSuccess = true,
            Data = string.Empty
        };
    }
}