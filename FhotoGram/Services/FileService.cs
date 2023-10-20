using FhotoGram.Interfaces;

namespace FhotoGram.Services;

public class FileService : IFileService
{
    public string FolderName => throw new NotImplementedException();

    public ValueTask<bool> DeleteAsync(IFormFile image)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string> SaveImageAsync(IFormFile image)
    {
        throw new NotImplementedException();
    }
}
