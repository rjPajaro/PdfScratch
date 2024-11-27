namespace PdfScratch.Models
{
    public record FileModel(
        string FileName,
        decimal FileSize,
        string FileType,
        byte[] File
    );
}
