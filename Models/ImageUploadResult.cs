namespace TableBuilder.Models;

public class ImageUploadResult
{
    public bool Success { get; set; }
    public string? ErrorMessage { get; set; }
    public string? ImageDataUrl { get; set; }
    public string? FileName { get; set; }
}
