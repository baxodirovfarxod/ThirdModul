
using System.IO.Compression;

namespace WebFileManagment.StorageBroker.Service;
public class LocalStorageBroker : IStorageBrokerService
{
    private readonly string _dataPath;
    public LocalStorageBroker()
    {
        _dataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(_dataPath))
        {
            Directory.CreateDirectory(_dataPath);
        }
    }
    public void CreateDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);

        if (Directory.Exists(directoryPath))
        {
            throw new Exception("Folder has already created!");
        }

        var parent = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parent.FullName))
        {
            throw new Exception("Parent folder not found");
        }

        Directory.CreateDirectory(directoryPath);
    }
    public void DeleteDirectory(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);

        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("Directory not found");
        }

        Directory.Delete(directoryPath);
    }
    public void DeleteFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);

        if (!File.Exists(filePath))
        {
            throw new Exception("File not found !");
        }

        File.Delete(filePath);
    }
    public Stream DownLoadDirectory(string directoryPath)
    {
        if (Path.GetExtension(directoryPath) != string.Empty)
        {
            throw new Exception("irectoryPath is not directory");
        }

        directoryPath = Path.Combine(_dataPath, directoryPath);
        if (!Directory.Exists(directoryPath))
        {
            throw new Exception("Directory not found");
        }

        var zipPath = directoryPath + ".zip";
        ZipFile.CreateFromDirectory(directoryPath, zipPath);

        var stream = new FileStream(zipPath, FileMode.Open, FileAccess.Read);
        return stream;
    }
    public Stream DownLoadFile(string filePath)
    {
        filePath = Path.Combine(_dataPath, filePath);

        if (!File.Exists(filePath))
        {
            throw new Exception("File not found");
        }

        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        return stream;
    }
    public List<string> GetAllFilesAndDirectories(string directoryPath)
    {
        directoryPath = Path.Combine(_dataPath, directoryPath);

        var parentFolder = Directory.GetParent(directoryPath);
        if (!Directory.Exists(parentFolder.FullName))
        {
            throw new Exception("Parent folder not found");
        }

        var allFilesAndFolders = Directory.GetFileSystemEntries(directoryPath).ToList();
        allFilesAndFolders = allFilesAndFolders.Select(file => file.Remove(0, directoryPath.Length + 1)).ToList();
        return allFilesAndFolders;
    }
    public void UploadFile(string filePath, Stream stream)
    {
        filePath = Path.Combine(_dataPath, filePath);

        var parentFolder = Directory.GetParent(filePath);
        if (!Directory.Exists(parentFolder.FullName))
        {
            throw new Exception("Parent folder not found");
        }

        using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            stream.CopyTo(fileStream);
        }
    }
}
