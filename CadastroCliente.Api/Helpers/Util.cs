namespace CadastroCliente.Api.Helpers
{
    public class Util(IWebHostEnvironment hostEnvironment) : IUtil
    {
        public void DeleteImage(string imageName, string folderName)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                var imagePath = Path.Combine(hostEnvironment.ContentRootPath, @$"Resources/{folderName}", imageName);
                if (File.Exists(imagePath))
                        File.Delete(imagePath);
            }
        }

        public async Task<string> SaveImage(IFormFile image, string folderName)
        {
            var imageName = new string(Path.GetFileNameWithoutExtension(image.FileName)
                                        .Take(10)
                                        .ToArray())
                                        .Replace(' ', '-');

            imageName = $"{imageName}{DateTime.UtcNow.ToString("yymssfff")}{Path.GetExtension(image.FileName)}";
            var imagePath = Path.Combine(hostEnvironment.ContentRootPath, @$"Resources/{folderName}", "logo.jpg");

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}

