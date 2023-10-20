namespace FhotoGram.Interfaces;

public interface IFileService
{
    string FolderName { get; }

    ValueTask<string> SaveImageAsync(IFormFile image);
    ValueTask<bool> DeleteAsync(IFormFile image);
}