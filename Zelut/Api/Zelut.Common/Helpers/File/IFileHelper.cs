using Microsoft.AspNetCore.Http;

namespace Zelut.Common.Helpers.File;

public interface IFileHelper
{
    Task<ResultData<string>> UploadFileAsync(IFormFile file);
    Task<ResultData<string>> DeleteFileAsync(string fileName);
}