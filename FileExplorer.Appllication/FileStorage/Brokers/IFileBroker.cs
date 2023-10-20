namespace FileExplorer.Appllication.FileStorage.Brokers;

public interface IFileBroker
{
    StorageFile GetByPath(string filePath);
}
