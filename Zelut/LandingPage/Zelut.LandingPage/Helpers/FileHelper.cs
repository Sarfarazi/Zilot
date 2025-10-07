namespace Zelut.LandingPage.Helpers;

public class FileHelper : IFileHelper
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileHelper(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<ResultData<string>> UploadAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return new ResultData<string>
            {
                IsSuccess = false,
                Data = null,
                Message = "فایلی برای آپلود انتخاب نشده است"
            };
        }

        var permittedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".png" };

        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!permittedExtensions.Contains(ext))
        {
            return new ResultData<string>
            {
                IsSuccess = false,
                Data = null,
                Message = "نوع فایل معتبر نیست. فقط PDF، تصاویر با پسوند jpg, png, bmp, gif و Word مجاز هستند."
            };
        }

        const long maxSize = 5 * 1024 * 1024;
        if (file.Length > maxSize)
        {
            return new ResultData<string>
            {
                IsSuccess = false,
                Data = null,
                Message = "حجم فایل باید کمتر از 5 مگابایت باشد"
            };
        }

        string folder = Path.Combine("FileUpload", "Factor");
        var uploadsRootFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

        if (!Directory.Exists(uploadsRootFolder))
        {
            Directory.CreateDirectory(uploadsRootFolder);
        }

        string fileName = $"{DateTime.Now.Ticks}{ext}";
        string filePath = Path.Combine(uploadsRootFolder, fileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        string relativePath = Path.Combine(folder, fileName).Replace("\\", "/");

        return new ResultData<string>
        {
            IsSuccess = true,
            Data = relativePath,
            Message = "فایل با موفقیت آپلود شد"
        };
    }
}
