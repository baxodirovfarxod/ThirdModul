namespace WebFileManagment.Service.Service;
public interface IStorageService
{
    void UploadFile(string filePath, Stream stream);
    void CreateDirectory(string directoryPath);
    List<string> GetAllFilesAndDirectories(string directoryPath);
    void DeleteFile(string filePath);
    void DeleteDirectory(string directoryPath);
    Stream DownLoadFile(string filePath);
    Stream DownLoadDirectory(string directoryPath);
}
