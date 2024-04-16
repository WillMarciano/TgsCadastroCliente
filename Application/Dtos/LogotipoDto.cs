using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
    public record LogotipoDto
    {
        public byte[]? LogoByte { get; set; }
        public IFormFile? LogoFile { get; set; }
    }
}
