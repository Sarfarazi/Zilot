namespace Zelut.LandingPage.Helpers;

public interface IFileHelper
{
    Task<ResultData<string>> UploadAsync(IFormFile file);
}
