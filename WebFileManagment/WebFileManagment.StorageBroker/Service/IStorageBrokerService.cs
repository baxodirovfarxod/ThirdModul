namespace WebFileManagment.StorageBroker.Service;
public interface IStorageBrokerService
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directoryPath);
    List<string> GetAllFilesAndDirectories(string directoryPath);
    Stream DownLoadFile(string filePath);
    Stream DownLoadDirectory(string directoryPath);
    void DeleteFile(string filePath);
    void DeleteDirectory(string directoryPath);
}
