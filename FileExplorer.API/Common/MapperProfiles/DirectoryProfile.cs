using AutoMapper;
using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace FileExplorer.API.Common.MapperProfiles;

public class DirectoryProfile : Profile
{
    public DirectoryProfile()
    {
        CreateMap<StorageDirectory, StorageDirectoryDto>,

    }
}
