
using WebFileManagment.StorageBroker.Service;

namespace WebFileManagment.Service.Service;
public class StorageService : IStorageService
{
    private IStorageBrokerService _storageBrokerService;
    public StorageService(IStorageBrokerService storageBrokerService)
    {
        _storageBrokerService = storageBrokerService;
    }
    public void CreateDirectory(string directoryPath)
    {
        _storageBrokerService.CreateDirectory(directoryPath);
    }
    public void DeleteDirectory(string directoryPath)
    {
        _storageBrokerService.DeleteDirectory(directoryPath);
    }
    public void DeleteFile(string filePath)
    {
        _storageBrokerService.DeleteFile(filePath);
    }
    public Stream DownLoadDirectory(string directoryPath)
    {
        return _storageBrokerService.DownLoadDirectory(directoryPath);
    }
    public Stream DownLoadFile(string filePath)
    {
        return _storageBrokerService.DownLoadFile(filePath);
    }
    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        return _storageBrokerService.GetAllFilesAndDirectories(directoryPath);
    }
    public void UploadFile(string filePath, Stream stream)
    {
        _storageBrokerService.UploadFile(filePath, stream);
    }
}
